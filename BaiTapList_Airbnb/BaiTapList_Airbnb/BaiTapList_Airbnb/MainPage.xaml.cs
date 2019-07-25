using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BaiTapList_Airbnb
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private ObservableCollection<Search> _searches = new ObservableCollection<Search>
        {
                new Search{Id=1, Location="52 Lac Long Quan", CheckIn="3/2/2000", CheckOut="3/1/2100"},
                new Search{Id=2, Location="367 Hoang Quoc Viet", CheckIn="2/12/2000", CheckOut="3/1/2100"},
                new Search{Id=3, Location="31 Cau Dien", CheckIn="23/2/2000", CheckOut="3/1/2100"},
                new Search{Id=4, Location="23 Co Nhue", CheckIn="29/2/2000", CheckOut="3/1/2100"}
        };
        public MainPage()
        {
            InitializeComponent();
            listV.ItemsSource = _searches;
        }

        IEnumerable<Search> GetSearches(string filter = null)
        {
            if (String.IsNullOrEmpty(filter))
                return _searches;
            return _searches.Where(c => c.Location.Contains(filter));
        }
        private void Delete_Clicked(object sender, EventArgs e)
        {
            var search = (sender as MenuItem).CommandParameter as Search;
            _searches.Remove(search);
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            listV.ItemsSource = GetSearches(e.NewTextValue);
        }

        private void ListV_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var search = e.SelectedItem as Search;
            DisplayAlert("Selected", search.Location, "OK");
        }
    }
}
