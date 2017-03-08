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
            ((System.ComponentModel.ISupportInitialize)(this.pboAttribution)).BeginInit();
            this.SuspendLayout();
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(200, 152);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 0;
            this.btnQuery.Text = "Test Query";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // txtQuery
            // 
            this.txtQuery.Location = new System.Drawing.Point(128, 184);
            this.txtQuery.Name = "txtQuery";
            this.txtQuery.Size = new System.Drawing.Size(224, 20);
            this.txtQuery.TabIndex = 1;
            this.txtQuery.Text = "apple";
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
            this.lblCurrentUser.Location = new System.Drawing.Point(12, 10);
            this.lblCurrentUser.Name = "lblCurrentUser";
            this.lblCurrentUser.Size = new System.Drawing.Size(374, 18);
            this.lblCurrentUser.TabIndex = 3;
            this.lblCurrentUser.Text = "Not logged in";
            this.lblCurrentUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pboAttribution
            // 
            this.pboAttribution.Image = global::NutritionAssistant.Properties.Resources.nutritionix_attribution_alpha;
            this.pboAttribution.Location = new System.Drawing.Point(328, 294);
            this.pboAttribution.Name = "pboAttribution";
            this.pboAttribution.Size = new System.Drawing.Size(147, 35);
            this.pboAttribution.TabIndex = 4;
            this.pboAttribution.TabStop = false;
            this.pboAttribution.Click += new System.EventHandler(this.pboAttribution_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 341);
            this.Controls.Add(this.pboAttribution);
            this.Controls.Add(this.lblCurrentUser);
            this.Controls.Add(this.btnUsers);
            this.Controls.Add(this.txtQuery);
            this.Controls.Add(this.btnQuery);
            this.Name = "MainForm";
            this.Text = "Nutrition Assistant";
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
    }
}