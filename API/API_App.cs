using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json;

namespace API
{
    public partial class API_App : Form
    {

        public API_App()
        {
            InitializeComponent();
        }

        public async void load()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://unogs-unogs-v1.p.rapidapi.com/aaapi.cgi?t=deleted&cl=PL&st=1"),
                //RequestUri= new Uri("https://numbersapi.p.rapidapi.com/6/21/date?fragment=true&json=true"),

            Headers =
                {
                    { "x-rapidapi-key", "bb39cfd0f9mshfa3efd401f9eb7cp12860djsn6e8a143a24f8" },
                    { "x-rapidapi-host", "unogs-unogs-v1.p.rapidapi.com" },
                    //{ "x-rapidapi-host", "numbersapi.p.rapidapi.com" },
                },
            };

            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                string body = await response.Content.ReadAsStringAsync();
                label1.Text = (body);
            }
           /*
            HttpClient httpClient = new HttpClient();
            string call = "http://api.openweathermap.org/data/2.5/weather?id=1&appid=5b699a1e4b97ac1a6a9cee3366eb509c";

            string json = await httpClient.GetStringAsync(call);
            label1.Text = (json);
           */
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nazwa = textBox1.Text.ToLower();
            Baza baza = new Baza(nazwa);
            label2.Text = baza.LoadingStates(nazwa);
        }
    }
}
