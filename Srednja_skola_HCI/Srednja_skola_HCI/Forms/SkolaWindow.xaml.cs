using Srednja_skola_HCI.DAO;
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
using System.Windows.Controls.Primitives;
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
    /// Interaction logic for SkolaWindow.xaml
    /// </summary>
    public partial class SkolaWindow : Window
    {
        ISkolaDAO skolaDAO;

        GenericWindow<Skola> genericWindow;
        public SkolaWindow()
        {
            InitializeComponent();
            Header.Title.Text = Properties.Resources.SkoleHeader;
            skolaDAO = DAOFactory.Instance(DAOType.MySQL).Skole;

            genericWindow = new GenericWindow<Skola>(skolaDAO, this, skoleDG, new List<string>() { Properties.Resources.JIBHeader }, new SkolaValidationRule());

        }

        private void Thumb_OnDragDelta(object sender, DragDeltaEventArgs e)
        {
            Left = Left + e.HorizontalChange;
            Top = Top + e.VerticalChange;
        }

        private void Delete_Click(object sender, RoutedEventArgs e) => genericWindow.Delete_Click(sender, e);

    }
    public class SkolaValidationRule : ValidationUtil
    {
        public override ValidationResult Validate(object value,
            System.Globalization.CultureInfo cultureInfo)
        {
            Skola skola = (value as BindingGroup).Items[0] as Skola;
            if (skola != null && (string.IsNullOrEmpty(skola.JIB) || string.IsNullOrEmpty(skola.Naziv) || string.IsNullOrEmpty(skola.Vrsta) || string.IsNullOrEmpty(skola.MailAdresa) || string.IsNullOrEmpty(skola.Adresa) || string.IsNullOrEmpty(skola.Telefon)))
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
            Skola skola = o as Skola;
            if (string.IsNullOrEmpty(skola.JIB) || string.IsNullOrEmpty(skola.Naziv) || string.IsNullOrEmpty(skola.Vrsta) || string.IsNullOrEmpty(skola.MailAdresa) || string.IsNullOrEmpty(skola.Adresa) || string.IsNullOrEmpty(skola.Telefon))
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
