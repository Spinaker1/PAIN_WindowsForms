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
        public ListForm()
        {
            FormClosing += ListForm_Closing;
            Enter += ListForm_Enter;
            Leave += ListForm_Leave;
            InitializeComponent();
        }

        private void ListForm_Load(object sender, EventArgs e)
        {

        }

        public void addItem(Vehicle v)
        {
            string[] row = { v.carMake, v.topSpeed.ToString(), v.date.ToShortDateString(), v.type.ToString() };
            ListViewItem item = new ListViewItem(row);
            item.Tag = v;
            listView1.Items.Add(item);
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
            
        }

        private void ListForm_Leave(Object sender, EventArgs e)
        {
            ToolStripManager.RevertMerge(((MainForm)MdiParent).menuStrip, menuStrip1);
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
    }
}
