using Srednja_skola_HCI.DAO;
using Srednja_skola_HCI.DTO;
using Srednja_skola_HCI.Util;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Srednja_skola_HCI.Forms
{
    public enum Pol
    {
        MUSKI, ZENSKI
    }

    /// <summary>
    /// Interaction logic for ProfesorWindow.xaml
    /// </summary>
    public partial class ProfesorWindow : Window
    {
        IProfesorDAO profesorDAO;

        GenericWindow<Profesor> genericWindow;
        public ProfesorWindow()
        {

            InitializeComponent();
            Header.Title.Text = Properties.Resources.ProfesoriHeader;

            profesorDAO = DAOFactory.Instance(DAOType.MySQL).Profesori;

            genericWindow = new GenericWindow<Profesor>(profesorDAO, this, profesorDG, new List<string>() { Properties.Resources.JMBHeader}, new ProfesorValidationRule());
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            
            genericWindow.Delete_Click(sender, e);
        }

    }
    public class ProfesorValidationRule : ValidationUtil
    {
        public override ValidationResult Validate(object value,
            System.Globalization.CultureInfo cultureInfo)
        {
            Profesor p = (value as BindingGroup).Items[0] as Profesor;
            if (p != null && (string.IsNullOrEmpty(p.Osoba.JMB) || string.IsNullOrEmpty(p.Osoba.Ime) || string.IsNullOrEmpty(p.Osoba.Prezime) || string.IsNullOrEmpty(p.Osoba.Adresa) || string.IsNullOrEmpty(p.Osoba.Lozinka) || string.IsNullOrEmpty(p.Osoba.MailAdresa) || p.Osoba.Pol == null || p.Osoba.DatumRodjenja == null || p.Verifikovan == null || p.Plata == null))
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
            Profesor p = o as Profesor;
            if (string.IsNullOrEmpty(p.Osoba.JMB) || string.IsNullOrEmpty(p.Osoba.Ime) || string.IsNullOrEmpty(p.Osoba.Prezime) || string.IsNullOrEmpty(p.Osoba.Adresa) || string.IsNullOrEmpty(p.Osoba.Lozinka) || string.IsNullOrEmpty(p.Osoba.MailAdresa) || p.Osoba.Pol == null || p.Osoba.DatumRodjenja == null || p.Verifikovan == null || p.Plata == null)
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