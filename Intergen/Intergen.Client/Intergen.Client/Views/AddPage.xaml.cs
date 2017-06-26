using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace MyIntergenites.Client.Views
{
    public partial class AddPage : ContentPage
    {
        private string Url = Constants.Url;
        public AddPage()
        {
            InitializeComponent();
        }

        public async Task AddIntergeniteAsync()
        {
            var httpClient = new HttpClient();

            var name = NameEntry.Text;
            var department = DepartmentEntry.Text;

            var Intergenite = new Intergenite
            {
                Name = name,
                Department = department
            };

            var json = JsonConvert.SerializeObject(Intergenite);

            HttpContent httpContent = new StringContent(json);

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var result = await httpClient.PostAsync(Url, httpContent);
            await DisplayAlert("Confirmation", "New Intergenite has been added", "OK");
        }

        private async void AddIntergenite_Clicked(object sender, EventArgs e)
        {
            await AddIntergeniteAsync();
        }
    }
}
