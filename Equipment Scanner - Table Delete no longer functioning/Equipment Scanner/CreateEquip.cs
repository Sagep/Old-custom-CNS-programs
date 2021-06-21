using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Equipment_Scanner
{
    public partial class CreateEquip : Form
    {
        string tagids;
        public CreateEquip(string tagid)
        {
            InitializeComponent();
            tagids = tagid;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label11.Text = tagids;
            textBox2.Text = "Office";
            textBox3.Text = "Office";
            textBox4.Text = "Grand Junction";
            comboBox3.SelectedItem = "CO";
            textBox5.Text = "81501";
            comboBox1.SelectedItem = "Active";
            comboBox2.SelectedItem = "Tablet";
            checkBox2.Checked = true;
            Office.Checked = true;
        }

        private void CheckBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = true;
                label15.Visible = false;
                textBox6.Visible = false;
            }
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                checkBox1.Checked = true;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                label15.Visible = false;
                textBox6.Visible = false;
            }
        }

        private void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                checkBox1.Checked = false;
                checkBox2.Checked = true;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                label15.Visible = false;
                textBox6.Visible = false;
            }
        }

        private void CheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = true;
                checkBox4.Checked = false;
                label15.Visible = true;
                textBox6.Visible = true;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == ""||textBox2.Text==""||comboBox3.Text==""||comboBox2.Text=="")
            {
                MessageBox.Show("Error! Please fill in all details!");
            }
            else
            {
                ELSCDataContext newequip = new ELSCDataContext();

                char temp = ' ';

                if (comboBox1.Text.ToString() == "Active")
                    temp = 'A';
                if (comboBox1.Text.ToString() == "Disabled")
                    temp = 'D';
                if (comboBox1.Text.ToString() == "Suspended")
                    temp = 'S';
                bool patient = false;
                bool office = false;

                if (radioButton1.Checked && !Office.Checked)
                    patient = true;
                else if (radioButton2.Checked && !Office.Checked)
                    patient = false;
                else if (Office.Checked)
                {
                    patient = false;
                    office = true;
                }

                if (checkBox3.Checked)
                {
                    string software = "";
                    software = textBox6.Text.Replace(", ", ",");
                    software += ",";

                    if (textBox6.Text == "")
                    {
                        MessageBox.Show("Error! Please fill in software details");
                    }
                    else
                    {
                        Equipment inf = new Equipment
                        {
                            TagID = tagids,
                            SerialNumber = textBox1.Text.ToString(),
                            Type = comboBox2.Text.ToString(),
                            CurrentAssignee = textBox2.Text.ToString(),
                            CurrentLocation = textBox3.Text.ToString()+" "+ textBox4.Text.ToString()+", "+comboBox3.Text.ToString()+" "+textBox5.Text.ToString(),
                            BitlockerStatus = temp,
                            DateEncryptionChecked = DateTime.Now,
                            Destroyed = false,
                            IsPatient = patient,
                            Installed_Software = software,
                            Address = textBox3.Text,
                            City = textBox4.Text,
                            State = comboBox3.Text,
                            ZIP = textBox5.Text,
                            Office = office
                        };
                        newequip.Equipments.InsertOnSubmit(inf);
                        var r = from i in newequip.Equipments
                                select i;

                        bool caught = false;

                        foreach (var x in r)
                        {
                            if (x.TagID.ToString() == tagids)
                            {
                                MessageBox.Show("Error! Unable to save. The tag ID matches another device. " + tagids);
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
                    if (checkBox4.Checked)
                    {
                        software = "Mobile Iron Go,";
                    }
                    if (checkBox1.Checked)
                    {
                        software = "Adobe Reader,Microsoft Office,GFI Faxmaker Client,Event Sentry Agent,SolarWinds Windows Agent,Cisco Any Connect,Trend Micro,Google Chrome,Lenovo System Update,CNS IT Ticketing System,Windows 10 Update Assistant,";
                    }
                    if (checkBox2.Checked)
                    {
                        software = "Mobile Iron Go,ISL Light,Red Cross First Aid,";
                    }
                    Equipment inf = new Equipment
                    {
                        TagID = tagids,
                        SerialNumber = textBox1.Text.ToString(),
                        Type = comboBox2.Text.ToString(),
                        CurrentAssignee = textBox2.Text.ToString(),
                        CurrentLocation = textBox3.Text.ToString() + " " + textBox4.Text.ToString() + ", " + comboBox3.Text.ToString() + " " + textBox5.Text.ToString(),
                        BitlockerStatus = temp,
                        DateEncryptionChecked = DateTime.Now,
                        Destroyed = false,
                        IsPatient = patient,
                        Installed_Software = software,
                        Address = textBox3.Text,
                        City = textBox4.Text,
                        State = comboBox3.Text,
                        ZIP = textBox5.Text,
                        Office = office
                    };
                    newequip.Equipments.InsertOnSubmit(inf);

                    var r = from i in newequip.Equipments
                            select i;

                    bool caught = false;

                    foreach (var x in r)
                    {
                        if (x.TagID.ToString() == tagids)
                        {
                            MessageBox.Show("Error! Unable to save. The tag ID matches another device. " + tagids);
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
        }

        private void Office_CheckedChanged(object sender, EventArgs e)
        {
            if(Office.Checked)
            {
                label4.Visible = false;
                label5.Visible = false;
                label8.Visible = false;
                textBox2.Visible = false;
                textBox3.Visible = false;
                textBox5.Visible = false;
            }
            else
            {
                label4.Visible = true;
                label5.Visible = true;
                label8.Visible = true;
                textBox2.Visible = true;
                textBox3.Visible = true;
                textBox5.Visible = true;
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
