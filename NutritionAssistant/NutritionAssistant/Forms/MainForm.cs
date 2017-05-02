using System;
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
        public enum flpItems { Custom, Eaten, Search, NoResults, None };
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
            CheckArchive();
            SetCalories();
            UpdateSourceLabel();
        }

        public void CheckArchive()
        {
            if(Properties.Settings.Default.LastRunTime < DateTime.Today)
            {
                ArchiveUsers();
                ClearResults();
            }
        }

        public void GetCurrentUser()
        {
            List<User> users = GetAllUsers();
            User user = JsonFunctions.GetLoggedIn(users);
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
            lblSource.Text = "";

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
            return JsonFunctions.ReadUserJSON(JsonFunctions.GetFilepath(UserForm.filename));
        }

        public void ArchiveUsers()
        {
            List<User> users = GetAllUsers();

            for (int i = 0; i < users.Count; i++)
            {
                users[i].eaten_cal = 0;
                if (users[i].food_eaten == null)
                    users[i].food_eaten = new List<Food>();

                List<Food> tempFood = users[i].food_eaten;

                if (users[i].food_eaten.Count != 0)
                {
                    users[i].Archive(tempFood);
                    users[i].food_eaten = new List<Food>();
                }
                
                if (users[i].id == currentUser.id)
                    currentUser = users[i];
            }

            JsonFunctions.WriteJSON(users, JsonFunctions.GetFilepath(UserForm.filename));
            SetCalories();
        }

        public void ResetUser(User user)
        {
            List<User> users = GetAllUsers();
            user.eaten_cal = 0;
            if (user.food_eaten == null)
                user.food_eaten = new List<Food>();
            else
                user.food_eaten.Clear();

            if (user.id == currentUser.id)
                currentUser = user;

            int i = users.FindIndex(x => x.id == user.id);
            if (i != -1)
                users[i] = user;

            JsonFunctions.WriteJSON(users, JsonFunctions.GetFilepath(UserForm.filename));

            SetCalories();
        }

        private bool CheckHits(string message)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            return true;
        }

        private void UpdateSourceLabel()
        {
            switch (flpCurrent)
            {
                case flpItems.Custom:
                    lblSource.Text = "Created foods";
                    break;
                case flpItems.Eaten:
                    lblSource.Text = "Today's eaten food";
                    break;
                case flpItems.Search:
                    lblSource.Text = "Query results";
                    break;
                case flpItems.NoResults:
                    lblSource.Text = "No results";
                    break;
                case flpItems.None:
                    lblSource.Text = "";
                    break;
                default:
                    lblSource.Text = "";
                    break;
            }
        }

        private void UpdateSourceLabel(string text)
        {
            lblSource.Text = text;
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
            {
                flpCurrent = flpItems.NoResults;
                //MessageBox.Show("No results found for \"" + queryString + "\"", "No results", MessageBoxButtons.OK);
                UpdateSourceLabel("No results for \"" + queryString + "\"");
            }
            else
            {
                flpCurrent = flpItems.Search;
                UpdateSourceLabel("Query results for \"" + queryString + "\"");
                PopulateResults(ro.GetFoods(), false, false);
            }            
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

        private void btnEaten_Click(object sender, EventArgs e)
        {
            if (currentUser.eaten_cal == 0)
                ClearResults();

            PopulateResults(GetFoodEaten(currentUser), true, true);

            txtQuery.Clear();

            flpCurrent = flpItems.Eaten;
            UpdateSourceLabel();
        }

        private void btnCustom_Click(object sender, EventArgs e)
        {
            CustomForm form = new CustomForm(this);
            form.ShowDialog();
        }

        private void btnShowCustom_Click(object sender, EventArgs e)
        {
            List<Food> customFood = CustomForm.GetCustomFood(JsonFunctions.GetFilepath(CustomForm.foodFile));
            PopulateResults(customFood, false, true);

            flpCurrent = flpItems.Custom;
            UpdateSourceLabel();
        }

        private void btnArchive_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.LastRunTime = DateTime.Today.AddDays(-1);
            Properties.Settings.Default.Save();

            CheckArchive();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.LastRunTime = DateTime.Now;
            Properties.Settings.Default.Save();
        }

        private async void btnSuggest_Click(object sender, EventArgs e)
        {
            //Filters f = new Filters(500, 100, 100, 100, 500);
            Filters f = new Filters(currentUser.CalRemain(), currentUser.SugarLeft(), currentUser.SodiumLeft(), currentUser.TotalFatLeft(), currentUser.CholesterolLeft());
            Filters f2 = new Filters(currentUser.CalRemain() / 2, currentUser.SugarLeft(), currentUser.SodiumLeft(), currentUser.TotalFatLeft(), currentUser.CholesterolLeft());
            Filters f3 = new Filters(currentUser.CalRemain() / 3, currentUser.SugarLeft(), currentUser.SodiumLeft(), currentUser.TotalFatLeft(), currentUser.CholesterolLeft());

            ClearResults();

            string message = await Query.query(f);
            string message2 = await Query.query(f2);
            string message3 = await Query.query(f3);

            Results ro = JsonConvert.DeserializeObject<Results>(message);
            Results ro2 = JsonConvert.DeserializeObject<Results>(message2);
            Results ro3 = JsonConvert.DeserializeObject<Results>(message3);

            if (ro.total + ro2.total + ro3.total == 0)
            {
                flpCurrent = flpItems.NoResults;
                UpdateSourceLabel("No suggestions for foods");
            }
            else
            {
                flpCurrent = flpItems.Search;
                UpdateSourceLabel("Food suggestions");

                List<Food> randomFoods = new List<Food>();
                List<Food> allFoods = (ro.GetFoods().Union(ro2.GetFoods()).ToList()).Union(ro3.GetFoods()).ToList();

                int times = Math.Min(allFoods.Count(), 10);
                Random r = new Random();
                List<int> usedNums = new List<int>();

                for (int i = 0; i < times; i++)
                {
                    int rand = r.Next(allFoods.Count());
                    while (usedNums.Contains(rand))
                        rand = r.Next(allFoods.Count());
                    usedNums.Add(rand);

                    randomFoods.Add(allFoods[rand]);
                }
                PopulateResults(randomFoods, false, false);
            }
        }
    }
}
