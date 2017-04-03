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
        bool rightClick = false;

        public FoodControl(Food _food, MainForm _parent, bool _edit)
        {
            InitializeComponent();

            parent = _parent;
            edit = _edit;
            food = _food;

            string txt = _food.nf_serving_size_qty + " " + _food.nf_serving_size_unit;

            lblName.Text = _food.item_name + ((_food.servings != 1) ? " (" + _food.servings.ToString() + ")" : "");
            lblInfo.Text = _food.brand_name + ", " + (string.IsNullOrWhiteSpace(txt) ? "1 serving" : txt);
            lblCalories.Text = ((int)(double.Parse(_food.nf_calories) * (_food.servings != 0 ? _food.servings : 1.0))).ToString();
        }

        public FoodControl(Food _food, MainForm _parent, bool _edit, bool _rightClick)
        {
            InitializeComponent();

            parent = _parent;
            edit = _edit;
            food = _food;
            rightClick = _rightClick;

            string txt = _food.nf_serving_size_qty + " " + _food.nf_serving_size_unit;

            lblName.Text = _food.item_name + ((_food.servings != 1) ? " (" + _food.servings.ToString() + ")" : "");
            lblInfo.Text = _food.brand_name + ", " + (string.IsNullOrWhiteSpace(txt) ? "1 serving" : txt);
            lblCalories.Text = ((int)(double.Parse(_food.nf_calories) * (_food.servings != 0 ? _food.servings : 1.0))).ToString();
        }

        private void ShowFoodForm()
        {
            FoodForm foodForm = new FoodForm(food, parent, edit);
            foodForm.ShowDialog();
        }

        private void ShowCustomForm()
        {
            CustomForm customForm = new CustomForm(parent, food);
            customForm.ShowDialog();
        }

        public void MenuAdd_Click(object sender, EventArgs e)
        {
            ShowFoodForm();
        }

        public void MenuEdit_Click(object sender, EventArgs e)
        {
            ShowCustomForm();
            string fp = UserForm.GetFilepath(CustomForm.foodFile);
            parent.PopulateResults(CustomForm.GetCustomFood(fp), edit, rightClick);
        }

        public void MenuDelete_Click(object sender, EventArgs e)
        {

            if (parent.flpCurrent == MainForm.flpItems.Custom)
            {
                string fp = UserForm.GetFilepath(CustomForm.foodFile);
                CustomForm.RemoveCustomFood(fp, food);
                parent.PopulateResults(CustomForm.GetCustomFood(fp), edit, rightClick);
            }
            else if (parent.flpCurrent == MainForm.flpItems.Eaten)
            {

                List<User> users = FoodForm.GetAllUsers();
                User user = users.Find(x => x.id == parent.currentUser.id);
                int i = users.IndexOf(user);
                int foodIndex = user.food_eaten.FindIndex(x => x.item_id == food.item_id);
                if (foodIndex != -1)
                {
                    user.food_eaten.RemoveAt(foodIndex);
                    user.eaten_cal = user.EatenCal();

                    users[i] = user;
                    UserForm.WriteJSON(users, UserForm.GetFilepath());

                    parent.currentUser = user;
                    parent.SetCalories();
                    parent.PopulateResults(user.food_eaten, edit, rightClick);
                }

            }
            else if (parent.flpCurrent == MainForm.flpItems.Search)            
                return;
        }

        public void FoodControl_Click(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            if (me.Button == MouseButtons.Right) {
                if (rightClick)
                {
                    ContextMenu cm = new ContextMenu();
                    cm.MenuItems.Add(edit ? "Edit servings" : "Add to eaten", MenuAdd_Click);
                    if (parent.flpCurrent == MainForm.flpItems.Custom)
                        cm.MenuItems.Add("Edit food", MenuEdit_Click);
                    cm.MenuItems.Add(edit ? "Remove" : "Delete", MenuDelete_Click);
                    this.ContextMenu = cm;
                }
            }
            else if (me.Button == MouseButtons.Left) {
                ShowFoodForm();
            }
        }

        private void FoodControl_Click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (rightClick)
                {
                    ContextMenu cm = new ContextMenu();
                    cm.MenuItems.Add(edit ? "Edit servings" : "Add to eaten", MenuAdd_Click);
                    if (parent.flpCurrent == MainForm.flpItems.Custom)
                        cm.MenuItems.Add("Edit food", MenuEdit_Click);
                    cm.MenuItems.Add("Delete", MenuDelete_Click);
                    this.ContextMenu = cm;
                }
            }
            else if (e.Button == MouseButtons.Left)
            {
                ShowFoodForm();
            }
        }
    }
}
