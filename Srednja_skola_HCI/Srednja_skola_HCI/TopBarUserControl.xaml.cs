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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Srednja_skola_HCI
{
    /// <summary>
    /// Interaction logic for TopBarUserControl.xaml
    /// </summary>
    public partial class TopBarUserControl : UserControl
    {
        public TopBarUserControl()
        {
            InitializeComponent();
        }
        public TopBarUserControl(string title)
        {
            InitializeComponent();
            Title.Text = title;
        }

        private void Thumb_OnDragDelta(object sender, DragDeltaEventArgs e)
        {
            Window window = Window.GetWindow(this);
           window.Left = window.Left + e.HorizontalChange;
            window.Top = window.Top + e.VerticalChange;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Close();
        }
    }
}
