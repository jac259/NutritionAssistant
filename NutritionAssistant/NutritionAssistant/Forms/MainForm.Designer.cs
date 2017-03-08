namespace NutritionAssistant
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
            this.pboAttribution = new System.Windows.Forms.PictureBox();
            this.lblCalories = new System.Windows.Forms.Label();
            this.gboMain = new System.Windows.Forms.GroupBox();
            this.lblFoodTitle = new System.Windows.Forms.Label();
            this.lblCalTitle = new System.Windows.Forms.Label();
            this.flpResults = new System.Windows.Forms.FlowLayoutPanel();
            this.btnReset = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pboAttribution)).BeginInit();
            this.gboMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(15, 294);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 0;
            this.btnQuery.Text = "Search";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // txtQuery
            // 
            this.txtQuery.Location = new System.Drawing.Point(96, 296);
            this.txtQuery.Name = "txtQuery";
            this.txtQuery.Size = new System.Drawing.Size(154, 20);
            this.txtQuery.TabIndex = 1;
            this.txtQuery.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuery_KeyPress);
            // 
            // btnUsers
            // 
            this.btnUsers.Location = new System.Drawing.Point(392, 8);
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.Size = new System.Drawing.Size(83, 23);
            this.btnUsers.TabIndex = 2;
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
            // pboAttribution
            // 
            this.pboAttribution.Image = global::NutritionAssistant.Properties.Resources.nutritionix_attribution_alpha;
            this.pboAttribution.Location = new System.Drawing.Point(328, 315);
            this.pboAttribution.Name = "pboAttribution";
            this.pboAttribution.Size = new System.Drawing.Size(147, 35);
            this.pboAttribution.TabIndex = 4;
            this.pboAttribution.TabStop = false;
            this.pboAttribution.Click += new System.EventHandler(this.pboAttribution_Click);
            // 
            // lblCalories
            // 
            this.lblCalories.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCalories.Location = new System.Drawing.Point(15, 332);
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
            this.gboMain.Location = new System.Drawing.Point(12, 37);
            this.gboMain.Name = "gboMain";
            this.gboMain.Size = new System.Drawing.Size(463, 251);
            this.gboMain.TabIndex = 6;
            this.gboMain.TabStop = false;
            // 
            // lblFoodTitle
            // 
            this.lblFoodTitle.AutoSize = true;
            this.lblFoodTitle.Location = new System.Drawing.Point(6, 15);
            this.lblFoodTitle.Name = "lblFoodTitle";
            this.lblFoodTitle.Size = new System.Drawing.Size(27, 13);
            this.lblFoodTitle.TabIndex = 5;
            this.lblFoodTitle.Text = "Item";
            this.lblFoodTitle.Visible = false;
            // 
            // lblCalTitle
            // 
            this.lblCalTitle.AutoSize = true;
            this.lblCalTitle.Location = new System.Drawing.Point(384, 15);
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
            this.flpResults.Location = new System.Drawing.Point(6, 32);
            this.flpResults.Name = "flpResults";
            this.flpResults.Size = new System.Drawing.Size(451, 212);
            this.flpResults.TabIndex = 3;
            this.flpResults.WrapContents = false;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(15, 8);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 7;
            this.btnReset.Text = "New Day";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 362);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.gboMain);
            this.Controls.Add(this.lblCalories);
            this.Controls.Add(this.txtQuery);
            this.Controls.Add(this.pboAttribution);
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.lblCurrentUser);
            this.Controls.Add(this.btnUsers);
            this.Name = "MainForm";
            this.Text = "Nutrition Assistant";
            ((System.ComponentModel.ISupportInitialize)(this.pboAttribution)).EndInit();
            this.gboMain.ResumeLayout(false);
            this.gboMain.PerformLayout();
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
        private System.Windows.Forms.Button btnReset;
    }
}