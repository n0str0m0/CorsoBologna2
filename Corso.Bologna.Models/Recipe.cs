using System;

namespace Corso.Bologna.Models
{
    public class Recipe
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string PicturePath { get; set; }
        public string Level { get; set; }
        public DateTime PubDate { get; set; }
        public string People { get; set; }

    }
}
