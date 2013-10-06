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

        /**Custom Application Bar **/
        private void myPivot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch(((Pivot)sender).SelectedIndex)
            {
                case 0:
                ApplicationBar=((ApplicationBar)this.Resources["appPage1"]);
                break;
                case 1:
                ApplicationBar = ((ApplicationBar)this.Resources["appPage2"]);
                break;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.NavigationService.RemoveBackEntry();
            if (AmountBox.Text == "" || RecipientBox.Text == "")
            {
                MessageBox.Show("Some Fields are Incomplete");
            }
            else
            {
                MessageBox.Show("Transaction Complete");
            }
        }
        // Load data for the ViewModel Items
        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {

            if (!App.ViewModel.IsDataLoaded)
            {
                App.ViewModel.LoadData();
            }

            base.OnNavigatedTo(e);
            string Text = "";
            string thePageNum;
            if (NavigationContext.QueryString.TryGetValue("Text", out Text))
            {
                NavigationContext.QueryString.TryGetValue("Page", out thePageNum);
                MainPivot.SelectedIndex = Convert.ToInt32(thePageNum);
                RecipientBox.Text = Text;
            }

        }


        /** Button Actions **/
        
        //Add recipient name for transaction
        private void Button_Click(object sender, RoutedEventArgs e)
        {
                NavigationService.Navigate(
                    new Uri("/ContactList.xaml", UriKind.Relative));
            
        }

        private void TransactionHistory_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(
                new Uri("/TransactionList.xaml", UriKind.Relative));
        }
    }
}
