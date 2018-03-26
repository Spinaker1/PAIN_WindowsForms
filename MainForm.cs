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

        private void createChildForm()
        {
            formsCount++;
            ListForm view = new ListForm();
            view.MdiParent = this;
            view.Show();
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
