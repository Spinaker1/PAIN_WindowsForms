using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace WindowsFormsApp1
{
    public partial class ChangeType : UserControl
    {
        private Image[] image = new Image[3];

        private VehicleType actualType = VehicleType.PASSENGER;

        public ChangeType()
        {
            image[0] = Image.FromFile(@"Resources\passenger.png");
            image[1] = Image.FromFile(@"Resources\truck.png");
            image[2] = Image.FromFile(@"Resources\onewheeler.png");
            InitializeComponent();
            pictureBox1.Image = image[(int)actualType];
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            actualType = (VehicleType)(((int)((actualType)+1))%3);
            pictureBox1.Image = image[(int)actualType];
        }
    }
}
