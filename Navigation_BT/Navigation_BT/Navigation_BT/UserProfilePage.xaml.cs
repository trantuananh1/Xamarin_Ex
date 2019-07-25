using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Navigation_BT.Service;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Navigation_BT
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserProfilePage : ContentPage
    {
        private UserService _service = new UserService();
        public UserProfilePage(int userId)
        {
            BindingContext = _service.GetUser(userId);

            InitializeComponent();
        }
    }
}