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
        string symbol = "";
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
                RequestUri = new Uri("https://unogs-unogs-v1.p.rapidapi.com/aaapi.cgi?t=deleted&cl=" + symbol + "&st=1"),
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
                label3.Text = (body);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nazwa = textBox1.Text.ToLower();
            Baza baza = new Baza(nazwa);
            symbol = baza.LoadingStates(nazwa);
            label2.Text = symbol;

            if (symbol != "Brak znalezienia") load();
        }
            
    }
}
