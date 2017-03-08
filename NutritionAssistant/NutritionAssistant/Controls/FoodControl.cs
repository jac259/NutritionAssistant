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

        public FoodControl(Food _food, MainForm _parent)
        {
            InitializeComponent();

            parent = _parent;

            food = _food;
            lblName.Text = _food.item_name;
            lblInfo.Text = _food.brand_name + ", " + _food.nf_serving_size_qty + " " + _food.nf_serving_size_unit;
            lblCalories.Text = ((int)double.Parse(_food.nf_calories)).ToString();
        }

        public void FoodControl_Click(object sender, EventArgs e)
        {
            FoodForm foodForm = new FoodForm(food, parent);
            foodForm.Show();
        }

        private void FoodControl_Click(object sender, MouseEventArgs e)
        {
            FoodForm foodForm = new FoodForm(food, parent);
            foodForm.Show();
        }
    }
}
