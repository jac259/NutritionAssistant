using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionAssistant.JSON
{
    public class RootObject
    {
        public int total { get; set; }
        public double max_score { get; set; }
        public List<Hit> hits { get; set; }

        public string Print()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(string.Format("Total hits: {0}\n", total.ToString()));
            //sb.Append(string.Format("Max score: {0}\n", max_score.ToString()));
            //sb.Append(string.Format("Hits: {0}\n", hits.Count));

            for (int i = 0; i < hits.Count; i++)
            {
                //sb.Append(hits[i].Print());
                //sb.Append(string.Format("  Index: {0}\n", hits[i]._index));
                //sb.Append(string.Format("  Type: {0}\n", hits[i]._type));
                //sb.Append(string.Format("  ID: {0}\n", hits[i]._id));
                //sb.Append(string.Format("  Score: {0}\n", hits[i]._score.ToString()));
                sb.Append(string.Format("Name: {0}\n", hits[i].fields.item_name));
                sb.Append(string.Format("Brand: {0}\n", hits[i].fields.brand_name));
                sb.Append(string.Format("Calories: {0}\n", hits[i].fields.nf_calories));
                sb.Append(string.Format("Total Fat (g): {0}\n", hits[i].fields.nf_total_fat));
                sb.Append(string.Format("Sodium (mg): {0}\n", hits[i].fields.nf_sodium));
                sb.Append(string.Format("Sugars (g): {0}\n", hits[i].fields.nf_sugars));
                sb.Append(string.Format("Protein (g): {0}\n", hits[i].fields.nf_protein));
                sb.Append("\n");
            }

            return sb.ToString();
        }

        public List<Food> GetFoods()
        {
            List<Food> foods = new List<Food>();

            for(int i = 0; i < hits.Count; i++)
                foods.Add(hits[i].fields);

            return foods;
        }
    }
}
