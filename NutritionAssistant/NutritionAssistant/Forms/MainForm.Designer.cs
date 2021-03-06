﻿namespace NutritionAssistant
{
    partial class MainForm
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
            this.btnQuery = new System.Windows.Forms.Button();
            this.txtQuery = new System.Windows.Forms.TextBox();
            this.btnUsers = new System.Windows.Forms.Button();
            this.lblCurrentUser = new System.Windows.Forms.Label();
            this.lblCalories = new System.Windows.Forms.Label();
            this.gboMain = new System.Windows.Forms.GroupBox();
            this.lblFoodTitle = new System.Windows.Forms.Label();
            this.lblCalTitle = new System.Windows.Forms.Label();
            this.flpResults = new System.Windows.Forms.FlowLayoutPanel();
            this.pboAttribution = new System.Windows.Forms.PictureBox();
            this.btnCustom = new System.Windows.Forms.Button();
            this.btnEaten = new System.Windows.Forms.Button();
            this.btnShowCustom = new System.Windows.Forms.Button();
            this.btnArchive = new System.Windows.Forms.Button();
            this.lblSource = new System.Windows.Forms.Label();
            this.btnSuggest = new System.Windows.Forms.Button();
            this.gboMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboAttribution)).BeginInit();
            this.SuspendLayout();
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(175, 315);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 1;
            this.btnQuery.Text = "Search";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // txtQuery
            // 
            this.txtQuery.Location = new System.Drawing.Point(15, 317);
            this.txtQuery.Name = "txtQuery";
            this.txtQuery.Size = new System.Drawing.Size(154, 20);
            this.txtQuery.TabIndex = 0;
            this.txtQuery.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuery_KeyPress);
            // 
            // btnUsers
            // 
            this.btnUsers.Location = new System.Drawing.Point(392, 8);
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.Size = new System.Drawing.Size(83, 23);
            this.btnUsers.TabIndex = 6;
            this.btnUsers.Text = "Change User";
            this.btnUsers.UseVisualStyleBackColor = true;
            this.btnUsers.Click += new System.EventHandler(this.btnUsers_click);
            // 
            // lblCurrentUser
            // 
            this.lblCurrentUser.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblCurrentUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentUser.Location = new System.Drawing.Point(200, 10);
            this.lblCurrentUser.Name = "lblCurrentUser";
            this.lblCurrentUser.Size = new System.Drawing.Size(186, 18);
            this.lblCurrentUser.TabIndex = 3;
            this.lblCurrentUser.Text = "Not logged in";
            this.lblCurrentUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCalories
            // 
            this.lblCalories.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCalories.Location = new System.Drawing.Point(15, 359);
            this.lblCalories.Name = "lblCalories";
            this.lblCalories.Size = new System.Drawing.Size(307, 18);
            this.lblCalories.TabIndex = 5;
            this.lblCalories.Text = "Calories consumed: ";
            this.lblCalories.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gboMain
            // 
            this.gboMain.Controls.Add(this.lblFoodTitle);
            this.gboMain.Controls.Add(this.lblCalTitle);
            this.gboMain.Controls.Add(this.flpResults);
            this.gboMain.Location = new System.Drawing.Point(12, 55);
            this.gboMain.Name = "gboMain";
            this.gboMain.Size = new System.Drawing.Size(463, 251);
            this.gboMain.TabIndex = 6;
            this.gboMain.TabStop = false;
            // 
            // lblFoodTitle
            // 
            this.lblFoodTitle.AutoSize = true;
            this.lblFoodTitle.Location = new System.Drawing.Point(6, 21);
            this.lblFoodTitle.Name = "lblFoodTitle";
            this.lblFoodTitle.Size = new System.Drawing.Size(27, 13);
            this.lblFoodTitle.TabIndex = 5;
            this.lblFoodTitle.Text = "Item";
            this.lblFoodTitle.Visible = false;
            // 
            // lblCalTitle
            // 
            this.lblCalTitle.AutoSize = true;
            this.lblCalTitle.Location = new System.Drawing.Point(384, 21);
            this.lblCalTitle.Name = "lblCalTitle";
            this.lblCalTitle.Size = new System.Drawing.Size(44, 13);
            this.lblCalTitle.TabIndex = 4;
            this.lblCalTitle.Text = "Calories";
            this.lblCalTitle.Visible = false;
            // 
            // flpResults
            // 
            this.flpResults.AutoScroll = true;
            this.flpResults.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpResults.Location = new System.Drawing.Point(6, 38);
            this.flpResults.Name = "flpResults";
            this.flpResults.Size = new System.Drawing.Size(451, 212);
            this.flpResults.TabIndex = 3;
            this.flpResults.WrapContents = false;
            // 
            // pboAttribution
            // 
            this.pboAttribution.Image = global::NutritionAssistant.Properties.Resources.nutritionix_attribution_alpha;
            this.pboAttribution.Location = new System.Drawing.Point(328, 342);
            this.pboAttribution.Name = "pboAttribution";
            this.pboAttribution.Size = new System.Drawing.Size(147, 35);
            this.pboAttribution.TabIndex = 4;
            this.pboAttribution.TabStop = false;
            this.pboAttribution.Click += new System.EventHandler(this.pboAttribution_Click);
            // 
            // btnCustom
            // 
            this.btnCustom.Location = new System.Drawing.Point(256, 315);
            this.btnCustom.Name = "btnCustom";
            this.btnCustom.Size = new System.Drawing.Size(75, 23);
            this.btnCustom.TabIndex = 2;
            this.btnCustom.Text = "Create Food";
            this.btnCustom.UseVisualStyleBackColor = true;
            this.btnCustom.Click += new System.EventHandler(this.btnCustom_Click);
            // 
            // btnEaten
            // 
            this.btnEaten.Location = new System.Drawing.Point(15, 8);
            this.btnEaten.Name = "btnEaten";
            this.btnEaten.Size = new System.Drawing.Size(75, 23);
            this.btnEaten.TabIndex = 4;
            this.btnEaten.Text = "View Eaten";
            this.btnEaten.UseVisualStyleBackColor = true;
            this.btnEaten.Click += new System.EventHandler(this.btnEaten_Click);
            // 
            // btnShowCustom
            // 
            this.btnShowCustom.Location = new System.Drawing.Point(96, 8);
            this.btnShowCustom.Name = "btnShowCustom";
            this.btnShowCustom.Size = new System.Drawing.Size(78, 23);
            this.btnShowCustom.TabIndex = 5;
            this.btnShowCustom.Text = "View Created";
            this.btnShowCustom.UseVisualStyleBackColor = true;
            this.btnShowCustom.Click += new System.EventHandler(this.btnShowCustom_Click);
            // 
            // btnArchive
            // 
            this.btnArchive.Enabled = false;
            this.btnArchive.Location = new System.Drawing.Point(180, 8);
            this.btnArchive.Name = "btnArchive";
            this.btnArchive.Size = new System.Drawing.Size(78, 23);
            this.btnArchive.TabIndex = 9;
            this.btnArchive.Text = "Archive";
            this.btnArchive.UseVisualStyleBackColor = true;
            this.btnArchive.Visible = false;
            this.btnArchive.Click += new System.EventHandler(this.btnArchive_Click);
            // 
            // lblSource
            // 
            this.lblSource.AutoSize = true;
            this.lblSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSource.Location = new System.Drawing.Point(15, 39);
            this.lblSource.Name = "lblSource";
            this.lblSource.Size = new System.Drawing.Size(47, 13);
            this.lblSource.TabIndex = 10;
            this.lblSource.Text = "Source";
            // 
            // btnSuggest
            // 
            this.btnSuggest.Location = new System.Drawing.Point(337, 315);
            this.btnSuggest.Name = "btnSuggest";
            this.btnSuggest.Size = new System.Drawing.Size(75, 23);
            this.btnSuggest.TabIndex = 3;
            this.btnSuggest.Text = "Suggest";
            this.btnSuggest.UseVisualStyleBackColor = true;
            this.btnSuggest.Click += new System.EventHandler(this.btnSuggest_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 389);
            this.Controls.Add(this.btnSuggest);
            this.Controls.Add(this.lblSource);
            this.Controls.Add(this.btnArchive);
            this.Controls.Add(this.btnCustom);
            this.Controls.Add(this.btnShowCustom);
            this.Controls.Add(this.btnEaten);
            this.Controls.Add(this.gboMain);
            this.Controls.Add(this.lblCalories);
            this.Controls.Add(this.txtQuery);
            this.Controls.Add(this.pboAttribution);
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.lblCurrentUser);
            this.Controls.Add(this.btnUsers);
            this.Name = "MainForm";
            this.Text = "Nutrition Assistant";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.gboMain.ResumeLayout(false);
            this.gboMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboAttribution)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.TextBox txtQuery;
        private System.Windows.Forms.Button btnUsers;
        private System.Windows.Forms.Label lblCurrentUser;
        private System.Windows.Forms.PictureBox pboAttribution;
        private System.Windows.Forms.Label lblCalories;
        private System.Windows.Forms.GroupBox gboMain;
        private System.Windows.Forms.FlowLayoutPanel flpResults;
        private System.Windows.Forms.Label lblCalTitle;
        private System.Windows.Forms.Label lblFoodTitle;
        private System.Windows.Forms.Button btnCustom;
        private System.Windows.Forms.Button btnEaten;
        private System.Windows.Forms.Button btnShowCustom;
        private System.Windows.Forms.Button btnArchive;
        private System.Windows.Forms.Label lblSource;
        private System.Windows.Forms.Button btnSuggest;
    }
}