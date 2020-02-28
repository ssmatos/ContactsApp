using ContactsApp.Models;
using ContactsApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ContactsApp.ViewModels
{
	public class ContactViewModel : INotifyPropertyChanged
	{
        Contact selectedContact;
        const string PhoneCallText = "Call";
        const string OptionsTitleText = "Choose an option";
        const string OptionsSubtitleText = "Cancel";
        public Command AddContactCommand { get; set; }
        public Command DeleteContactCommand { get; set; }
        public Command AddContactPageCommand { get; set; }
        public Command EditContactCommand { get; set; }
        public ObservableCollection<Contact> Contacts { get; set; } = new ObservableCollection<Contact>();
        public event PropertyChangedEventHandler PropertyChanged;

        public Contact SelectedContact
        {
            get
            {
                return selectedContact;
            }
            set
            {
                selectedContact = value;

                if (selectedContact != null)
                    DisplayElementSelected();

            }
        }

        public void Call(string number)
        {
            try
            {
                PhoneDialer.Open(number);
            }
            catch (ArgumentNullException a)
            {
            }
            catch (FeatureNotSupportedException b)
            {
            }
            catch (Exception b)
            {
            }
        }

        public async void DisplayElementSelected()
        {
            string answer = await App.Current.MainPage.DisplayActionSheet($"{OptionsTitleText}", $"{OptionsSubtitleText}", "  ", $"{PhoneCallText} {SelectedContact.firstName} {SelectedContact.lastName}");

            if (answer == PhoneCallText)
            {
                Call(selectedContact.number);
            }
        }

        public ContactViewModel(ObservableCollection<Contact> contacts)
        {
            AddContactPageCommand = new Command<Contact>(async (selectedContact) =>
            {
                await App.Current.MainPage.Navigation.PushModalAsync(new AddContactPage(Contacts));
            });

            DeleteContactCommand = new Command<Contact>((selectedContact) =>
            {
                Contacts.Remove(selectedContact);
            });

            EditContactCommand = new Command<Contact>(async (selectedContact) =>
            {
                await App.Current.MainPage.Navigation.PushModalAsync(new AddContactPage(Contacts, selectedContact));
            });
        }
    }
}
