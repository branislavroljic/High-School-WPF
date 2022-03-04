using Srednja_skola_HCI.DAO;
using Srednja_skola_HCI.DAO.MySqlDAO;
using Srednja_skola_HCI.Dialogs;
using Srednja_skola_HCI.DTO;
using Srednja_skola_HCI.Util;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Threading;

namespace Srednja_skola_HCI.Forms
{
    public class GenericWindow<T>
    {
        IGenericDAO<T> genericDAO;

        public Boolean ValidInput { get; set; }

        public ObservableCollection<T> genericList { get; set; }

        public ValidationUtil ValidationUtil{ get; set; }

        Window currentWindow;
        private DataGrid dataGrid;
        private List<string> readonlyColumns;

        //public GenericWindow(IGenericDAO<T> dao, Window currentWIndow, DataGrid dataGrid, DataGrid novaDataGrid, ValidationUtil validationUtil)
        //{

        //    this.currentWindow = currentWIndow;

        //    this.dataGrid = dataGrid;

        //    this.novaDataGrid = novaDataGrid;

        //    ValidationUtil = validationUtil;

        //    genericDAO = dao;

        //    genericList = new ObservableCollection<T>(genericDAO.GetDTOList());

        //    NovaGenericList = new ObservableCollection<T>();

        //    dataGrid.ItemsSource = genericList;

        //    dataGrid.RowEditEnding += OnRowEditEnding;

        //    dataGrid.BeginningEdit += gridData_BeginningEdit;
        //    novaDataGrid.ItemsSource = NovaGenericList;

        //    novaDataGrid.RowEditEnding += OnNovaGenericRowEditEnding;

        //}

        public GenericWindow(IGenericDAO<T> dao, Window currentWIndow, DataGrid dataGrid, List<String> readonlyColumns, ValidationUtil validationUtil)
        {

            this.currentWindow = currentWIndow;

            this.dataGrid = dataGrid;

            this.readonlyColumns = readonlyColumns;
            
            ValidationUtil = validationUtil;

            genericDAO = dao;

            genericList = new ObservableCollection<T>(genericDAO.GetDTOList());

            dataGrid.ItemsSource = genericList;

            dataGrid.RowEditEnding += OnRowEditEnding;

            dataGrid.BeginningEdit += gridData_BeginningEdit;

        }


        private void gridData_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            foreach (String column in readonlyColumns)
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
                    if (view.CurrentEditItem is T)
                    {

                        T? updatedItem = (T)view.CurrentEditItem;

                        if (ValidationUtil != null &&  !ValidationUtil.Validate(updatedItem))
                            return;

                        currentWindow.Dispatcher.BeginInvoke(new DispatcherOperationCallback(param =>
                        {

                            if (ValidationUtil != null && !ValidationUtil.Validate(updatedItem))
                                return null;

                            if (!genericDAO.UpdateDTO(updatedItem))
                            {
                                T oldItem = genericDAO.GetDTO(updatedItem);
                                int index = genericList.IndexOf(updatedItem);
                                if (oldItem != null)
                                {

                                    genericList.RemoveAt(index);
                                    genericList.Add(oldItem);
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

                    if (view.CurrentAddItem is T)
                    {

                        T? o = (T)view.CurrentAddItem;

                        currentWindow.Dispatcher.BeginInvoke(new DispatcherOperationCallback(param =>
                        {
                            if (ValidationUtil != null && !ValidationUtil.Validate(o))
                                return null;
                            if (!genericDAO.CreateDTO(o))
                            {

                                genericList.Remove(o);
                            }
                            else
                            {
                                if (o is Profesor)
                                    RefreshView();

                                new YesNoDialog(Properties.Resources.DodavanjeMessage, false).ShowDialog();
                            }
                            return null;
                        }), DispatcherPriority.Background, new object[] { null });
                    }
                }
            }



        }

        private void RefreshView()
        {
            dataGrid.ItemsSource = null;
            dataGrid.ItemsSource = new ObservableCollection<T>(genericDAO.GetDTOList());
        }



        public void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem is T)
            {
                T? selectedItem = (T)dataGrid.CurrentItem;

                if (selectedItem != null)
                {
                    YesNoDialog yesNoDialog = new YesNoDialog(Properties.Resources.PotvrdaBrisanjaMessage, true);
                    if (yesNoDialog.ShowDialog() == true)
                    {
                        currentWindow.Dispatcher.BeginInvoke(new DispatcherOperationCallback(param =>
                    {
                        if (!genericDAO.DeleteDTOById(selectedItem))
                        {
                            new ErrorDialog(Properties.Resources.DeleteError).ShowDialog();
                        }
                        else
                        {
                            genericList.Remove(selectedItem);
                        }
                        return null;
                    }), DispatcherPriority.Background, new object[] { null });

                    }
                }
            }
        }

    }
}
