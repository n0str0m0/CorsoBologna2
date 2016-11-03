using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corso.Bologna.Models
{
    public enum StepType
    {
        Text = 1,
        Image = 2
    }
    public class Step
    {
        public int Index { get; set; }
        public string Value { get; set; }
        public StepType Type { get; set; }
        public string UriValue
        {
            get
            {
                if (Type == StepType.Image)

                    return string.Format("http://www.forchettina.it{0}", Value);
                return Value;
            }
        }
    }
}
