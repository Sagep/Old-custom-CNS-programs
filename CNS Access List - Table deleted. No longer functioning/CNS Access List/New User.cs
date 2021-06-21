using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.DirectoryServices.AccountManagement;

namespace CNS_Access_List
{
    public partial class New_User : Form
    {
        public New_User()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            bool stop = false;
            Data_Connections.UsersDataContext newuser = new Data_Connections.UsersDataContext();
            var r = from i in newuser.Users
                    select i;

            foreach(var x in r)
            {
                if(x.Username==textBox3.Text)
                {
                    stop = true;
                    MessageBox.Show("ERROR! User is already in the system.");
                }
            }
            if (stop == false)
            {
                bool inemail = false;
                bool outemail = false;
                bool async = false;
                char stat = 'a';

                if (comboBox3.Text == "Yes")
                    async = true;

                if (comboBox2.Text == "Yes")
                    inemail = true;

                if (comboBox1.Text == "Yes")
                    outemail = true;

                if (comboBox4.Text == "Active")
                    stat = 'A';

                if (comboBox4.Text == "Terminated")
                    stat = 'T';

                if (comboBox4.Text == "Pending")
                    stat = 'P';

                Data_Connections.User users = new Data_Connections.User
                {
                    First_name = textBox1.Text,
                    Last_name = textBox2.Text,
                    Username = textBox3.Text,
                    Department = textBox4.Text,
                    Location = textBox5.Text,
                    BatFile = textBox6.Text,
                    Security = textBox7.Text + ";",
                    Drives = textBox8.Text + ";",
                    Async = async,
                    Status = stat,
                    IncomingEmail = inemail,
                    OutgoingEmail = outemail
                };
                newuser.Users.InsertOnSubmit(users);
                newuser.SubmitChanges();
                if (textBox10.Text != "")
                {
                    try
                    {
                        string domainName = "192.168.10.5";

                        //get AD users
                        PrincipalContext ctx = new PrincipalContext(ContextType.Domain, domainName);
                        UserPrincipal user = UserPrincipal.FindByIdentity(ctx, textBox3.Text);
                        user.VoiceTelephoneNumber = textBox10.Text;
                        user.Save();
                    }
                    catch
                    { }
                }
                this.Close();
            }
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                textBox3.Text = "CNS\\" + textBox1.Text + "." + textBox2.Text;
                textBox6.Text = textBox1.Text + "." + textBox2.Text + ".bat";
            }
        }

        private void New_User_Load(object sender, EventArgs e)
        {
            comboBox1.Text = "No";
            comboBox2.Text = "No";
            comboBox3.Text = "No";
            comboBox4.Text = "Pending";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox10.Text = "";
        }
    }
}
