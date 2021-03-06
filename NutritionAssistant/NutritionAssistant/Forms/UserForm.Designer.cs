﻿namespace NutritionAssistant
{
    partial class UserForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cboUsers = new System.Windows.Forms.ComboBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtWeight = new System.Windows.Forms.TextBox();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.txtCalories = new System.Windows.Forms.TextBox();
            this.gboUserInfo = new System.Windows.Forms.GroupBox();
            this.cboSex = new System.Windows.Forms.ComboBox();
            this.lblSex = new System.Windows.Forms.Label();
            this.cboActivity = new System.Windows.Forms.ComboBox();
            this.lblActivity = new System.Windows.Forms.Label();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.lblAge = new System.Windows.Forms.Label();
            this.lblCalories = new System.Windows.Forms.Label();
            this.lblHeight = new System.Windows.Forms.Label();
            this.lblWeight = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblUser = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.gboCal = new System.Windows.Forms.GroupBox();
            this.rdoCalManual = new System.Windows.Forms.RadioButton();
            this.rdoCalAuto = new System.Windows.Forms.RadioButton();
            this.lblWeightChange = new System.Windows.Forms.Label();
            this.cboWeightChange = new System.Windows.Forms.ComboBox();
            this.gboUserInfo.SuspendLayout();
            this.gboCal.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboUsers
            // 
            this.cboUsers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUsers.FormattingEnabled = true;
            this.cboUsers.Location = new System.Drawing.Point(160, 12);
            this.cboUsers.Name = "cboUsers";
            this.cboUsers.Size = new System.Drawing.Size(112, 21);
            this.cboUsers.TabIndex = 0;
            this.cboUsers.SelectedIndexChanged += new System.EventHandler(this.cboUsers_SelectedIndexChanged);
            this.cboUsers.DataSourceChanged += new System.EventHandler(this.cboUsers_DataSourceChanged);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(125, 24);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(112, 20);
            this.txtName.TabIndex = 1;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // txtWeight
            // 
            this.txtWeight.Location = new System.Drawing.Point(125, 50);
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.Size = new System.Drawing.Size(112, 20);
            this.txtWeight.TabIndex = 2;
            this.txtWeight.TextChanged += new System.EventHandler(this.txtWeight_TextChanged);
            // 
            // txtHeight
            // 
            this.txtHeight.Location = new System.Drawing.Point(125, 76);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(112, 20);
            this.txtHeight.TabIndex = 3;
            this.txtHeight.TextChanged += new System.EventHandler(this.txtHeight_TextChanged);
            // 
            // txtCalories
            // 
            this.txtCalories.Location = new System.Drawing.Point(125, 77);
            this.txtCalories.Name = "txtCalories";
            this.txtCalories.Size = new System.Drawing.Size(112, 20);
            this.txtCalories.TabIndex = 7;
            this.txtCalories.TextChanged += new System.EventHandler(this.txtCalories_TextChanged);
            // 
            // gboUserInfo
            // 
            this.gboUserInfo.Controls.Add(this.cboSex);
            this.gboUserInfo.Controls.Add(this.lblSex);
            this.gboUserInfo.Controls.Add(this.cboActivity);
            this.gboUserInfo.Controls.Add(this.lblActivity);
            this.gboUserInfo.Controls.Add(this.txtAge);
            this.gboUserInfo.Controls.Add(this.lblAge);
            this.gboUserInfo.Controls.Add(this.lblHeight);
            this.gboUserInfo.Controls.Add(this.lblWeight);
            this.gboUserInfo.Controls.Add(this.lblName);
            this.gboUserInfo.Controls.Add(this.txtHeight);
            this.gboUserInfo.Controls.Add(this.txtWeight);
            this.gboUserInfo.Controls.Add(this.txtName);
            this.gboUserInfo.Location = new System.Drawing.Point(13, 45);
            this.gboUserInfo.Name = "gboUserInfo";
            this.gboUserInfo.Size = new System.Drawing.Size(259, 186);
            this.gboUserInfo.TabIndex = 1;
            this.gboUserInfo.TabStop = false;
            this.gboUserInfo.Text = "User Info";
            // 
            // cboSex
            // 
            this.cboSex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSex.FormattingEnabled = true;
            this.cboSex.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.cboSex.Location = new System.Drawing.Point(125, 127);
            this.cboSex.Name = "cboSex";
            this.cboSex.Size = new System.Drawing.Size(112, 21);
            this.cboSex.TabIndex = 5;
            this.cboSex.SelectedIndexChanged += new System.EventHandler(this.cboSex_SelectedIndexChanged);
            // 
            // lblSex
            // 
            this.lblSex.AutoSize = true;
            this.lblSex.Location = new System.Drawing.Point(18, 130);
            this.lblSex.Name = "lblSex";
            this.lblSex.Size = new System.Drawing.Size(25, 13);
            this.lblSex.TabIndex = 14;
            this.lblSex.Text = "Sex";
            // 
            // cboActivity
            // 
            this.cboActivity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboActivity.FormattingEnabled = true;
            this.cboActivity.Items.AddRange(new object[] {
            "Sedentary",
            "Lightly Active",
            "Moderately Active",
            "Very Active",
            "Extra Active"});
            this.cboActivity.Location = new System.Drawing.Point(125, 154);
            this.cboActivity.Name = "cboActivity";
            this.cboActivity.Size = new System.Drawing.Size(112, 21);
            this.cboActivity.TabIndex = 6;
            this.cboActivity.SelectedIndexChanged += new System.EventHandler(this.cboActivity_SelectedIndexChanged);
            // 
            // lblActivity
            // 
            this.lblActivity.AutoSize = true;
            this.lblActivity.Location = new System.Drawing.Point(18, 157);
            this.lblActivity.Name = "lblActivity";
            this.lblActivity.Size = new System.Drawing.Size(41, 13);
            this.lblActivity.TabIndex = 12;
            this.lblActivity.Text = "Activity";
            // 
            // txtAge
            // 
            this.txtAge.Location = new System.Drawing.Point(125, 102);
            this.txtAge.Name = "txtAge";
            this.txtAge.Size = new System.Drawing.Size(112, 20);
            this.txtAge.TabIndex = 4;
            this.txtAge.TextChanged += new System.EventHandler(this.txtAge_TextChanged);
            // 
            // lblAge
            // 
            this.lblAge.AutoSize = true;
            this.lblAge.Location = new System.Drawing.Point(18, 105);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(48, 13);
            this.lblAge.TabIndex = 10;
            this.lblAge.Text = "Age (yrs)";
            // 
            // lblCalories
            // 
            this.lblCalories.AutoSize = true;
            this.lblCalories.Location = new System.Drawing.Point(19, 80);
            this.lblCalories.Name = "lblCalories";
            this.lblCalories.Size = new System.Drawing.Size(85, 13);
            this.lblCalories.TabIndex = 8;
            this.lblCalories.Text = "Calories Per Day";
            // 
            // lblHeight
            // 
            this.lblHeight.AutoSize = true;
            this.lblHeight.Location = new System.Drawing.Point(18, 79);
            this.lblHeight.Name = "lblHeight";
            this.lblHeight.Size = new System.Drawing.Size(55, 13);
            this.lblHeight.TabIndex = 7;
            this.lblHeight.Text = "Height (m)";
            // 
            // lblWeight
            // 
            this.lblWeight.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblWeight.AutoSize = true;
            this.lblWeight.Location = new System.Drawing.Point(18, 53);
            this.lblWeight.Name = "lblWeight";
            this.lblWeight.Size = new System.Drawing.Size(62, 13);
            this.lblWeight.TabIndex = 6;
            this.lblWeight.Text = "Weight (kg)";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(18, 27);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 5;
            this.lblName.Text = "Name";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(167, 353);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(83, 23);
            this.btnUpdate.TabIndex = 9;
            this.btnUpdate.Text = "OK";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(34, 353);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(83, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(122, 16);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(32, 13);
            this.lblUser.TabIndex = 11;
            this.lblUser.Text = "User:";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(13, 10);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(83, 23);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "Delete User";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // gboCal
            // 
            this.gboCal.Controls.Add(this.cboWeightChange);
            this.gboCal.Controls.Add(this.lblWeightChange);
            this.gboCal.Controls.Add(this.rdoCalAuto);
            this.gboCal.Controls.Add(this.rdoCalManual);
            this.gboCal.Controls.Add(this.txtCalories);
            this.gboCal.Controls.Add(this.lblCalories);
            this.gboCal.Location = new System.Drawing.Point(13, 238);
            this.gboCal.Name = "gboCal";
            this.gboCal.Size = new System.Drawing.Size(259, 109);
            this.gboCal.TabIndex = 12;
            this.gboCal.TabStop = false;
            this.gboCal.Text = "Daily Calories";
            // 
            // rdoCalManual
            // 
            this.rdoCalManual.AutoSize = true;
            this.rdoCalManual.Checked = true;
            this.rdoCalManual.Location = new System.Drawing.Point(21, 22);
            this.rdoCalManual.Name = "rdoCalManual";
            this.rdoCalManual.Size = new System.Drawing.Size(60, 17);
            this.rdoCalManual.TabIndex = 9;
            this.rdoCalManual.TabStop = true;
            this.rdoCalManual.Text = "Manual";
            this.rdoCalManual.UseVisualStyleBackColor = true;
            this.rdoCalManual.CheckedChanged += new System.EventHandler(this.rdoCalManual_CheckedChanged);
            // 
            // rdoCalAuto
            // 
            this.rdoCalAuto.AutoSize = true;
            this.rdoCalAuto.Location = new System.Drawing.Point(125, 22);
            this.rdoCalAuto.Name = "rdoCalAuto";
            this.rdoCalAuto.Size = new System.Drawing.Size(72, 17);
            this.rdoCalAuto.TabIndex = 10;
            this.rdoCalAuto.Text = "Automatic";
            this.rdoCalAuto.UseVisualStyleBackColor = true;
            this.rdoCalAuto.CheckedChanged += new System.EventHandler(this.rdoCalAuto_CheckedChanged);
            // 
            // lblWeightChange
            // 
            this.lblWeightChange.AutoSize = true;
            this.lblWeightChange.Enabled = false;
            this.lblWeightChange.Location = new System.Drawing.Point(18, 51);
            this.lblWeightChange.Name = "lblWeightChange";
            this.lblWeightChange.Size = new System.Drawing.Size(81, 13);
            this.lblWeightChange.TabIndex = 11;
            this.lblWeightChange.Text = "Weight Change";
            // 
            // cboWeightChange
            // 
            this.cboWeightChange.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboWeightChange.Enabled = false;
            this.cboWeightChange.FormattingEnabled = true;
            this.cboWeightChange.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.cboWeightChange.Location = new System.Drawing.Point(125, 48);
            this.cboWeightChange.Name = "cboWeightChange";
            this.cboWeightChange.Size = new System.Drawing.Size(112, 21);
            this.cboWeightChange.TabIndex = 15;
            this.cboWeightChange.SelectedIndexChanged += new System.EventHandler(this.cboWeightChange_SelectedIndexChanged);
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 385);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.gboUserInfo);
            this.Controls.Add(this.cboUsers);
            this.Controls.Add(this.gboCal);
            this.Name = "UserForm";
            this.Text = "User Editor";
            this.gboUserInfo.ResumeLayout(false);
            this.gboUserInfo.PerformLayout();
            this.gboCal.ResumeLayout(false);
            this.gboCal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboUsers;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtWeight;
        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.TextBox txtCalories;
        private System.Windows.Forms.GroupBox gboUserInfo;
        private System.Windows.Forms.Label lblCalories;
        private System.Windows.Forms.Label lblHeight;
        private System.Windows.Forms.Label lblWeight;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblActivity;
        private System.Windows.Forms.TextBox txtAge;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.ComboBox cboActivity;
        private System.Windows.Forms.ComboBox cboSex;
        private System.Windows.Forms.Label lblSex;
        private System.Windows.Forms.GroupBox gboCal;
        private System.Windows.Forms.RadioButton rdoCalAuto;
        private System.Windows.Forms.RadioButton rdoCalManual;
        private System.Windows.Forms.ComboBox cboWeightChange;
        private System.Windows.Forms.Label lblWeightChange;
    }
}