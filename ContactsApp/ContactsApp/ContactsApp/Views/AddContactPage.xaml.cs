using ContactsApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ContactsApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddContactPage : ContentPage
	{
        public AddContactPage(ObservableCollection<Contact> contact)
        {
            InitializeComponent();
            BindingContext = new AddContactPage(contact);
        }
        public AddContactPage(ObservableCollection<Contact> contact, Contact selectedContact)
        {
            InitializeComponent();
            BindingContext = new AddContactPage(contact, selectedContact);
        }
    }
}