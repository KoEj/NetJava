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

            if (textBox2.Text.Length > 0 && textBox1.Text.Length > 0) label1.Text = "Kolejność";
            if (textBox2.Text.Length > 0 && textBox1.Text.Length > 0) backpack_sort(sender, e);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            check_null(sender, e);
            //label2.Text = "wylosowana kolejnosc";
        }

        private void backpack_sort(object sender, EventArgs e)
        {
            int t1 = int.Parse(textBox1.Text);
            int t2 = int.Parse(textBox2.Text);

            Zadanie1.Backpack BP = new Zadanie1.Backpack(t1, t2);

            BP.init();
            BP.sort();
            BP.put_in();

           // label2.Text = BP.bp_value;


            //Console.WriteLine("{0} {1} {2} {3}", "lp", "value", "weight", "ratio");
            //for (int i = 0; i < elements_n; i++)
            //{
            //    if (inout[i] == 1)
            //        Console.WriteLine("{0,2} {1,5} {2,4} {3,5}", queue[i], values[i], size[i], ratio[i]);
            //}
        }


    }
}
