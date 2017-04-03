namespace NutritionAssistant.Forms
{
    partial class CustomForm
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
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtServingQty = new System.Windows.Forms.TextBox();
            this.lblServing = new System.Windows.Forms.Label();
            this.txtCalories = new System.Windows.Forms.TextBox();
            this.lblCalories = new System.Windows.Forms.Label();
            this.txtBrand = new System.Windows.Forms.TextBox();
            this.lblBrand = new System.Windows.Forms.Label();
            this.gboRequired = new System.Windows.Forms.GroupBox();
            this.gboOptional = new System.Windows.Forms.GroupBox();
            this.flpNutrition = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtServingUnit = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gboRequired.SuspendLayout();
            this.gboOptional.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(13, 24);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(105, 21);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 20);
            this.txtName.TabIndex = 1;
            // 
            // txtServingQty
            // 
            this.txtServingQty.Location = new System.Drawing.Point(105, 73);
            this.txtServingQty.Name = "txtServingQty";
            this.txtServingQty.Size = new System.Drawing.Size(100, 20);
            this.txtServingQty.TabIndex = 3;
            // 
            // lblServing
            // 
            this.lblServing.AutoSize = true;
            this.lblServing.Location = new System.Drawing.Point(13, 76);
            this.lblServing.Name = "lblServing";
            this.lblServing.Size = new System.Drawing.Size(83, 13);
            this.lblServing.TabIndex = 2;
            this.lblServing.Text = "Serving quantity";
            // 
            // txtCalories
            // 
            this.txtCalories.Location = new System.Drawing.Point(105, 124);
            this.txtCalories.Name = "txtCalories";
            this.txtCalories.Size = new System.Drawing.Size(100, 20);
            this.txtCalories.TabIndex = 5;
            // 
            // lblCalories
            // 
            this.lblCalories.AutoSize = true;
            this.lblCalories.Location = new System.Drawing.Point(13, 127);
            this.lblCalories.Name = "lblCalories";
            this.lblCalories.Size = new System.Drawing.Size(44, 13);
            this.lblCalories.TabIndex = 4;
            this.lblCalories.Text = "Calories";
            // 
            // txtBrand
            // 
            this.txtBrand.Location = new System.Drawing.Point(105, 47);
            this.txtBrand.Name = "txtBrand";
            this.txtBrand.Size = new System.Drawing.Size(100, 20);
            this.txtBrand.TabIndex = 2;
            // 
            // lblBrand
            // 
            this.lblBrand.AutoSize = true;
            this.lblBrand.Location = new System.Drawing.Point(13, 50);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(35, 13);
            this.lblBrand.TabIndex = 6;
            this.lblBrand.Text = "Brand";
            // 
            // gboRequired
            // 
            this.gboRequired.Controls.Add(this.txtServingUnit);
            this.gboRequired.Controls.Add(this.label1);
            this.gboRequired.Controls.Add(this.txtBrand);
            this.gboRequired.Controls.Add(this.txtCalories);
            this.gboRequired.Controls.Add(this.lblCalories);
            this.gboRequired.Controls.Add(this.txtServingQty);
            this.gboRequired.Controls.Add(this.lblServing);
            this.gboRequired.Controls.Add(this.lblBrand);
            this.gboRequired.Controls.Add(this.txtName);
            this.gboRequired.Controls.Add(this.lblName);
            this.gboRequired.Location = new System.Drawing.Point(12, 12);
            this.gboRequired.Name = "gboRequired";
            this.gboRequired.Size = new System.Drawing.Size(228, 155);
            this.gboRequired.TabIndex = 0;
            this.gboRequired.TabStop = false;
            this.gboRequired.Text = "Required";
            // 
            // gboOptional
            // 
            this.gboOptional.Controls.Add(this.flpNutrition);
            this.gboOptional.Location = new System.Drawing.Point(13, 173);
            this.gboOptional.Name = "gboOptional";
            this.gboOptional.Size = new System.Drawing.Size(228, 136);
            this.gboOptional.TabIndex = 6;
            this.gboOptional.TabStop = false;
            this.gboOptional.Text = "Optional";
            // 
            // flpNutrition
            // 
            this.flpNutrition.AutoScroll = true;
            this.flpNutrition.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpNutrition.Location = new System.Drawing.Point(6, 19);
            this.flpNutrition.Name = "flpNutrition";
            this.flpNutrition.Size = new System.Drawing.Size(216, 111);
            this.flpNutrition.TabIndex = 9;
            this.flpNutrition.WrapContents = false;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(160, 315);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 10;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(19, 315);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtServingUnit
            // 
            this.txtServingUnit.Location = new System.Drawing.Point(105, 98);
            this.txtServingUnit.Name = "txtServingUnit";
            this.txtServingUnit.Size = new System.Drawing.Size(100, 20);
            this.txtServingUnit.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Serving unit";
            // 
            // CustomForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(253, 345);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.gboOptional);
            this.Controls.Add(this.gboRequired);
            this.Name = "CustomForm";
            this.Text = "Custom Food";
            this.gboRequired.ResumeLayout(false);
            this.gboRequired.PerformLayout();
            this.gboOptional.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtServingQty;
        private System.Windows.Forms.Label lblServing;
        private System.Windows.Forms.TextBox txtCalories;
        private System.Windows.Forms.Label lblCalories;
        private System.Windows.Forms.TextBox txtBrand;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.GroupBox gboRequired;
        private System.Windows.Forms.GroupBox gboOptional;
        private System.Windows.Forms.FlowLayoutPanel flpNutrition;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtServingUnit;
        private System.Windows.Forms.Label label1;
    }
}