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
    public partial class MainForm : Form
    {
        private List<View> views = new List<View>();
        private List<Vehicle> model = new List<Vehicle>();

        public MenuStrip menuStrip
        {
            get { return this.menuStrip1; }
        }

        public StatusStrip statusStrip
        {
            get { return this.statusStrip1; }
        }

        public int formsCount { get; set; }

        public MainForm()
        {
            InitializeComponent();
            IsMdiContainer = true;
            formsCount = 0;
        }

        public void addVehicle()
        {
            ModifyElementForm form = new ModifyElementForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                Vehicle v = new Vehicle(form.CarMake, form.TopSpeed, form.date, VehicleType.PASSENGER);
                foreach (ListForm view in views)
                {
                    view.addItem(v);
                }
                model.Add(v);
            }
        }

        public void deleteVehicle(Vehicle v)
        {
            foreach (ListForm view in views)
            {
                view.DeleteItem(v);
            }
            model.Remove(v);
        }

        private void createChildForm()
        {
            formsCount++;
            ListForm view = new ListForm();
            view.MdiParent = this;
            view.Show();
            views.Add(view);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            createChildForm();
        }

        private void newViewToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            createChildForm();
        }
    }
}
