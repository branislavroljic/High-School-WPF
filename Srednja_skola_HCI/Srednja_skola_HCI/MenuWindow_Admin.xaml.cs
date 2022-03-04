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
    /// Interaction logic for MenuWindow_Admin.xaml
    /// </summary>
    public partial class MenuWindow_Admin : Window
    {
        public MenuWindow_Admin(Admin admin)
        {
            InitializeComponent();
            Header.Text = Properties.Resources.MeniHeader;
            this.Admin = admin;
        }

        public Admin Admin { get; }


        private void Thumb_OnDragDelta(object sender, DragDeltaEventArgs e)
        {
            Left = Left + e.HorizontalChange;
            Top = Top + e.VerticalChange;
        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            this.Effect = new BlurEffect();
            new SettingsWindow(Admin.Osoba.JMB).ShowDialog();
            this.Effect = null;
        }

        private void Schools_Click(object sender, RoutedEventArgs e)
        {
            new SkolaWindow().Show();
        }
        private void Smjerovi_Click(object sender, RoutedEventArgs e)
        {
            new SmjerWindow().Show();
        }

        private void PredmetiNaSmjeru_Click(object sender, RoutedEventArgs e)
        {
            new PredmetNaSmjeruWindow().Show();
        }

        private void Profesori_Click(object sender, RoutedEventArgs e)
        {
            new ProfesorWindow().Show();
        }
        private void Logout_Cick(object sender, RoutedEventArgs e)
        {
            new Login().Show();
            Close();
        }
    }
}
