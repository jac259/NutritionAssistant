﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web.Script.Serialization;
using NutritionAssistant.JSON;
using NutritionAssistant.Controls;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.IO;
using System.Diagnostics;
using NutritionAssistant.Forms;

namespace NutritionAssistant
{
    public partial class MainForm : Form
    {
        public enum flpItems { Custom, Eaten, Search, None };
        public flpItems flpCurrent = flpItems.None;

        public User currentUser;

        public MainForm()
        {
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;

            InitializeComponent();
            this.Icon = NutritionAssistant.Properties.Resources.Nutrition_Assistant;
            GetCurrentUser();
            SetCalories();
        }

        public void GetCurrentUser()
        {
            List<User> users = GetAllUsers();
            User user = UserForm.GetLoggedIn(users);
            SetCurrentUser(user);
        }

        public void PopulateResults(List<Food> foods, bool edit, bool rightClick)
        {
            flpResults.Controls.Clear();

            for (int i = 0; i < foods.Count; i++)
                flpResults.Controls.Add(new FoodControl(foods[i], this, edit, rightClick));

            lblCalTitle.Visible = foods.Count != 0;
            lblFoodTitle.Visible = foods.Count != 0;
        }

        public void ClearResults()
        {
            flpResults.Controls.Clear();
            txtQuery.Clear();

            lblCalTitle.Visible = false;
            lblFoodTitle.Visible = false;
        }

        public List<Food> GetFoodEaten(User user)
        {
            return user.food_eaten;
        }

        public void SetCurrentUser(User user)
        {
            lblCurrentUser.Text = user.name;
            currentUser = user;
        }

        public void ChangeUser(User user)
        {
            SetCurrentUser(user);
            SetCalories();
        }

        public void SetCalories()
        {
            lblCalories.Text = "Calories consumed: " + currentUser.eaten_cal.ToString() + "  (Max: " + currentUser.daily_cal.ToString() + ")";
            btnEaten.Enabled = currentUser.eaten_cal != 0;
        }

        public List<User> GetAllUsers()
        {
            return UserForm.ReadUserJSON(UserForm.GetFilepath());
        }

        public void ResetUsers()
        {
            List<User> users = GetAllUsers();

            for (int i = 0; i < users.Count; i++)
            {
                User tempUser = users[i];
                tempUser.eaten_cal = 0;

                if (tempUser.food_eaten == null)
                    tempUser.food_eaten = new List<Food>();

                tempUser.food_eaten.Clear();
                
                if (tempUser.id == currentUser.id)
                    currentUser = tempUser;

                users[i] = tempUser;
            }

            UserForm.WriteJSON(users, UserForm.GetFilepath());

            SetCalories();
        }

        private bool CheckHits(string message)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            return true;
        }

        private async void btnQuery_Click(object sender, System.EventArgs e)
        {
            string queryString = txtQuery.Text;

            if (string.IsNullOrEmpty(queryString))
                return;

            ClearResults();

            string message = await Query.query(queryString);

            //JavaScriptSerializer jss = new JavaScriptSerializer();
            //Results ro = jss.Deserialize<Results>(message);

            Results ro = JsonConvert.DeserializeObject<Results>(message);

            if (ro.total == 0)
                MessageBox.Show("No results found for \"" + queryString + "\"", "No results", MessageBoxButtons.OK);
            else
                PopulateResults(ro.GetFoods(), false, false);

            flpCurrent = flpItems.Search;
        }

        private void btnUsers_click(object sender, EventArgs e)
        {
            UserForm form = new UserForm(this);
            form.ShowDialog();
        }

        private void pboAttribution_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.nutritionix.com/api");
        }

        private void txtQuery_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Return)
                btnQuery_Click(sender, new EventArgs());
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetUsers();
            ClearResults();
        }

        private void btnEaten_Click(object sender, EventArgs e)
        {
            if (currentUser.eaten_cal == 0)
                ClearResults();

            PopulateResults(GetFoodEaten(currentUser), true, true);

            txtQuery.Clear();

            flpCurrent = flpItems.Eaten;
        }

        private void btnCustom_Click(object sender, EventArgs e)
        {
            CustomForm form = new CustomForm(this);
            form.ShowDialog();
        }

        private void btnShowCustom_Click(object sender, EventArgs e)
        {
            List<Food> customFood = CustomForm.GetCustomFood(UserForm.GetFilepath(CustomForm.foodFile));
            PopulateResults(customFood, false, true);

            flpCurrent = flpItems.Custom;
        }
    }
}
