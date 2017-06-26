using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace MyIntergenites.Client.Views
{
    public partial class EditPage : ContentPage
    {
        private int IntergeniteId = 0;
        private string Url = Constants.Url;
        public EditPage(Intergenite Intergenite)
        {
            InitializeComponent();

            NameEntry.Text = Intergenite.Name;
            DepartmentEntry.Text = Intergenite.Department;
            IntergeniteId = Intergenite.Id;
        }

        private async void EditIntergenite_Clicked(object sender, EventArgs e)
        {
            var Intergenite = new Intergenite
            {
                Id = IntergeniteId,
                Name = NameEntry.Text,
                Department = DepartmentEntry.Text
            };

            var httpClient = new HttpClient();

            var json = JsonConvert.SerializeObject(Intergenite);

            HttpContent httpContent = new StringContent(json);

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var result = await httpClient.PutAsync(Url + IntergeniteId, httpContent);
            await DisplayAlert("Confirmation", "Intergenite has been updated", "OK");
        }

        private async void DeleteIntergenite_Clicked(object sender, EventArgs e)
        {
            var httpClient = new HttpClient();

            var response = await httpClient.DeleteAsync(Url + IntergeniteId);
            await DisplayAlert("Confirmation", "Intergenite has been deleted", "OK");
        }
    }
}
