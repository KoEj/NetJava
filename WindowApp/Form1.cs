using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

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

        private void check(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
            }
            else 
            {
                MessageBox.Show("Brak liczby wygenerowanych przedmiotów!", "Błąd 1", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (textBox2.Text.Length > 0)
            {
            }
            else
            {
                MessageBox.Show("Brak dopuszczalnej wagi plecaka!", "Błąd 2", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (textBox2.Text.Length > 0 && textBox1.Text.Length > 0)
            {
                backpack_sort(sender, e);
            }
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void backpack_sort(object sender, EventArgs e)
        {
            int t1 = int.Parse(textBox1.Text);
            int t2 = int.Parse(textBox2.Text);

            Zadanie1.Backpack BP = new Zadanie1.Backpack(t1, t2);

            BP.init();
            BP.sort();
            BP.put_in();


            string str_tab="";

            for (int i = 0; i < BP.elements_n; i++)
            {
                if (BP.inout[i] == 1)
                {
                    BP.queue[i] = BP.queue[i] + 1;
                    str_tab += BP.queue[i].ToString();
                }
            }
            string result = String.Join(",", str_tab.Select(x => x.ToString()).ToArray());

            label1.Text = ("Wartość przedmiotów: " + BP.bp_value.ToString());
            label2.Text = ("Kolejność: " + result);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            check(sender, e);
            //label2.Text = "wylosowana kolejnosc";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Music_Load(sender, e);
        }

        private void Music_Load(object sender, EventArgs e)
        {
            SoundPlayer audio = new SoundPlayer(WindowApp.Properties.Resources.plecak);
            audio.Play();
        }


    }
}
