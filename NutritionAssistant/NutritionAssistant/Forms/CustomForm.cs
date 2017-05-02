using NutritionAssistant.Controls;
using NutritionAssistant.JSON;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NutritionAssistant.Forms
{
    public partial class CustomForm : Form
    {
        MainForm calledBy;
        NutritionAddControl[] nutrFacts;
        TextBox[] optionals;
        bool edit = false;
        Food editFood;
        public static string foodFile = "CustomFood.json";

        public CustomForm(MainForm _calledBy)
        {
            calledBy = _calledBy;
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;

            InitializeComponent();
            this.Icon = NutritionAssistant.Properties.Resources.Nutrition_Assistant;

            SetupControls();
        }

        public CustomForm(MainForm _calledBy, Food food)
        {
            calledBy = _calledBy;
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;

            InitializeComponent();
            this.Icon = NutritionAssistant.Properties.Resources.Nutrition_Assistant;

            edit = true;
            editFood = food;
            btnAdd.Text = "Save";

            SetupControls(food);
        }

        public void SetupControls(Food food)
        {
            flpNutrition.Controls.Clear();

            txtName.Text = food.item_name;
            txtBrand.Text = food.brand_name;
            txtServingQty.Text = food.nf_serving_size_qty;
            txtServingUnit.Text = food.nf_serving_size_unit;
            txtCalories.Text = food.nf_calories;

            nutrFacts = new NutritionAddControl[]
            {
                new NutritionAddControl("Calories from fat", "", food.nf_calories_from_fat),
                new NutritionAddControl("Total fat", "g", food.nf_total_fat),
                new NutritionAddControl("Saturated fat", "g", food.nf_saturated_fat),
                new NutritionAddControl("Cholesterol", "mg", food.nf_cholesterol),
                new NutritionAddControl("Sodium", "mg", food.nf_sodium),
                new NutritionAddControl("Total carbs", "g", food.nf_total_carbohydrate),
                new NutritionAddControl("Fiber", "g", food.nf_dietary_fiber),
                new NutritionAddControl("Sugar", "g", food.nf_sugars),
                new NutritionAddControl("Protein", "g", food.nf_protein),
                new NutritionAddControl("Vitamin A", "%", food.nf_vitamin_a_dv),
                new NutritionAddControl("Vitamin C", "%", food.nf_vitamin_c_dv),
                new NutritionAddControl("Calcium", "%", food.nf_calcium_dv),
                new NutritionAddControl("Iron", "%", food.nf_iron_dv),
                new NutritionAddControl("Potassium", "mg", food.nf_potassium)
            };

            flpNutrition.Controls.AddRange(nutrFacts);

            optionals = new TextBox[flpNutrition.Controls.Count];
            for (int i = 0; i < flpNutrition.Controls.Count; i++)
                optionals[i] = nutrFacts[i].Controls.OfType<TextBox>().First();
        }

        public void SetupControls()
        {
            flpNutrition.Controls.Clear();

            nutrFacts = new NutritionAddControl[]
            {
                new NutritionAddControl("Calories from fat", ""),
                new NutritionAddControl("Total fat", "g"),
                new NutritionAddControl("Saturated fat", "g"),
                new NutritionAddControl("Cholesterol", "mg"),
                new NutritionAddControl("Sodium", "mg"),
                new NutritionAddControl("Total carbs", "g"),
                new NutritionAddControl("Fiber", "g"),
                new NutritionAddControl("Sugar", "g"),
                new NutritionAddControl("Protein", "g"),
                new NutritionAddControl("Vitamin A", "%"),
                new NutritionAddControl("Vitamin C", "%"),
                new NutritionAddControl("Calcium", "%"),
                new NutritionAddControl("Iron", "%"),
                new NutritionAddControl("Potassium", "mg")
            };

            flpNutrition.Controls.AddRange(nutrFacts);

            optionals = new TextBox[flpNutrition.Controls.Count];
            for (int i = 0; i < flpNutrition.Controls.Count; i++)
                optionals[i] = nutrFacts[i].Controls.OfType<TextBox>().First();
        }

        private bool DataValidation()
        {
            string message = "";
            double d;
            string optionalText;
            
            // Food name
            if (string.IsNullOrWhiteSpace(txtName.Text))
                message += "Please enter a name for this food.";

            // Brand name
            if (string.IsNullOrWhiteSpace(txtBrand.Text))
                message += (string.IsNullOrWhiteSpace(message) ? "" : "\n") + "Please enter a brand name.";

            // Serving quantity
            if (string.IsNullOrWhiteSpace(txtServingQty.Text) || !double.TryParse(txtServingQty.Text, out d))
                message += (string.IsNullOrWhiteSpace(message) ? "" : "\n") + "Please enter a valid serving quantity.";

            // Serving unit
            if (string.IsNullOrWhiteSpace(txtServingUnit.Text))
                message += (string.IsNullOrWhiteSpace(message) ? "" : "\n") + "Please enter a unit for servings.";

            // Calories
            if (string.IsNullOrWhiteSpace(txtCalories.Text) || !double.TryParse(txtCalories.Text, out d))
                message += (string.IsNullOrWhiteSpace(message) ? "" : "\n") + "Please enter a valid number of calories.";

            // Optionals
            // Calories from fat
            optionalText = (from t in optionals where t.Name == "txtCaloriesfromfat" select t).First().Text;
            if (!string.IsNullOrWhiteSpace(optionalText) && !double.TryParse(optionalText, out d))
                message += (string.IsNullOrWhiteSpace(message) ? "" : "\n") + "Please enter a valid number of calories from fat.";

            // Total Fat
            optionalText = (from t in optionals where t.Name == "txtTotalfat" select t).First().Text;
            if (!string.IsNullOrWhiteSpace(optionalText) && !double.TryParse(optionalText, out d))
                message += (string.IsNullOrWhiteSpace(message) ? "" : "\n") + "Please enter a valid number of grams of fat.";

            // Saturated Fat
            optionalText = (from t in optionals where t.Name == "txtSaturatedfat" select t).First().Text;
            if (!string.IsNullOrWhiteSpace(optionalText) && !double.TryParse(optionalText, out d))
                message += (string.IsNullOrWhiteSpace(message) ? "" : "\n") + "Please enter a valid number of grams of saturated fat.";

            // Cholesterol
            optionalText = (from t in optionals where t.Name == "txtCholesterol" select t).First().Text;
            if (!string.IsNullOrWhiteSpace(optionalText) && !double.TryParse(optionalText, out d))
                message += (string.IsNullOrWhiteSpace(message) ? "" : "\n") + "Please enter a valid number of milligrams of cholesterol.";

            // Sodium
            optionalText = (from t in optionals where t.Name == "txtSodium" select t).First().Text;
            if (!string.IsNullOrWhiteSpace(optionalText) && !double.TryParse(optionalText, out d))
                message += (string.IsNullOrWhiteSpace(message) ? "" : "\n") + "Please enter a valid number of milligrams of sodium.";

            // Total carbs
            optionalText = (from t in optionals where t.Name == "txtTotalcarbs" select t).First().Text;
            if (!string.IsNullOrWhiteSpace(optionalText) && !double.TryParse(optionalText, out d))
                message += (string.IsNullOrWhiteSpace(message) ? "" : "\n") + "Please enter a valid number of grams of carbs.";

            // Fiber
            optionalText = (from t in optionals where t.Name == "txtFiber" select t).First().Text;
            if (!string.IsNullOrWhiteSpace(optionalText) && !double.TryParse(optionalText, out d))
                message += (string.IsNullOrWhiteSpace(message) ? "" : "\n") + "Please enter a valid number of grams of fiber.";

            // Sugar
            optionalText = (from t in optionals where t.Name == "txtSugar" select t).First().Text;
            if (!string.IsNullOrWhiteSpace(optionalText) && !double.TryParse(optionalText, out d))
                message += (string.IsNullOrWhiteSpace(message) ? "" : "\n") + "Please enter a valid number of grams of sugar.";

            // Protein
            optionalText = (from t in optionals where t.Name == "txtProtein" select t).First().Text;
            if (!string.IsNullOrWhiteSpace(optionalText) && !double.TryParse(optionalText, out d))
                message += (string.IsNullOrWhiteSpace(message) ? "" : "\n") + "Please enter a valid number of grams of protein.";

            // Vitamin A
            optionalText = (from t in optionals where t.Name == "txtVitaminA" select t).First().Text;
            if (!string.IsNullOrWhiteSpace(optionalText) && !double.TryParse(optionalText, out d))
                message += (string.IsNullOrWhiteSpace(message) ? "" : "\n") + "Please enter a valid percentage of vitamin A.";

            // Vitamin C
            optionalText = (from t in optionals where t.Name == "txtVitaminC" select t).First().Text;
            if (!string.IsNullOrWhiteSpace(optionalText) && !double.TryParse(optionalText, out d))
                message += (string.IsNullOrWhiteSpace(message) ? "" : "\n") + "Please enter a valid percentage of vitamin C.";

            // Calcium
            optionalText = (from t in optionals where t.Name == "txtCalcium" select t).First().Text;
            if (!string.IsNullOrWhiteSpace(optionalText) && !double.TryParse(optionalText, out d))
                message += (string.IsNullOrWhiteSpace(message) ? "" : "\n") + "Please enter a valid percentage of calcium.";

            // Iron
            optionalText = (from t in optionals where t.Name == "txtIron" select t).First().Text;
            if (!string.IsNullOrWhiteSpace(optionalText) && !double.TryParse(optionalText, out d))
                message += (string.IsNullOrWhiteSpace(message) ? "" : "\n") + "Please enter a valid percentage of iron.";

            // Potassium
            optionalText = (from t in optionals where t.Name == "txtPotassium" select t).First().Text;
            if (!string.IsNullOrWhiteSpace(optionalText) && !double.TryParse(optionalText, out d))
                message += (string.IsNullOrWhiteSpace(message) ? "" : "\n") + "Please enter a valid number of milligrams of potassium.";

            if (!string.IsNullOrWhiteSpace(message))
                MessageBox.Show(message, "Invalid input", MessageBoxButtons.OK);

            return string.IsNullOrWhiteSpace(message);
        }

        private Food BuildFood()
        {
            Food customFood = new Food();


            // Required
            customFood.item_name = txtName.Text;
            customFood.brand_name = txtBrand.Text;
            customFood.nf_serving_size_qty = txtServingQty.Text;
            customFood.nf_serving_size_unit = txtServingUnit.Text;
            customFood.nf_calories = txtCalories.Text;

            // Optional
            customFood.nf_calories_from_fat = (from t in optionals where t.Name == "txtCaloriesfromfat" select t).First().Text;
            customFood.nf_total_fat = (from t in optionals where t.Name == "txtTotalfat" select t).First().Text;
            customFood.nf_saturated_fat = (from t in optionals where t.Name == "txtSaturatedfat" select t).First().Text;
            customFood.nf_cholesterol = (from t in optionals where t.Name == "txtCholesterol" select t).First().Text;
            customFood.nf_sodium = (from t in optionals where t.Name == "txtSodium" select t).First().Text;
            customFood.nf_total_carbohydrate = (from t in optionals where t.Name == "txtTotalcarbs" select t).First().Text;
            customFood.nf_dietary_fiber = (from t in optionals where t.Name == "txtFiber" select t).First().Text;
            customFood.nf_sugars = (from t in optionals where t.Name == "txtSugar" select t).First().Text;
            customFood.nf_protein = (from t in optionals where t.Name == "txtProtein" select t).First().Text;
            customFood.nf_vitamin_a_dv = (from t in optionals where t.Name == "txtVitaminA" select t).First().Text;
            customFood.nf_vitamin_c_dv = (from t in optionals where t.Name == "txtVitaminC" select t).First().Text;
            customFood.nf_calcium_dv = (from t in optionals where t.Name == "txtCalcium" select t).First().Text;
            customFood.nf_iron_dv = (from t in optionals where t.Name == "txtIron" select t).First().Text;
            customFood.nf_potassium = (from t in optionals where t.Name == "txtPotassium" select t).First().Text;

            // Set ID
            string fp = JsonFunctions.GetFilepath(foodFile);
            List<Food> customFoods = GetCustomFood(fp);
            if (edit)
            {
                customFood.item_id = editFood.item_id;
                int i = customFoods.FindIndex(x => x.item_id == editFood.item_id);
                customFoods[i] = customFood;
            }
            else
            {
                if (customFoods.Count == 0)
                    customFood.item_id = "-2";
                else
                {
                    int min = -2;
                    for (int i = 0; i < customFoods.Count; i++)
                        min = Math.Min(min, ParseInt(customFoods[i].item_id));
                    customFood.item_id = (min - 1).ToString();
                }
                customFoods.Add(customFood);
            }

            JsonFunctions.WriteJSON(customFoods, fp);
            return customFood;
        }

        private List<User> GetAllUsers()
        {
            return JsonFunctions.ReadUserJSON(JsonFunctions.GetFilepath(UserForm.filename));
        }

        public static List<Food> GetCustomFood(string filepath)
        {
            if (!File.Exists(filepath))
            {
                List<Food> newFoods = new List<Food>();
                JsonFunctions.WriteJSON(newFoods, filepath);
                return newFoods;
            }

            return JsonFunctions.ReadFoodJSON(filepath);
        }

        public static void RemoveCustomFood(string filepath, Food food)
        {
            if (!File.Exists(filepath))
                return;

            List<Food> customFoods = GetCustomFood(filepath);
            customFoods.Remove(customFoods.Find(x => x.item_id == food.item_id));
            JsonFunctions.WriteJSON(customFoods, filepath);
        }

        double ParseDbl(string s)
        {
            double output;
            return double.TryParse(s, out output) ? output : 0;
        }

        int ParseInt(string s)
        {
            int output;
            return int.TryParse(s, out output) ? output : 0;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //UpdateUser();
            if (!DataValidation())
                return;


            List<User> users = GetAllUsers();
            User user = users.Find(x => x.id == calledBy.currentUser.id);
            int i = users.IndexOf(user);
            Food food = BuildFood();

            int foodIndex = user.food_eaten.IndexOf(user.food_eaten.Find(x => x.item_id == food.item_id));

            if (!edit)
                if (foodIndex != -1)
                {
                    food.servings = 1 + user.food_eaten[foodIndex].servings;
                    user.food_eaten[foodIndex] = food;
                }
                else
                {
                    food.servings = 1;
                    user.food_eaten.Add(food);
                }
            else
            {
                user.food_eaten[foodIndex] = food;
            }

            user.eaten_cal = user.EatenCal();

            users[i] = user;
            JsonFunctions.WriteJSON(users, JsonFunctions.GetFilepath(UserForm.filename));

            calledBy.currentUser = user;
            calledBy.SetCalories();

            this.Close();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
