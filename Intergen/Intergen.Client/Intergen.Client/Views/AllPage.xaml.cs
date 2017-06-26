using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace MyIntergenites.Client.Views
{
    public partial class AllPage : ContentPage
    {
        private string Url = Constants.Url;
        public AllPage()
        {
            InitializeComponent();

            DownloadIntergenitesAsync();
        }

        private async Task DownloadIntergenitesAsync()
        {
            var httpClient = new HttpClient();

            var json = await httpClient.GetStringAsync(Url);

            var Intergenites = JsonConvert.DeserializeObject<List<Intergenite>>(json);
            
            IntergenitesListView.ItemsSource = Intergenites;
        }

        private async void IntergenitesListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var Intergenite = e.Item as Intergenite;

            if (Intergenite != null)
            {
                await Navigation.PushModalAsync(new EditPage(Intergenite));
            }
        }

        private void Refresh_Clicked(object sender, EventArgs e)
        {
             DownloadIntergenitesAsync();
        }
    }
}
