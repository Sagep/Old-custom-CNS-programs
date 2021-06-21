using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.DirectoryServices.AccountManagement;

namespace CNS_Access_List
{
    public partial class Form1 : Form
    {
        private int id = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Name of Agent
            label2.Text = "";

            //location
            label4.Text = "";

            //Department
            label6.Text = "";

            //Status
            label8.Text = "";

            //Batch File
            label10.Text = "";

            //Active Sync
            label12.Text = "";

            //incoming email
            label14.Text = "";

            //outgoing email
            label16.Text = "";

            //username
            label22.Text = "";

            //phone number
            label24.Text = "";

            //email address
            label26.Text = "";

            //security groups
            textBox2.Text = "";

            //mapped drives
            textBox3.Text = "";

            //equipment
            textBox4.Text = "";

            textBox5.Text = "";

        }

        public void loaddata()
        {
            textBox5.Text = "";
            textBox4.Text = "";
            int count = 0;
            string first = "";
            string last = "";
            bool message = false;

            //User Access data
            Data_Connections.UsersDataContext loaduser = new Data_Connections.UsersDataContext();
            var r = from i in loaduser.Users
                    where ((i.First_name.ToString() + " " + i.Last_name.ToString()).Contains(textBox1.Text)) || i.Username.ToString().Contains(textBox1.Text)
                    select i;
            foreach (var x in r)
            {
                count += 1;
                if (count >= 2)
                {
                    if (message == false)
                    {
                        //Name of Agent
                        label2.Text = "";

                        //location
                        label4.Text = "";

                        //Department
                        label6.Text = "";

                        //Status
                        label8.Text = "";

                        //Batch File
                        label10.Text = "";

                        //Active Sync
                        label12.Text = "";

                        //incoming email
                        label14.Text = "";

                        //outgoing email
                        label16.Text = "";

                        //username
                        label22.Text = "";

                        //phone number
                        label24.Text = "";

                        //email address
                        label26.Text = "";

                        //security groups
                        textBox2.Text = "";

                        //mapped drives
                        textBox3.Text = "";

                        //equipment
                        textBox4.Text = "";

                        textBox5.Text = "";

                        MessageBox.Show("ERROR! More than one user found. Please try again with full name or username instead");
                        message = true;
                    }
                }
                else
                {
                    //Name of Agent
                    label2.Text = x.First_name + " " + x.Last_name;
                    first = x.First_name;
                    last = x.Last_name;

                    //location
                    label4.Text = x.Location;

                    //Department
                    label6.Text = x.Department;

                    //Status
                    if (x.Status == 'A')
                        label8.Text = "Active";
                    if (x.Status == 'T')
                        label8.Text = "Terminated";
                    if (x.Status == 'P')
                        label8.Text = "Pending";

                    //Batch File
                    label10.Text = x.BatFile;

                    //Active Sync
                    if (x.Async == true)
                        label12.Text = "Yes";
                    else
                        label12.Text = "No";

                    //incoming email
                    if (x.IncomingEmail == true)
                        label14.Text = "Yes";
                    else
                        label14.Text = "No";

                    //outgoing email
                    if (x.OutgoingEmail == true)
                        label16.Text = "Yes";
                    else
                        label16.Text = "No";

                    //username
                    label22.Text = x.Username;

                    //security groups
                    textBox2.Text = x.Security;

                    //mapped drives
                    textBox3.Text = x.Drives.Replace(";", "\r\n");

                    //get the ID
                    id = x.Id;
                }
            }

            if ((label2.Text == null || label2.Text == "") && message == false)
            {
                MessageBox.Show("ERROR! User is not found in the database. Please try again and check spelling.");
            }
            else if (count>=2){}
            else
            {
                try
                {
                    string domainName = "192.168.10.5";

                    //get AD users
                    PrincipalContext ctx = new PrincipalContext(ContextType.Domain, domainName);
                    UserPrincipal user = UserPrincipal.FindByIdentity(ctx, label22.Text);
                    label26.Text = user.EmailAddress;
                    label24.Text = user.VoiceTelephoneNumber;

                    ////this pulls data from AD and displays it.
                    //var groups = user.GetAuthorizationGroups();
                    //string groupers = "";
                    //foreach (GroupPrincipal group in groups)
                    //{
                    //    if (group.Name.ToString() != "Domain Users" && group.Name.ToString() != "Everyone" &&
                    //        group.Name.ToString() != "Users" && group.Name.ToString() != "Authenticated Users"
                    //        && group.Name.ToString() != "This Organization" && group.Name.ToString() != "Medium Mandatory Level")
                    //        groupers += group.Name.ToString() + ";";
                    //}
                    //textBox2.Text = groupers;
                }
                catch
                { }

                //Tickets data
                Data_Connections.TicketsDataContext loadtickets = new Data_Connections.TicketsDataContext();
                var s = from i in loadtickets.Ticketers
                        where i.Ticketor.ToString().Contains(label22.Text)
                        select i;
                foreach (var x in s)
                {
                    if (textBox5.Text == "")
                        textBox5.Text = x.ID2.ToString();
                    else
                    {
                        textBox5.Text += "\r\n" + x.ID2.ToString();
                    }
                }

                //Equipment Data
                Data_Connections.EquipmentDataContext loadequip = new Data_Connections.EquipmentDataContext();
                var t = from i in loadequip.Equipments
                        where i.CurrentAssignee.Contains(first + " " + last) || i.CurrentAssignee.Contains(last + ", " + first)
                        select i;
                foreach (var x in t)
                {
                    if (textBox4.Text == "")
                        textBox4.Text = x.TagID;
                    else
                        textBox4.Text += "\r\n" + x.TagID.ToString();
                }
            }
        }

