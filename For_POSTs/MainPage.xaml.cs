using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace For_POSTs
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public async void Go()
        {
            var user = new User();
            user.Name = "Yuriy_Ledenev";
            user.Job = "Teacher";
            string json = JsonConvert.SerializeObject(user);
            HttpContent content = new StringContent(json);
            HttpClient client = new HttpClient();
            try
            {
                HttpResponseMessage response = await client.PostAsync("https://reqres.in/api/users", content);
                Label.Text = "Успех";
            }
            catch (Exception ex)
            {
                Label.Text= ex.Message;
            }


        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Go();
        }
    }
}
