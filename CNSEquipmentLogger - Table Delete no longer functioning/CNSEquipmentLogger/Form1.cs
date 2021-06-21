using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;



namespace CNSEquipmentLogger
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            listView1.View = View.Details;
            listView1.FullRowSelect = true;

            reloaddata();
        }

        public void reloaddata()
        {
            if (comboBox1.SelectedIndex == 0)
            {
                listView1.Items.Clear();
                EquipInfoDataContext equipment = new EquipInfoDataContext();

                var r = from i in equipment.Equipments
                        select i;

                string temp = "";
                foreach (var e in r)
                {
                    string patient = "No";
                    if (e.IsPatient == true)
                    {
                        patient = "Yes";
                    }
                    if (e.Destroyed == false || e.Destroyed == null)
                    {
                        if (e.BitlockerStatus == 'A')
                        {
                            temp = "Active";
                            string[] row = { temp, e.DateEncryptionChecked.ToString(), e.CurrentAssignee, e.Type, patient, e.CurrentLocation,e.Id.ToString() };
                            listView1.Items.Add(e.TagID).SubItems.AddRange(row);
                        }
                        if (e.BitlockerStatus == 'D')
                        {
                            temp = "Disabled";
                            string[] row = { temp, e.DateEncryptionChecked.ToString(), e.CurrentAssignee, e.Type, patient, e.CurrentLocation, e.Id.ToString() };
                            listView1.Items.Add(e.TagID).SubItems.AddRange(row);
                        }
                        if (e.BitlockerStatus == 'S')
                        {
                            temp = "Suspended";
                            string[] row = { temp, e.DateEncryptionChecked.ToString(), e.CurrentAssignee, e.Type, patient, e.CurrentLocation, e.Id.ToString() };
                            listView1.Items.Add(e.TagID).SubItems.AddRange(row);
                        }
                    }
                    //destroyed
                    else
                    {
                        if (e.BitlockerStatus == 'A')
                        {
                            temp = "Active";
                            string[] row = { temp, e.DateEncryptionChecked.ToString(), "Destroyed", e.Type, patient, "Destroyed", e.Id.ToString() };
                            listView1.Items.Add(e.TagID).SubItems.AddRange(row);
                        }
                        if (e.BitlockerStatus == 'D')
                        {
                            temp = "Disabled";
                            string[] row = { temp, e.DateEncryptionChecked.ToString(), "Destroyed", e.Type, patient, "Destroyed", e.Id.ToString() };
                            listView1.Items.Add(e.TagID).SubItems.AddRange(row);
                        }
                        if (e.BitlockerStatus == 'S')
                        {
                            temp = "Suspended";
                            string[] row = { temp, e.DateEncryptionChecked.ToString(), "Destroyed", e.Type, patient, "Destroyed", e.Id.ToString() };
                            listView1.Items.Add(e.TagID).SubItems.AddRange(row);
                        }
                    }
                }

            }
            else
            {
                listView1.Items.Clear();
                EquipInfoDataContext equipment = new EquipInfoDataContext();

                var r = from i in equipment.Equipments
                        where i.Type.ToString()==comboBox1.Text.ToString()
                        select i;

                string temp = "";
                foreach (var e in r)
                {
                    string patient = "No";
                    if (e.IsPatient == true)
                    {
                        patient = "Yes";
                    }
                    if (e.Destroyed == false || e.Destroyed == null)
                    {
                        if (e.BitlockerStatus == 'A')
                        {
                            temp = "Active";
                            string[] row = { temp, e.DateEncryptionChecked.ToString(), e.CurrentAssignee, e.Type, patient, e.CurrentLocation, e.Id.ToString() };
                            listView1.Items.Add(e.TagID).SubItems.AddRange(row);
                        }
                        if (e.BitlockerStatus == 'D')
                        {
                            temp = "Disabled";
                            string[] row = { temp, e.DateEncryptionChecked.ToString(), e.CurrentAssignee, e.Type, patient, e.CurrentLocation, e.Id.ToString() };
                            listView1.Items.Add(e.TagID).SubItems.AddRange(row);
                        }
                        if (e.BitlockerStatus == 'S')
                        {
                            temp = "Suspended";
                            string[] row = { temp, e.DateEncryptionChecked.ToString(), e.CurrentAssignee, e.Type, patient, e.CurrentLocation, e.Id.ToString() };
                            listView1.Items.Add(e.TagID).SubItems.AddRange(row);
                        }
                    }
                    //destroyed
                    else
                    {
                        if (e.BitlockerStatus == 'A')
                        {
                            temp = "Active";
                            string[] row = { temp, e.DateEncryptionChecked.ToString(), "Destroyed", e.Type, patient, "Destroyed", e.Id.ToString() };
                            listView1.Items.Add(e.TagID).SubItems.AddRange(row);
                        }
                        if (e.BitlockerStatus == 'D')
                        {
                            temp = "Disabled";
                            string[] row = { temp, e.DateEncryptionChecked.ToString(), "Destroyed", e.Type, patient, "Destroyed", e.Id.ToString() };
                            listView1.Items.Add(e.TagID).SubItems.AddRange(row);
                        }
                        if (e.BitlockerStatus == 'S')
                        {
                            temp = "Suspended";
                            string[] row = { temp, e.DateEncryptionChecked.ToString(), "Destroyed", e.Type, patient, "Destroyed", e.Id.ToString() };
                            listView1.Items.Add(e.TagID).SubItems.AddRange(row);
                        }
                    }
                }

            }
            listView1.Sorting = SortOrder.Ascending;
            listView1.Sort();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (EquipInfoDataContext dbContext = new EquipInfoDataContext())
            {
                try
                {
                    Equipment eq = dbContext.Equipments.SingleOrDefault(X => X.TagID.ToString() == listView1.FocusedItem.Text.ToString());

                    eq.DateEncryptionChecked = DateTime.Now;
                    dbContext.SubmitChanges();
                }
                catch
                {
                    MessageBox.Show("Please select an item to update bitlocker check-in");
                }
            }                
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.FocusedItem != null)
            {
                var update = new Update(listView1.FocusedItem.Text.ToString(), this);
                update.Show();
            }
            else
            {
                MessageBox.Show("Please pick a Item to update!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //if (listView1.FocusedItem != null)
            //{
            //    MessageBox.Show(listView1.FocusedItem.Text.ToString());
            //    using (EquipInfoDataContext dbContext = new EquipInfoDataContext())
            //    {
            //        try
            //        {
            //            Equipment eq = dbContext.Equipments.SingleOrDefault(X => X.TagID.ToString() == listView1.FocusedItem.Text.ToString());
            //            savedetails(eq);
            //        }
            //        catch
            //        {
            //            MessageBox.Show("Unable to save details on selected item.");
            //        }
            //        reloaddata();
            //    }
            //}
            //else
            //{
                savedetails();
                reloaddata();
            //}
        }

        //save ALL details
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
                string[] hrow = new string[] { "Tag ID", "Serial Number", "Encryption Status", "Last Encryption Check", "Current Location", "Address", "City", "State", "ZIP", "Previous Location", "Currently Assigned to:", "Previous Assignee", "Destroyed", "Type", "Assigned to Patient?", "Notes", "Currently Installed Software", "Previously Installed Software" };
                sb.AppendLine(string.Join(delimiter, hrow));

                EquipInfoDataContext db = new EquipInfoDataContext();
                var eqs = from p in db.Equipments
                          select p;

                foreach (var eq in eqs)
                {
                    string bitlocker = "";
                    string destroyed = "";
                    string patient = "";

                    string tagid = eq.TagID;
                    string SN = eq.SerialNumber;
                    string date = eq.DateEncryptionChecked.ToString();
                    string cloc = eq.CurrentLocation;
                    string cass = eq.CurrentAssignee;
                    string ploc = eq.PreviousLocation;
                    string pass = eq.PreviousAssignee;
                    string type = eq.Type;
                    string notes = eq.Notes;
                    string psoft = eq.P_Software;
                    string csoft = eq.Installed_Software;
                    string caddre = eq.Address;
                    string cstate = eq.State;
                    string zip = eq.ZIP;
                    string city = eq.City;


                    removecoma(ref tagid);
                    removecoma(ref SN);
                    removecoma(ref date);
                    removecoma(ref cloc);
                    removecoma(ref cass);
                    removecoma(ref ploc);
                    removecoma(ref pass);
                    removecoma(ref type);
                    removecoma(ref notes);
                    removecoma(ref caddre);
                    removecoma(ref cstate);
                    removecoma(ref zip);
                    removecoma(ref city);


                    if (eq.BitlockerStatus == 'A')
                        bitlocker = "Active";
                    else if (eq.BitlockerStatus == 'D')
                        bitlocker = "Disabled";
                    else if (eq.BitlockerStatus == 'S')
                        bitlocker = "Suspended";

                    if (eq.Destroyed == true)
                        destroyed = "Destroyed";
                    else
                        destroyed = "Active";

                    if (eq.IsPatient == true)
                    {
                        patient = "Yes";
                    }
                    else if (eq.IsPatient == false)
                    {
                        patient = "No";
                    }
                    removecoma2(ref csoft);
                    removecoma2(ref psoft);
                    removecoma(ref bitlocker);
                    removecoma(ref destroyed);

                    Console.WriteLine(cloc);
                    Console.WriteLine(ploc);
                    //MessageBox.Show(tagid+ SN+ bitlocker+ date+ cloc+ ploc+ cass+ pass+ destroyed+ type+ patient+ notes+ csoft+ psoft);
                    string[] row = new string[] { tagid, SN, bitlocker, date, cloc, caddre, city, cstate, zip, ploc, cass, pass, destroyed, type, patient, notes, csoft, psoft };
                    sb.AppendLine(string.Join(delimiter, row));
                }
                File.WriteAllText(path, sb.ToString(), Encoding.UTF8);
            }
            catch { }
        }

        private void removecoma(ref string a)
        {
            if (a != null)
            {
                a = a.Replace(",", "");
                a = a.Replace("\r\n", "");
            }
        }
        private void removecoma2(ref string b)
        {
            if (b != null)
            {
                b = b.Replace(",", " & ");
                b = b.Replace("\r\n", "");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure this equipment was destroyed?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                using (EquipInfoDataContext dbContext = new EquipInfoDataContext())
                {
                    try
                    {
                        Equipment eq = dbContext.Equipments.SingleOrDefault(X => X.TagID.ToString() == listView1.FocusedItem.Text.ToString());

                        eq.Destroyed = true;
                        dbContext.SubmitChanges();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("No Server connection available. Please try again. \r\n" + ex.ToString());
                    }
                    reloaddata();
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var newequip = new Form2(this);
            newequip.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            reloaddata();
        }

        private void button8_Click(object sender, EventArgs ex)
        {
            listView1.Items.Clear();
            EquipInfoDataContext equipment = new EquipInfoDataContext();

            var r = from i in equipment.Equipments
                    where i.TagID.ToString().Contains(textBox1.Text.ToString()) || i.CurrentAssignee.ToString().Contains(textBox1.Text.ToString()) || 
                    i.CurrentLocation.ToString().Contains(textBox1.Text.ToString()) || i.PreviousAssignee.ToString().Contains(textBox1.Text.ToString()) || 
                    i.PreviousLocation.ToString().Contains(textBox1.Text.ToString()) || i.SerialNumber.ToString().Contains(textBox1.Text.ToString())
                    select i;

            string temp = "";
            foreach (var e in r)
            {
                string patient = "No";
                if (e.IsPatient == true)
                {
                    patient = "Yes";
                }
                if (e.Destroyed == false || e.Destroyed == null)
                {
                    if (e.BitlockerStatus == 'A')
                    {
                        temp = "Active";
                        string[] row = { temp, e.DateEncryptionChecked.ToString(), e.CurrentAssignee, e.Type, patient, e.CurrentLocation, e.Id.ToString() };
                        listView1.Items.Add(e.TagID).SubItems.AddRange(row);
                    }
                    if (e.BitlockerStatus == 'D')
                    {
                        temp = "Disabled";
                        string[] row = { temp, e.DateEncryptionChecked.ToString(), e.CurrentAssignee, e.Type, patient, e.CurrentLocation, e.Id.ToString() };
                        listView1.Items.Add(e.TagID).SubItems.AddRange(row);
                    }
                    if (e.BitlockerStatus == 'S')
                    {
                        temp = "Suspended";
                        string[] row = { temp, e.DateEncryptionChecked.ToString(), e.CurrentAssignee, e.Type, patient, e.CurrentLocation, e.Id.ToString() };
                        listView1.Items.Add(e.TagID).SubItems.AddRange(row);
                    }
                }
                //destroyed
                else
                {
                    if (e.BitlockerStatus == 'A')
                    {
                        temp = "Active";
                        string[] row = { temp, e.DateEncryptionChecked.ToString(), "Destroyed", e.Type, patient, "Destroyed", e.Id.ToString() };
                        listView1.Items.Add(e.TagID).SubItems.AddRange(row);
                    }
                    if (e.BitlockerStatus == 'D')
                    {
                        temp = "Disabled";
                        string[] row = { temp, e.DateEncryptionChecked.ToString(), "Destroyed", e.Type, patient, "Destroyed", e.Id.ToString() };
                        listView1.Items.Add(e.TagID).SubItems.AddRange(row);
                    }
                    if (e.BitlockerStatus == 'S')
                    {
                        temp = "Suspended";
                        string[] row = { temp, e.DateEncryptionChecked.ToString(), "Destroyed", e.Type, patient, "Destroyed", e.Id.ToString() };
                        listView1.Items.Add(e.TagID).SubItems.AddRange(row);
                    }
                }
            }
            listView1.SelectedIndices.Clear();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            reloaddata();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void ListView1_DoubleClick(object sender, EventArgs e)
        {
            if (listView1.FocusedItem != null)
            {
                var update = new Update(listView1.FocusedItem.Text.ToString(), this);
                update.Show();
            }
            else
            {
                MessageBox.Show("Please pick a Item to update!");
            }
        }

        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                button8_Click(this, e);
            }
        }
    }
}
