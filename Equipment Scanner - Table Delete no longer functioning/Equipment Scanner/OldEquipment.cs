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
    public partial class OldEquipment : Form
    {

        private string infoLoc = "";
        string tagids;
        public OldEquipment(string tagid)
        {
            InitializeComponent();
            tagids = tagid;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            textBox1.ReadOnly = true;
            comboBox2.Enabled = false;
            textBox6.Visible = true;
            ELSCDataContext equipment = new ELSCDataContext();

            var r = from i in equipment.Equipments
                    where i.TagID.ToString() == tagids
                    select i;

            foreach (var eq in r)
            {

                if (eq.Destroyed == true)
                    label6.Text = "DESTROYED";
                textBox2.Text = eq.CurrentAssignee;
                if (eq.BitlockerStatus == 'A')
                {
                    comboBox1.SelectedIndex = 0;
                }
                if (eq.BitlockerStatus == 'D')
                {
                    comboBox1.SelectedIndex = 1;
                }
                if (eq.BitlockerStatus == 'S')
                {
                    comboBox1.SelectedIndex = 2;
                }
                textBox3.Text = eq.Address;
                textBox4.Text = eq.City;
                comboBox3.Text = eq.State;
                textBox5.Text = eq.ZIP;

                label11.Text = eq.TagID;
                textBox1.Text = eq.SerialNumber;
                comboBox2.SelectedItem = eq.Type.ToString();
                
                if (eq.IsPatient == true)
                {
                    radioButton1.Checked = true;
                }
                else if (eq.Office == true && eq.IsPatient == false)
                {
                    Office.Checked = true;
                }
                else
                {
                    radioButton2.Checked = true;
                }
                textBox6.Text = eq.Installed_Software;
            }
        }

        //fix me
        private void Button1_Click(object sender, EventArgs e)
        {
            Address_Leave(this, e);
            ELSCDataContext equipment = new ELSCDataContext();

            var r = from i in equipment.Equipments
                    where i.TagID.ToString() == tagids
                    select i;

            foreach (var eq in r)
            {
                if (Office.Checked)
                {
                    eq.Office = true;
                    eq.IsPatient = false;
                }
                else
                    eq.Office = false;
                //checking for assignee change
                if (textBox2.Text.ToString() != eq.CurrentAssignee)
                {
                    //first change?
                    if (eq.PreviousAssignee == null)
                    {
                        //yes
                        eq.PreviousAssignee += eq.CurrentAssignee + ": (" + DateTime.Now + ") ";
                    }
                    else
                    {
                        //no
                        eq.PreviousAssignee += ", " + eq.CurrentAssignee + ": (" + DateTime.Now + ") ";
                    }
                    //assignee changed
                    eq.CurrentAssignee = textBox2.Text.ToString();
                }
                //checking for location change
                if (textBox3.Text + " " + textBox4.Text + ", " + comboBox3.Text + " " + textBox5.Text != eq.CurrentLocation)
                {
                    //first change?
                    if (eq.PreviousLocation == null)
                    {
                        //yes
                        eq.PreviousLocation += eq.CurrentLocation + ": (" + DateTime.Now + ") ";
                    }
                    else
                    {
                        //no
                        eq.PreviousLocation += ", " + eq.CurrentLocation + ": (" + DateTime.Now + ") ";
                    }
                    //assignee changed
                    eq.CurrentLocation = textBox3.Text + " " + textBox4.Text + ", " + comboBox3.Text + " " + textBox5.Text;
                }
                if (comboBox1.Text == "Active")
                {
                    eq.BitlockerStatus = 'A';
                }
                if (comboBox1.Text == "Disabled")
                {
                    eq.BitlockerStatus = 'D';
                }
                if (comboBox1.Text == "Suspended")
                {
                    eq.BitlockerStatus = 'S';
                }
                if (eq.Installed_Software != textBox6.Text)
                {
                    string temp = "";
                    string newcurrent = "";
                    foreach (char car in eq.Installed_Software)
                    {
                        if (car == ',')
                        {
                            if (textBox6.Text.Contains(temp))
                            {
                                temp = "";
                            }
                            else
                            {
                                //MessageBox.Show("Added the word "+temp+ " to previous software");
                                eq.P_Software += " -- Removed Software -- " + DateTime.Now + ": " + temp;
                                temp = "";
                            }
                        }
                        else
                        {
                            temp += car;
                        }
                    }
                    textBox6.Text += ',';
                    foreach (char car in textBox6.Text.Replace(", ", ","))
                    {
                        if (car == ',')
                        {
                            if (eq.Installed_Software.Contains(temp))
                            {
                                newcurrent += temp + ',';
                                temp = "";
                            }
                            else
                            {
                                //MessageBox.Show("Added the word "+temp+ " to previous software");
                                newcurrent += temp + ',';
                                temp = "";
                            }
                        }
                        else
                        {
                            temp += car;
                        }
                    }
                    eq.Installed_Software = newcurrent;
                    //eq.P_Software += " -- Software Change -- " + DateTime.Now + ": "+eq.Installed_Software;
                    //eq.Installed_Software = textBox4.Text.Replace(", ", ",");
                }
                if (radioButton1.Checked)
                    eq.IsPatient = true;
                else if (radioButton2.Checked)
                    eq.IsPatient = false;
                eq.Address = textBox3.Text;
                eq.City = textBox4.Text;
                eq.State = comboBox3.Text;
                eq.ZIP = textBox5.Text;

            }
            equipment.SubmitChanges();
            this.Close();
        }

        private void Office_CheckedChanged(object sender, EventArgs e)
        {
            if (Office.Checked)
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
        private void Address_Leave(object sender, EventArgs e)
        {
            infoLoc = textBox3.Text + " " + textBox4.Text + ", " + comboBox3.Text + " " + textBox5.Text;
        }
    }
}
