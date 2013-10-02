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

namespace Venmo
{
    public partial class ContactList : PhoneApplicationPage
    {
        public ContactList()
        {
            //Add to contact list
            List<AddressBook> source = new List<AddressBook>();
            source.Add(new AddressBook("Jim Bob"));
            source.Add(new AddressBook("Kelly Kim"));
            source.Add(new AddressBook("Jasmine Daly"));
            List<AlphaKeyGroup<AddressBook>> DataSource = AlphaKeyGroup<AddressBook>.CreateGroups(source,
                System.Threading.Thread.CurrentThread.CurrentUICulture,
                (AddressBook s) => { return s.UserName; }, true);

            InitializeComponent();
            AddrBook.ItemsSource = DataSource;
        }
    }
        public class AddressBook
        {
            public string UserName
            {
                get;
                set;
            }
          
           

            public AddressBook(string UserName)
            {
                this.UserName = UserName;
              }
        
 

    }
}