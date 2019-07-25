using Navigation_BT.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Navigation_BT
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ActivityFeedPage : ContentPage
    {
        private ActivityService _service = new ActivityService();
        public ActivityFeedPage()
        {
            InitializeComponent();

            activityFeed.ItemsSource = _service.GetActivities();
        }

      async   void ActivityFeed_ItemSelected(object sender, SelectedItemChangedEventArgs e)
         {
            if (e.SelectedItem == null)
                return;
            var activity = e.SelectedItem as Activity;
            activityFeed.SelectedItem = null;
         await  Navigation.PushAsync(new UserProfilePage(activity.UserId));
         }
    }
}