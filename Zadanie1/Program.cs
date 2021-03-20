using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1
{
    public class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Podaj liczbę przedmiotów: ");
            int t1 = int.Parse(Console.ReadLine());

            Console.WriteLine("Podaj dopuszczalną wagę plecaka: ");
            int t2 = int.Parse(Console.ReadLine());

            Backpack BP = new Backpack(t1, t2);

            BP.init();
            BP.print_init();
            BP.sort();
            BP.put_in();
            BP.print_equipment();

            Console.Read();
        }
    }
}