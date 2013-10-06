using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace Venmo
{
    public partial class TransactionList : PhoneApplicationPage
    {
        public TransactionList()
        {
            InitializeComponent();
            Loaded += new RoutedEventHandler(TransactionList_Loaded);
        }

        private void TransactionList_Loaded(object sender, RoutedEventArgs e)
        {
            List<Transactions> list = new List<Transactions>();

            //Generate Hard-Coded Data which will represent transactions
            list.Add(new Transactions("Fred Murray","Jamie Kay", "Paid", 12.00));
            list.Add(new Transactions("Martha Denning","Chris Gunner", "Charged", 5.57));

            this.TransList.ItemsSource = list;
        }
    }

    public class Transactions
    {
        public string RecipientName
        {
            get;
            set;
        }

        public string Type
        {
            get;
            set;
        }

        public String Message
        {
            get;
            set;
        }

        public Transactions(string sender, string recipientName, string type, double amount)
        {

           
            this.RecipientName = " $" + amount +" to "+ recipientName;
            this.Type = type;
            Message = sender + " " + type + ": ";
            
            
           
        }
    }
}