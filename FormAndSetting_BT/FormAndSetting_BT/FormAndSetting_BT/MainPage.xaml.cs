using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FormAndSetting_BT
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private ObservableCollection<Contact> _contacts = new ObservableCollection<Contact>
        {
            new Contact { Id = 1, FirstName = "John", LastName = "Smith", Email = "john@smith.com", Phone = "1111" },
            new Contact { Id = 2, FirstName = "Mary", LastName = "Johnson", Email = "mary@johnson.com", Phone = "2222" }

        };
        public MainPage()
        {
            InitializeComponent();

            listV.ItemsSource = _contacts;
        }

        async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            var page = new ContactDetailPage(new Contact());

            //ContactAdded event using a lambda expression 
            page.ContactAdded += (source, contact) =>
            {
                _contacts.Add(contact);
            };
            await Navigation.PushAsync(page);
        }

        async void Contact_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (listV.SelectedItem == null)
                return;
            var selectedContact = e.SelectedItem as Contact;

            //when we comeback to the Contact page we can tap it again
            listV.SelectedItem = null;

            var page = new ContactDetailPage(selectedContact);
            page.ContactUpdated += (source, contact) =>
              {
                  selectedContact.Id = contact.Id;
                  selectedContact.FirstName = contact.FirstName;
                  selectedContact.LastName = contact.LastName;
                  selectedContact.Phone = contact.Phone;
                  selectedContact.Email = contact.Email;
                  selectedContact.IsBlocked = contact.IsBlocked;
              };
            await Navigation.PushAsync(page);
        }

        async private void Delete_Clicked(object sender, EventArgs e)
        {
            var contact = (sender as MenuItem).CommandParameter as Contact;
            if (await DisplayAlert("Warning", $"Are you sure you want to delete{contact.FullName}?", "Yes", "No"))
                _contacts.Remove(contact);
        }
    }
}
