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
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.IO;

namespace NutritionAssistant
{
    public partial class UserForm : Form
    {
        public enum WeightChange {Lose=0, Gain=1, Maintain=2}

        MainForm calledBy;

        public const string filename = "UserData.json";
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
            SetupCboWeightChange();
            SetupCboUsers();
        }

        void GetUsers()
        {
            if (!File.Exists(Functions.GetFilepath(filename)))
            {
                users = new List<User>();
                Functions.WriteJSON(users, Functions.GetFilepath(filename));
                return;
            }

            users = Functions.ReadUserJSON(Functions.GetFilepath(filename));
        }
        
        User GetLoggedIn()
        {
            int index = users.FindIndex(x => x.logged_in == true);
            if (index == -1)
            {
                users[0] = users[0].SetLogin(true);
                currentUser = users[0];
                return users[0];
            }
            else
                return users[index];
        }

        bool SetLoggedIn(User newLogin)
        {
            int i = users.FindIndex(x => x.logged_in);
            
            if(i != -1)
                users[i].logged_in = false;

            newLogin.logged_in = true;
            users[users.FindIndex(x => x.id == newLogin.id)] = newLogin;

            Functions.WriteJSON(users, Functions.GetFilepath(filename));
            return true;
        }

        void SetupCboUsers()
        {
            GetUsers();
            cboUsers.DataSource = users;
            cboUsers_DataSourceChanged(cboUsers, new EventArgs());
            cboUsers.DisplayMember = "name";
            cboUsers.SelectedIndex = users.FindIndex(x => x.logged_in);
        }

        void SetupCboWeightChange()
        {
            String[] WeightChange = { "Lose weight", "Gain weight", "Maintain weight" };
            cboWeightChange.DataSource = WeightChange;
            cboWeightChange.SelectedIndex = 0;
        }

        void CreateUser(User newUser)
        {
            users.Add(newUser);
            Functions.WriteJSON(users, Functions.GetFilepath(filename));
            SetupCboUsers();
        }

        void DeleteUser(User delUser)
        {
            users.Remove(users.Find(x => x.id == delUser.id));
            users[0] = users[0].SetLogin(true);
            currentUser = users[0];
            Functions.WriteJSON(users, Functions.GetFilepath(filename));
            SetupCboUsers();
        }

