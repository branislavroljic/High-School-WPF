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
    /// Interaction logic for SmjerWindow.xaml
    /// </summary>
    public partial class SmjerWindow : Window
    {
        ISmjerDAO smjerDAO;

        GenericWindow<Smjer> genericWindow;

        public SmjerWindow()
        {

            InitializeComponent();
            Header.Title.Text = Properties.Resources.SmjeroviHeader;

            smjerDAO = DAOFactory.Instance(DAOType.MySQL).Smjerovi;


            genericWindow = new GenericWindow<Smjer>(smjerDAO, this, smjeroviDG, new List<string>() { Properties.Resources.NazivSkoleHeader, Properties.Resources.IdSmjeraHeader }, new SmjerValidationRule());

           

            JIBcmb.ItemsSource = DAOFactory.Instance(DAOType.MySQL).Skole.GetDTOList(); 

            ListCollectionView collectionView = new ListCollectionView(genericWindow.genericList);
            collectionView.GroupDescriptions.Add(new PropertyGroupDescription("Skola.Naziv"));
            smjeroviDG.ItemsSource = collectionView;

        }
        private void Delete_Click(object sender, RoutedEventArgs e) => genericWindow.Delete_Click(sender, e);

    }



    internal class TrajanjeValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            if (value != null)
            {
                int proposedValue;
                if (!int.TryParse(value.ToString(), out proposedValue) || proposedValue <3 || proposedValue > 5)
                {
                    return new ValidationResult(false, Properties.Resources.TrajanjeGodinaError);
                }

            }
            return new ValidationResult(true, null);

        }

    }
    public class SmjerValidationRule : ValidationUtil
    {
        public override ValidationResult Validate(object value,
            System.Globalization.CultureInfo cultureInfo)
        {
           Smjer s = (value as BindingGroup).Items[0] as Smjer;
            if (s != null && (string.IsNullOrEmpty(s.Naziv)  || string.IsNullOrEmpty(s.Zvanje) || s.IdSmjera == null || string.IsNullOrEmpty(s.Skola.JIB) || s.TrajanjeGodina == null))
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
            Smjer s = o as Smjer;
            if (string.IsNullOrEmpty(s.Naziv) || string.IsNullOrEmpty(s.Zvanje) || s.IdSmjera == null || string.IsNullOrEmpty(s.Skola.JIB) || s.TrajanjeGodina == null)
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




 

