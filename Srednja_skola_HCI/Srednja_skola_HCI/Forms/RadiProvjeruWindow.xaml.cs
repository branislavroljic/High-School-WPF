using Srednja_skola_HCI.DAO;
using Srednja_skola_HCI.Dialogs;
using Srednja_skola_HCI.DTO;
using Srednja_skola_HCI.Util;
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
    public enum Ocjena : byte
    {
        NEDOVOLJAN = 1, DOVOLJAN = 2, DOBAR = 3, VRLODOBAR = 4, ODLICAN = 5, NEOCIJENJEN
    }
    public partial class RadiProvjeruWindow : Window
    {

        private Profesor profesor;
        private UcenikDetaljno ucenikDetaljno;
        private ObservableCollection<RadiProvjeru> provjereList;
        IRadiProvjeruDAO radiProvjeruDAO;

        public RadiProvjeruWindow(Profesor profesor, UcenikDetaljno ucenikDetaljno)
        {
            InitializeComponent();
            this.profesor = profesor;
            this.ucenikDetaljno = ucenikDetaljno;

            radiProvjeruDAO = DAOFactory.Instance(DAOType.MySQL).RadjenjaProvjere;

            radiProvjeruDG.ItemsSource = provjereList = new ObservableCollection<RadiProvjeru>(radiProvjeruDAO.GetDTOList(profesor.Osoba.JMB, ucenikDetaljno));

            radiProvjeruDG.RowEditEnding += OnRowEditEnding;

        }

        private void OnRowEditEnding(object? sender, DataGridRowEditEndingEventArgs e)
        {
            DataGrid dataGrid = sender as DataGrid;
            if (e.EditAction == DataGridEditAction.Commit)
            {
                ListCollectionView view = CollectionViewSource.GetDefaultView(dataGrid.ItemsSource) as ListCollectionView;
                if (view.IsEditingItem)
                {
                    if (view.CurrentEditItem is RadiProvjeru)
                    {

                        RadiProvjeru? createdItem = (RadiProvjeru)view.CurrentEditItem;
                        
                        this.Dispatcher.BeginInvoke(new DispatcherOperationCallback(param =>
                            {
                                if (!new RPValidationRule().Validate(createdItem))
                                    return null;

                                if (!radiProvjeruDAO.UpdateDTO(createdItem))
                                {
                                    radiProvjeruDAO.CreateDTO(createdItem);
                                }
                                

                                return null;
                            }), DispatcherPriority.Background, new object[] { null });
                        }
                    
                }

            }



        }
    }

    public class RPValidationRule : ValidationUtil
    {
        public override ValidationResult Validate(object value,
            System.Globalization.CultureInfo cultureInfo)
        {
            RadiProvjeru rp = (value as BindingGroup).Items[0] as RadiProvjeru;
            if (rp != null && rp.Ocjena == null)
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
            RadiProvjeru rp = o as RadiProvjeru;
            if(rp.Ocjena == null)
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
