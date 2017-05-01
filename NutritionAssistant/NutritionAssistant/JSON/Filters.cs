using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionAssistant.JSON
{
    public class NfCalories
    {
        public int from { get; set; }
        public int to { get; set; }

        public NfCalories(int calories)
        {
            Random r = new Random();
            from = calories / r.Next(2, 4);
            to = calories;
        }
    }

    public abstract class NfLte
    {
        public int lte { get; set; }
    }

    public class NfSugars : NfLte
    {
        public NfSugars(int sugars)
        {
            lte = sugars;
        }
    }

    public class NfSodium : NfLte
    {
        public NfSodium(int sodium)
        {
            lte = sodium;
        }
    }

    public class NfTotalFat : NfLte
    {
        public NfTotalFat(int fat)
        {
            lte = fat;
        }
    }

    public class NfTotalCarbohydrate : NfLte
    {
        public NfTotalCarbohydrate(int carbs)
        {
            lte = carbs;
        }
    }

    public class NfCholesterol : NfLte
    {
        public NfCholesterol(int cholesterol)
        {
            lte = cholesterol;
        }
    }

    //public class Not
    //{
    //    public int item_type { get; set; }

    //    public Not()
    //    {
    //        item_type = 1;
    //    }
    //}

    public class Filters
    {
        public NfCalories nf_calories { get; set; }
        public NfSugars nf_sugars { get; set; }
        public NfSodium nf_sodium { get; set; }
        public NfTotalFat nf_total_fat { get; set; }
        public NfCholesterol nf_cholesterol { get; set; }
        //public Not not { get; set; }
        public int item_type = 2;

        public Filters(int calories, int sugar, int sodium, int fat, int cholesterol)
        {
            nf_calories = new NfCalories(calories);
            nf_sugars = new NfSugars(sugar);
            nf_sodium = new NfSodium(sodium);
            nf_total_fat = new NfTotalFat(fat);
            nf_cholesterol = new NfCholesterol(cholesterol);
            //not = new Not();
        }
    }
}
