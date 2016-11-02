using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Corso.Bologna.Models;
using Xamarin.Forms;

namespace Corso.Bologna.TeplatesSelector
{
    public class StepTypeDataTemplateSelector : DataTemplateSelector
    {
        public  DataTemplate ImageDataTemplate { get; set; }
        public  DataTemplate TextDataTemplae { get; set; }
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            Step step = item as Step;
            if (step.Type == StepType.Image)
            {
                return ImageDataTemplate;
            }
            else
            {
                return TextDataTemplae;
            }

        }
    }
}
