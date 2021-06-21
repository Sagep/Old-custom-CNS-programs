using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;

namespace Information_Update
{
    public partial class Form1 : Form
    {
        private string domainName = "192.168.10.5";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DirectoryEntry entry = new DirectoryEntry("LDAP://CNS.local");
                DirectorySearcher searcher = new DirectorySearcher(entry);

                //searcher.PropertiesToLoad.Add("givenName");
                //searcher.PropertiesToLoad.Add("sn");
                //searcher.PropertiesToLoad.Add("samAccountName");

                searcher.Filter = "(&(objectCategory=person)(samAccountName=" + comboBox1.Text.ToString() + "))";

                SearchResult result = searcher.FindOne();
                
                if (result != null)
                {
                    DirectoryEntry entryToUpdate = result.GetDirectoryEntry();

                    if (textBox1.Text != "")
                    entryToUpdate.Properties["telephoneNumber"].Value = textBox1.Text;
                    if (textBox2.Text != "")
                    entryToUpdate.Properties["streetAddress"].Value = textBox2.Text;
                    if (textBox3.Text != "")
                    entryToUpdate.Properties["postOfficeBox"].Value = textBox3.Text;
                    if (textBox4.Text != "")
                    entryToUpdate.Properties["l"].Value = textBox4.Text;
                    if (textBox5.Text != "")
                    entryToUpdate.Properties["st"].Value = textBox5.Text;
                    if (textBox6.Text != "")
                    entryToUpdate.Properties["postalCode"].Value = textBox6.Text;
                    if (textBox7.Text != "")
                    entryToUpdate.Properties["mobile"].Value = textBox7.Text;
                    if (textBox8.Text != "")
                    entryToUpdate.Properties["physicalDeliveryOfficeName"].Value = textBox8.Text;


                    entryToUpdate.CommitChanges();

                    MessageBox.Show(comboBox1.Text.ToString() + " has had their information updated");
                    comboBox1.Text = "";
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                    textBox7.Text = "";
                    textBox8.Text = "";
                }
                else
                    MessageBox.Show("Error! Unable to find user");
            }
            catch(Exception er)
            {
                if(comboBox1.Text==""||comboBox1.Text==" ")
                {
                    MessageBox.Show("Error! Not a valid user name. Please try again");
                }
                else
                {
                    MessageBox.Show("Error! Unable to complete request. Error: \r\n\r\n" + er);
                }
            }
        }
        

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //loads up users for future refernce
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text.ToString() == "" || comboBox1.Text.ToString() == " ")
            {
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                textBox8.Text = "";
            }
            else
            {
                try
                {
                    DirectoryEntry entry = new DirectoryEntry("LDAP://CNS.local");
                    DirectorySearcher searcher = new DirectorySearcher(entry);

                    //searcher.PropertiesToLoad.Add("givenName");
                    //searcher.PropertiesToLoad.Add("sn");
                    //searcher.PropertiesToLoad.Add("samAccountName");

                    searcher.Filter = "(&(objectCategory=person)(samAccountName=" + comboBox1.Text.ToString() + "))";

                    SearchResult result = searcher.FindOne();

                    if (result != null)
                    {
                        if (result.Properties["telephoneNumber"].Count > 0)
                            textBox1.Text = result.Properties["telephoneNumber"][0].ToString();
                        if (result.Properties["streetAddress"].Count > 0)
                            textBox2.Text = result.Properties["streetAddress"][0].ToString();
                        if (result.Properties["postOfficeBox"].Count > 0)
                            textBox3.Text = result.Properties["postOfficeBox"][0].ToString();
                        if (result.Properties["l"].Count > 0)
                            textBox4.Text = result.Properties["l"][0].ToString();
                        if (result.Properties["st"].Count > 0)
                            textBox5.Text = result.Properties["st"][0].ToString();
                        if (result.Properties["postalCode"].Count > 0)
                            textBox6.Text = result.Properties["postalCode"][0].ToString();
                        if (result.Properties["mobile"].Count > 0)
                            textBox7.Text = result.Properties["mobile"][0].ToString();
                        if (result.Properties["physicalDeliveryOfficeName"].Count > 0)
                            textBox8.Text = result.Properties["physicalDeliveryOfficeName"][0].ToString();
                    }
                    else
                        MessageBox.Show("Error! Unable to find user");
                }
                catch (Exception er)
                {
                    MessageBox.Show("Error! Unable to complete request. Error: \r\n\r\n" + er);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.Text = "1114 North 1st Street, Suite 200";
            textBox4.Text = "Grand Junction";
            textBox5.Text = "CO";
            textBox6.Text = "81501";
            textBox8.Text = "Corporate";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox2.Text = "919 W. Kirby, Suite 2E";
            textBox4.Text = "Champaign";
            textBox5.Text = "IL";
            textBox6.Text = "61821";
            textBox8.Text = "Champaign, IL";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            textBox2.Text = "KUSD Bus Ctr, 400 mesa View Rd #204";
            textBox4.Text = "Kayenta";
            textBox5.Text = "AZ";
            textBox6.Text = "86033";
            textBox8.Text = "Kayenta, AZ";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox2.Text = "237 Barnwell Ave.";
            textBox4.Text = "Aiken";
            textBox5.Text = "SC";
            textBox6.Text = "29801";
            textBox8.Text = "Aiken, SC";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox2.Text = "7001 San Antonio Dr. Suite H";
            textBox4.Text = "Albuquerque";
            textBox5.Text = "NM";
            textBox6.Text = "87109";
            textBox8.Text = "ABQ, NM";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox2.Text = "1552 S. Midway Ave.";
            textBox4.Text = "Ammon";
            textBox5.Text = "ID";
            textBox6.Text = "83406";
            textBox8.Text = "Ammon, ID";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox2.Text = "3540 Wheeler Rd. Suite 308";
            textBox4.Text = "Augusta";
            textBox5.Text = "GA";
            textBox6.Text = "30909";
            textBox8.Text = "Augusta, GA";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox2.Text = "8927 N. US Highway 259";
            textBox4.Text = "Broken Bow";
            textBox5.Text = "OK";
            textBox6.Text = "74728";
            textBox8.Text = "Broken Bow, OK";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox2.Text = "7033 Village Parkway Suite 216";
            textBox4.Text = "Dublin";
            textBox5.Text = "CA";
            textBox6.Text = "94568";
            textBox8.Text = "Dublin, CA";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox2.Text = "801 Roosevelt Ave.";
            textBox4.Text = "Grants";
            textBox5.Text = "NM";
            textBox6.Text = "87020";
            textBox8.Text = "Grants, NM";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox2.Text = "10704 Highway 152";
            textBox4.Text = "Hillsboro";
            textBox5.Text = "NM";
            textBox6.Text = "88042";
            textBox8.Text = "Hillsboro, NM";
        }

        private void button14_Click(object sender, EventArgs e)
        {
            textBox2.Text = "1235 9th ST. Suite 100";
            textBox4.Text = "Las Vegas";
            textBox5.Text = "NM";
            textBox6.Text = "87701";
            textBox8.Text = "Las Vegas, NM";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            textBox2.Text = "1050 E Flamingo Rd. Suite W146";
            textBox4.Text = "Las Vegas";
            textBox5.Text = "NV";
            textBox6.Text = "89119";
            textBox8.Text = "Las Vegas, NV";
        }

        private void button16_Click(object sender, EventArgs e)
        {
            textBox2.Text = "1750 SW Skyline Blvd. Suite 101";
            textBox4.Text = "Portland";
            textBox5.Text = "OR";
            textBox6.Text = "97221";
            textBox8.Text = "Portland, OR";
        }

        private void button17_Click(object sender, EventArgs e)
        {
            textBox2.Text = "8819 S. Redwood Rd. Suite C Main Floor";
            textBox4.Text = "West Jordan";
            textBox5.Text = "UT";
            textBox6.Text = "84088";
            textBox8.Text = "Salt Lake City, UT";
        }

        private void button19_Click(object sender, EventArgs e)
        {
            textBox2.Text = "36 South Richards Run Suite D";
            textBox4.Text = "Springboro";
            textBox5.Text = "OH";
            textBox6.Text = "45066";
            textBox8.Text = "Springboro, OH";
        }

        private void button20_Click(object sender, EventArgs e)
        {
            textBox2.Text = "295 Bradley Blvd. Suite 101";
            textBox4.Text = "Richland";
            textBox5.Text = "WA";
            textBox6.Text = "99352";
            textBox8.Text = "Richland, WA";
        }

        private void button18_Click(object sender, EventArgs e)
        {
            textBox2.Text = "9222 Culebra Rd. Suite 111";
            textBox4.Text = "San Antonio";
            textBox5.Text = "TX";
            textBox6.Text = "78251";
            textBox8.Text = "Springboro, OH";
        }

        private void button21_Click(object sender, EventArgs e)
        {
            textBox2.Text = "5650 Mexico Road, Suite 12";
            textBox4.Text = "St. Peters";
            textBox5.Text = "MO";
            textBox6.Text = "63376";
            textBox8.Text = "ARC - St. Pters, MO";
        }
    }
}