        private void newWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 test = new Form1();

            test.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Name of Agent
            label2.Text = "";

            //location
            label4.Text = "";

            //Department
            label6.Text = "";

            //Status
            label8.Text = "";

            //Batch File
            label10.Text = "";

            //Active Sync
            label12.Text = "";

            //incoming email
            label14.Text = "";

            //outgoing email
            label16.Text = "";

            //username
            label22.Text = "";

            //phone number
            label24.Text = "";

            //email address
            label26.Text = "";

            //security groups
            textBox2.Text = "";

            //mapped drives
            textBox3.Text = "";

            //equipment
            textBox4.Text = "";

            textBox5.Text = "";
            loaddata();
        }

        private void openEquipmentLoggerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("\\\\CNS-SERVER01\\netlogon\\CNSEquipmentLogger.exe");
        }

        private void openITTicketsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("\\\\CNS-SERVER01\\netlogon\\CNS IT Ticketing System2.exe");
        }

        private void newUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            New_User test = new New_User();
            test.Show();
        }

        private void updateUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (label2.Text == null || label2.Text == "")
            {
                MessageBox.Show("ERROR! User is not found in the database. Please search again and check spelling.");
            }
            else
            {
                UpdateUser updater = new UpdateUser(id);
                updater.Show();
            }
        }

        private void terminateUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure that this user has been terminated?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                Data_Connections.UsersDataContext loaduser = new Data_Connections.UsersDataContext();
                var r = from i in loaduser.Users
                        select i;

                foreach (var z in r)
                {
                    if (z.Id == id)
                    {
                        z.Status = 'T';

                        string domainName = "192.168.10.5";
                        PrincipalContext ctx = new PrincipalContext(ContextType.Domain, domainName);
                        UserPrincipal user = UserPrincipal.FindByIdentity(ctx, z.Username);
                        var groups = user.GetAuthorizationGroups();
                        foreach(GroupPrincipal group in groups)
                        {
                            if (group.Name.ToString() != "Domain Users" && group.Name.ToString() != "Everyone" &&
                                group.Name.ToString() != "Users" && group.Name.ToString() != "Authenticated Users"
                                && group.Name.ToString() != "This Organization" && group.Name.ToString() != "Medium Mandatory Level")
                            {
                                group.Members.Remove(user);
                                group.Save();
                            }
                        }
                        user.Enabled = false;
                        user.Save();
                    }
                }
                loaduser.SubmitChanges();
            }
        }

        private void saveToCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            savedetails();
        }
        private void savedetails()
        {
            try
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "Spreadsheet|*.csv";
                save.ShowDialog();

                string path = save.FileName.ToString();
                string delimiter = ",";

                //string builder
                StringBuilder sb = new StringBuilder();

                //header
                string[] hrow = new string[] { "First Name", "Last Name", "Username", "Location", "Department", "Status", "Batch File", "Security", "Drives", "Async", "Incoming", "Outgoing", "History", "Equipment", "Tickets" };
                sb.AppendLine(string.Join(delimiter, hrow));

                Data_Connections.UsersDataContext loaduser = new Data_Connections.UsersDataContext();
                var r = from i in loaduser.Users
                        select i;

                foreach (var z in r)
                {
                    if (z.Id == id)
                    {
                        string firstname = z.First_name;
                        string lastname = z.Last_name;
                        string username = z.Username;
                        string location = z.Location.ToString().Replace(",", "-");
                        string department = z.Department;
                        string status = z.Status.ToString();
                        string batch = z.BatFile;
                        string security = z.Security;
                        string drives = z.Drives.Replace("\r\n", ";");
                        string async = "No";
                        if (z.Async == true)
                            async = "Yes";
                        string incoming = "No";
                        if (z.IncomingEmail == true)
                            incoming = "Yes";
                        string outgoing = "No";
                        if (z.OutgoingEmail == true)
                            outgoing = "Yes";
                        string history = z.UserHistory;

                        string tickets = "";
                        string equipment = "";

                        //Tickets data
                        Data_Connections.TicketsDataContext loadtickets = new Data_Connections.TicketsDataContext();
                        var s = from i in loadtickets.Ticketers
                                where i.Ticketor.ToString().Contains(label22.Text)
                                select i;
                        foreach (var x in s)
                        {
                            if (tickets == "")
                                tickets = x.ID2.ToString();
                            else
                            {
                                tickets += ";" + x.ID2.ToString();
                            }
                        }

                        //Equipment Data
                        Data_Connections.EquipmentDataContext loadequip = new Data_Connections.EquipmentDataContext();
                        var t = from i in loadequip.Equipments
                                where i.CurrentAssignee.Contains(z.First_name + " " + z.Last_name) || i.CurrentAssignee.Contains(z.Last_name + ", " + z.First_name)
                                select i;
                        foreach (var x in t)
                        {
                            if (equipment == "")
                                equipment = x.TagID;
                            else
                                equipment += ";" + x.TagID.ToString();
                        }



                        string[] row = new string[] { firstname, lastname, username, location, department, status, batch, security, drives, async, incoming, outgoing, history, equipment, tickets};
                        sb.AppendLine(string.Join(delimiter, row));
                    }
                }
                File.WriteAllText(path, sb.ToString(), Encoding.UTF8);
            }
            catch { }


        }

        private void newUserToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            New_User test = new New_User();
            test.Show();
        }

        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void updateUserToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (label2.Text == null || label2.Text == "")
            {
                MessageBox.Show("ERROR! User is not found in the database. Please search again and check spelling.");
            }
            else
            {
                UpdateUser updater = new UpdateUser(id);
                updater.Show();
            }
        }
    }
}
