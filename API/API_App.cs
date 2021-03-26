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
            load();
        }

        private void API_App_Load(object sender, EventArgs e)
        {

        }

        public static async void load()
        {
            HttpClient httpClient = new HttpClient();
            string call = "http:// tu link";

            string json = await httpClient.GetStringAsync(call);
        }

        
    }
}
