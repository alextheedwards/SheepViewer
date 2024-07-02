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
    public partial class lambingInfo : Form
    {
        //string source = "";
        string[] source = new string[2];

        public lambingInfo()
        {
            InitializeComponent();
        }

        public lambingInfo(string tagNo, string dob)
        {
            InitializeComponent();
            emptyDateTimePicker();

            source[0] = tagNo;
            source[1] = dob;

            //populate text boxes in form
            List<string> lambingInfo = dbLink.viewLambing(tagNo,dob);

            if (lambingInfo[0].Length == 14)
            {
                farmNoInput.Text = lambingInfo[0].Substring(0, 9);
                tagNoInput.Text = lambingInfo[0].Substring(9, 5);
            }
            if (lambingInfo[1] != " ")
            {
                dobInput.Checked = true;
                dobInput.Text = lambingInfo[1];
            }
            for (int i = 2; i < lambingInfo.Count; i++)
            {
                if (lambingInfo[i].Length == 14)
                {
                    string lambFarmNoTextBox = "lambFarmNoInput" + (i-1);
                    Control ctn1 = this.Controls[lambFarmNoTextBox];
                    ctn1.Text = lambingInfo[i].Substring(0, 9);

                    string lambTagNoTextBox = "lambTagNoInput" + (i - 1);
                    Control ctn2 = this.Controls[lambTagNoTextBox];
                    ctn2.Text = lambingInfo[i].Substring(9, 5);
                }
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
                if (source[0] != "")
                {
                    dbLink.deleteLambing(farmNoInput.Text + tagNoInput.Text, dobInput.Text);
                    dbLink.saveLambing(farmNoInput.Text + tagNoInput.Text, dobInput.Text, lambFarmNoInput1.Text + lambTagNoInput1.Text);
                    if (lambTagNoInput2.Text != "")
                    {
                        dbLink.saveLambing(farmNoInput.Text + tagNoInput.Text, dobInput.Text, lambFarmNoInput2.Text + lambTagNoInput2.Text);
                    }
                    if (lambTagNoInput3.Text != "")
                    {
                        dbLink.saveLambing(farmNoInput.Text + tagNoInput.Text, dobInput.Text, lambFarmNoInput3.Text + lambTagNoInput3.Text);
                    }
                    if (lambTagNoInput4.Text != "")
                    {
                        dbLink.saveLambing(farmNoInput.Text + tagNoInput.Text, dobInput.Text, lambFarmNoInput4.Text + lambTagNoInput4.Text);
                    }
                    Close();
                }
                else
                {
                    dbLink.saveLambing(farmNoInput.Text + tagNoInput.Text, dobInput.Text, lambFarmNoInput1.Text + lambTagNoInput1.Text);
                    if (lambTagNoInput2.Text != "")
                    {
                        dbLink.saveLambing(farmNoInput.Text + tagNoInput.Text, dobInput.Text, lambFarmNoInput2.Text + lambTagNoInput2.Text);
                    }
                    if (lambTagNoInput3.Text != "")
                    {
                        dbLink.saveLambing(farmNoInput.Text + tagNoInput.Text, dobInput.Text, lambFarmNoInput3.Text + lambTagNoInput3.Text);
                    }
                    if (lambTagNoInput4.Text != "")
                    {
                        dbLink.saveLambing(farmNoInput.Text + tagNoInput.Text, dobInput.Text, lambFarmNoInput4.Text + lambTagNoInput4.Text);
                    }
                    Close();
                }
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Dtp_ValueChanged(object sender, EventArgs e)
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
            if (farmNoInput.Text == "")
            {
                valid = false;
                detail += "\nFarm Number (input cannot be empty)";
            }
            if (tagNoInput.Text == "")
            {
                valid = false;
                detail += "\nTag Number (input cannot be empty)";
            }
            if (dobInput.Text == "")
            {
                valid = false;
                detail += "\nDate Of Lambing (input cannot be empty)";
            }
            if (lambFarmNoInput1.Text == "")
            {
                valid = false;
                detail += "\nLamb Farm Number (at least 1 lamb must be born)";
            }
            if (lambTagNoInput1.Text == "")
            {
                valid = false;
                detail += "\nLamb Tag Number (at least 1 lamb must be born)";
            }
            if (!valid) { MessageBox.Show(detail, "Invalid Information"); }
            return valid;
        }
    }
}
