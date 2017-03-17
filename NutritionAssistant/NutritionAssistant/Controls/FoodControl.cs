using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NutritionAssistant.JSON;
using NutritionAssistant.Forms;

namespace NutritionAssistant.Controls
{
    public partial class FoodControl : UserControl
    {
        Food food;
        MainForm parent;
        bool edit;

        public FoodControl(Food _food, MainForm _parent, bool _edit)
        {
            InitializeComponent();

            parent = _parent;
            edit = _edit;
            food = _food;

            lblName.Text = _food.item_name + ((_food.servings != 1) ? " (" + _food.servings.ToString() + ")" : "");
            lblInfo.Text = _food.brand_name + ", " + _food.nf_serving_size_qty + " " + _food.nf_serving_size_unit;
            lblCalories.Text = ((int)(double.Parse(_food.nf_calories) * (_food.servings != 0 ? _food.servings : 1.0))).ToString();
        }

        public void FoodControl_Click(object sender, EventArgs e)
        {
            FoodForm foodForm = new FoodForm(food, parent, edit);
            foodForm.Show();
        }

        private void FoodControl_Click(object sender, MouseEventArgs e)
        {
            FoodForm foodForm = new FoodForm(food, parent, edit);
            foodForm.Show();
        }
    }
}
