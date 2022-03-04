using Srednja_skola_HCI.DAO;
using Srednja_skola_HCI.DTO;
using Srednja_skola_HCI.Util;
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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Srednja_skola_HCI.Forms
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            Header.Title.Text = Properties.Resources.LoginHeader;
        }

        private void CloseClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            LogIn();
        }

        private void LogIn()
        {
            foreach(Admin admin in DAOFactory.Instance(DAOType.MySQL).Admini.GetDTOList())
            {
                if(admin.Osoba.MailAdresa.Equals(Mail.Text) && admin.Osoba.Lozinka.Equals(Password.Password))
                {
                    setCustomThemeAndLang(admin.Osoba.JMB);
                    new MenuWindow_Admin(admin).Show();
                    Close();
                    return;
                }
            }

            Profesor? p =  DAOFactory.Instance(DAOType.MySQL).Profesori.getProfesorByMailAndPassword(Mail.Text, Password.Password);
            {
                if (p != null)
                {
                    setCustomThemeAndLang(p.Osoba.JMB);
                    new MenuWindow_Profesor(p).Show();
                    Close();
                    return;
                }
            }

            Mail.BorderBrush = Brushes.Red;
            Password.BorderBrush = Brushes.Red;
            ErrorMessage.Visibility = Visibility.Visible;
        }

        private void setCustomThemeAndLang(string JMB)
        {
            string lang = SettingsUtil.ReadSetting(SettingType.LANG, JMB);
            TranslationSource.Instance.CurrentCulture = new System.Globalization.CultureInfo(lang.ToLower());

            string theme = SettingsUtil.ReadSetting(SettingType.THEME, JMB);

            ResourceDictionary resourceDictionary = new ResourceDictionary();
            if ("C".Equals(theme))
                resourceDictionary.Source = new Uri("pack://application:,,,/Resources/Themes/DarkTheme.xaml");
            else if ("P".Equals(theme))
                resourceDictionary.Source = new Uri("pack://application:,,,/Resources/Themes/BlueTheme.xaml");
            else 
                resourceDictionary.Source = new Uri("pack://application:,,,/Resources/Themes/WhiteTheme.xaml");

            Application.Current.Resources.MergedDictionaries.Add(resourceDictionary);
        }

        private void Thumb_OnDragDelta(object sender, DragDeltaEventArgs e)
        {
            Left = Left + e.HorizontalChange;
            Top = Top + e.VerticalChange;
        }

        private void ReturnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                LogIn();
            }
        }

    }
}
