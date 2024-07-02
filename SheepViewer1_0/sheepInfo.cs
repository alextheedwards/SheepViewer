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
    public partial class sheepInfo : Form
    {
        string source = "";

        public sheepInfo()
        {
            InitializeComponent();
        }

        public sheepInfo(string sheepID)
        {
            InitializeComponent();
            emptyDateTimePicker();

            source = sheepID;

            //populate text boxes in form
            List<string> sheepInfo = dbLink.viewSheep(sheepID);

            if (sheepInfo[0].Length == 14)
            {
                farmNoInput.Text = sheepInfo[0].Substring(0, 9);
                tagNoInput.Text = sheepInfo[0].Substring(9, 5);
            }
            if (sheepInfo[1] == "True")
            {
                ownedInput.Checked = true;
            }
            nameInput.Text = sheepInfo[2];
            if (sheepInfo[3].Length == 14)
            {
                sireFarmNoInput.Text = sheepInfo[3].Substring(0, 8);
                sireTagNoInput.Text = sheepInfo[3].Substring(9, 13);
            }
            if (sheepInfo[3].Length == 14)
            {
                damFarmNoInput.Text = sheepInfo[4].Substring(0, 8);
                damTagNoInput.Text = sheepInfo[4].Substring(9, 13);
            }
            if (sheepInfo[5] != " ")
            {
                dobInput.Checked = true;

                dobInput.Text = sheepInfo[5];
            }
            dobInput.Text = sheepInfo[5];
            if (sheepInfo[6] == "m")
            {
                sexMBtn.Checked = true;
            }
            else if (sheepInfo[6] == "f")
            {
                sexFBtn.Checked = true;
            }
            else
            {
                MessageBox.Show("An unknown error occurred \n #");
            }
        }

        private void emptyDateTimePicker()
        {
            dobInput.Value = DateTime.Now;
            dobInput.ValueChanged += new System.EventHandler(this.Dtp_ValueChanged);
            dobInput.ShowCheckBox = true;
            dobInput.Checked = true;
            dobInput.Checked = false;

            if (dobInput.ShowCheckBox == true)
            {
                if (dobInput.Checked == false)
                {
                    dobInput.CustomFormat = " ";
                    dobInput.Format = DateTimePickerFormat.Custom;
                }
                else
                {
                    dobInput.Format = DateTimePickerFormat.Short;
                }
            }
            else
            {
                dobInput.Format = DateTimePickerFormat.Short;
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (valid())
            {
                string sex;
                if (sexMBtn.Checked)
                {
                    sex = "m";
                }
                else
                {
                    sex = "f";
                }

                if (source != "")
                {
                    if (source == farmNoInput.Text + tagNoInput.Text)
                    {
                        dbLink.editSheep(farmNoInput.Text + tagNoInput.Text, ownedInput.Checked.ToString(), nameInput.Text, sireFarmNoInput.Text + sireTagNoInput.Text, damFarmNoInput.Text + damTagNoInput.Text, dobInput.Text, sex);
                        Close();
                    }
                    else
                    {
                        var confirmResult = MessageBox.Show("Are you sure that you want to change this sheep's tag number from: " + source + " to " + tagNoInput.Text + farmNoInput.Text + "??\nTo go back to the form press Cancel, to reset the tag number and return to the form, press No, or to continue, press Yes.", "Confirm Delete!!", MessageBoxButtons.YesNoCancel);
                        if (confirmResult == DialogResult.Yes)
                        {
                            dbLink.deleteSheep(source);
                            dbLink.saveSheep(farmNoInput.Text + tagNoInput.Text, ownedInput.Checked.ToString(), nameInput.Text, sireFarmNoInput.Text + sireTagNoInput.Text, damFarmNoInput.Text + damTagNoInput.Text, dobInput.Text, sex);
                            Close();
                        }
                        if (confirmResult == DialogResult.No)
                        {
                            string resetTagNo = dbLink.viewSheep(source)[0];
                            if (resetTagNo.Length == 14)
                            {
                                farmNoInput.Text = resetTagNo.Substring(0, 9);
                                tagNoInput.Text = resetTagNo.Substring(9, 5);
                            }
                        }
                        if (confirmResult == DialogResult.Cancel)
                        {
                            Close();
                        }
                    }
                }
                else
                {
                    dbLink.saveSheep(farmNoInput.Text + tagNoInput.Text, ownedInput.Checked.ToString(), nameInput.Text, sireFarmNoInput.Text + sireTagNoInput.Text, damFarmNoInput.Text + damTagNoInput.Text, dobInput.Text, sex);
                    Close();
                }
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        void Dtp_ValueChanged(object sender, EventArgs e)
        {
            if (((DateTimePicker)sender).ShowCheckBox == true)
            {
                if (((DateTimePicker)sender).Checked == false)
                {
                    ((DateTimePicker)sender).CustomFormat = " ";
                    ((DateTimePicker)sender).Format = DateTimePickerFormat.Custom;
                }
                else
                {
                    ((DateTimePicker)sender).Format = DateTimePickerFormat.Short;
                }
            }
            else
            {
                ((DateTimePicker)sender).Format = DateTimePickerFormat.Short;
            }
        }

        private bool valid()
        {
            bool valid = true;
            string detail = "The following information was invalid:";
            if(farmNoInput.Text == "")
            {
                valid = false;
                detail += "\nFarm Number (input cannot be empty)";
            }
            if(tagNoInput.Text == "")
            {
                valid = false;
                detail += "\nTag Number (input cannot be empty)";
            }
            //ownedInput does not require validation as there are only two possible states
            //if(nameInput.Text == "")
            //{
            //    valid = false;
            //}
            //if (damFarmNoInput.Text == "")
            //{
            //    valid = false;
            //}
            //if (damTagNoInput.Text == "")
            //{
            //    valid = false;
            //}
            //if (sireFarmNoInput.Text == "")
            //{
            //    valid = false;
            //}
            //if (sireTagNoInput.Text == "")
            //{
            //    valid = false;
            //}
            //dobInput does not require validation as it is built in to the function
            if(sexFBtn.Checked == false && sexMBtn.Checked == false)
            {
                valid = false;
                detail += "\nSex (at least one option must be selected)";
            }
            if (!valid) { MessageBox.Show(detail, "Invalid Information"); }
            return valid;
        }
    }
}
