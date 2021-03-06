using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;

namespace API
{
    public class Movie
    {

        //Opis: " + description[0] + "
        //\nRok premiery: " + read[j + 33] + "\n
        //Data wygasniecia filmu: " + read[j + 45];
        public int Id { set; get; }
        public int netflixID { set; get; }
        public string title { set; get; }
        public string description { set; get; }
        public int premiere { set; get; }
        public string date_exp { set; get; }
        public string csymbol { set; get; }

    }

    public class MOVIE_DataB_Context : DbContext
    {
        public virtual DbSet<Movie> Movies { get; set; }
    }
}

