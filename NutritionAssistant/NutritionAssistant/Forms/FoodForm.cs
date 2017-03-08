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

        public FoodForm(Food _food, MainForm _calledBy)
        {
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;

            InitializeComponent();

            calledBy = _calledBy;
            food = _food;
            PopulateFields();
        }

        public void PopulateFields()
        {
            lblName.Text = food.item_name;
            SetServingSize(food.nf_serving_size_qty, food.nf_serving_size_unit);
            SetNutrition(food);
        }

        public void SetServingSize(string qty, string units)
        {
            lblSize.Text = qty + " " + units;
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

            if (!b)
                MessageBox.Show("Please enter a valid number of servings.", "Invalid serving", MessageBoxButtons.OK);

            return b;
        }

        private List<User> GetAllUsers()
        {
            return UserForm.ReadJSON(UserForm.GetFilepath());
        }

        private void UpdateUser()
        {
            if (!DataValidation())
                return;

            food.servings = ParseDbl(txtServings.Text);

            List<User> users = GetAllUsers();
            User user = users.Find(x => x.id == calledBy.currentUser.id);
            int i = users.IndexOf(user);

            if (user.food_eaten == null)
                user.food_eaten = new List<Food>();
            user.food_eaten.Add(food);
            user.eaten_cal += (int)(ParseDbl(food.nf_calories) * ParseDbl(txtServings.Text));

            users[i] = user;
            UserForm.WriteJSON(users, UserForm.GetFilepath());

            calledBy.currentUser = user;
            calledBy.SetCalories();
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
            UpdateUser();
            this.Close();
        }
    }
}
