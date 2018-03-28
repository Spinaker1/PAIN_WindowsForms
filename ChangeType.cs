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
    public partial class ChangeType : PictureBox
    {
        public event EventHandler ChangeTypeEvent;

        private void onChangeTypeEvent()
        {
            //Null check makes sure the main page is attached to the event
            if (this.ChangeTypeEvent != null)
                this.ChangeTypeEvent(this, new EventArgs());
        }

        private Image[] image = new Image[3];

        private VehicleType actualType = VehicleType.PASSENGER;

        public ChangeType()
        {
            try
            { 
                image[0] = Image.FromFile(@"Resources\passenger.png");
                image[1] = Image.FromFile(@"Resources\truck.png");
                image[2] = Image.FromFile(@"Resources\onewheeler.png");
                InitializeComponent();
                Image = image[(int)actualType];
                Click += ChangeType_Click;
            }
            catch (IOException e) { }
        }

        [Editor(typeof(System.Drawing.Design.UITypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        [Category("Type")]
        [Browsable(true)]
        public VehicleType Type
        {
            get { return actualType; }
            set
            {
                this.actualType = value;
                Image = image[(int)actualType];
            }
        }

        private void ChangeType_Click(object sender, EventArgs e)
        {
            actualType = (VehicleType)(((int)((actualType)+1))%3);
            Image = image[(int)actualType];
            onChangeTypeEvent();
        }
    }
}
