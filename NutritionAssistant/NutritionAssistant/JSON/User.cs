using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionAssistant.JSON
{
    public class User
    {
        public User(int _id, string _name, double _weight, double _height, int _daily_cal)
        {
            id = _id;
            name = _name;
            weight_kg = _weight;
            height_m = _height;
            daily_cal = _daily_cal;
            eaten_cal = 0;
            logged_in = false;
            food_eaten = new List<Food>();
        }

        public int id { get; set; }
        public string name { get; set; }
        public double weight_kg { get; set; }
        public double height_m { get; set; }        
        public int daily_cal { get; set; }
        public int eaten_cal { get; set; }
        public bool logged_in { get; set; }
        public List<Food> food_eaten { get; set; }

        public double BMI()
        {
            return weight_kg / (height_m * height_m);
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

        public void AddFood(Food food)
        {
            food_eaten.Add(food);
        }
    }
}