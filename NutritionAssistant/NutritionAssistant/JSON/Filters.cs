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
            to = calories;// / r.Next(1, 2);
        }
    }

    public class NfSugars
    {
        public int lte { get; set; }

        public NfSugars(int sugars)
        {
            lte = sugars;
        }
    }

    public class NfSodium
    {
        public int lte { get; set; }

        public NfSodium(int sodium)
        {
            lte = sodium;
        }
    }

    public class NfTotalFat
    {
        public int lte { get; set; }
        
        public NfTotalFat(int fat)
        {
            lte = fat;
        }
    }

    public class NfTotalCarbohydrate
    {
        public int lte { get; set; }

        public NfTotalCarbohydrate(int carbs)
        {
            lte = carbs;
        }
    }

    public class NfCholesterol
    {
        public int lte { get; set; }

        public NfCholesterol(int cholesterol)
        {
            lte = cholesterol;
        }
    }

    //public class NfProtein
    //{
    //    public int gte { get; set; }
    //}

    //public class NfVitaminA
    //{
    //    public int gte { get; set; }
    //}

    //public class NfVitaminC
    //{
    //    public int gte { get; set; }
    //}

    //public class NfPotassium
    //{
    //    public int gte { get; set; }
    //}

    public class Not
    {
        public int item_type { get; set; }

        public Not()
        {
            item_type = 1;
        }
    }

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
