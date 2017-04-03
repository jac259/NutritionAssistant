namespace NutritionAssistant.Controls
{
    partial class NutritionAddControl
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
            this.lblProperty = new System.Windows.Forms.Label();
            this.txtProperty = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblProperty
            // 
            this.lblProperty.Location = new System.Drawing.Point(3, 0);
            this.lblProperty.Name = "lblProperty";
            this.lblProperty.Size = new System.Drawing.Size(87, 21);
            this.lblProperty.TabIndex = 0;
            this.lblProperty.Text = "property (unit)";
            this.lblProperty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtProperty
            // 
            this.txtProperty.Location = new System.Drawing.Point(95, 0);
            this.txtProperty.Name = "txtProperty";
            this.txtProperty.Size = new System.Drawing.Size(90, 20);
            this.txtProperty.TabIndex = 1;
            // 
            // NutritionAddControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtProperty);
            this.Controls.Add(this.lblProperty);
            this.Name = "NutritionAddControl";
            this.Size = new System.Drawing.Size(185, 21);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblProperty;
        private System.Windows.Forms.TextBox txtProperty;
    }
}
