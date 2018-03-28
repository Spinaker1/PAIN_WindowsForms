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
    public partial class ListForm : View
    {
        private enum Condition { NO_FILTER, L100, EG100 };

        public ListForm()
        {
            FormClosing += ListForm_Closing;
            Enter += ListForm_Enter;
            Leave += ListForm_Leave;
            InitializeComponent();
            toolStripStatusLabel1.Text = listView1.Items.Count.ToString();
        }

        public void addItem(Vehicle v)
        {
            string[] row = { v.carMake, v.topSpeed.ToString(), v.date.ToShortDateString(), v.type.ToString() };
            ListViewItem item = new ListViewItem(row);
            item.Tag = v;
            listView1.Items.Add(item);
            toolStripStatusLabel1.Text = listView1.Items.Count.ToString();
        }

        public void updateItem(Vehicle v)
        {
            ListViewItem itemToUpdate = null;
            foreach (ListViewItem item in listView1.Items)
            {
                if (item.Tag == v)
                {
                    itemToUpdate = item;
                }
            }

            if (itemToUpdate == null)
            {
                addItem(v);
            }
            else
            {
                string[] row = { v.carMake, v.topSpeed.ToString(), v.date.ToShortDateString(), v.type.ToString() };
                for (int i = 0; i < row.Length; i++)
                {
                    itemToUpdate.SubItems[i].Text = row[i];
                }
            }
        }

        public void DeleteItem(Vehicle v)
        {
            foreach (ListViewItem item in listView1.Items)
            {
                if (item.Tag == v)
                {
                    listView1.Items.Remove(item);
                    toolStripStatusLabel1.Text = listView1.Items.Count.ToString();
                    return;
                }
            }
        }

        private void ListForm_Closing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.MdiFormClosing && ((MainForm)MdiParent).formsCount <= 1)
            {
                e.Cancel = true;
            }
            else
            {
                ((MainForm)MdiParent).formsCount--;
            }
        }

        private void ListForm_Enter(Object sender, EventArgs e)
        {
            ToolStripManager.Merge(menuStrip1, ((MainForm)MdiParent).menuStrip);
            ToolStripManager.Merge(statusStrip1, ((MainForm)MdiParent).statusStrip);
            toolStripStatusLabel1.Text = listView1.Items.Count.ToString();
        }

        private void ListForm_Leave(Object sender, EventArgs e)
        {
            ToolStripManager.RevertMerge(((MainForm)MdiParent).menuStrip, menuStrip1);
            ToolStripManager.RevertMerge(((MainForm)MdiParent).statusStrip, statusStrip1);
            toolStripStatusLabel1.Text = "";
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ((MainForm)MdiParent).addVehicle();
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                Vehicle v = (Vehicle)listView1.SelectedItems[0].Tag;
                ((MainForm)MdiParent).deleteVehicle(v);
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                Vehicle v = (Vehicle)listView1.SelectedItems[0].Tag;
                ((MainForm)MdiParent).updateVehicle(v);
            }
        }

        private void RefreshList(Condition cond)
        {
            this.listView1.Items.Clear();

            List<Vehicle> model = ((MainForm)MdiParent).Model;
            foreach (Vehicle v in model) {
                switch(cond)
                {
                    case Condition.NO_FILTER:
                        addItem(v);
                        break;

                    case Condition.L100:
                        if (v.topSpeed < 100)
                            addItem(v);
                        break;

                    case Condition.EG100:
                        if (v.topSpeed >= 100)
                            addItem(v);
                        break;
                }
            }

            toolStripStatusLabel1.Text = listView1.Items.Count.ToString();
        }

        private void noFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefreshList(Condition.NO_FILTER);
        }

        private void lessThan100KmhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefreshList(Condition.L100);
        }

        private void moreOrEqual100KmhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefreshList(Condition.EG100);
        }
    }
}
