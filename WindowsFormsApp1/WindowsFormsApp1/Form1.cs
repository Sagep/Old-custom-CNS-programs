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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            checkBox2.Checked = true;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox2.Checked==true)
            {
                checkBox1.Checked = false;
                checkBox2.Checked = true;

                comboBox1.Items.Clear();
                comboBox1.ResetText();
                comboBox1.Items.Add("TagID");
                comboBox1.Items.Add("Serial Number");
                comboBox1.Items.Add("Bitlocker Status");
                comboBox1.Items.Add("Date Encryption Checked");
                comboBox1.Items.Add("Current Location");
                comboBox1.Items.Add("Previous Location");
                comboBox1.Items.Add("Curent Assignee");
                comboBox1.Items.Add("Destroyed");
                comboBox1.Items.Add("Type");
                comboBox1.Items.Add("Notes");
                comboBox1.Items.Add("Is Patient");
                comboBox1.Items.Add("Installed Software");
                comboBox1.Items.Add("Previous Software");

                comboBox2.Items.Clear();
                comboBox2.ResetText();
                comboBox2.Items.Add("TagID");
                comboBox2.Items.Add("Serial Number");
                comboBox2.Items.Add("Bitlocker Status");
                comboBox2.Items.Add("Date Encryption Checked");
                comboBox2.Items.Add("Current Location");
                comboBox2.Items.Add("Previous Location");
                comboBox2.Items.Add("Current Assignee");
                comboBox2.Items.Add("Destroyed");
                comboBox2.Items.Add("Type");
                comboBox2.Items.Add("Notes");
                comboBox2.Items.Add("Is Patient");
                comboBox2.Items.Add("Installed Software");
                comboBox2.Items.Add("Previous Software");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                checkBox1.Checked = true;
                checkBox2.Checked = false;

                comboBox1.Items.Clear();
                comboBox1.ResetText();
                comboBox1.Items.Add("Ticketor");
                comboBox1.Items.Add("Ticketor Phone Number");
                comboBox1.Items.Add("Ticketor Email");
                comboBox1.Items.Add("Date of Issue");
                comboBox1.Items.Add("Issue");
                comboBox1.Items.Add("Resolver");
                comboBox1.Items.Add("Resolver Email");
                comboBox1.Items.Add("Resolver Phone Number");
                comboBox1.Items.Add("Resolution");
                comboBox1.Items.Add("Status");
                comboBox1.Items.Add("ID2");
                comboBox1.Items.Add("Notes");
                comboBox1.Items.Add("Date of Resolution");
                comboBox1.Items.Add("Device ID");
                comboBox1.Items.Add("Issue Type");
                comboBox1.Items.Add("Priority");
                comboBox1.Items.Add("Does IT Support This");
                comboBox1.Items.Add("Assigned to who?");

                comboBox2.Items.Clear();
                comboBox2.ResetText();
                comboBox2.Items.Add("Ticketor");
                comboBox2.Items.Add("Ticketor Phone Number");
                comboBox2.Items.Add("Ticketor Email");
                comboBox2.Items.Add("Date of Issue");
                comboBox2.Items.Add("Issue");
                comboBox2.Items.Add("Resolver");
                comboBox2.Items.Add("Resolver Email");
                comboBox2.Items.Add("Resolver Phone Number");
                comboBox2.Items.Add("Resolution");
                comboBox2.Items.Add("Status");
                comboBox2.Items.Add("ID2");
                comboBox2.Items.Add("Notes");
                comboBox2.Items.Add("Date of Resolution");
                comboBox2.Items.Add("Device ID");
                comboBox2.Items.Add("Issue Type");
                comboBox2.Items.Add("Priority");
                comboBox2.Items.Add("Does IT Support This");
                comboBox2.Items.Add("Assigned to who?");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to update all ''" + comboBox1.Text + "'' with ''" + textBox1.Text + "'' when ''" + comboBox2.Text + "'' equals ''" + textBox2.Text + "''?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    DataClasses1DataContext equipment = new DataClasses1DataContext();
                    //"When X is equal to Y"
                    var r = Checkequip(equipment);
                    //"Replace All of W with V"
                    changerequip(r);
                    equipment.SubmitChanges();
                }
            }
            if (checkBox1.Checked)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to update all ''" + comboBox1.Text + "'' with ''" + textBox1.Text + "'' when ''" + comboBox2.Text + "'' equals ''" + textBox2.Text + "''?\r\n\r\nThis Can NOT be reversed.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    TicketorDataContext tickets = new TicketorDataContext();
                    Checkticket(tickets);

                }
            }
        }

        private IQueryable<Ticketer> Checkticket(TicketorDataContext tickets)
        {
            if (comboBox2.Text == "Ticketor")
            {
                var r = from i in tickets.Ticketers
                        where i.Ticketor == textBox2.Text
                        select i;
                return r;
            }
            else if (comboBox2.Text == "Ticketor Email")
            {
                var r = from i in tickets.Ticketers
                        where i.Temail == textBox2.Text
                        select i;
                return r;
            }
            else if (comboBox2.Text == "Date of Issue")
            {
                var r = from i in tickets.Ticketers
                        where i.Dissue == textBox2.Text
                        select i;
                return r;
            }
            else if (comboBox2.Text == "Issue")
            {
                var r = from i in tickets.Ticketers
                        where i.Issue == textBox2.Text
                        select i;
                return r;
            }
            else if (comboBox2.Text == "Resolver")
            {
                var r = from i in tickets.Ticketers
                        where i.Resolver == textBox2.Text
                        select i;
                return r;
            }
            else if (comboBox2.Text == "Resolver Email")
            {
                var r = from i in tickets.Ticketers
                        where i.Remail == textBox2.Text
                        select i;
                return r;
            }
            else if (comboBox2.Text == "Resolver Phone Number")
            {
                var r = from i in tickets.Ticketers
                        where i.Rphone == textBox2.Text
                        select i;
                return r;
            }
            else if (comboBox2.Text == "Resolution")
            {
                var r = from i in tickets.Ticketers
                        where i.Resolution == textBox2.Text
                        select i;
                return r;
            }
            else if (comboBox2.Text == "Status")
            {
                char stat = 'z';
                if(textBox2.Text.Contains("open"))
                {
                    stat = 'O';
                }
                else if (textBox2.Text.Contains("pending"))
                {
                    stat = 'P';
                }
                else if (textBox2.Text.Contains("closed"))
                {
                    stat = 'C';
                }
                else if (textBox2.Text.Contains("Follow"))
                {
                    stat = 'F';
                }
                var r = from i in tickets.Ticketers
                        where i.Status == stat
                        select i;
                return r;
            }
            else if (comboBox2.Text == "ID2")
            {
                var r = from i in tickets.Ticketers
                        where i.ID2 == long.Parse(textBox2.Text)
                        select i;
                return r;
            }
            else if (comboBox2.Text == "Notes")
            {
                var r = from i in tickets.Ticketers
                        where i.Notes == textBox2.Text
                        select i;
                return r;
            }
            else if (comboBox2.Text == "Date of Resolution")
            {
                var r = from i in tickets.Ticketers
                        where i.Dresolve == textBox2.Text
                        select i;
                return r;
            }
            else if (comboBox2.Text == "Device ID")
            {
                var r = from i in tickets.Ticketers
                        where i.DeviceID == textBox2.Text
                        select i;
                return r;
            }
            else if (comboBox2.Text == "Issue Type")
            {
                var r = from i in tickets.Ticketers
                        where i.IssueType == textBox2.Text
                        select i;
                return r;
            }
            else if (comboBox2.Text == "Priority")
            {
                char prior = 'z';
                if (textBox2.Text.Contains("high")) {
                    prior = 'H';
                }
                else if (textBox2.Text.Contains("medium"))
                {
                    prior = 'M';
                }
                else if (textBox2.Text.Contains("low"))
                {
                    prior = 'L';
                }
                var r = from i in tickets.Ticketers
                        where i.Priority == prior
                        select i;
                return r;
            }
            else if (comboBox2.Text == "Does IT Support This")
            {

                bool support = false;
                if (textBox2.Text.Contains("True"))
                    support = true;
                var r = from i in tickets.Ticketers
                        where i.Supported == support
                        select i;
                return r;
            }
            else if (comboBox2.Text == "Assigned to who?")
            {
                var r = from i in tickets.Ticketers
                        where i.Assigned == textBox2.Text
                        select i;
                return r;
            }
            else
            {
                MessageBox.Show("Error! No Combobox selection made!");
                return null;
            }            
        }

        private void changerticket(IQueryable<Ticketer> r)
        {
            foreach (var x in r)
            {
                if (comboBox1.Text == "Ticketor") { x.Ticketor = textBox1.Text; }
                else if (comboBox1.Text == "Ticketor Email") { x.Temail = textBox1.Text; }
                else if (comboBox1.Text == "Date of Issue") {x.Dissue = textBox1.Text; }
                else if (comboBox1.Text == "Issue") {x.Issue = textBox1.Text; }
                else if (comboBox1.Text == "Resolver") { x.Resolver = textBox1.Text; }
                else if (comboBox1.Text == "Resolver Email") {x.Remail = textBox1.Text; }
                else if (comboBox1.Text == "Resolver Phone Number") { x.Rphone = textBox1.Text; }
                else if (comboBox1.Text == "Resolution") { x.Resolution = textBox1.Text; }
                else if (comboBox1.Text == "Status")
                {
                    char stat = 'z';
                    if (textBox1.Text.Contains("open"))
                    {
                        stat = 'O';
                    }
                    else if (textBox1.Text.Contains("pending"))
                    {
                        stat = 'P';
                    }
                    else if (textBox1.Text.Contains("closed"))
                    {
                        stat = 'C';
                    }
                    else if (textBox1.Text.Contains("Follow"))
                    {
                        stat = 'F';
                    }
                    x.Status = stat;
                }
                else if (comboBox1.Text == "ID2") { x.ID2 = long.Parse(textBox1.Text); }
                else if (comboBox1.Text == "Notes") {x.Notes = textBox1.Text; }
                else if (comboBox1.Text == "Date of Resolution") { x.Dresolve = textBox1.Text; }
                else if (comboBox1.Text == "Device ID") {x.DeviceID = textBox1.Text; }
                else if (comboBox1.Text == "Issue Type") { x.IssueType = textBox1.Text; }
                else if (comboBox1.Text == "Priority")
                {
                    char prior = 'z';
                    if (textBox2.Text.Contains("high"))
                    {
                        prior = 'H';
                    }
                    else if (textBox2.Text.Contains("medium"))
                    {
                        prior = 'M';
                    }
                    else if (textBox2.Text.Contains("low"))
                    {
                        prior = 'L';
                    }
                    x.Priority = prior;
                }
                else if (comboBox1.Text == "Does IT Support This")
                {
                    bool support = false;
                    if (textBox2.Text.Contains("True"))
                        support = true;
                    x.Supported = support;
                }
                else if (comboBox1.Text == "Assigned to who?") { x.Assigned = textBox1.Text; }
            }
        }

        private void changerequip(IQueryable<Equipment> r)
        {
            foreach (var x in r)
            {
                if (comboBox1.Text == "TagID")
                {
                    x.TagID = textBox1.Text;
                }
                if (comboBox1.Text == "Serial Number")
                {
                    x.SerialNumber = textBox1.Text;
                }
                if (comboBox1.Text == "Bitlocker Status")
                {
                    char stat = 'z';
                    if(textBox1.Text=="Active")
                    {
                        stat = 'A';
                    }
                    else if (textBox1.Text=="Disabled")
                    {
                        stat = 'D';
                    }
                    else if (textBox1.Text=="Suspended")
                    {
                        stat = 'S';
                    }
                    else
                    {
                        MessageBox.Show("Error! Make sure you enter Active, Suspended, or Disabled in the textbox");
                    }
                    x.BitlockerStatus = stat;
                }
                if (comboBox1.Text == "Date Encryption Checked")
                {
                    try
                    {
                        x.DateEncryptionChecked = Convert.ToDateTime(textBox1.Text);
                    }
                    catch
                    {
                        MessageBox.Show("Unable to convert the given string to datetime format. Please try again");
                    }
                }
                if (comboBox1.Text == "Current Location")
                {
                    x.CurrentLocation = textBox1.Text;
                }
                if (comboBox1.Text == "Previous Location")
                {
                    x.PreviousLocation = textBox1.Text;
                }
                if (comboBox1.Text == "Current Assignee")
                {
                    x.CurrentAssignee = textBox1.Text;
                }
                if (comboBox1.Text == "Destroyed")
                {
                    bool dest = false;
                    if (textBox1.Text == "True")
                        dest = true;
                    x.Destroyed = dest;
                }
                if (comboBox1.Text == "Type")
                {
                    x.Type = textBox1.Text;
                }
                if (comboBox1.Text == "Notes")
                {
                    x.Notes = textBox1.Text;
                }
                if (comboBox1.Text == "Is Patient")
                {
                    bool dest = false;
                    if (textBox1.Text == "True")
                        dest = true;
                    x.IsPatient = dest;
                }
                if (comboBox1.Text == "Installed Software")
                {
                    x.Installed_Software = textBox1.Text;
                }
                if (comboBox1.Text == "Previous Software")
                {
                    x.P_Software = textBox1.Text;
                }
            }
        }

        private IQueryable<Equipment> Checkequip(DataClasses1DataContext equipment)
        {
            if (comboBox2.Text == "TagID")
            {
                var r = from i in equipment.Equipments
                        where i.TagID.ToString() == textBox2.Text
                        select i;
                return r;
            }
            else if (comboBox2.Text == "Serial Number")
            {
                var r = from i in equipment.Equipments
                        where i.SerialNumber.ToString() == textBox2.Text
                        select i;
                return r;
            }
            else if (comboBox2.Text == "Bitlocker Status")
            {
                char stat = 'z';
                if(textBox2.Text=="Active")
                {
                    stat = 'A';
                }
                if(textBox2.Text=="Disabled")
                {
                    stat = 'D';
                }
                if(textBox2.Text=="Suspended")
                {
                    stat = 'S';
                }
                else
                {
                    MessageBox.Show("ERROR! Please enter Active, Disabled, Or Suspended");
                }
                var r = from i in equipment.Equipments
                        where i.BitlockerStatus==stat
                        select i;
                return r;
            }
            else if (comboBox2.Text == "Date Encryption Checked")
            {
                var r = from i in equipment.Equipments
                        where i.DateEncryptionChecked.ToString()==textBox2.Text
                        select i;
                return r;
            }
            else if (comboBox2.Text == "Current Location")
            {
                var r = from i in equipment.Equipments
                        where i.CurrentLocation.ToString() == textBox2.Text
                        select i;
                return r;
            }
            else if (comboBox2.Text == "Previous Location")
            {
                var r = from i in equipment.Equipments
                        where i.PreviousLocation.ToString() == textBox2.Text
                        select i;
                return r;
            }
            else if (comboBox2.Text == "Current Assignee")
            {
                var r = from i in equipment.Equipments
                        where i.CurrentAssignee.ToString() == textBox2.Text
                        select i;
                return r;
            }
            else if (comboBox2.Text == "Destroyed")
            {
                bool destr = false;
                if (textBox2.Text.Contains("True"))
                    destr = true;
                var r = from i in equipment.Equipments
                        where i.Destroyed==destr
                        select i;
                return r;
            }
            else if (comboBox2.Text == "Type")
            {
                var r = from i in equipment.Equipments
                        where i.Type.ToString() == textBox2.Text
                        select i;
                return r;
            }
            else if (comboBox2.Text == "Notes")
            {
                var r = from i in equipment.Equipments
                        where i.Notes.ToString() == textBox2.Text
                        select i;
                return r;
            }
            else if (comboBox2.Text == "Is Patient")
            {
                bool pat = false;
                if (textBox2.Text.Contains("True"))
                    pat = true;
                var r = from i in equipment.Equipments
                        where i.IsPatient==pat
                        select i;
                return r;
            }
            else if (comboBox2.Text == "Installed Software")
            {
                var r = from i in equipment.Equipments
                        where i.Installed_Software.ToString() == textBox2.Text
                        select i;
                return r;
            }
            else if (comboBox2.Text == "Previous Software")
            {
                var r = from i in equipment.Equipments
                        where i.P_Software.ToString() == textBox2.Text
                        select i;
                return r;
            }
            else
            {
                MessageBox.Show("Error! No Combobox selection made!");
                return null;
            }
        }

    }
}
