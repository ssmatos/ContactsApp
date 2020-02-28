using ContactsApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace ContactsApp.ViewModels
{
	public class AddPageViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		Contact selectedContact;
		public Command AddContactCommand { get; set; }

		public Contact SelectedContact
		{
			get
			{
				return selectedContact;
			}
            set
            {
                selectedContact = value;
            }
        }

        public AddPageViewModel(ObservableCollection<Contact> Contacts)
        {
            SelectedContact = new Contact() { image = "selecteduser" };

            AddContactCommand = new Command(async () =>
            {
                Contacts.Add(SelectedContact);
                await App.Current.MainPage.Navigation.PopModalAsync();
            });
        }

        public AddPageViewModel(ObservableCollection<Contact> contacts, Contact selectedContact)
        {
            SelectedContact = selectedContact;
            AddContactCommand = new Command(async () =>
            {
                await App.Current.MainPage.Navigation.PopModalAsync();
            });
        }
    }
}
