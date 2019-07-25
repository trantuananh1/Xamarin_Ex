using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FormAndSetting_BT
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactDetailPage : ContentPage
    {
        public event EventHandler<Contact> ContactAdded;
        public event EventHandler<Contact> ContactUpdated;
        public ContactDetailPage(Contact contact)
        {
            if (contact == null)
                throw new ArgumentNullException(nameof(contact));

            InitializeComponent();

            BindingContext = new Contact
            {
                Id = contact.Id,
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                Phone = contact.Phone,
                Email = contact.Email,
                IsBlocked = contact.IsBlocked
            };
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            var contact = BindingContext as Contact;

            if (String.IsNullOrWhiteSpace(contact.FullName))
            {
                await DisplayAlert("Error", "Please enter the name", "OK");
                return;
            }
            if (contact.Id == 0)
            {
                // differ a new and an existing Contact obj
                contact.Id = 1;

                ContactAdded?.Invoke(this, contact);
            }
            else
            {
                ContactUpdated?.Invoke(this, contact);
            }
            await Navigation.PopAsync();
        }
    }
}