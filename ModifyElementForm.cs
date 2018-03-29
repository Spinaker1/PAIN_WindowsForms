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
        }


        private bool Validation()
        {
            string caption = "Invalid data";
            MessageBoxButtons buttons = MessageBoxButtons.OK;

            if (textBox1.Text.Length == 0)
            {
                string message = "Car make should be not empty";
                MessageBox.Show(message, caption, buttons);
                return false;
            }

            if (textBox2.Text.Length == 0)
            {
                string message = "Top speed should be not empty";
                MessageBox.Show(message, caption, buttons);
                return false;
            }

            int x;
            if (!Int32.TryParse(textBox2.Text,out x))
            {
                string message = "Top speed should be integer";
                MessageBox.Show(message, caption, buttons);
                return false;
            }

            if (x <= 0 )
            {
                string message = "Top speed should be positive";
                MessageBox.Show(message, caption, buttons);
                return false;
            }

            if (dateTimePicker1.Value > DateTime.Now)
            {
                string message = "Date cannot be in future";
                MessageBox.Show(message, caption, buttons);
                return false;
            }

            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Validation() ==  false)
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

        private void changeType2_Click(object sender, EventArgs e)
        {

        }
    }
}
