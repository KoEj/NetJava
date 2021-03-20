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

        private void backpack_sort(object sender, EventArgs e)
        {
            int t1 = int.Parse(textBox1.Text);
            int t2 = int.Parse(textBox2.Text);

            Zadanie1.Backpack BP = new Zadanie1.Backpack(t1, t2);

            BP.init();
            BP.sort();
            BP.put_in();

            for (int i = 0; i < BP.elements_n; i++)
            {
                if (BP.inout[i] == 1)
                {
                    //BP.queue[i] + 1;
                }
            }

            string result = String.Join(",", BP.queue.Select(x => x.ToString()).ToArray());

            label1.Text = ("Wartość przedmiotów: " + BP.bp_value.ToString());
            //label2.Text = ("Kolejność: " + result);
            label2.Text = ("Kolejność: ");
            
            //label2.Text = ("Kolejność: " + BP.bp_value.ToString());
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
            System.Media.SoundPlayer player = new System.Media.SoundPlayer();
            player.SoundLocation = Application.StartupPath + "plecak.wav";
            player.Load();
            player.Play();
        }
    }
}
