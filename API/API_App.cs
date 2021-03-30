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
            label2.Text = "symbol";
            label3.Text = ""; 
        }

        public async void last_deleted()
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
                    { "x-rapidapi-host", "unogs-unogs-v1.p.rapidapi.com"  },

                },
            };

            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                string body = await response.Content.ReadAsStringAsync();
                label3.Text = body;

                var read = body.Split("\"");
                if (read[3] == "0") richTextBox1.Text = "Brak wyników w bazie!";
                else if (read[3]=="1") richTextBox1.Text ="Netflix ID: " + read[9] + "\nTytuł: " + read[13] + "\nData usunięcia: " + read[21];


                //{"COUNT":"1","ITEMS":[{"netflixid":"60000861","title":"American Psycho",
                //"ccode":"PL","date":"2021-03-26 00:18:43"}]}
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string nazwa = textBox1.Text.ToLower();
            Baza baza = new Baza(nazwa);
            symbol = baza.LoadingStates(nazwa);
            label2.Text = symbol;

            if (symbol != "Brak znalezienia") last_deleted();
            else MessageBox.Show("Nie ma takiego państwa!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);

 
        }
    }
}
