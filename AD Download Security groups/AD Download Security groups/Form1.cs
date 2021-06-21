using System;
using System.DirectoryServices.AccountManagement;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace AD_Download_Security_groups
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            #region Users
                string groupName = "Domain Users";
                string domainName = "192.168.10.5";

                //get AD users
                PrincipalContext ctx = new PrincipalContext(ContextType.Domain, domainName);
                GroupPrincipal grp = GroupPrincipal.FindByIdentity(ctx, IdentityType.SamAccountName, groupName);

                try
                {
                    foreach (Principal p in grp.GetMembers(false))
                    {
                        if (p.DisplayName != null)
                            comboBox2.Items.Add(p.DisplayName);
                    }
                    grp.Dispose();
                    ctx.Dispose();
                }
                catch
                {
                    MessageBox.Show("We are sorry, we are not able to run the program at this time. Please check Internet and VPN connections.");
                    this.Close();
                }
                comboBox2.Sorted = true;
            #endregion

            PrincipalContext ctx2 = new PrincipalContext(ContextType.Domain, domainName);
            GroupPrincipal grp2 = new GroupPrincipal(ctx2);
            PrincipalSearcher ps = new PrincipalSearcher(grp2);
            try
            {
                foreach (var p in ps.FindAll())
                {
                    if (p.Name != null)
                        comboBox1.Items.Add(p.Name);
                }
                grp2.Dispose();
                ctx2.Dispose();
            }
            catch
            {
                MessageBox.Show("We are sorry, we are not able to run the program at this time. Please check Internet and VPN connections.");
                this.Close();
            }
            comboBox1.Sorted = true;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Spreadsheet|*.csv";
            save.ShowDialog();

            string path = save.FileName.ToString();

            string groupName = "Domain Users";
            string domainName = "192.168.10.5";

            //get AD users
            PrincipalContext ctx = new PrincipalContext(ContextType.Domain, domainName);
            GroupPrincipal grp = GroupPrincipal.FindByIdentity(ctx, IdentityType.SamAccountName, groupName);


            string delimiter = ",";
            StringBuilder sb = new StringBuilder();
            //header
            string[] hrow = new string[] { "Employee's Name", "Security Groups", "Drives" };
            sb.AppendLine(string.Join(delimiter, hrow));

            string usert = "";


            try
            {
                foreach (Principal p in grp.GetMembers(false))
                {

                    // MessageBox.Show(p.UserPrincipalName);
                    if (p.DisplayName != null)
                    {

                        string accesser = "";
                        try
                        {

                            UserPrincipal user = UserPrincipal.FindByIdentity(ctx, p.UserPrincipalName);

                            foreach (var r in user.GetAuthorizationGroups())
                            {

                                if (r.Name != "Everyone" && r.Name != null && r.Name != "Domain Users" && r.Name != "Users" && r.Name != "Authenticated Users" && r.Name != "This Organization" && r.Name != "Service asserted identity" && r.Name != "SophosUser" && r.Name != "Medium Mandatory Level")
                                {
                                    //textBox1.Text += r.Name + "---";
                                    accesser += r.Name + "---";
                                }
                            }
                            if (user.UserPrincipalName != "")
                            {
                                string netlogon = Regex.Replace(System.IO.File.ReadAllText(@"\\CNS-DC01\\netlogon\" + user.GivenName.ToString() + "." + user.Surname.ToString() + ".bat"), @"\r\n|\n", "---");
                                string[] row = new string[] { user.DisplayName, accesser, netlogon};
                                sb.AppendLine(string.Join(delimiter, row));
                            }
                        }
                        catch
                        {
                            usert = p.DisplayName;
                        }
                    }

                }
                grp.Dispose();
                ctx.Dispose();
            }
            catch
            {
                MessageBox.Show("We are sorry, we are not able to run the program at this time. Please check Internet and VPN connections.\r\n" + usert);
                this.Close();
            }
            File.WriteAllText(path, sb.ToString(), Encoding.UTF8);
            MessageBox.Show("Completed!");
            this.Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Spreadsheet|*.csv";
            save.ShowDialog();

            string path = save.FileName.ToString();

            string groupName = "Domain Users";
            string domainName = "192.168.10.5";

            //get AD users
            PrincipalContext ctx = new PrincipalContext(ContextType.Domain, domainName);
            GroupPrincipal grp = GroupPrincipal.FindByIdentity(ctx, IdentityType.SamAccountName, groupName);


            string delimiter = ",";
            StringBuilder sb = new StringBuilder();
            //header
            string[] hrow = new string[] { "Employee's Name", "Security Groups", "Drives" };
            sb.AppendLine(string.Join(delimiter, hrow));

            string usert = "";


            try
            {
                foreach (Principal p in grp.GetMembers(false))
                {

                    // MessageBox.Show(p.UserPrincipalName);
                    if (p.DisplayName != null)
                    {

                        string accesser = "";
                        try
                        {

                            UserPrincipal user = UserPrincipal.FindByIdentity(ctx, p.UserPrincipalName);

                            //foreach (var r in user.GetGroups())
                            //{
                            //    if (r.Name != "Everyone" && r.Name != null && r.Name != "Domain Users" && r.Name != "Users" && r.Name != "Authenticated Users" && r.Name != "This Organization" && r.Name != "Service asserted identity" && r.Name != "SophosUser" && r.Name != "Medium Mandatory Level")
                            //    {
                            //        //textBox1.Text += r.Name + "---";
                            //        accesser += r.Name + "---";
                            //    }
                            //}


                            if (user != null)
                            {
                                // get all roles for that user
                                var roles = user.GetGroups();

                                // set up two lists for each type of groups
                                List<GroupPrincipal> securityGroups = new List<GroupPrincipal>();
                                List<GroupPrincipal> distributionGroups = new List<GroupPrincipal>();

                                // iterate over groups found
                                foreach (Principal ps in roles)
                                {
                                    // cast to GroupPrincipal
                                    GroupPrincipal gp = (ps as GroupPrincipal);

                                    if (gp != null)
                                    {
                                        // check whether it's a security group or a distribution group
                                        if (!gp.IsSecurityGroup.GetValueOrDefault())
                                            accesser += gp.Name+"---";
                                    }
                                }
                            }
                            if (user.UserPrincipalName != "")
                            {
                                string[] row = new string[] { user.DisplayName, accesser};
                                sb.AppendLine(string.Join(delimiter, row));
                            }
                        }
                        catch
                        {
                            usert = p.DisplayName;
                        }
                    }

                }
                grp.Dispose();
                ctx.Dispose();
            }
            catch
            {
                MessageBox.Show("We are sorry, we are not able to run the program at this time. Please check Internet and VPN connections.\r\n" + usert);
                this.Close();
            }
            File.WriteAllText(path, sb.ToString(), Encoding.UTF8);
            MessageBox.Show("Completed!");
            this.Close();
        }

        private void Button3_Click(object sender, EventArgs e)
        {

            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Spreadsheet|*.csv";
            save.ShowDialog();

            string path = save.FileName.ToString();


            string domainName = "192.168.10.5";

            PrincipalContext ctx = new PrincipalContext(ContextType.Domain, domainName);
            GroupPrincipal grp = GroupPrincipal.FindByIdentity(ctx, IdentityType.SamAccountName, comboBox1.Text.ToString());


            string delimiter = ",";
            StringBuilder sb = new StringBuilder();
            //header
            string[] hrow = new string[] { "Employee's Name"};
            sb.AppendLine(string.Join(delimiter, hrow));

            string usert = "";


            try
            {
                foreach (Principal p in grp.GetMembers(false))
                {

                    // MessageBox.Show(p.UserPrincipalName);
                    if (p.DisplayName != null)
                    {

                        string accesser = "";
                        try
                        {

                            UserPrincipal user = UserPrincipal.FindByIdentity(ctx, p.UserPrincipalName);

                            foreach (var r in user.GetAuthorizationGroups())
                            {

                                if (r.Name != "Everyone" && r.Name != null && r.Name != "Domain Users" && r.Name != "Users" && r.Name != "Authenticated Users" && r.Name != "This Organization" && r.Name != "Service asserted identity" && r.Name != "SophosUser" && r.Name != "Medium Mandatory Level")
                                {
                                    //textBox1.Text += r.Name + "---";
                                    accesser += r.Name + "---";
                                }
                            }
                            if (user.UserPrincipalName != "")
                            {
                                string[] row = new string[] { user.DisplayName};
                                sb.AppendLine(string.Join(delimiter, row));
                            }
                        }
                        catch
                        {
                            usert = p.DisplayName;
                        }
                    }

                }
                grp.Dispose();
                ctx.Dispose();
            }
            catch
            {
                MessageBox.Show("We are sorry, we are not able to run the program at this time. Please check Internet and VPN connections.\r\n" + usert);
                this.Close();
            }
            File.WriteAllText(path, sb.ToString(), Encoding.UTF8);
            MessageBox.Show("Completed!");
            this.Close();

        }
    }
}
