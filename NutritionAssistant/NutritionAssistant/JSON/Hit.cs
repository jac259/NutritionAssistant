using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionAssistant.JSON
{
    public class Hit
    {
        public string _index { get; set; }
        public string _type { get; set; }
        public string _id { get; set; }
        public double _score { get; set; }
        public Fields fields { get; set; }

        public string Print()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(string.Format("Index: {0}\n", _index));
            sb.Append(string.Format("Type: {0}\n", _type));
            sb.Append(string.Format("ID: {0}\n", _id));
            sb.Append(string.Format("Score: {0}\n", _score.ToString()));
            //sb.Append(string.Format("Fields: {0}\n\t", fields.Print()));
            sb.Append(string.Format("Name: {0}\n", fields.item_name));
            sb.Append(string.Format("Brand: {0}\n", fields.brand_name));

            return sb.ToString();
        }
    }
}
