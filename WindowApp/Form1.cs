using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label1.Text = "";
            label2.Text = "";
        }

        private void check_null(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                int t1 = int.Parse(textBox1.Text);
            }
            else 
            {
                MessageBox.Show("Brak liczby wygenerowanych przedmiotów!", "Błąd 1", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (textBox2.Text.Length > 0)
            {
                int t2 = int.Parse(textBox2.Text);
            }
            else
            {
                MessageBox.Show("Brak dopuszczalnej wagi plecaka!", "Błąd 2", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (textBox2.Text.Length > 0 && textBox1.Text.Length > 0) label1.Text = "Kolejność";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            check_null(sender, e);
 
            
            //label2.Text="wylosowana kolejnosc"
        }

    }
}
