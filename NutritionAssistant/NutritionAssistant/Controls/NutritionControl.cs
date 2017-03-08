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
    public partial class NutritionControl : UserControl
    {
        double baseValue, scale;
        string units, name;

        public NutritionControl(string _name, double _baseValue, double _scale, string _units)
        {
            name = _name;
            baseValue = _baseValue;
            scale = _scale;
            units = _units;

            InitializeComponent();

            SetName(name);
            UpdateValue(_scale);
        }

        public void UpdateValue(double _scale)
        {
            scale = _scale;
            SetValue((baseValue * scale).ToString() + " " + units);
        }

        public void SetValue(string value)
        {
            lblValue.Text = value;
        }

        public void SetName(string value)
        {
            lblName.Text = value;
        }
    }
}
