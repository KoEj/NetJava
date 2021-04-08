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
                //label3.Text = body;

                var read = body.Split("\"");
                //richTextBox1.Text = body;
                if (read[3] == "0") richTextBox1.Text = "Brak wyników w bazie!";
                else richTextBox1.Text = "Netflix ID: " + read[9] + "\nTytuł: " + read[13] + "\nData usunięcia: " + read[21];


                //{"COUNT":"1","ITEMS":[{"netflixid":"60000861","title":"American Psycho",
                //"ccode":"PL","date":"2021-03-26 00:18:43"}]}
            }
        }

        public async void DB_expiring()
        {
            var context = new MOVIE_DB_Context();
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://unogs-unogs-v1.p.rapidapi.com/aaapi.cgi?q=get%3Aexp%3A" + symbol + "&t=ns&st=adv&p=1"),
                Headers =
    {
        { "x-rapidapi-key", "bb39cfd0f9mshfa3efd401f9eb7cp12860djsn6e8a143a24f8" },
        { "x-rapidapi-host", "unogs-unogs-v1.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                richTextBox2.Text = body;

                var read = body.Split("\"");

                if (read[3] == "0") richTextBox2.Text = "Brak wyników w bazie!";
                else
                {
                    int n = int.Parse(read[3]);
                    for (int i = 0; i < n; i++)
                    {
                        int j = i * 48;
                        var description = read[j + 21].Split("<");
                        context.Movies.Add(new Movie { ID = int.Parse(read[j + 9]), title = read[j + 13], description = description[0], premiere = int.Parse(read[j + 33]), date_exp = read[j + 45] });
                        //richTextBox2.Text = "Netflix ID: " + read[j + 9] + "\nTytuł: " + read[j + 13] + "\nOpis: " + description[0] + "\nRok premiery: " + read[j + 33] + "\nData wygasniecia filmu: " + read[j + 45];
                    }
                }
                // wysrywanie tego całehgo gówna
                // TO DO!!!!!!
                var students = (from s in context.Students select s).ToList<Student>();
                foreach (var st in students)
                {
                    Console.WriteLine("ID: {0}, Name: {1}, Avg: {2:0.00}", st.ID, st.Name, st.Avg);
                }


                /*
                 * {"COUNT":"22","ITEMS":[{"netflixid":"80100648","title":"The Infiltrator","image":"https://occ-0-2773-2774.1.nflxso.net/dnm/api/v6/evlCitJPPCVCry0BZlEFb5-QjKc/AAAABbto1zY2QhLF7uva7FMogD_oW0oFSBVuPxayhUJS4-JoJo1feknVHk6RpzB-hJrrFjVwoVw9apl8PpheiBj4fVjFMQ.jpg?r=d3c","synopsis":"A canny federal agent navigates a deadly world in which one mistake could get him killed: the criminal underworld of Colombia, ruled by Pablo Escobar.<br><b>Expires on 2021-04-08</b>","rating":"7","type":"movie","released":"2016","runtime":"2h6m","largeimage":"https://occ-0-114-116.1.nflxso.net/dnm/api/v6/evlCitJPPCVCry0BZlEFb5-QjKc/AAAABSCw_hM_WWEaQE0P9a3zQxNLJ3TfRUwzD8jfGdf-qsvQL1a7KxHObZDIyLcY9zL2gvQAuWiIjqq4WPOS57xk15TY3d-h.jpg?r=7b6","unogsdate":"2021-04-08","imdbid":"tt1355631","download":"1"},
                 * {"netflixid":"80036832","title":"How to Change the World","image":"https://occ-0-2717-360.1.nflxso.net/dnm/api/v6/evlCitJPPCVCry0BZlEFb5-QjKc/AAAABYtukAQro9yQfGCsTcnyfV9rtMnt9YuvdxmbJe5Vgc3F5NaCoA1x6xt2D6gw0qEPfMNKdjUjbi8nHBbLfHe74o0K6Q.jpg?r=bcb","synopsis":"In the 1970s, a group of activists who gathered to protest nuclear testing formed the iconic Greenpeace environmental organization.<br><b>Expires on 2021-04-09</b>","rating":"7.6","type":"movie","released":"2015","runtime":"1h50m","largeimage":"https://occ-0-1068-92.1.nflxso.net/dnm/api/v6/evlCitJPPCVCry0BZlEFb5-QjKc/AAAABV71SZ3lvUVyTuCI-t-Renv0F55kA0aN5hA6JhCbgle_MDzY3UGlhApRLbkyd9Wxm7llNa92IVM7iHkEOb1WzQq-PUE9.jpg?r=784","unogsdate":"2021-04-09","imdbid":"tt4144504","download":"0"}
            */
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string nazwa = textBox1.Text.ToLower();
            Baza baza = new Baza(nazwa);
            symbol = baza.LoadingStates(nazwa);
            label2.Text = symbol;

            DB_expiring();

            if (symbol != "Brak znalezienia") last_deleted();
            else MessageBox.Show("Nie ma takiego państwa!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
    }
}
