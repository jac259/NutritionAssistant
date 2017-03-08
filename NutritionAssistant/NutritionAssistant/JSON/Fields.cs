using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NutritionAssistant.JSON;

namespace NutritionAssistant
{
    public class Fields : Food
    {
        //public string item_id { get; set; }
        //public string item_name { get; set; }
        //public string brand_name { get; set; }
        //public string nf_calories { get; set; }
        //public string nf_total_fat { get; set; }
        //public string nf_sodium { get; set; }
        //public string nf_sugars { get; set; }
        //public string nf_protein { get; set; }

        public string Print()
        {
            //return new String[3] { item_id, item_name, brand_name };

            StringBuilder sb = new StringBuilder();

            sb.Append(string.Format("Item ID: {0}\n", item_id));
            sb.Append(string.Format("Name: {0}\n", item_name));
            sb.Append(string.Format("Brand: {0}\n", brand_name));

            return sb.ToString();
        }
    }
}
