using Srednja_skola_HCI.DAO;
using Srednja_skola_HCI.DTO;
using Srednja_skola_HCI.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Srednja_skola_HCI
{
    /// <summary>
    /// Interaction logic for MenuWindow_Profesor.xaml
    /// </summary>
    public partial class MenuWindow_Profesor : Window
    {
        public MenuWindow_Profesor(Profesor profesor)
        {
            InitializeComponent();
            Header.Text = Properties.Resources.MeniHeader;
            this.Profesor = profesor;
        }

        public Profesor Profesor { get; }

        private void Predmeti_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                new PredmetNaSmjeruWindow(Profesor).Show();
            }
            catch (Exception)
            {
            }         
        }

        private void Provjere_Click(object sender, RoutedEventArgs e)
        {

            new ProvjeraWindow().Show();
        }

        private void Ucenici_Click(object sender, RoutedEventArgs e)
        {
            new UcenikDetaljnoWindow(Profesor).Show();
        }

        private void Thumb_OnDragDelta(object sender, DragDeltaEventArgs e)
        {
            Left = Left + e.HorizontalChange;
            Top = Top + e.VerticalChange;
        }
        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            this.Effect = new BlurEffect();
            new SettingsWindow(Profesor.Osoba.JMB).ShowDialog();
            this.Effect = null;
        }

        private void Logout_Cick(object sender, RoutedEventArgs e)
        {
            new Login().Show(); 
            Close();
        }
    }
}
