namespace NutritionAssistant.Forms
{
    partial class FoodForm
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
            this.lblName = new System.Windows.Forms.Label();
            this.lblServingsTitle = new System.Windows.Forms.Label();
            this.txtServings = new System.Windows.Forms.TextBox();
            this.lblSizeTitle = new System.Windows.Forms.Label();
            this.lblSize = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.flpNutrition = new System.Windows.Forms.FlowLayoutPanel();
            this.lblNutritionInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoEllipsis = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(9, 9);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(290, 23);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name";
            // 
            // lblServingsTitle
            // 
            this.lblServingsTitle.AutoSize = true;
            this.lblServingsTitle.Location = new System.Drawing.Point(9, 40);
            this.lblServingsTitle.Name = "lblServingsTitle";
            this.lblServingsTitle.Size = new System.Drawing.Size(100, 13);
            this.lblServingsTitle.TabIndex = 1;
            this.lblServingsTitle.Text = "Number of Servings";
            // 
            // txtServings
            // 
            this.txtServings.Location = new System.Drawing.Point(268, 37);
            this.txtServings.Name = "txtServings";
            this.txtServings.Size = new System.Drawing.Size(31, 20);
            this.txtServings.TabIndex = 2;
            this.txtServings.Text = "1";
            this.txtServings.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtServings.TextChanged += new System.EventHandler(this.txtServings_TextChanged);
            // 
            // lblSizeTitle
            // 
            this.lblSizeTitle.AutoSize = true;
            this.lblSizeTitle.Location = new System.Drawing.Point(9, 65);
            this.lblSizeTitle.Name = "lblSizeTitle";
            this.lblSizeTitle.Size = new System.Drawing.Size(63, 13);
            this.lblSizeTitle.TabIndex = 3;
            this.lblSizeTitle.Text = "Seving Size";
            // 
            // lblSize
            // 
            this.lblSize.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblSize.Location = new System.Drawing.Point(190, 65);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(109, 13);
            this.lblSize.TabIndex = 4;
            this.lblSize.Text = "100g";
            this.lblSize.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(190, 268);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(47, 268);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // flpNutrition
            // 
            this.flpNutrition.AutoScroll = true;
            this.flpNutrition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpNutrition.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpNutrition.Location = new System.Drawing.Point(12, 111);
            this.flpNutrition.Name = "flpNutrition";
            this.flpNutrition.Size = new System.Drawing.Size(287, 145);
            this.flpNutrition.TabIndex = 8;
            this.flpNutrition.WrapContents = false;
            // 
            // lblNutritionInfo
            // 
            this.lblNutritionInfo.AutoSize = true;
            this.lblNutritionInfo.Location = new System.Drawing.Point(12, 92);
            this.lblNutritionInfo.Name = "lblNutritionInfo";
            this.lblNutritionInfo.Size = new System.Drawing.Size(101, 13);
            this.lblNutritionInfo.TabIndex = 9;
            this.lblNutritionInfo.Text = "Nutrition Information";
            // 
            // FoodForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 303);
            this.Controls.Add(this.lblNutritionInfo);
            this.Controls.Add(this.flpNutrition);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblSize);
            this.Controls.Add(this.lblSizeTitle);
            this.Controls.Add(this.txtServings);
            this.Controls.Add(this.lblServingsTitle);
            this.Controls.Add(this.lblName);
            this.Name = "FoodForm";
            this.Text = "FoodForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblServingsTitle;
        private System.Windows.Forms.TextBox txtServings;
        private System.Windows.Forms.Label lblSizeTitle;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.FlowLayoutPanel flpNutrition;
        private System.Windows.Forms.Label lblNutritionInfo;
    }
}