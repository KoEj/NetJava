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
                else richTextBox1.Text ="Netflix ID: " + read[9] + "\nTytuł: " + read[13] + "\nData usunięcia: " + read[21];


                //{"COUNT":"1","ITEMS":[{"netflixid":"60000861","title":"American Psycho",
                //"ccode":"PL","date":"2021-03-26 00:18:43"}]}
            }
        }

        public async void DB_expiring()
        {
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

                /*
                 * {"COUNT":"22","ITEMS":[{"netflixid":"80100648","title":"The Infiltrator","image":"https://occ-0-2773-2774.1.nflxso.net/dnm/api/v6/evlCitJPPCVCry0BZlEFb5-QjKc/AAAABbto1zY2QhLF7uva7FMogD_oW0oFSBVuPxayhUJS4-JoJo1feknVHk6RpzB-hJrrFjVwoVw9apl8PpheiBj4fVjFMQ.jpg?r=d3c","synopsis":"A canny federal agent navigates a deadly world in which one mistake could get him killed: the criminal underworld of Colombia, ruled by Pablo Escobar.<br><b>Expires on 2021-04-08</b>","rating":"7","type":"movie","released":"2016","runtime":"2h6m","largeimage":"https://occ-0-114-116.1.nflxso.net/dnm/api/v6/evlCitJPPCVCry0BZlEFb5-QjKc/AAAABSCw_hM_WWEaQE0P9a3zQxNLJ3TfRUwzD8jfGdf-qsvQL1a7KxHObZDIyLcY9zL2gvQAuWiIjqq4WPOS57xk15TY3d-h.jpg?r=7b6","unogsdate":"2021-04-08","imdbid":"tt1355631","download":"1"},{"netflixid":"80036832","title":"How to Change the World","image":"https://occ-0-2717-360.1.nflxso.net/dnm/api/v6/evlCitJPPCVCry0BZlEFb5-QjKc/AAAABYtukAQro9yQfGCsTcnyfV9rtMnt9YuvdxmbJe5Vgc3F5NaCoA1x6xt2D6gw0qEPfMNKdjUjbi8nHBbLfHe74o0K6Q.jpg?r=bcb","synopsis":"In the 1970s, a group of activists who gathered to protest nuclear testing formed the iconic Greenpeace environmental organization.<br><b>Expires on 2021-04-09</b>","rating":"7.6","type":"movie","released":"2015","runtime":"1h50m","largeimage":"https://occ-0-1068-92.1.nflxso.net/dnm/api/v6/evlCitJPPCVCry0BZlEFb5-QjKc/AAAABV71SZ3lvUVyTuCI-t-Renv0F55kA0aN5hA6JhCbgle_MDzY3UGlhApRLbkyd9Wxm7llNa92IVM7iHkEOb1WzQq-PUE9.jpg?r=784","unogsdate":"2021-04-09","imdbid":"tt4144504","download":"0"},{"netflixid":"80221166","title":"Earth to Luna!","image":"https://occ-0-1490-1489.1.nflxso.net/dnm/api/v6/evlCitJPPCVCry0BZlEFb5-QjKc/AAAABR4RlW3WcMDxtyaIetuj4e08F6yZOq9Bys9zZin4_AqbfPxBk6Rbqu07T9AjrJgr7lG8XT17f4VFXZcAxgq4xbfb-w.jpg?r=c3c","synopsis":"Curious about everything and excited about science, 12-year-old Luna, her brother Jupiter and pet Clyde explore nature to learn about the world.<br><b>Expires on 2021-04-09</b>","rating":"7.4","type":"series","released":"2014","runtime":"","largeimage":"https://occ-0-37-33.1.nflxso.net/dnm/api/v6/evlCitJPPCVCry0BZlEFb5-QjKc/AAAABd-OaPCg0oagaAAPBRcAq_yRw35LxN-aDNklZOy9qF-eXLi23wT7byL-y_lO-O2p3zH68_Och1HU2Ltq50YIcvK9ehXy.jpg?r=530","unogsdate":"2021-04-09","imdbid":"tt6428704","download":"0"},{"netflixid":"81043542","title":"Dabbe 6: The Return","image":"https://occ-0-2851-38.1.nflxso.net/dnm/api/v6/evlCitJPPCVCry0BZlEFb5-QjKc/AAAABTI6IJwv6SAm9yelEvOV-dCJaoVc_22jpK9hU5Hc4eUde7SrXntsfqpQPjrvgz01b5EPVIhL4GsvqZFNPoSFqaopTg.jpg?r=8b1","synopsis":"A cardiologist tries to pinpoint the cause of her mother&#39;s sudden death as her sister, who witnessed it, claims malevolent demons are at play.<br><b>Expires on 2021-04-11</b>","rating":"5.7","type":"movie","released":"2015","runtime":"2h33m","largeimage":"","unogsdate":"2021-04-11","imdbid":"tt4967920","download":"0"},{"netflixid":"80231602","title":"Hungerford","image":"https://occ-0-2717-360.1.nflxso.net/dnm/api/v6/evlCitJPPCVCry0BZlEFb5-QjKc/AAAABWSD8E1Fy-u-Kk1XMYlgIAbmsxsOO1LsyogU2CZ9ibQoyw0Xqfy89JJWcuiish0-qxo9jxPXtgJZjjkeesmYbCBaIQ.jpg?r=0b7","synopsis":"While filming his daily life for a media course, Cowen discovers his small English town may be under an ominous and otherworldly influence.<br><b>Expires on 2021-04-14</b>","rating":"3.8","type":"movie","released":"2014","runtime":"1h19m","largeimage":"","unogsdate":"2021-04-14","imdbid":"tt3552892","download":"0"},{"netflixid":"80231601","title":"The Darkest Dawn","image":"https://occ-0-2851-38.1.nflxso.net/dnm/api/v6/evlCitJPPCVCry0BZlEFb5-QjKc/AAAABUeatdn5-9OizI_5KpCGZNJ8J2YX6O6zFPhwYuISu-4MaRPLuHMOjkjrnX-6-fXqiO3Xfd4ny5Pmu-6zHJEkkGTF8Q.jpg?r=4d6","synopsis":"An aspiring filmmaker records the chaos of an alien invasion while struggling to stay alive with her sister and a bickering band of survivors.<br><b>Expires on 2021-04-14</b>","rating":"4","type":"movie","released":"2016","runtime":"1h15m","largeimage":"","unogsdate":"2021-04-14","imdbid":"tt6017594","download":"0"},{"netflixid":"70059700","title":"Eddie Murphy: Delirious","image":"http://occ-0-2851-38.1.nflxso.net/dnm/api/v6/evlCitJPPCVCry0BZlEFb5-QjKc/AAAABYPPpoTVD9QQT1SzX3E83wx6_9ySxVJvFRdPAY8bvgUK_HJtwKV9TDny_zkD9-W0lFMy6wln-8C9YtRST0RbGshxkA.jpg?r=05d","synopsis":"Flashing the wild stand-up comedy that made him a household name, Eddie Murphy unleashes uncensored observations and parodies in this 1983 live show.<br><b>Expires on 2021-04-14</b>","rating":"8.2","type":"movie","released":"1983","runtime":"1h8m","largeimage":"https://occ-0-2218-2219.1.nflxso.net/dnm/api/v6/evlCitJPPCVCry0BZlEFb5-QjKc/AAAABSY7U_XUxOwX15HcmsI4qkTjtbKQG-0I7dIWCgI9LsBDzuhSysQg_TPhpEuXmA4OfcCy2-xQ7MBTallKLrV6NyEMU9Fl.jpg?r=05d","unogsdate":"2021-04-14","imdbid":"tt0085474","download":"0"},{"netflixid":"80995078","title":"Little Singham in London","image":"http://occ-0-1490-1489.1.nflxso.net/dnm/api/v6/evlCitJPPCVCry0BZlEFb5-QjKc/AAAABfd6XwFT3nmPc2bc1SzBPXnACkcqLHY3UfU_ZSamo9Uc0DXd6W01T8rSCVM3WrEqyvbdNedckSmBJyXZfAt4w8YfWA.jpg?r=a1b","synopsis":"Little Singham is in London to meet the queen, but when the famed Kohinoor Diamond gets stolen, the kid cop goes on a wild, citywide hunt for the thief.<br><b>Expires on 2021-04-14</b>","rating":"","type":"movie","released":"2019","runtime":"1h6m","largeimage":"https://occ-0-56-55.1.nflxso.net/dnm/api/v6/evlCitJPPCVCry0BZlEFb5-QjKc/AAAABdB6Chl8GYYKP5FbFbhyl5XSrkHlqrvCb992M8ksQ611PbMbNngMFeNQt6U9FeN-5lWxcpKWjX_4qEG9V98mV77mcTs6.jpg?r=a1b","unogsdate":"2021-04-14","imdbid":"notfound","download":"0"},{"netflixid":"80062111","title":"Final Girl","image":"https://occ-0-2851-38.1.nflxso.net/dnm/api/v6/evlCitJPPCVCry0BZlEFb5-QjKc/AAAABbk4lqFHi-HBui8YcLuB56G2bcF_om3ROjVmLx2VZvvO3yUZFBMyoIJhihpkgNDFHYGh4gQy6jE37dFIZaMJzdOj0A.jpg?r=0e7","synopsis":"A group of sociopaths that&#39;s been killing girls in the woods for sport sets its sights on a teen who turns out to be a trained assassin.<br><b>Expires on 2021-04-14</b>","rating":"4.7","type":"movie","released":"2015","runtime":"1h24m","largeimage":"https://occ-0-58-64.1.nflxso.net/dnm/api/v6/evlCitJPPCVCry0BZlEFb5-QjKc/AAAABZqL-eGGNPdP_li37GGOfprGsDAYou6eLP0bQdMcUvQzILhbUem87vHzSLiIwP58cF-soYq73bF28LqD0D25Na-K64vM.jpg?r=0e7","unogsdate":"2021-04-14","imdbid":"tt2124787","download":"1"},{"netflixid":"80114987","title":"Race for the White House","image":"https://occ-0-2851-38.1.nflxso.net/dnm/api/v6/evlCitJPPCVCry0BZlEFb5-QjKc/AAAABSv6HOwaJ6xY-dxcLtWOuv45AHzZj-66C58XsLy2nZfpu8LIxTXnhunT9JpU1CGctve2uQRhnzPVBS3QiX0eGHTNpw.jpg?r=e7f","synopsis":"This miniseries featuring archival footage and interviews with experts captures the drama of six of history&#39;s most iconic presidential campaigns.<br><b>Expires on 2021-04-14</b>","rating":"7.8","type":"series","released":"2016","runtime":"","largeimage":"https://occ-0-2705-2706.1.nflxso.net/dnm/api/v6/evlCitJPPCVCry0BZlEFb5-QjKc/AAAABWU9pI5aJezGY1LposFaAcyA1Fqqu0C4eHxG-7jaq-is6MqhJbSBpVCSgz6A_X4qr5gBAx1vb9Gvo-_X4iLZ680tYP1u.jpg?r=d7d","unogsdate":"2021-04-14","imdbid":"tt5194802","download":"1"},{"netflixid":"80229824","title":"Team Chocolate","image":"https://occ-0-2773-2774.1.nflxso.net/dnm/api/v6/evlCitJPPCVCry0BZlEFb5-QjKc/AAAABbmdNXqPpwZ_XoyxRblKZpHOZG1mTWUg4AAlvGdFUAVRN4Q8yr1LjcCa0Cmprs01B3-ZME1cYtTKaoHIWFG_HqkzZg.jpg?r=491","synopsis":"A young man with Down syndrome who works at a chocolate factory falls in love with a colleague, but her immigration status could pose a problem.<br><b>Expires on 2021-04-14</b>","rating":"7.3","type":"series","released":"2017","runtime":"","largeimage":"https://occ-0-56-55.1.nflxso.net/dnm/api/v6/evlCitJPPCVCry0BZlEFb5-QjKc/AAAABYdP7V_WMEIktfa-yCvG7JB2eXARrfQJ_NQRIBOs5Fpq3r8P1li4Hv352lOpeelKipZFKZqlDxB_F0oRjeLIRpkjB8Sj.jpg?r=358","unogsdate":"2021-04-14","imdbid":"tt7388652","download":"0"},{"netflixid":"80149141","title":"Four Seasons in Havana","image":"https://occ-0-2773-2774.1.nflxso.net/dnm/api/v6/evlCitJPPCVCry0BZlEFb5-QjKc/AAAABaoEtbyh-pqoz9tHe-7fV5M25oAZZz9QRWvRkuK_r8KOWJyfbvEkEnbfAaxiKaXOTYZHGk5gwk2txeyAnXQ3hgxLZKIki53yb0ieC9aDL4XBnFIKK6vEiCu3Kwo.jpg?r=7e9","synopsis":"As Havana slowly revolves through the year, wistful detective Mario Conde probes the sultry heart of the city to investigate dark and deadly crimes.<br><b>Expires on 2021-04-15</b>","rating":"6.7","type":"series","released":"2016","runtime":"","largeimage":"https://occ-0-55-56.1.nflxso.net/dnm/api/v6/evlCitJPPCVCry0BZlEFb5-QjKc/AAAABR2r71V2f9MOp9Ja9ISbqbItn_14F5C71Bekks3xBjYIbi6Nd78S_gmoakkcSyiQNuP2WCyrMYx6V9GavAeVuxnXkxCWptKdC2bjkEcJ-gWne-fuQbrA_zWycIGOKg.jpg?r=7e9","unogsdate":"2021-04-15","imdbid":"tt4944644","download":"1"},{"netflixid":"80190407","title":"Murderous Affairs","image":"https://occ-0-1490-1489.1.nflxso.net/dnm/api/v6/evlCitJPPCVCry0BZlEFb5-QjKc/AAAABUAO623oPExncxN8VdvSwyeAosvCqFQfwoB3cTEWKQOTLRTufDUCMt5Cv_yoUueF1adExOf0k8CTem_We-iliL8UGw.jpg?r=458","synopsis":"Mixing interviews with dramatic re-enactments, this series focuses on lethal love affairs and spouses driven to murder.<br><b>Expires on 2021-04-16</b>","rating":"6.8","type":"series","released":"2016","runtime":"","largeimage":"https://occ-0-34-32.1.nflxso.net/dnm/api/v6/evlCitJPPCVCry0BZlEFb5-QjKc/AAAABfatTUwhDjqg28StZBRS9085E51DgcGnLP1yVbD6g7JkOQNsh245Vn74lKlcidwhwQhs94lOSyyT9TR6NuM8mthe_hXU.jpg?r=458","unogsdate":"2021-04-16","imdbid":"tt6059970","download":"0"},{"netflixid":"81065424","title":"Bruder: Schwarze Macht","image":"https://occ-0-2773-2774.1.nflxso.net/dnm/api/v6/evlCitJPPCVCry0BZlEFb5-QjKc/AAAABWU4pwDSoXliWoepm0AW9APNs8XpaRhHAkZvD2SCxbXlbZiSaJthEKlFOVk5OAPAzVP5X-J_rE7Gp3b6TJau4jf03w.jpg?r=4d2","synopsis":"A Muslim teen becomes radicalized after struggling to find his place in German society.<br><b>Expires on 2021-04-18</b>","rating":"7.3","type":"series","released":"2017","runtime":"","largeimage":"https://occ-0-2773-1490.1.nflxso.net/dnm/api/v6/evlCitJPPCVCry0BZlEFb5-QjKc/AAAABdKdzbqg1zthkOfxgAVsnZgKb9iZAqCQGeY9_jI8qBJqjZIhhxwKMMF8cZ0eignjK19d525lWU19MvyQRYkQP42fMQBX.jpg?r=4d2","unogsdate":"2021-04-18","imdbid":"tt7475940","download":"0"},{"netflixid":"81065430","title":"Das Pubertier","image":"https://occ-0-2773-2774.1.nflxso.net/dnm/api/v6/evlCitJPPCVCry0BZlEFb5-QjKc/AAAABY5cIMjRrUi65AGL7TDDr8IXpXsrXiDDqCQSltnBqCOeV1xw6tMjGft0sEKm7odSQD5J-lkQbBwQqIx39EajDXnTLg.jpg?r=662","synopsis":"A warm, fun-loving family is thrown into hilariously unexpected melodrama as their tweenaged daughter Carla enters angst-filled adolescence.<br><b>Expires on 2021-04-18</b>","rating":"5.2","type":"series","released":"2017","runtime":"","largeimage":"https://occ-0-2773-1490.1.nflxso.net/dnm/api/v6/evlCitJPPCVCry0BZlEFb5-QjKc/AAAABUxMuuWfHv0veLwmszVuswlKiMvzjldEZzl5G7GvKN1j4l3gFaVNpzj79p0Oqy3AKu95bIh81AO8Bwus3hBe3tBlaq7M.jpg?r=662","unogsdate":"2021-04-18","imdbid":"tt6756454","download":"0"},{"netflixid":"80178897","title":"The Story of God with Morgan Freeman","image":"https://occ-0-2851-38.1.nflxso.net/dnm/api/v6/evlCitJPPCVCry0BZlEFb5-QjKc/AAAABQ2EnTI7evNfMfxY4fRv_uu9lcIaTL3kWGfeVgI25Ny371u_HzYRMt78vltXRsrKLOH1FBsRSRzOKyBBP9qRmrZ1MlKNP34zytolAWwWsWgjSTWr--ucrEOcg9gOCY2r.jpg?r=ed2","synopsis":"Host Morgan Freeman explores religion&#39;s role in human history, how our beliefs connect us and possible answers to life&#39;s million-dollar questions.<br><b>Expires on 2021-04-21</b>","rating":"7.9","type":"series","released":"2016","runtime":"","largeimage":"https://occ-0-2218-2219.1.nflxso.net/dnm/api/v6/evlCitJPPCVCry0BZlEFb5-QjKc/AAAABWQvhWHHUyqcsXSUm3CGCLWq5Du61N8nUA_po43CMfLRzQWuVL1JsGYoT7Bk183UVlGX198mn5J5-F7IiUBRM9Fn890u.jpg?r=85d","unogsdate":"2021-04-21","imdbid":"tt5242220","download":"0"},{"netflixid":"81065385","title":"Tannbach - Schicksal eines Dorfes","image":"https://occ-0-2773-2774.1.nflxso.net/dnm/api/v6/evlCitJPPCVCry0BZlEFb5-QjKc/AAAABY98FdZ2z_RatxbT1h1tFbsqC02F7qJlivG7AFDOnOV06hKnxeV1TTk8Rzd4Kn8Xgd7Hoc6tQa73omgAoKvU7oiSBw.jpg?r=069","synopsis":"Torn apart by political loyalties, three families -- a mix of patriots and rebels -- dwell in a village divided by the Iron Curtain after WWII.<br><b>Expires on 2021-04-25</b>","rating":"7.2","type":"series","released":"2018","runtime":"","largeimage":"https://occ-0-2773-1490.1.nflxso.net/dnm/api/v6/evlCitJPPCVCry0BZlEFb5-QjKc/AAAABXKuHeC0acVsJscKuUGyx0EJRDLALOX4XxzaRGm2Ku5PvoZPGrrFp7YptLYC0AIy8C63xyQFzORNnd5pPsIOwC6n_WlB.jpg?r=832","unogsdate":"2021-04-25","imdbid":"tt3658364","download":"0"},{"netflixid":"80227186","title":"Simon","image":"https://occ-0-2851-38.1.nflxso.net/dnm/api/v6/evlCitJPPCVCry0BZlEFb5-QjKc/AAAABWT9QRFqD3RGP4LIEogGgzvSmHdE1pv9ZWdon7PqG-Nmj5rlTTYQAi9lGpznPfqmDJuUZC-JFDnQK08TpkVkea5EDg.jpg?r=e7b","synopsis":"With his vivid imagination, Simon the rabbit searches for fun while learning about the importance of responsibility and communication.<br><b>Expires on 2021-04-30</b>","rating":"4.6","type":"series","released":"2016","runtime":"","largeimage":"https://occ-0-2773-2774.1.nflxso.net/dnm/api/v6/evlCitJPPCVCry0BZlEFb5-QjKc/AAAABXm0tDxopUyVj8OxjaJwJ4nW0IA83r16FemGH1MIFdxc1TBQnh1p4kmJUDCE4Unkt6tEuqrzd6JcMUtOfzi3zFny8x41.jpg?r=e7b","unogsdate":"2021-04-30","imdbid":"tt3283708","download":"0"},{"netflixid":"70285309","title":"Laura&#39;s Ster","image":"https://occ-0-2773-2774.1.nflxso.net/dnm/api/v6/evlCitJPPCVCry0BZlEFb5-QjKc/AAAABTE3nVMZ4kbVcqGsC60YSIoyzfuG6oEuKuA71-xdPIXRSeiEg3wpydz1OlHBZxewup6w4XsUuo1vca0l8sgpP0biHg.jpg?r=80e","synopsis":"Laura is a 7-year-old girl who moves to the city. During her first night in the new house, she captures a falling star and brings it home.<br><b>Expires on 2021-04-30</b>","rating":"6.1","type":"series","released":"2002","runtime":"","largeimage":"https://occ-0-2773-1490.1.nflxso.net/dnm/api/v6/evlCitJPPCVCry0BZlEFb5-QjKc/AAAABZairBsNH5a6cgfllPW0acFdweHQkn6FX95sqdK9ANle03X3LkqrwWDmRbLA5-2Q2zwF2L3x37K_wFfTH66MzRX4tOBu.jpg?r=80e","unogsdate":"2021-04-30","imdbid":"tt0416908","download":"1"},{"netflixid":"70308733","title":"Wolfblood","image":"https://occ-0-2851-38.1.nflxso.net/dnm/api/v6/evlCitJPPCVCry0BZlEFb5-QjKc/AAAABVub6S19MDLRkZMNjl2x-tMVxfGaTSRmDy0Jrwf-guDGNqBjNnPTu8QKKO4rkk6hWEIGCmSb5VtzTdIJSnBlZeubHg.jpg?r=409","synopsis":"This supernatural drama series follows a teenage girl who has the powers of a werewolf: heightened senses and super strength and speed.<br><b>Expires on 2021-04-30</b>","rating":"7.7","type":"series","released":"2012","runtime":"","largeimage":"https://occ-0-58-64.1.nflxso.net/dnm/api/v6/evlCitJPPCVCry0BZlEFb5-QjKc/AAAABVyHBZeeMmQcc1cS-3v1UeMXlKkz7EUufcPRunrGKsK_ehkKD4V1oPZLGT1KujLDwd2BVGktxWD1ihWfdXPKE039uYhP.jpg?r=409","unogsdate":"2021-04-30","imdbid":"tt2321596","download":"1"},{"netflixid":"80165033","title":"Wendy","image":"http://occ-0-2773-2774.1.nflxso.net/dnm/api/v6/evlCitJPPCVCry0BZlEFb5-QjKc/AAAABf7XtMdPPo90CFamuev470t3S9RPTyLG5sEgYUuSjmQ-zC58W_nieDp2W6RA-TQHG2yVFs2INpL0HOXqYQwB5t8Sqw.jpg?r=218","synopsis":"Teenage Wendy seeks a balance between her love of riding horses and the sometimes confusing life and dramas of a 15-year-old girl.<br><b>Expires on 2021-04-30</b>","rating":"6.9","type":"series","released":"2013","runtime":"","largeimage":"https://occ-0-2773-1490.1.nflxso.net/dnm/api/v6/evlCitJPPCVCry0BZlEFb5-QjKc/AAAABQiOfTBVMhhrLY8iGNj7Pou4Z-Zy3FjrxECgVIHF0qXsW8wsiKUA0qyB2c2qESxbCjtK1tUYTWDPCxOIBDJA_7TDU-c7.jpg?r=218","unogsdate":"2021-04-30","imdbid":"tt2094693","download":"0"},{"netflixid":"80159732","title":"Japanese Style Originator","image":"https://occ-0-2851-38.1.nflxso.net/dnm/api/v6/evlCitJPPCVCry0BZlEFb5-QjKc/AAAABV7EpsrBLm4iSj5NdgQvka93tDgf76X-PRnjL1qcIkMdQUMqLai5gQ7Uwt0GL9fsF-nKYdXt8hztOb7D-sh4gN1WJw.jpg?r=539","synopsis":"Find out everything there is to know about Japanese tradition, from food to culture to objects and arts, and the people who are continuing it today.<br><b>Expires on 2021-05-01</b>","rating":"8.1","type":"series","released":"2008","runtime":"","largeimage":"https://occ-0-2705-2706.1.nflxso.net/dnm/api/v6/evlCitJPPCVCry0BZlEFb5-QjKc/AAAABa290JWWoR_aJCARgKXMQqOnP94XAAGCZP-J1gOewJyVv0oYJI02Iak10BYwT0kSac6kFnmIlvINcfl9I_XiO9_Wq6KV.jpg?r=539","unogsdate":"2021-05-01","imdbid":"tt6937876","download":"0"}]}
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
