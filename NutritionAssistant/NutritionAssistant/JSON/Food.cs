using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionAssistant.JSON
{
    public class Food
    {
        public string brand_name { get; set; }
        public string item_name { get; set; }
        public string brand_id { get; set; }
        public string item_id { get; set; }
        public string item_type { get; set; }
        public string item_description { get; set; }
        public string nf_ingredient_statement { get; set; }
        public string nf_calories { get; set; }
        public string nf_calories_from_fat { get; set; }
        public string nf_total_fat { get; set; }
        public string nf_saturated_fat { get; set; }
        public string nf_cholesterol { get; set; }
        public string nf_sodium { get; set; }
        public string nf_total_carbohydrate { get; set; }
        public string nf_dietary_fiber { get; set; }
        public string nf_sugars { get; set; }
        public string nf_protein { get; set; }
        public string nf_vitamin_a_dv { get; set; }
        public string nf_vitamin_c_dv { get; set; }
        public string nf_calcium_dv { get; set; }
        public string nf_iron_dv { get; set; }
        public string nf_potassium { get; set; }
        public string nf_servings_per_container { get; set; }
        public string nf_serving_size_qty { get; set; }
        public string nf_serving_size_unit { get; set; }
    }
}
