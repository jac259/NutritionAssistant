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
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.IO;
using System.Diagnostics;

namespace NutritionAssistant
{
    public partial class MainForm : Form
    {
        User currentUser;

        public MainForm()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            GetCurrentUser();
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

            MessageBoxButtons btns = MessageBoxButtons.OK;
            MessageBox.Show(ro.Print(), "Results", btns);
        }

        private void btnUsers_click(object sender, EventArgs e)
        {
            UserForm form = new UserForm(this);
            form.Show();
        }

        public void GetCurrentUser()
        {
            //User user = UserForm.GetLoggedIn(UserForm.ReadJSON(UserForm.GetFilepath()));
            string fp = UserForm.GetFilepath();
            List<User> users = UserForm.ReadJSON(fp);
            User user = UserForm.GetLoggedIn(users);
            SetCurrentUser(user);
        }

        public void SetCurrentUser(User user)
        {
            lblCurrentUser.Text = user.name;
            currentUser = user;
        }

        private void pboAttribution_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.nutritionix.com/api");
        }
    }
}
