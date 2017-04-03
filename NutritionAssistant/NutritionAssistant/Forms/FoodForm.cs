using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NutritionAssistant.JSON;
using NutritionAssistant.Controls;

namespace NutritionAssistant.Forms
{
    public partial class FoodForm : Form
    {
        Food food;
        MainForm calledBy;
        NutritionControl[] nutrFacts;
        bool edit;

        public FoodForm(Food _food, MainForm _calledBy, bool _edit)
        {
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;

            edit = _edit;
            calledBy = _calledBy;
            food = _food;

            InitializeComponent();
            this.Icon = NutritionAssistant.Properties.Resources.Nutrition_Assistant;
            btnAdd.Text = edit ? "Save" : "Add";
            this.Text = edit ? "Edit Food" : "Add Food";

            PopulateFields();
        }

        public void PopulateFields()
        {
            lblName.Text = food.item_name;
            SetServingSize(food.nf_serving_size_qty, food.nf_serving_size_unit);
            SetNutrition(food);
            txtServings.Text = food.servings.ToString();
        }

        public void SetServingSize(string qty, string units)
        {
            string txt = qty + " " + units;
            lblSize.Text = string.IsNullOrWhiteSpace(txt) ? "1 serving" : txt;

            //lblSize.Text = qty + " " + units;
        }

        public void SetNutrition(Food _food)
        {
            double scale = double.Parse(txtServings.Text);
            nutrFacts = new NutritionControl[]
            {
                new NutritionControl("Calories", ParseDbl(_food.nf_calories), scale, ""),
                new NutritionControl("Calories from fat", ParseDbl(_food.nf_calories_from_fat), scale, ""),
                new NutritionControl("Total fat", ParseDbl(_food.nf_total_fat), scale, "g"),
                new NutritionControl("Saturated fat", ParseDbl(_food.nf_saturated_fat), scale, "g"),
                new NutritionControl("Cholesterol", ParseDbl(_food.nf_cholesterol), scale, "mg"),
                new NutritionControl("Sodium", ParseDbl(_food.nf_sodium), scale, "mg"),
                new NutritionControl("Total carbs", ParseDbl(_food.nf_total_carbohydrate), scale, "g"),
                new NutritionControl("Fiber", ParseDbl(_food.nf_dietary_fiber), scale, "g"),
                new NutritionControl("Sugar", ParseDbl(_food.nf_sugars), scale, "g"),
                new NutritionControl("Protein", ParseDbl(_food.nf_protein), scale, "g"),
                new NutritionControl("Vitamin A", ParseDbl(_food.nf_vitamin_a_dv), scale, "%"),
                new NutritionControl("Vitamin C", ParseDbl(_food.nf_vitamin_c_dv), scale, "%"),
                new NutritionControl("Calcium", ParseDbl(_food.nf_calcium_dv), scale, "%"),
                new NutritionControl("Iron", ParseDbl(_food.nf_iron_dv), scale, "%"),
                new NutritionControl("Potassium", ParseDbl(_food.nf_potassium), scale, "mg")
            };

            flpNutrition.Controls.AddRange(nutrFacts);
        }

        double ParseDbl(string s)
        {
            double output;
            return double.TryParse(s, out output) ? output : 0;
        }

        bool DataValidation()
        {
            double d;
            bool b = double.TryParse(txtServings.Text, out d);

            b = b && (d != 0 || edit);

            if (!b)
                MessageBox.Show("Please enter a valid number of servings.", "Invalid serving", MessageBoxButtons.OK);

            return b;
        }

        public static List<User> GetAllUsers()
        {
            return UserForm.ReadUserJSON(UserForm.GetFilepath());
        }

        private void UpdateUser()
        {

            double newServings = ParseDbl(txtServings.Text);

            List<User> users = GetAllUsers();
            User user = users.Find(x => x.id == calledBy.currentUser.id);
            int i = users.IndexOf(user);

            if (user.food_eaten == null)
                user.food_eaten = new List<Food>();

            if (edit)
            {
                double oldServings = food.servings;
                int foodIndex = user.food_eaten.IndexOf(user.food_eaten.Find(x => x.item_id == food.item_id));

                food.servings = newServings;

                if (newServings == 0)
                    user.food_eaten.RemoveAt(foodIndex);
                else
                    user.food_eaten[foodIndex] = food;
            }
            else
            {
                int foodIndex = user.food_eaten.IndexOf(user.food_eaten.Find(x => x.item_id == food.item_id));

                if(foodIndex != -1)
                {
                    food.servings = newServings + user.food_eaten[foodIndex].servings;
                    user.food_eaten[foodIndex] = food;
                }
                else
                {
                    food.servings = newServings;
                    user.food_eaten.Add(food);
                }
            }

            user.eaten_cal = user.EatenCal();

            users[i] = user;
            UserForm.WriteJSON(users, UserForm.GetFilepath());

            calledBy.currentUser = user;
            calledBy.SetCalories();
            if (edit)
                calledBy.PopulateResults(user.food_eaten, true, true);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtServings_TextChanged(object sender, EventArgs e)
        {
            for(int i = 0; i < nutrFacts.Length; i++)
            {
                nutrFacts[i].UpdateValue(ParseDbl(txtServings.Text));
            }
            flpNutrition.Controls.Clear();
            flpNutrition.Controls.AddRange(nutrFacts);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!DataValidation())
                return;

            UpdateUser();
            this.Close();
        }
    }
}
