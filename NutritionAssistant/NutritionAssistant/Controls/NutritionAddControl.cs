using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NutritionAssistant.Controls
{
    public partial class NutritionAddControl : UserControl
    {
        public NutritionAddControl(string property, string unit)
        {
            InitializeComponent();
            lblProperty.Text = property + (string.IsNullOrWhiteSpace(unit) ? "" : " (" + unit + ")");
            txtProperty.Name = "txt" + property.Replace(" ", "");
        }

        public NutritionAddControl(string property, string unit, string value)
        {
            InitializeComponent();
            lblProperty.Text = property + (string.IsNullOrWhiteSpace(unit) ? "" : " (" + unit + ")");
            txtProperty.Text = value;
            txtProperty.Name = "txt" + property.Replace(" ", "");
        }
    }
}
