#pragma checksum "..\..\..\..\Forms\ProvjeraInputDialogWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "A7B2B9BA4614EF8363FC27B5AC16178EA225A36B"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Srednja_skola_HCI.Forms;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace Srednja_skola_HCI.Forms {
    
    
    /// <summary>
    /// ProvjeraInputDialogWindow
    /// </summary>
    public partial class ProvjeraInputDialogWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\..\Forms\ProvjeraInputDialogWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker datumProvjereDP;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\..\Forms\ProvjeraInputDialogWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox odjeljenjeTB;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\..\Forms\ProvjeraInputDialogWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox trajanjeCB;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\..\Forms\ProvjeraInputDialogWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox ponovljenaCB;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\..\Forms\ProvjeraInputDialogWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton usmenaRB;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\..\Forms\ProvjeraInputDialogWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton pismenaRB;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Srednja_skola_HCI;component/forms/provjerainputdialogwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Forms\ProvjeraInputDialogWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.datumProvjereDP = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 2:
            this.odjeljenjeTB = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.trajanjeCB = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.ponovljenaCB = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 5:
            this.usmenaRB = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 6:
            this.pismenaRB = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 7:
            
            #line 20 "..\..\..\..\Forms\ProvjeraInputDialogWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.OK_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

