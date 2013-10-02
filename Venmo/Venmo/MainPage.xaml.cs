using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Venmo.Resources;

namespace Venmo
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Set the data context of the listbox control to the sample data
            DataContext = App.ViewModel;
        }

        

        private void myPivot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch(((Pivot)sender).SelectedIndex)
            {
                case 0:
                ApplicationBar=((ApplicationBar)Application.Current.Resources["appPage1"]);
                break;
                case 1:
                ApplicationBar = ((ApplicationBar)Application.Current.Resources["appPage2"]);
                break;
            }
        }

        // Load data for the ViewModel Items
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (!App.ViewModel.IsDataLoaded)
            {
                App.ViewModel.LoadData();
            }
        }


        //Button Actions
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(
                new Uri("/ContactList.xaml", UriKind.Relative));
        }
    }
}
