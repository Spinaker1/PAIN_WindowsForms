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
        public DateTime date { get { return dateTimePicker1.Value; }
}

public ModifyElementForm()
        {
            InitializeComponent();
        }

        private void ModifyElement_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
