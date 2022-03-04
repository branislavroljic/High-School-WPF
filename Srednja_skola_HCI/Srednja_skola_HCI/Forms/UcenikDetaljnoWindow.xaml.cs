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
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Srednja_skola_HCI.Forms
{
    /// <summary>
    /// Interaction logic for UcenikDetaljnoWindow.xaml
    /// </summary>
    public partial class UcenikDetaljnoWindow : Window
    {
        IUcenikDetaljnoDAO ucenikDetaljnoDAO;

        Profesor profesor;
        GenericWindow<UcenikDetaljno> genericWindow;
        public UcenikDetaljnoWindow()
        {

            InitializeComponent();
            Header.Title.Text = Properties.Resources.UceniciHeader;

            ucenikDetaljnoDAO = DAOFactory.Instance(DAOType.MySQL).UceniciDetaljno;

            genericWindow = new GenericWindow<UcenikDetaljno>(ucenikDetaljnoDAO, this, uceniciDetaljnoDG, new List<string>() { }, null);

            ListCollectionView collectionView = new ListCollectionView(genericWindow.genericList);
            collectionView.GroupDescriptions.Add(new PropertyGroupDescription("Smjer"));
            collectionView.GroupDescriptions.Add(new PropertyGroupDescription("Razred"));
            uceniciDetaljnoDG.ItemsSource = collectionView;
        }

        public UcenikDetaljnoWindow(Profesor profesor) : this()
        {
            this.profesor = profesor;
        }

        private void Ocijeni_Click(object sender, RoutedEventArgs e)
        {

            UcenikDetaljno? selectedUcenik = (UcenikDetaljno)uceniciDetaljnoDG.SelectedItem;
            if (selectedUcenik != null)
            {
                this.Effect = new BlurEffect();
                new RadiProvjeruWindow(profesor, selectedUcenik).ShowDialog();
                this.Effect = null;
                RefreshView(selectedUcenik);
            }
        }

        private void RefreshView(UcenikDetaljno ucenikDetaljno)
        {
           int index =  genericWindow.genericList.IndexOf(ucenikDetaljno);
            if(index != -1)
            {
                genericWindow.genericList[index] = DAOFactory.Instance(DAOType.MySQL).UceniciDetaljno.GetDTO(ucenikDetaljno);
            }
        }
    }
}
