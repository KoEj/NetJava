using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace API
{
    public class Baza
    {
        public string code;
        public string name_PL;
        public string name_EN;

        public Baza(string nazwa_PL)
        {
            name_PL = nazwa_PL;
        }

        public string LoadingStates(string nazwa)
        {
            string line = "";

            using (StreamReader sr = new StreamReader("Baza.txt"))
            {
                 while ((line = sr.ReadLine()) != null)
                 {

                     var read = line.Split("\t");
                     code = read[0];
                     name_PL = read[1];
                    if (nazwa.Equals(name_PL)) return code;
                     name_EN = read[2];
                     //Console.WriteLine(line);

                 }
                 sr.Close();
                return "Brak znalezienia";
            }
        }
    }
}
