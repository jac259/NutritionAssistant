﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NutritionAssistant.JSON;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.IO;

namespace NutritionAssistant
{
    public partial class UserForm : Form
    {
        MainForm calledBy;

        const string filename = "UserData.json";
        const string newUserName = "New user...";
        bool unsaved = false;
        
        List<User> users = new List<User>();
        User currentUser;

        public UserForm(MainForm _calledBy)
        {
            calledBy = _calledBy;
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;

            InitializeComponent();
            this.Icon = NutritionAssistant.Properties.Resources.Nutrition_Assistant;
            btnSave.Enabled = unsaved;

            SetupControls();
        }

        private void SetupControls()
        {
            GetUsers();
            currentUser = GetLoggedIn();
            SetupCboUsers();
        }

        public static string GetFilepath()
        {
            return Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).Substring(6) + '\\' + filename;
        }

        public static string GetFilepath(string _filename)
        {
            return Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).Substring(6) + '\\' + _filename;
        }

        void GetUsers()
        {
            if (!File.Exists(GetFilepath()))
            {
                users = new List<User>();
                WriteJSON();
                return;
            }

            ReadJSON();
        }

        static List<User> GetUsers(string filepath)
        {
            if (!File.Exists(filepath))
            {
                List<User> newUsers = new List<User>();
                WriteJSON(newUsers, filepath);
                return newUsers;
            }

            return ReadUserJSON(filepath);
        }
        
        User GetLoggedIn()
        {
            User user = users.Find(x => x.logged_in);

            if (user == null)
                return users[0];

            return user;
        }

        public static User GetLoggedIn(List<User> _users)
        {
            return _users.Find(x => x.logged_in);
        }

        void SetLoggedIn(User newLogin)
        {
            User oldLogin = GetLoggedIn();
            EditUser(oldLogin, oldLogin.SetLogin(false));
            EditUser(newLogin, newLogin.SetLogin(true));
        }

        void SetupCboUsers()
        {
            cboUsers.DataSource = users;
            cboUsers_DataSourceChanged(cboUsers, new EventArgs());
            cboUsers.DisplayMember = "name";
            cboUsers.SelectedItem = currentUser;
        }

        void CreateUser(User newUser)
        {
            users.Add(newUser);
            WriteJSON();
            //GetUsers();
        }

        void DeleteUser(User delUser)
        {
            users.Remove(delUser);
            WriteJSON();
            //GetUsers();
        }

        void EditUser(User oldUser, User newUser)
        {
            users[users.IndexOf(oldUser)] = newUser;
            WriteJSON();
            //GetUsers();
        }

        void WriteJSON() 
        {
            if (users.Last().name == newUserName)
                users.Remove(users.Last());

            using (StreamWriter file = File.CreateText(GetFilepath()))
            {
                JsonSerializer js = new JsonSerializer();
                js.Serialize(file, users);
            }
        }

        public static void WriteJSON(List<User> _users, string filepath)
        {
            using (StreamWriter file = File.CreateText(filepath))
            {
                JsonSerializer js = new JsonSerializer();
                js.Serialize(file, _users);
            }
        }

        public static void WriteJSON(List<Food> _foods, string filepath)
        {
            using (StreamWriter file = File.CreateText(filepath))
            {
                JsonSerializer js = new JsonSerializer();
                js.Serialize(file, _foods);
            }
        }

        void ReadJSON()
        {
            using (StreamReader file = File.OpenText(GetFilepath()))
            {
                JsonSerializer js = new JsonSerializer();
                users = (List<User>)js.Deserialize(file, typeof(List<User>));
            }
        }

        public static List<User> ReadUserJSON(string filepath)
        {
            using (StreamReader file = File.OpenText(filepath))
            {
                JsonSerializer js = new JsonSerializer();
                return (List<User>)js.Deserialize(file, typeof(List<User>));
            }
        }

        public static List<Food> ReadFoodJSON(string filepath)
        {
            using (StreamReader file = File.OpenText(filepath))
            {
                JsonSerializer js = new JsonSerializer();
                return (List<Food>)js.Deserialize(file, typeof(List<Food>));
            }
        }

        int MaxID()
        {
            int max = 0;
            foreach (User user in users)
                max = Math.Max(max, user.id);
            return max;
        }

        bool DataValidation()
        {
            double tempDbl; int tempInt; // ignore these
            bool valid = false;

            if ((string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtWeight.Text) ||
                string.IsNullOrWhiteSpace(txtHeight.Text) || string.IsNullOrWhiteSpace(txtCalories.Text)))
                valid = false;
            else if(double.TryParse(txtWeight.Text, out tempDbl) && double.TryParse(txtHeight.Text, out tempDbl) && 
                int.TryParse(txtCalories.Text, out tempInt))
                valid = true;

            if(!valid)
                MessageBox.Show("All fields must be filled with valid data.", "Invalid field.", MessageBoxButtons.OK);

            return valid;

        }

        void SaveChanges()
        {
            if (!DataValidation())
                return;

            int i = cboUsers.SelectedIndex;
            if (i == users.Count)
                CreateUser(new User(MaxID() + 1, txtName.Text, double.Parse(txtWeight.Text),
                    double.Parse(txtHeight.Text), int.Parse(txtCalories.Text)));
            else
                EditUser(users[i], new User(users[i].id, txtName.Text, double.Parse(txtWeight.Text),
                    double.Parse(txtHeight.Text), int.Parse(txtCalories.Text)));

            //cboUsers.DataSource = users;
            SetupCboUsers();
            cboUsers.SelectedIndex = i;

            unsaved = false;
            btnSave.Enabled = unsaved;
        }

        void CloseDialog()
        {
            if (unsaved)
            {
                DialogResult result = MessageBox.Show("You have unsaved changes. Would you like to save them?", "Unsaved Changes", MessageBoxButtons.YesNoCancel);
                switch (result)
                {
                    case DialogResult.Yes:
                        if (!DataValidation())
                            return;
                        SaveChanges();
                        calledBy.ChangeUser(((User)cboUsers.SelectedItem));
                        SetLoggedIn((User)cboUsers.SelectedItem);
                        break;
                    case DialogResult.Cancel:
                        return;
                    case DialogResult.No:
                        break;
                }
            }
            else
            {
                calledBy.ChangeUser(((User)cboUsers.SelectedItem));
                SetLoggedIn((User)cboUsers.SelectedItem);
            }
            this.Close();
        }


        #region "Event Handlers"


        private void cboUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = cboUsers.SelectedIndex;

            if(i == users.Count - 1)
            {
                txtName.Clear();
                txtWeight.Clear();
                txtHeight.Clear();
                txtCalories.Clear();
                unsaved = true;
            }
            else
            {
                txtName.Text = users[i].name;
                txtWeight.Text = users[i].weight_kg.ToString();
                txtHeight.Text = users[i].height_m.ToString();
                txtCalories.Text = users[i].daily_cal.ToString();
                unsaved = false;
            }
            btnSave.Enabled = unsaved;
        }

        private void cboUsers_DataSourceChanged(object sender, EventArgs e)
        {
            List<User> srcUsers = (List<User>)cboUsers.DataSource;
            srcUsers.Add(new User(MaxID() + 1, newUserName, 0, 0, 0));
            cboUsers.DataSource = srcUsers;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            CloseDialog();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveChanges();
        }

        #endregion

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            unsaved = true;
            btnSave.Enabled = unsaved;
        }

        private void txtWeight_TextChanged(object sender, EventArgs e)
        {
            unsaved = true;
            btnSave.Enabled = unsaved;
        }

        private void txtCalories_TextChanged(object sender, EventArgs e)
        {
            unsaved = true;
            btnSave.Enabled = unsaved;
        }

        private void txtHeight_TextChanged(object sender, EventArgs e)
        {
            unsaved = true;
            btnSave.Enabled = unsaved;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            calledBy.ResetUser(currentUser);
            MessageBox.Show(currentUser.name + "'s daily food successfully reset.", "Reset", MessageBoxButtons.OK);
        }
    }
}