        void EditUser(User oldUser, User newUser)
        {
            int i = users.FindIndex(x => x.id == oldUser.id);
            users[i] = newUser;
            if (currentUser.id == i)
                currentUser = newUser;
            Functions.WriteJSON(users, Functions.GetFilepath(filename));
            SetupCboUsers();
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
                string.IsNullOrWhiteSpace(txtHeight.Text) || string.IsNullOrWhiteSpace(txtAge.Text)))
                valid = false;
            else if (double.TryParse(txtWeight.Text, out tempDbl) && double.TryParse(txtHeight.Text, out tempDbl) &&
                    int.TryParse(txtAge.Text, out tempInt))
            { 
                if (string.IsNullOrWhiteSpace(txtCalories.Text))
                    valid = true;
                else if (int.TryParse(txtCalories.Text, out tempInt))
                    valid = true;
            }

            if(!valid)
                MessageBox.Show("All fields must be filled with valid data.", "Invalid field.", MessageBoxButtons.OK);

            return valid;

        }

        bool CalAutoValidate()
        {
            double tempDbl; int tempInt; // ignore these
            bool valid = false;

            if ((string.IsNullOrWhiteSpace(txtWeight.Text) || string.IsNullOrWhiteSpace(txtHeight.Text) || 
                string.IsNullOrWhiteSpace(txtAge.Text)))
                valid = false;
            else if (double.TryParse(txtWeight.Text, out tempDbl) && double.TryParse(txtHeight.Text, out tempDbl) &&
                    int.TryParse(txtAge.Text, out tempInt))
                valid = true;

            return valid;

        }

        void SaveChanges()
        {
            if (!DataValidation())
                return;

            int i = cboUsers.SelectedIndex;
            int cal;
            bool calBool = int.TryParse(txtCalories.Text, out cal);
            if (i == users.Count)
                CreateUser(calBool ? 
                    new User(MaxID() + 1, txtName.Text, double.Parse(txtWeight.Text),
                    double.Parse(txtHeight.Text), int.Parse(txtAge.Text), cboSex.SelectedItem.ToString(), 
                    cboActivity.SelectedItem.ToString(), cal, rdoCalManual.Checked, (WeightChange)cboWeightChange.SelectedIndex) :
                    new User(MaxID() + 1, txtName.Text, double.Parse(txtWeight.Text),
                    double.Parse(txtHeight.Text), int.Parse(txtAge.Text), cboSex.SelectedItem.ToString(),
                    cboActivity.SelectedItem.ToString(), rdoCalManual.Checked, (WeightChange)cboWeightChange.SelectedIndex));
            else
                EditUser(users[i], calBool ?
                    new User(users[i].id, txtName.Text, double.Parse(txtWeight.Text),
                    double.Parse(txtHeight.Text), int.Parse(txtAge.Text), cboSex.SelectedItem.ToString(),
                    cboActivity.SelectedItem.ToString(), cal, rdoCalManual.Checked, (WeightChange)cboWeightChange.SelectedIndex) :
                    new User(users[i].id, txtName.Text, double.Parse(txtWeight.Text),
                    double.Parse(txtHeight.Text), int.Parse(txtAge.Text), cboSex.SelectedItem.ToString(),
                    cboActivity.SelectedItem.ToString(), rdoCalManual.Checked, (WeightChange)cboWeightChange.SelectedIndex));

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
                        int i = users.FindIndex(x => x.id == ((User)cboUsers.SelectedItem).id);
                        SetLoggedIn(users[i]);
                        calledBy.ChangeUser(users[i]);
                        break;
                    case DialogResult.Cancel:
                        return;
                    case DialogResult.No:
                        break;
                }
            }
            else
            {
                int i = users.FindIndex(x => x.id == ((User)cboUsers.SelectedItem).id);
                SetLoggedIn(users[i]);
                calledBy.ChangeUser(users[i]);
            }
            calledBy.ClearResults();
            this.Close();
        }

        void AutoCalories()
        {
            if (rdoCalManual.Checked || !CalAutoValidate())
                return;

            string sex = cboSex.SelectedItem as string;
            string activity = cboActivity.SelectedItem as string;
            double weight_kg, height_m, modifier = 0.2;
            int age;

            if (string.IsNullOrWhiteSpace(sex))
                sex = currentUser.sex;
            if (string.IsNullOrWhiteSpace(activity))
                activity = currentUser.activity;
            if (!double.TryParse(txtWeight.Text, out weight_kg))
                weight_kg = currentUser.weight_kg;
            if (!double.TryParse(txtHeight.Text, out height_m))
                height_m = currentUser.height_m;
            if (!int.TryParse(txtAge.Text, out age))
                age = currentUser.age;

            WeightChange wgtChg = (WeightChange)cboWeightChange.SelectedIndex;
            switch (wgtChg)
            {
                case WeightChange.Lose:
                    modifier = 1 - modifier;
                    break;
                case WeightChange.Maintain:
                    modifier = 1;
                    break;
                case WeightChange.Gain:
                    modifier = 1 + modifier;
                    break;
            }

            double BMR = -1;
            if (sex.ToLower() == "male")
                BMR = (66 + 13.7 * weight_kg + 500 * height_m - 6.8 * age);
            else if (sex.ToLower() == "female")
                BMR = (655 + 9.6 * weight_kg + 180 * height_m - 4.7 * age);
            else
            {
                txtCalories.Text = "2000";
                return;
            }

            txtCalories.Text = ((int)(BMR * User.HBF[activity] * modifier)).ToString();
        }


        #region "Event Handlers"


        private void cboUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = cboUsers.SelectedIndex;
            int i2 = users.FindIndex(x => x.name == newUserName);

            if(i == i2)
            {
                txtName.Clear();
                txtWeight.Clear();
                txtHeight.Clear();
                txtAge.Clear();
                rdoCalManual.Checked = true;
                cboSex.SelectedIndex = 0;
                cboActivity.SelectedIndex = 0;                
                cboWeightChange.SelectedIndex = 0;
                txtCalories.Clear();
                unsaved = true;
                btnDelete.Enabled = false;
            }
            else
            {
                txtName.Text = users[i].name;
                txtWeight.Text = users[i].weight_kg.ToString();
                txtHeight.Text = users[i].height_m.ToString();
                txtAge.Text = users[i].age.ToString();
                if (users[i].manual_cal == true)
                    rdoCalManual.Checked = true;
                else if(users[i].manual_cal == false)
                    rdoCalAuto.Checked = true;
                cboSex.SelectedIndex = cboSex.FindString(users[i].sex);
                cboActivity.SelectedIndex = cboActivity.FindString(users[i].activity);
                cboWeightChange.SelectedIndex = (int)users[i].wgtchg;
                txtCalories.Text = users[i].daily_cal.ToString();
                unsaved = false;
                btnDelete.Enabled = true;
            }
            btnSave.Enabled = unsaved;
        }

        private void cboUsers_DataSourceChanged(object sender, EventArgs e)
        {
            List<User> srcUsers = (List<User>)cboUsers.DataSource;
            srcUsers.Add(new User(MaxID() + 1, newUserName, 0, 0, 0, "Male", "Lightly Active", 0, false, 0));
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

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            unsaved = true;
            btnSave.Enabled = unsaved;
        }

        private void txtWeight_TextChanged(object sender, EventArgs e)
        {
            unsaved = true;
            btnSave.Enabled = unsaved;
            AutoCalories();
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
            AutoCalories();
        }

        private void txtAge_TextChanged(object sender, EventArgs e)
        {
            unsaved = true;
            btnSave.Enabled = unsaved;
            AutoCalories();
        }

        private void cboSex_SelectedIndexChanged(object sender, EventArgs e)
        {
            unsaved = true;
            btnSave.Enabled = unsaved;
            AutoCalories();
        }

        private void cboActivity_SelectedIndexChanged(object sender, EventArgs e)
        {
            unsaved = true;
            btnSave.Enabled = unsaved;
            AutoCalories();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("This user will be permanently deleted. Continue?", "Delete User", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                DeleteUser(users[cboUsers.SelectedIndex]);
            }
        }

        private void rdoCalAuto_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb != null && rb.Checked)
            {
                txtCalories.Enabled = false;
                lblCalories.Enabled = false;
                cboWeightChange.Enabled = true;
                lblWeightChange.Enabled = true;
                AutoCalories();
                unsaved = true;
                btnSave.Enabled = unsaved;
            }
        }

        private void rdoCalManual_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb != null && rb.Checked)
            {
                txtCalories.Enabled = true;
                lblCalories.Enabled = true;
                cboWeightChange.Enabled = false;
                lblWeightChange.Enabled = false;
                unsaved = true;
                btnSave.Enabled = unsaved;
            }
        }

        private void cboWeightChange_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cbo = sender as ComboBox;
            if (cbo != null)
            {
                WeightChange wgtchg = (WeightChange)cboWeightChange.SelectedIndex;
                AutoCalories();
                unsaved = true;
                btnSave.Enabled = unsaved;
            }
        }

        #endregion
    }
}
