using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SheepViewer1_0
{
    public partial class import : Form
    {
        public import()
        {
            InitializeComponent();

            //Allows the user to select a row
            importView.View = View.Details;
            importView.FullRowSelect = true;

            //Creates columns
            importView.Columns.Add("TagNo", -2, HorizontalAlignment.Left);
            importView.Columns.Add("Owned", -2, HorizontalAlignment.Left);
            importView.Columns.Add("Name", -2, HorizontalAlignment.Left);
            importView.Columns.Add("Sire", -2, HorizontalAlignment.Left);
            importView.Columns.Add("Dam", -2, HorizontalAlignment.Left);
            importView.Columns.Add("Dob", -2, HorizontalAlignment.Left);
            importView.Columns.Add("Sex", -2, HorizontalAlignment.Left);
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void importBtn_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < importView.Items.Count; i++)
                {
                    dbLink.saveSheep(importView.Items[i].SubItems[0].Text, importView.Items[i].SubItems[1].Text, importView.Items[i].SubItems[2].Text, importView.Items[i].SubItems[3].Text, importView.Items[i].SubItems[4].Text, importView.Items[i].SubItems[5].Text, importView.Items[i].SubItems[6].Text);
                }
                MessageBox.Show("Items Imported");
                Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("We were unable to import this data:\n" + ex);
            }
        }

        private void open_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string file = openFileDialog1.FileName;
                try
                {
                    string[] lines = File.ReadAllLines(file);
                    foreach (string line in lines)
                    {
                        //Adds a row to the listview
                        string[] arr = new string[8];
                        ListViewItem itm;
                        string tagNo = line.Split(',')[1];
                        while (tagNo.Length < 5)
                        {
                            tagNo = "0" + tagNo;
                        }
                        arr[0] = line.Split(',')[0] + tagNo;
                        arr[1] = line.Split(',')[2];
                        arr[2] = line.Split(',')[3];
                        arr[3] = line.Split(',')[4];
                        arr[4] = line.Split(',')[5];
                        arr[5] = line.Split(',')[6];
                        arr[6] = line.Split(',')[7];
                        itm = new ListViewItem(arr);
                        importView.Items.Add(itm);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex);
                }
                importView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                importView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
        }

        private void deleteRow_Click(object sender, EventArgs e)
        {

        }
    }
}
