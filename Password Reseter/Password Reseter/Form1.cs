using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.DirectoryServices.AccountManagement;
using System.Windows.Forms;

namespace Password_Reseter
{
    public partial class Form1 : Form
    {
        string account;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string groupName = "Domain Users";
            string domainName = "192.168.10.5";
            //get AD users
            PrincipalContext ctx = new PrincipalContext(ContextType.Domain, domainName);
            GroupPrincipal grp = GroupPrincipal.FindByIdentity(ctx, IdentityType.SamAccountName, groupName);

            try
            {
                foreach (Principal p in grp.GetMembers(false))
                {
                    if (p.SamAccountName != null)
                        comboBox1.Items.Add(p.SamAccountName);
                }
                grp.Dispose();
                ctx.Dispose();
            }
            catch
            {
                MessageBox.Show("We are sorry, we are not able to run the program at this time. Please check Internet and VPN connections.");
            }
            comboBox1.Sorted = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string final = "";
            string initial = textBox1.Text;
            string confirm = textBox2.Text;

            if (initial.Equals(confirm) && initial != "")
                final = initial;
            else
            {
                MessageBox.Show("ERROR! Passwords don't match!");
                final = "f";
            }
            if (final != "f")
            {
                using (var context = new PrincipalContext(ContextType.Domain))
                {
                    using (var user = UserPrincipal.FindByIdentity(context, IdentityType.SamAccountName, account))
                    {
                       user.SetPassword(final);
                       user.UnlockAccount();
                       user.Save();
                    }
                }
                MessageBox.Show("Reset user: " + comboBox1.Text.ToString()+"\r\nPassword: "+final+". Inform them they will need to change password once they login.");
                this.Close();
            }
            }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var context = new PrincipalContext(ContextType.Domain))
            {
                using (var user = UserPrincipal.FindByIdentity(context, IdentityType.SamAccountName, account))
                {
                        user.Enabled = true;
                        user.UnlockAccount();
                        user.Save();
                }
            }
            MessageBox.Show("Unlocked user: " + comboBox1.Text.ToString() + ". Inform them they are now unlocked.");
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            account = comboBox1.Text.ToString();
        }
    }
}
