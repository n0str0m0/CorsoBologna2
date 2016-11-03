using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corso.Bologna.Models
{
    public class Ingredient
    {
        public string Name { get; set; }
        public string Note { get; set; }
        public string Parent { get; set; }
        public string Quantity { get; set; }
        public string Tag { get; set; }
        public string AggregatedName
        {
            get
            {
                return string.Format("{0} {1}", Quantity, Name);
            }
        }
    }
}
