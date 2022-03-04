using Srednja_skola_HCI.DAO;
using Srednja_skola_HCI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Globalization;
using System.Resources;
using System.Windows.Data;
using System.Collections.ObjectModel;
using System.Windows.Threading;
using System.Diagnostics;
using Srednja_skola_HCI.Dialogs;
using Srednja_skola_HCI.Util;

namespace Srednja_skola_HCI.Forms
{
    public enum TipProvjere
    {
        P, U
    }
    public partial class ProvjeraWindow : Window
    {
        IProvjeraDAO provjeraDAO;

        GenericWindow<Provjera> genericWindow;
        private UcenikDetaljno ucenikDetaljno;
        private UcenikDetaljno ucenik;
        private ObservableCollection<Provjera> provjereList;
        private PredmetNaSmjeru PredmetNaSmjeru;

        public ProvjeraWindow()
        {

            InitializeComponent();
            Header.Title.Text = Properties.Resources.ProvjereHeader;

            provjeraDAO = DAOFactory.Instance(DAOType.MySQL).Provjere;

            provjereDG.CanUserAddRows = false;
            provjereDG.IsReadOnly = true;
            var brisanjeColumn = provjereDG.Columns.FirstOrDefault(c => c.Header == Properties.Resources.BrisanjeHeader);
            provjereDG.Columns[provjereDG.Columns.IndexOf(brisanjeColumn)].Visibility = Visibility.Hidden;

           provjereDG.ItemsSource = new ObservableCollection<Provjera>(provjeraDAO.GetDTOList());

        }

        public ProvjeraWindow(PredmetNaSmjeru selectedPNS)
        {
            InitializeComponent();
            PredmetNaSmjeru = selectedPNS;

            provjeraDAO = DAOFactory.Instance(DAOType.MySQL).Provjere;

            var predmetColumn = provjereDG.Columns.FirstOrDefault(c => c.Header == Properties.Resources.NazivPredmetaHeader);
            var smjerColumn = provjereDG.Columns.FirstOrDefault(c => c.Header == Properties.Resources.NazivSmjeraHeader);
            var razredColumn = provjereDG.Columns.FirstOrDefault(c => c.Header == Properties.Resources.RazredHeader);



            var predmetIndex = provjereDG.Columns.IndexOf(predmetColumn);
            var smjerIndex = provjereDG.Columns.IndexOf(smjerColumn);
            var razredIndex = provjereDG.Columns.IndexOf(razredColumn);

            provjereDG.Columns[predmetIndex].Visibility = Visibility.Hidden;
            provjereDG.Columns[smjerIndex].Visibility = Visibility.Hidden;
            provjereDG.Columns[razredIndex].Visibility = Visibility.Hidden; 



            provjereList = new ObservableCollection<Provjera>(provjeraDAO.GetProvjerePoPredmetu(selectedPNS));
            provjereDG.ItemsSource = provjereList;
            provjereDG.RowEditEnding += ProvjereDG_RowEditEnding;
            provjereDG.BeginningEdit += gridData_BeginningEdit;

        }
        private void gridData_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            foreach (String column in new List<string>() { Properties.Resources.OdjeljenjeHeader, Properties.Resources.DatumHeader })
            {
                if ((string)e.Column.Header == column)
                {
                    if (!e.Row.IsNewItem)
                    {
                        e.Cancel = true;
                    }
                }
            }
        }
        private void ProvjereDG_RowEditEnding(object? sender, DataGridRowEditEndingEventArgs e)
        {

            DataGrid dataGrid = sender as DataGrid;
            if (e.EditAction == DataGridEditAction.Commit)
            {
                ListCollectionView view = CollectionViewSource.GetDefaultView(dataGrid.ItemsSource) as ListCollectionView;
                if (view.IsEditingItem)
                {
                    if (view.CurrentEditItem is Provjera)
                    {

                        Provjera? updatedItem = (Provjera)view.CurrentEditItem;

                       
                            this.Dispatcher.BeginInvoke(new DispatcherOperationCallback(param =>
                            {

                                if (!new ProvjeraValidationRule().Validate(updatedItem))
                                    return null;

                                if (!provjeraDAO.UpdateDTO(updatedItem))
                                {
                                    Provjera oldItem = provjeraDAO.GetDTO(updatedItem);
                                    int index = provjereList.IndexOf(updatedItem);
                                    if (oldItem != null)
                                    {

                                        provjereList.RemoveAt(index);
                                        provjereList.Add(oldItem);
                                    }
                                }
                                else
                                {
                                    new YesNoDialog(Properties.Resources.IzmjenaMessage, false).ShowDialog();
                                }

                                return null;
                            }), DispatcherPriority.Background, new object[] { null });
                        
                    }
                }
                else if (view.IsAddingNew)
                {
                    if (view.CurrentAddItem is Provjera)
                    {
                            Provjera? o = (Provjera)view.CurrentAddItem;
                            o.PredmetNaSmjeru = PredmetNaSmjeru;
                            this.Dispatcher.BeginInvoke(new DispatcherOperationCallback(param =>
                            {
                                if (!new ProvjeraValidationRule().Validate(o))
                                    return null;

                                if (!provjeraDAO.CreateDTO(o))
                                {
                                    provjereList.Remove(o);
                                }
                                else
                                {
                                    new YesNoDialog(Properties.Resources.DodavanjeMessage, false).ShowDialog();
                                }
                                return null;
                            }), DispatcherPriority.Background, new object[] { null });
                        
                    }
                }
            }


        }

        public void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (provjereDG.SelectedItem is Provjera)
            {
                Provjera? selectedItem = (Provjera)provjereDG.SelectedItem;
                if (selectedItem != null)
                {
                    this.Dispatcher.BeginInvoke(new DispatcherOperationCallback(param =>
                    {
                        if (!provjeraDAO.DeleteDTOById(selectedItem))
                        {
                            new ErrorDialog(Properties.Resources.DeleteError).ShowDialog();
                        }
                        else
                        {
                            provjereList.Remove(selectedItem);
                        }
                        return null;
                    }), DispatcherPriority.Background, new object[] { null });


                }
            }
        }
    }

    public class ProvjeraValidationRule : ValidationUtil
    {
        public override ValidationResult Validate(object value,
            System.Globalization.CultureInfo cultureInfo)
        {
            Provjera p = (value as BindingGroup).Items[0] as Provjera;
            if (p != null && (p.Datum == null || p.PredmetNaSmjeru.Predmet.IdPredmeta == null || p.PredmetNaSmjeru.Smjer.IdSmjera == null || p.Odjeljenje == null || p.TipProvjere == null || p.Trajanje == null || p.BrojPrisutnihUcenika == null  || p.BrojNegativnihOcjena == null || p.Ponovljena == null))
            {

                return new ValidationResult(false,
                   Properties.Resources.PraznaPoljaError);
            }
            else
            {
                return ValidationResult.ValidResult;
            }
        }
        public override bool Validate(object o)
        {
            Provjera p = o as Provjera;
            if (p.Datum == null || p.PredmetNaSmjeru.Predmet.IdPredmeta == null || p.PredmetNaSmjeru.Smjer.IdSmjera == null || p.Odjeljenje == null || p.TipProvjere == null || p.Trajanje == null || p.BrojPrisutnihUcenika == null || p.BrojNegativnihOcjena == null || p.Ponovljena == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}

