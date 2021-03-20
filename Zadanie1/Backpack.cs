using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.InteropServices.ComTypes;

namespace Zadanie1 {
    public class Backpack
    {
        int elements_n;
        int backpack_size;
        int bp_value = 0;


        List<int> values = new List<int>();
        List<int> size = new List<int>();
        List<int> ratio = new List<int>();
        List<int> queue = new List<int>();
        List<int> inout = new List<int>();

        public Backpack(int t1, int t2)
        {
            elements_n = t1;
            backpack_size = t2;

        }

        public void init()
        {
            RandomNumberGenerator rng = new RandomNumberGenerator(1);
            // losowanie wartosci
            for (int i = 0; i < elements_n; i++)
                values.Add(rng.nextInt(1, backpack_size * 10));

            // losowanie rozmiarow
            for (int i = 0; i < elements_n; i++)
                size.Add(rng.nextInt(1, backpack_size / 2));

            // liczenie stosunku
            for (int i = 0; i < elements_n; i++)
                ratio.Add(values[i] / size[i]);

            //tworzenie kolejki pakowania
            for (int i = 0; i < elements_n; i++)
                queue.Add(i);

            //zapakowane czy nie
            for (int i = 0; i < elements_n; i++)
                inout.Add(0);

        }
        public void sort()
        {

            for (int i = 1; i < elements_n; ++i)
                for (int j = elements_n - 1; j >= i; j--)
                    if (ratio[j - 1].CompareTo(ratio[j]) > 0)
                    {
                        int temp1 = ratio[j - 1];
                        int temp2 = queue[j - 1];
                        int temp3 = size[j - 1];
                        int temp4 = values[j - 1];
                        ratio[j - 1] = ratio[j];
                        queue[j - 1] = queue[j];
                        size[j - 1] = size[j];
                        values[j - 1] = values[j];

                        ratio[j] = temp1;
                        queue[j] = temp2;
                        size[j] = temp3;
                        values[j] = temp4;
                    }
        }

        public void put_in()
        {
            int loaded_weight = 0;

            for (int i = elements_n - 1; i >= 0; --i)
            {
                if ((loaded_weight + size[i]) <= backpack_size)
                {
                    inout[i] = 1;
                    loaded_weight += size[i];
                    bp_value += values[i];
                }
            }

        }

        public void print_init()
        {
            Console.WriteLine("{0} {1} {2} {3}", "lp", "value", "weight", "ratio");
            for (int i = 0; i < elements_n; i++)
                Console.WriteLine("{0,2} {1,5} {2,4} {3,5}", i + 1, values[i], size[i], ratio[i]);
        }

        public void print_equipment()
        {
            Console.WriteLine("Zapakowane przedmioty o łącznej wartosci " + bp_value + " to: ");

            Console.WriteLine("{0} {1} {2} {3}", "lp", "value", "weight", "ratio");
            for (int i = 0; i < elements_n; i++)
            {
                if (inout[i] == 1)
                    Console.WriteLine("{0,2} {1,5} {2,4} {3,5}", queue[i], values[i], size[i], ratio[i]);
            }
        }
    }


}