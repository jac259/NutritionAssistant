namespace NutritionAssistant.Controls
{
    partial class FoodControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblName = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            this.lblCalories = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoEllipsis = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(-3, 3);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(369, 16);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name";
            this.lblName.Click += new System.EventHandler(this.FoodControl_Click);
            // 
            // lblInfo
            // 
            this.lblInfo.AutoEllipsis = true;
            this.lblInfo.Location = new System.Drawing.Point(-3, 19);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(369, 18);
            this.lblInfo.TabIndex = 1;
            this.lblInfo.Text = "Brand, Serving oz";
            this.lblInfo.Click += new System.EventHandler(this.FoodControl_Click);
            // 
            // lblCalories
            // 
            this.lblCalories.Location = new System.Drawing.Point(372, 7);
            this.lblCalories.Name = "lblCalories";
            this.lblCalories.Size = new System.Drawing.Size(49, 23);
            this.lblCalories.TabIndex = 2;
            this.lblCalories.Text = "0";
            this.lblCalories.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCalories.Click += new System.EventHandler(this.FoodControl_Click);
            // 
            // FoodControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblCalories);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.lblName);
            this.Name = "FoodControl";
            this.Size = new System.Drawing.Size(425, 37);
            this.Click += new System.EventHandler(this.FoodControl_Click);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Label lblCalories;
    }
}
