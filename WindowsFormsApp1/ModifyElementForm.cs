using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class ModifyElementForm : Form
    {
        public string CarMake { get { return textBox1.Text; } }
        public int TopSpeed { get { return Int32.Parse(textBox2.Text); } }
        public DateTime date { get { return dateTimePicker1.Value; } }
        public VehicleType Type { get { return changeType2.Type; } }

        private ErrorProvider errorProvider = new ErrorProvider();

        public ModifyElementForm()
        {
            InitializeComponent();

            textBox3.Text = Type.ToString();
            this.changeType2.ChangeTypeEvent += new EventHandler(UserControl_ChangeType);
            setValidation();
        }

        public ModifyElementForm(Vehicle v)
        {
            InitializeComponent();
            textBox1.Text = v.carMake;
            textBox2.Text = v.topSpeed.ToString();
            dateTimePicker1.Value = v.date;
            changeType2.Type = v.type;

            textBox3.Text = Type.ToString();          
            this.changeType2.ChangeTypeEvent += new EventHandler(UserControl_ChangeType);
            setValidation();
        }

        private void setValidation()
        {
            this.AutoValidate = AutoValidate.EnableAllowFocusChange;

            textBox1.Validating += new CancelEventHandler(textBox1_Validating);
            textBox2.Validating += new CancelEventHandler(textBox2_Validating);
            dateTimePicker1.Validating += new CancelEventHandler(dateTimePicker1_Validating);

            textBox1.Validated += textBox1_Validated;
            textBox2.Validated += textBox2_Validated;
            dateTimePicker1.Validated += dateTimePicker1_Validated;
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (textBox1.Text.Length == 0)
            {
                e.Cancel = true;
                errorProvider.SetError(textBox1, "Car make should be not empty");
            }
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            if (textBox2.Text.Length == 0)
            {
                e.Cancel = true;
                errorProvider.SetError(textBox2, "Top speed should be not empty");
                return;
            }

            int x;
            if (!Int32.TryParse(textBox2.Text, out x))
            {
                e.Cancel = true;
                errorProvider.SetError(textBox2, "Top speed should be integer");
                return;
            }

            if (x <= 0)
            {
                e.Cancel = true;
                errorProvider.SetError(textBox2, "Top speed should be positive");
                return;
            }
        }

        private void dateTimePicker1_Validating(object sender, CancelEventArgs e)
        {
            if (dateTimePicker1.Value > DateTime.Now)
            {
                e.Cancel = true;
                errorProvider.SetError(dateTimePicker1, "Date cannot be in future");
            }
        }

        private void textBox1_Validated(object sender, EventArgs e)
        {
            errorProvider.SetError(textBox1, "");
        }

        private void textBox2_Validated(object sender, EventArgs e)
        {
            errorProvider.SetError(textBox2, "");
        }

        private void dateTimePicker1_Validated(object sender, EventArgs e)
        {
            errorProvider.SetError(dateTimePicker1, "");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ValidateChildren() ==  false)
            {
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void UserControl_ChangeType(object sender, EventArgs e)
        {
            textBox3.Text = Type.ToString();
        }
    }
}
