using Srednja_skola_HCI.DAO;
using Srednja_skola_HCI.Dialogs;
using Srednja_skola_HCI.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Threading;

namespace Srednja_skola_HCI.Forms
{
    /// <summary>
    /// Interaction logic for PredajeWindow.xaml
    /// </summary>
    public partial class PredajeWindow : Window
    {
        IPredajeDAO predajeDAO;
        IProfesorDAO profesorDAO;
        PredmetNaSmjeru predmetNaSmjeru;
        GenericWindow<Predaje> genericWindow;
        private ObservableCollection<Predaje> predajeList;
        public static ObservableCollection<Osoba> nerasporedjeniProfesoriList;
        public PredajeWindow(PredmetNaSmjeru predmetNaSmjeru, bool CanUserAddRows)
        {

            InitializeComponent();

            Header.Title.Text = Properties.Resources.PredajeHeader;

            this.predmetNaSmjeru = predmetNaSmjeru;

            predajeDAO = DAOFactory.Instance(DAOType.MySQL).Predavanja;
            profesorDAO = DAOFactory.Instance(DAOType.MySQL).Profesori;
            predajeDG.ItemsSource = predajeList = new ObservableCollection<Predaje>(predajeDAO.GetDTOList(predmetNaSmjeru));
            predajeDG.CanUserAddRows = CanUserAddRows;

            nerasporedjeniProfesoriList = new ObservableCollection<Osoba>(profesorDAO.GetDTOList().Select(p => p.Osoba).ToList());

            //foreach (var prof in predajeList.Select(p => p.Profesor).ToList())
            //{
            //    nerasporedjeniProfesoriList.Remove(prof.Osoba);
            //}

            predajeDG.RowEditEnding += OnRowEditEnding;

            ProfJMBCMB.ItemsSource = nerasporedjeniProfesoriList;

            predajeDG.BeginningEdit += gridData_BeginningEdit;
        }

        public void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (predajeDG.SelectedItem is Predaje)
            {
                Predaje? selectedItem = (Predaje)predajeDG.SelectedItem;
                if (selectedItem != null)
                {
                    this.Dispatcher.BeginInvoke(new DispatcherOperationCallback(param =>
                    {
                        if (!predajeDAO.DeleteDTOById(selectedItem))
                        {
                            new ErrorDialog(Properties.Resources.DeleteError).ShowDialog();
                        }
                        else
                        {
                            predajeList.Remove(selectedItem);
                        }
                        return null;
                    }), DispatcherPriority.Background, new object[] { null });


                }
            }
        }

        private void gridData_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            foreach (String column in new List<string>() { Properties.Resources.JMBHeader })
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

        private void OnRowEditEnding(object? sender, DataGridRowEditEndingEventArgs e)
        {
            DataGrid dataGrid = sender as DataGrid;
            if (e.EditAction == DataGridEditAction.Commit)
            {
                ListCollectionView view = CollectionViewSource.GetDefaultView(dataGrid.ItemsSource) as ListCollectionView;
                if (view.IsEditingItem)
                {
                    if (view.CurrentEditItem is Predaje)
                    {

                        Predaje? updatedItem = (Predaje)view.CurrentEditItem;
                        updatedItem.PredmetNaSmjeru = predmetNaSmjeru;

                        this.Dispatcher.BeginInvoke(new DispatcherOperationCallback(param =>
                        {

                            if (!predajeDAO.UpdateDTO(updatedItem))
                            {
                                Predaje oldItem = predajeDAO.GetDTO(updatedItem);
                                int index = predajeList.IndexOf(updatedItem);
                                if (oldItem != null)
                                {

                                    predajeList.RemoveAt(index);
                                    predajeList.Add(oldItem);
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
                    if (view.CurrentAddItem is Predaje)
                    {
                        Predaje? o = (Predaje)view.CurrentAddItem;
                        o.PredmetNaSmjeru = predmetNaSmjeru;

                        this.Dispatcher.BeginInvoke(new DispatcherOperationCallback(param =>
                        {
                            if (!predajeDAO.CreateDTO(o))
                            {
                                predajeList.Remove(o);
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
    }
}
