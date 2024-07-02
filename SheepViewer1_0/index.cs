using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SheepViewer1_0
{
    public partial class index : Form
    {
        public index()
        {
            InitializeComponent();
        }

        private void index_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'healthPlanTblDataSet1.healthPlan' table. You can move, or remove it, as needed.
            this.healthPlanTableAdapter.Fill(this.healthPlanTblDataSet1.healthPlan);
            // TODO: This line of code loads data into the 'supplierTblDataSet1.suppliers' table. You can move, or remove it, as needed.
            this.suppliersTableAdapter.Fill(this.supplierTblDataSet1.suppliers);
            // TODO: This line of code loads data into the 'medicinesTblDataSet1.medicines' table. You can move, or remove it, as needed.
            this.medicinesTableAdapter.Fill(this.medicinesTblDataSet1.medicines);
            // TODO: This line of code loads data into the 'medicineDispencedTblDataSet1.medicineDispenced' table. You can move, or remove it, as needed.
            this.medicineDispencedTableAdapter.Fill(this.medicineDispencedTblDataSet1.medicineDispenced);
            // TODO: This line of code loads data into the 'illnessTblDataSet1.illness' table. You can move, or remove it, as needed.
            this.illnessTableAdapter.Fill(this.illnessTblDataSet1.illness);
            // TODO: This line of code loads data into the 'lambingTblDataSet1.lambing' table. You can move, or remove it, as needed.
            this.lambingTableAdapter1.Fill(this.lambingTblDataSet1.lambing);
            // TODO: This line of code loads data into the 'sheepDBDataSet.lambing' table. You can move, or remove it, as needed.
            this.lambingTableAdapter.Fill(this.sheepDBDataSet.lambing);
            // TODO: This line of code loads data into the 'sheepDBDataSet.sheep' table. You can move, or remove it, as needed.
            this.sheepTableAdapter.Fill(this.sheepDBDataSet.sheep);
        }

        private void addSheepToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new sheepInfo().Show();
        }

        private void editSheepToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1[0, dataGridView1.SelectedRows[0].Index].Value != null)
            {
                new sheepInfo(dataGridView1[0, dataGridView1.SelectedRows[0].Index].Value.ToString()).Show();
            }
        }

        private void deleteSheepToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows[0].Index >= 0)
            {
                foreach (DataGridViewRow i in dataGridView1.SelectedRows)
                {
                    var confirmResult = MessageBox.Show("Are you sure that you want to delete this sheep from your records: " + dataGridView1[0, i.Index].Value.ToString() + "??\nYou can instead mark the animal as sold, from the edit sheep menu.\nPress Yes to delete, or No to cancel", "Confirm Delete!!", MessageBoxButtons.YesNo);
                    if (confirmResult == DialogResult.Yes)
                    {
                        dbLink.deleteSheep(dataGridView1[0, i.Index].Value.ToString());
                    }
                }
            }
            else
            {
                MessageBox.Show("You haven't selected a sheep to delete. Select a sheep and then try again.");
            }
        }

        private void addLambingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new lambingInfo().Show();
        }

        private void editLambingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView2[0, dataGridView2.SelectedRows[0].Index].Value != null)
            {
                new lambingInfo(dataGridView2[0, dataGridView2.SelectedRows[0].Index].Value.ToString(), dataGridView2[1, dataGridView2.SelectedRows[0].Index].Value.ToString()).Show();
            }
        }

        private void deleteLambingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows[0].Index >= 0)
            {
                foreach (DataGridViewRow i in dataGridView2.SelectedRows)
                {
                    var confirmResult = MessageBox.Show("Are you sure that you want to delete this lambing from your records: " + dataGridView2[0, i.Index].Value.ToString() + " on " + dataGridView2[1, i.Index].Value.ToString().Split(' ')[0] + "??\nYou can instead edit the lambing.\nPress Yes to delete, or No to cancel", "Confirm Delete!!", MessageBoxButtons.YesNo);
                    if (confirmResult == DialogResult.Yes)
                    {
                        dbLink.deleteLambing(dataGridView2[0, i.Index].Value.ToString(), dataGridView2[1, i.Index].Value.ToString());
                    }
                }
            }
            else
            {
                MessageBox.Show("You haven't selected a lambing to delete. Select a lambing and then try again.");
            }
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            index_Load(null, null);
            filter(null, null);
        }
        
        private void filter(object sender, EventArgs e)
        {
            index_Load(null, null);
            tagNoFilter();
            ownedFilter();
            nameFilter();
            sireFilter();
            damFilter();
            dobFilter();
            sexFilter();
        }

        private void tagNoFilter()
        {
            try
            {
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    if (dataGridView1[0, i].Value.ToString().ToLower().Contains(tagNoFilterInput.Text.ToLower()) == false)
                    {
                        DataGridViewRow dgvDelRow = dataGridView1.Rows[i];
                        dataGridView1.Rows.Remove(dgvDelRow);
                        i = i - 1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex + "");
            }
        }

        private void ownedFilter()
        {
            try
            {
                if (yesOwnedFilterInput.Checked || noOwnedFilterInput.Checked)
                {
                    for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                    {
                        if (dataGridView1[1, i].Value.ToString() != yesOwnedFilterInput.Checked.ToString())
                        {
                            DataGridViewRow dgvDelRow = dataGridView1.Rows[i];
                            dataGridView1.Rows.Remove(dgvDelRow);
                            i = i - 1;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex + "");
            }
        }

        private void nameFilter()
        {
            try
            {
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    if (dataGridView1[2, i].Value.ToString().ToLower().Contains(nameFilterInput.Text.ToLower()) == false)
                    {
                        DataGridViewRow dgvDelRow = dataGridView1.Rows[i];
                        dataGridView1.Rows.Remove(dgvDelRow);
                        i = i - 1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex + "");
            }
        }

        private void sireFilter()
        {
            try
            {
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    if (dataGridView1[3, i].Value.ToString().ToLower().Contains(sireFilterInput.Text.ToLower()) == false)
                    {
                        DataGridViewRow dgvDelRow = dataGridView1.Rows[i];
                        dataGridView1.Rows.Remove(dgvDelRow);
                        i = i - 1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex + "");
            }
        }

        private void damFilter()
        {
            try
            {
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    if (dataGridView1[4, i].Value.ToString().ToLower().Contains(damFilterInput.Text.ToLower()) == false)
                    {
                        DataGridViewRow dgvDelRow = dataGridView1.Rows[i];
                        dataGridView1.Rows.Remove(dgvDelRow);
                        i = i - 1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex + "");
            }
        }

        private void dobFilter()
        {
            try
            {
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    if (dataGridView1[5, i].Value.ToString().ToLower().Contains(dobFilterInput.Text.ToLower()) == false)
                    {
                        DataGridViewRow dgvDelRow = dataGridView1.Rows[i];
                        dataGridView1.Rows.Remove(dgvDelRow);
                        i = i - 1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex + "");
            }
        }

        private void sexFilter()
        {
            try
            {
                if (maleSexFilterInput.Checked || femaleSexFilterInput.Checked)
                {
                    string selectedSex;
                    if (maleSexFilterInput.Checked)
                    {
                        selectedSex = "m";
                    }
                    else
                    {
                        selectedSex = "f";
                    }

                    for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                    {
                        if (dataGridView1[6, i].Value.ToString() != selectedSex)
                        {
                            DataGridViewRow dgvDelRow = dataGridView1.Rows[i];
                            dataGridView1.Rows.Remove(dgvDelRow);
                            i = i - 1;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex + "");
            }
        }

        private void helpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //new help().Show();
            System.Diagnostics.Process.Start("https://aedwardspv.co.uk/sheepServer/index.html");
        }

        private void sheepDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new import().Show();
        }
    }
}
