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
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Srednja_skola_HCI.Forms
{
    public enum TipPredmeta
    {
        O, I
    }

    /// <summary>
    /// Interaction logic for PredmetNaSmjeruWindow.xaml
    /// </summary>
    public partial class PredmetNaSmjeruWindow : Window
    {
        IPredmetNaSmjeruDAO pNaSDAO;

        GenericWindow<PredmetNaSmjeru> genericWindow;
        public PredmetNaSmjeruWindow()
        {

            InitializeComponent();
            Header.Title.Text = Properties.Resources.PredmetiHeader;
            pNaSDAO = DAOFactory.Instance(DAOType.MySQL).PredmetiNaSmjeru;

            IDSmjeraCMB.ItemsSource = DAOFactory.Instance(DAOType.MySQL).Smjerovi.GetDTOList(); //.Select(s => s.IdSmjera).ToList();
            genericWindow = new GenericWindow<PredmetNaSmjeru>(pNaSDAO, this, pNaSDG, new List<string>() { Properties.Resources.IdSmjeraHeader, Properties.Resources.NazivPredmetaHeader, Properties.Resources.NazivSmjeraHeader }, new PNSValidationRule());


        }

        public PredmetNaSmjeruWindow(Profesor p)
        {
            InitializeComponent();
            Header.Title.Text = Properties.Resources.PredmetiHeader;
            P = p;
            pNaSDAO = DAOFactory.Instance(DAOType.MySQL).PredmetiNaSmjeru;

            IDSmjeraCMB.ItemsSource = DAOFactory.Instance(DAOType.MySQL).Smjerovi.GetDTOList();

            ObservableCollection<PredmetNaSmjeru> predmetiNaSmjeruProfesorList = new ObservableCollection<PredmetNaSmjeru>(DAOFactory.Instance(DAOType.MySQL).PredmetiNaSmjeru.GetPredmetPoProfesoru(p.Osoba.JMB));

            if(predmetiNaSmjeruProfesorList.Count == 0)
            {
                new YesNoDialog(Properties.Resources.NePredajePredmetMessage, false).ShowDialog();
                this.Close();
            }

            pNaSDG.ItemsSource = predmetiNaSmjeruProfesorList;
            pNaSDG.IsReadOnly = true;
            pNaSDG.CanUserAddRows = false;
            var imageColumn = (DataGridTemplateColumn)pNaSDG.Columns[7];
            imageColumn.Visibility = Visibility.Hidden;

            DataGridTemplateColumn colBtn = new DataGridTemplateColumn();
            DataTemplate DttBtn = new DataTemplate();
            FrameworkElementFactory btn = new FrameworkElementFactory(typeof(Button));
            btn.AddHandler(Button.ClickEvent, new RoutedEventHandler(Provjere_Click));
            btn.SetValue(Button.ContentProperty, Properties.Resources.PogledajButton);
            DttBtn.VisualTree = btn;
            colBtn.CellTemplate = DttBtn;

            colBtn.Header = Properties.Resources.ProvjereHeader;
            pNaSDG.Columns.Add(colBtn);

        }

        public Profesor P { get; }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            genericWindow.Delete_Click(sender, e);
        }

        private void Provjere_Click(object sender, RoutedEventArgs e)
        {
            PredmetNaSmjeru? selectedPNS = (PredmetNaSmjeru)pNaSDG.SelectedItem;
            if (selectedPNS != null)
            {
                this.Effect = new BlurEffect();
                new ProvjeraWindow(selectedPNS).ShowDialog();
                this.Effect = null;
            }
        }
        private void Idi_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                PredmetNaSmjeru? selectedPNS = (PredmetNaSmjeru)pNaSDG.SelectedItem;
                if (selectedPNS != null)
                {
                    this.Effect = new BlurEffect();
                    new PredajeWindow(selectedPNS, P == null).ShowDialog();
                    this.Effect = null;
                }
            }
            catch { }
        }


    }

    internal class RazredValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            if (value != null)
            {
                int proposedValue;
                if (!int.TryParse(value.ToString(), out proposedValue) || proposedValue < 1 || proposedValue > 4)
                {
                    return new ValidationResult(false, Properties.Resources.RazredError);
                }

            }
            return new ValidationResult(true, null);

        }

    }

    public class PNSValidationRule : ValidationUtil
    {
        public override ValidationResult Validate(object value,
            System.Globalization.CultureInfo cultureInfo)
        {
            PredmetNaSmjeru pns = (value as BindingGroup).Items[0] as PredmetNaSmjeru;
            if (pns != null &&( pns.Predmet.IdPredmeta == null  || pns.Smjer.IdSmjera == null || pns.Tip == null || pns.MinimalniBrojPismenihProvjera == null || pns.MinimalniBrojUsmenihProvjera == null))
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
            PredmetNaSmjeru pns = o as PredmetNaSmjeru;
            if (pns.Predmet.IdPredmeta == null || pns.Smjer.IdSmjera == null || pns.Tip == null || pns.MinimalniBrojPismenihProvjera == null || pns.MinimalniBrojUsmenihProvjera == null)
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

