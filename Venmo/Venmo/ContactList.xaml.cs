using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Globalization;
using System.Globalization;
using Microsoft.Phone.Shell;
using System.Windows.Media;

namespace Venmo
{
    public partial class ContactList : PhoneApplicationPage
    {
        public ContactList()
        {
            InitializeComponent();
            Loaded += new RoutedEventHandler(ContactList_Loaded);
        }

        private void ContactList_Loaded(object sender, RoutedEventArgs e)
        {
            List<AddressBook> addrList = new List<AddressBook>();

            //Generate Hard-Coded Data which will eventually be people's names
            addrList.Add(new AddressBook("Jamie Sullivan"));
            addrList.Add(new AddressBook("Kristin Good"));
            addrList.Add(new AddressBook("Joslyn Lynn"));


            //Bind contacts with the View
            this.ContactLst.ItemsSource = addrList;

        }

        /** Event Handlers **/
        private void SelectName_Click(object sender, RoutedEventArgs e)
        {
            AddressBook data = (sender as Button).DataContext as AddressBook;
            ListBoxItem selectedItem = this.ContactLst.ItemContainerGenerator.ContainerFromItem(data) as ListBoxItem;

            if (selectedItem != null)
            {
                string uri = "/MainPage.xaml?Text=" + data.UserName + "&Page=" + 1;

                //This is the name that will be saved
                NavigationService.Navigate(
                new Uri(uri, UriKind.Relative));

            }
        }

        private void ContactList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AddressBook contactData = (sender as ListBox).SelectedItem as AddressBook;
            ListBoxItem selectedItem = this.ContactLst.ItemContainerGenerator.ContainerFromIndex(2) as ListBoxItem;
            MessageBox.Show(contactData.UserName);
        }

    }

}

/**
* This class creates the recipients of transactions
* **/
public class AddressBook
{
    public string UserName
    {
        get;
        set;
    }

    public string Profile
    {
        get;
        set;
    }


    public AddressBook(string UserName)
    {
        this.UserName = UserName;
        this.Profile = "Assets/Images/profile.png";

    }



}
