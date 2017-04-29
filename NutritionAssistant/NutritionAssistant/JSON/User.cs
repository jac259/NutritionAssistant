using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionAssistant.JSON
{
    public class User
    {
        [Newtonsoft.Json.JsonConstructor]
        public User(int _id, string _name, double _weight, double _height, int _age, string _sex, string _activity, int _daily_cal, bool _manual_cal, UserForm.WeightChange _wgtchg)
        {
            id = _id;
            name = _name;
            weight_kg = _weight;
            height_m = _height;
            age = _age;
            sex = _sex;
            activity = _activity;
            daily_cal = _daily_cal;
            eaten_cal = 0;
            logged_in = false;
            manual_cal = _manual_cal;
            wgtchg = _wgtchg;
            food_eaten = new List<Food>();
            archived_eaten = new Queue<List<Food>>();
        }

        public User(int _id, string _name, double _weight, double _height, int _age, string _sex, string _activity, bool _manual_cal, UserForm.WeightChange _wgtchg)
        {
            id = _id;
            name = _name;
            weight_kg = _weight;
            height_m = _height;
            age = _age;
            sex = _sex;
            activity = _activity;
            daily_cal = BMI();
            eaten_cal = 0;
            logged_in = false;
            manual_cal = _manual_cal;
            wgtchg = _wgtchg;
            food_eaten = new List<Food>();
            archived_eaten = new Queue<List<Food>>();
        }

        public static Dictionary<string, double> HBF = new Dictionary<string, double>() {
            { "Sedentary", 1.2 },
            { "Lightly Active", 1.375 },
            { "Moderately Active", 1.55 },
            { "Very Active", 1.725 },
            { "Extra Active", 1.9 }
        };

        public int id { get; set; }
        public string name { get; set; }
        public double weight_kg { get; set; }
        public double height_m { get; set; }        
        public int age { get; set; }
        public string sex { get; set; }
        public string activity { get; set; }
        public int daily_cal { get; set; }
        public int eaten_cal { get; set; }
        public bool logged_in { get; set; }
        public bool manual_cal { get; set; }
        public UserForm.WeightChange wgtchg { get; set; }
        public List<Food> food_eaten { get; set; }
        public Queue<List<Food>> archived_eaten { get; set; }

        public int BMI()
        {
            double BMR = -1;
            if (sex.ToLower() == "male")
                BMR = (66 + 13.7 * weight_kg + 500 * height_m - 6.8 * age);
            else if (sex.ToLower() == "female")
                BMR = (655 + 9.6 * weight_kg + 180 * height_m - 4.7 * age);

            return (int)(BMR * HBF[activity]);
        }

        public int CalRemain()
        {
            return daily_cal - eaten_cal;
        }

        public User SetLogin(bool login)
        {
            logged_in = login;
            return this;
        }

        public void Archive(List<Food> eaten)
        {
            if (archived_eaten.Count == 30)
                archived_eaten.Dequeue();

            archived_eaten.Enqueue(eaten);
        }

        public void AddFood(Food food)
        {
            food_eaten.Add(food);
        }

        public int EatenCal()
        {
            int cal = 0;
            for(int i = 0; i < food_eaten.Count; ++i)
            {
                cal += (int)(double.Parse(food_eaten[i].nf_calories) * food_eaten[i].servings);
            }
            return cal;
        }

        public int SugarLeft()
        {
            int max = sex.ToLower() == "female" ? 25 : 36; // 25 grams for women, 36 grams for men per day
            int eaten = 0;
            int temp = 0;
            for (int i = 0; i < food_eaten.Count(); i++)
                eaten += (int.TryParse(food_eaten[i].nf_sugars, out temp) ? temp : 0);
            return Math.Max(max - eaten, 0);
        }

        public int CholesterolLeft()
        {
            int max = 300; // 300 mg per day
            int eaten = 0;
            int temp = 0;
            for (int i = 0; i < food_eaten.Count(); i++)
                eaten += (int.TryParse(food_eaten[i].nf_cholesterol, out temp) ? temp : 0);
            return Math.Max(max - eaten, 0);
        }

        public int SodiumLeft()
        {
            int max = 2400; // 1500 mg per day
            int eaten = 0;
            int temp = 0;
            for (int i = 0; i < food_eaten.Count(); i++)
                eaten += (int.TryParse(food_eaten[i].nf_sodium, out temp) ? temp : 0);
            return Math.Max(max - eaten, 0);
        }

        public int TotalFatLeft()
        {
            int max = 65; // 65 g per day
            int eaten = 0;
            int temp = 0;
            for (int i = 0; i < food_eaten.Count(); i++)
                eaten += (int.TryParse(food_eaten[i].nf_sodium, out temp) ? temp : 0);
            return Math.Max(max - eaten, 0);
        }
    }
}