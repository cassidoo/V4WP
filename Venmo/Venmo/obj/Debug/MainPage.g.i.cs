﻿#pragma checksum "C:\Users\Hannah\Documents\GitHub\V4WP\Venmo\Venmo\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "CD3A6E378C232B77CE851C653EFA24AE"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18051
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace Venmo {
    
    
    public partial class MainPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal Microsoft.Phone.Shell.ApplicationBarIconButton sender;
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal Microsoft.Phone.Controls.Pivot MainPivot;
        
        internal System.Windows.Controls.Button T_History;
        
        internal System.Windows.Controls.Button Pending;
        
        internal System.Windows.Controls.Button Find_F;
        
        internal System.Windows.Controls.Button Invite_F;
        
        internal System.Windows.Controls.TextBox RecipientBox;
        
        internal System.Windows.Controls.Button addbutton;
        
        internal System.Windows.Controls.TextBox AmountBox;
        
        internal Microsoft.Phone.Controls.ListPicker OptionSelector;
        
        internal Microsoft.Phone.Controls.ListPickerItem Pay;
        
        internal Microsoft.Phone.Controls.ListPickerItem Charge;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/Venmo;component/MainPage.xaml", System.UriKind.Relative));
            this.sender = ((Microsoft.Phone.Shell.ApplicationBarIconButton)(this.FindName("sender")));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.MainPivot = ((Microsoft.Phone.Controls.Pivot)(this.FindName("MainPivot")));
            this.T_History = ((System.Windows.Controls.Button)(this.FindName("T_History")));
            this.Pending = ((System.Windows.Controls.Button)(this.FindName("Pending")));
            this.Find_F = ((System.Windows.Controls.Button)(this.FindName("Find_F")));
            this.Invite_F = ((System.Windows.Controls.Button)(this.FindName("Invite_F")));
            this.RecipientBox = ((System.Windows.Controls.TextBox)(this.FindName("RecipientBox")));
            this.addbutton = ((System.Windows.Controls.Button)(this.FindName("addbutton")));
            this.AmountBox = ((System.Windows.Controls.TextBox)(this.FindName("AmountBox")));
            this.OptionSelector = ((Microsoft.Phone.Controls.ListPicker)(this.FindName("OptionSelector")));
            this.Pay = ((Microsoft.Phone.Controls.ListPickerItem)(this.FindName("Pay")));
            this.Charge = ((Microsoft.Phone.Controls.ListPickerItem)(this.FindName("Charge")));
        }
    }
}

