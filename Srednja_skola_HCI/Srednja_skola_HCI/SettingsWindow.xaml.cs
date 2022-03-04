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

namespace Srednja_skola_HCI
{
    enum Languages
    {
        EN, SR
    }

    public partial class SettingsWindow : Window
    {

        private string JMB;

        public SettingsWindow(string JMB)
        {
            InitializeComponent();
            Header.Title.Text = Properties.Resources.PodesavanjaHeader;
            this.JMB = JMB;

            string lang = SettingsUtil.ReadSetting(SettingType.LANG, JMB);
            if("SR".Equals(lang))
                SrRB.IsChecked = true;

            string theme = SettingsUtil.ReadSetting(SettingType.THEME, JMB);
            if ("C".Equals(theme))
                DarkRB.IsChecked = true;
            else if ("P".Equals(theme))
                BlueRB.IsChecked = true;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            string lang = (bool)EnRB.IsChecked?"EN":"SR"; ;
            SettingsUtil.SaveSetting(SettingType.LANG, lang, JMB);

            TranslationSource.Instance.CurrentCulture = new System.Globalization.CultureInfo(lang.ToLower());

            ResourceDictionary resourceDictionary = new ResourceDictionary();

            if ((bool)WhiteRB.IsChecked)
            {
                SettingsUtil.SaveSetting(SettingType.THEME, "B", JMB);
                resourceDictionary.Source = new Uri("pack://application:,,,/Resources/Themes/WhiteTheme.xaml");
            }
            else if ((bool)DarkRB.IsChecked)
            {
                SettingsUtil.SaveSetting(SettingType.THEME, "C", JMB);
                resourceDictionary.Source = new Uri("pack://application:,,,/Resources/Themes/DarkTheme.xaml");
            }
            else
            {
                SettingsUtil.SaveSetting(SettingType.THEME, "P", JMB);
                resourceDictionary.Source = new Uri("pack://application:,,,/Resources/Themes/BlueTheme.xaml");
            }
            Application.Current.Resources.MergedDictionaries.Add(resourceDictionary);

            this.Close();
        }

        private void Thumb_OnDragDelta(object sender, DragDeltaEventArgs e)
        {
            Left = Left + e.HorizontalChange;
            Top = Top + e.VerticalChange;
        }
        private void CloseClick(object sender, RoutedEventArgs e) => this.Close();

    }
}
