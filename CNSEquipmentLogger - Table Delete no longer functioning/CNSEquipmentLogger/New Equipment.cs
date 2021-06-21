using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CNSEquipmentLogger
{
    public partial class Form2 : Form
    {
        Form1 _owner;
        public Form2(Form1 owner)
        {
            InitializeComponent();
            _owner = owner;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
        }

        string oldadd = "";
        string oldAss = "";
        string oldzip = "";

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            _owner.reloaddata();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            infoAssignee.Text = "IT Team";
            infoLoc.Text = "1114 North 1st Street Grand Junction, CO 81501";
            Address.Text = "1114 North 1st Street";
            City.Text = "Grand Junction";
            comboBox3.Text = "CO";
            ZIP.Text = "81501";
            checkBox2.Checked = true;
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            Office.Checked = true;
            Address_Leave(this, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (infoTagID.Text != "" && infoSN.Text != "" && comboBox2.Text != "" && infoAssignee.Text != ""&&infoLoc.Text != "")
            {


                EquipInfoDataContext newequip = new EquipInfoDataContext();

                char temp = ' ';

                if (comboBox1.Text.ToString() == "Active")
                    temp = 'A';
                if (comboBox1.Text.ToString() == "Disabled")
                    temp = 'D';
                if (comboBox1.Text.ToString() == "Suspended")
                    temp = 'S';
                bool patient = false;
                bool office = false;

                if (radioButton1.Checked&&!Office.Checked)
                    patient = true;
                else if (radioButton2.Checked&&!Office.Checked)
                    patient = false;
                else if(Office.Checked)
                {
                    patient = false;
                    office = true;
                }

                if (checkBox3.Checked)
                {
                    string software = "";
                    software = textBox1.Text.Replace(", ", ",");
                    software += ",";

                    string addcnstotag = "";
                    if(!infoTagID.Text.Contains("CNS"))
                    {
                        addcnstotag = "CNS-";
                    }

                    if (textBox1.Text == "")
                    {
                        MessageBox.Show("Error! Please fill in software details");
                    }
                    else
                    {
                        Equipment inf = new Equipment
                        {
                            TagID = addcnstotag + infoTagID.Text.ToString(),
                            SerialNumber = infoSN.Text.ToString(),
                            Type = comboBox2.Text.ToString(),
                            CurrentAssignee = infoAssignee.Text.ToString(),
                            CurrentLocation = infoLoc.Text.ToString(),
                            BitlockerStatus = temp,
                            DateEncryptionChecked = DateTime.Now,
                            Destroyed = false,
                            IsPatient = patient,
                            Installed_Software = software,
                            Address = Address.Text,
                            City = City.Text,
                            State = comboBox3.Text,
                            ZIP = ZIP.Text,
                            Office = office,
                            DatePurchased = dateTimePicker1.Value.Date,
                            PurchasePrice = textBox4.Text,
                            Vendor = textBox2.Text
                        };
                        newequip.Equipments.InsertOnSubmit(inf);
                        var r = from i in newequip.Equipments
                                select i;

                        bool caught = false;

                        foreach (var x in r)
                        {
                            if (x.TagID.ToString() == infoTagID.Text)
                            {
                                MessageBox.Show("Error! Unable to save. The tag ID matches another device. " + infoTagID.Text);
                                caught = true;
                            }
                        }
                        if (caught == false)
                        {
                            newequip.SubmitChanges();
                            this.Close();
                        }
                    }
                }
                else
                {
                    string software = "";
                    if(checkBox4.Checked)
                    {
                        software = "Mobile Iron Go,";
                    }
                    if(checkBox1.Checked)
                    {
                        software = "Adobe Reader,Microsoft Office,GFI Faxmaker Client,Event Sentry Agent,SolarWinds Windows Agent,Cisco Any Connect,Trend Micro,Google Chrome,Lenovo System Update,CNS IT Ticketing System,Windows 10 Update Assistant,";
                    }
                    if(checkBox2.Checked)
                    {
                        software = "Mobile Iron Go,ISL Light,Red Cross First Aid,";
                    }
                    if(checkBox5.Checked)
                    {
                        software = "NA";
                    }
                    Equipment inf = new Equipment
                    {
                        TagID = "CNS-"+infoTagID.Text.ToString(),
                        SerialNumber = infoSN.Text.ToString(),
                        Type = comboBox2.Text.ToString(),
                        CurrentAssignee = infoAssignee.Text.ToString(),
                        CurrentLocation = infoLoc.Text.ToString(),
                        BitlockerStatus = temp,
                        DateEncryptionChecked = DateTime.Now,
                        Destroyed = false,
                        IsPatient = patient,
                        Installed_Software = software,
                        Address = Address.Text,
                        City = City.Text,
                        State = comboBox3.Text,
                        ZIP = ZIP.Text,
                        Office = office,
                        DatePurchased = dateTimePicker1.Value.Date,
                        PurchasePrice = textBox4.Text,
                        Vendor = textBox2.Text
                    };
                    newequip.Equipments.InsertOnSubmit(inf);

                    var r = from i in newequip.Equipments
                            select i;

                    bool caught = false;

                    foreach (var x in r)
                    {
                        if (x.TagID.ToString() == infoTagID.Text)
                        {
                            MessageBox.Show("Error! Unable to save. The tag ID matches another device. "+infoTagID.Text);
                            caught = true;
                        }
                    }
                    if (caught == false)
                    {
                        newequip.SubmitChanges();
                        this.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please fill in all details");
            }
        }


        //Software Logs

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = true;
                checkBox4.Checked = false;
                checkBox5.Checked = false;
                label10.Visible = true;
                textBox1.Visible = true;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                checkBox1.Checked = false;
                checkBox2.Checked = true;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox5.Checked = false;
                label10.Visible = false;
                textBox1.Visible = false;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                checkBox1.Checked = true;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox5.Checked = false;
                label10.Visible = false;
                textBox1.Visible = false;
            }
        }

        private void label12_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This contains the following applications:\r\n\r\nMobile Iron Go");
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = true;
                checkBox5.Checked = false;
                label10.Visible = false;
                textBox1.Visible = false;
            }
        }

        private void CheckBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked)
            {
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox5.Checked = true;
                label10.Visible = false;
                textBox1.Visible = false;
            }
        }

        private void label8_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("This contains the following applications:\r\n\r\nAdobe Reader\r\nMicrosoft Office\r\nGFI Faxmaker Client\r\nEvent Sentry Agent\r\nSolarWinds Windows Agent\r\nCisco Any Connect\r\nTrend Micro\r\nGoogle Chrome\r\nLenovo System Update\r\nCNS IT Ticketing System");
        }

        private void label9_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("This contains the following applications:\r\n\r\nMobile Iron Go\r\nISL Light\r\nRed Cross First Aid");
        }

        private void Address_Leave(object sender, EventArgs e)
        {
            infoLoc.Text = Address.Text+" "+City.Text+", "+comboBox3.Text+" "+ZIP.Text;
            if (Address.Text == "Office")
            {
                infoLoc.Text = City.Text + ", " + comboBox3.Text;
            }
        }

        private void City_Leave(object sender, EventArgs e)
        {
            infoLoc.Text = Address.Text + " " + City.Text + ", " + comboBox3.Text + " " + ZIP.Text;
            if (Address.Text == "Office")
            {
                infoLoc.Text = City.Text + ", " + comboBox3.Text;
            }
        }

        private void ComboBox3_Leave(object sender, EventArgs e)
        {
            infoLoc.Text = Address.Text + " " + City.Text + ", " + comboBox3.Text + " " + ZIP.Text;
            if (Address.Text == "Office")
            {
                infoLoc.Text = City.Text + ", " + comboBox3.Text;
            }
        }

        private void ZIP_Leave(object sender, EventArgs e)
        {
            infoLoc.Text = Address.Text + " " + City.Text + ", " + comboBox3.Text + " " + ZIP.Text;
            if (Address.Text == "Office")
            {
                infoLoc.Text = City.Text + ", " + comboBox3.Text;
            }
        }

        private void Office_CheckedChanged(object sender, EventArgs e)
        {
            if (Office.Checked)
            {
                oldadd = Address.Text;
                oldAss = infoAssignee.Text;
                oldzip = ZIP.Text;
                Address.Text = "Office";
                infoAssignee.Text = "Office";
                ZIP.Text = "Office";
                label1.Visible = false;
                label11.Visible = false;
                label15.Visible = false;
                infoAssignee.Visible = false;
                Address.Visible = false;
                ZIP.Visible = false;
            }
            else
            {
                Address.Text = oldadd;
                infoAssignee.Text = oldAss;
                ZIP.Text = oldzip;
                infoAssignee.Visible = true;
                Address.Visible = true;
                ZIP.Visible = true;
                label1.Visible = true;
                label11.Visible = true;
                label15.Visible = true;
            }
        }

    }
}
