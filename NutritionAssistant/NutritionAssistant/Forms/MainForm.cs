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

namespace NutritionAssistant
{
    public partial class MainForm : Form
    {
        public User currentUser;

        public MainForm()
        {
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;

            InitializeComponent();
            GetCurrentUser();
            SetCalories();
        }

        public void GetCurrentUser()
        {
            //string fp = UserForm.GetFilepath();
            //List<User> users = UserForm.ReadJSON(fp);
            List<User> users = GetAllUsers();
            User user = UserForm.GetLoggedIn(users);
            SetCurrentUser(user);
        }

        public void PopulateResults(List<Food> foods)
        {
            flpResults.Controls.Clear();

            for (int i = 0; i < foods.Count; i++)
                flpResults.Controls.Add(new FoodControl(foods[i], this));

            lblCalTitle.Visible = true;
            lblFoodTitle.Visible = true;
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
        }

        public List<User> GetAllUsers()
        {
            return UserForm.ReadJSON(UserForm.GetFilepath());
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

        private async void btnQuery_Click(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(txtQuery.Text))
            {
                MessageBox.Show("Please enter a query.", "Error", MessageBoxButtons.OK);
                return;
            }

            string message = await Query.query(txtQuery.Text);

            JavaScriptSerializer jss = new JavaScriptSerializer();
            RootObject ro = jss.Deserialize<RootObject>(message);

            PopulateResults(ro.GetFoods());

            //MessageBoxButtons btns = MessageBoxButtons.OK;
            //MessageBox.Show(ro.Print(), "Results", btns);
        }

        private void btnUsers_click(object sender, EventArgs e)
        {
            UserForm form = new UserForm(this);
            form.Show();
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
        }
    }
}
