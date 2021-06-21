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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                if(textBox1.Text.Contains("http")|| textBox1.Text.Contains("https"))
                {
                    System.Diagnostics.Process.Start(textBox1.Text);
                    textBox1.Text = "";
                }
                else
                {
                    string tagnumber = "CNS-"+textBox1.Text;
                    textBox1.Text = "";

                    ELSCDataContext equipment = new ELSCDataContext();

                    if(equipment.Equipments.Any(eq => eq.TagID.ToString() == tagnumber))
                    {
                        var oldequip = new OldEquipment(tagnumber);
                        oldequip.Show();
                        if (checkBox1.Checked)
                        {
                            this.BringToFront();
                        }
                    }
                    else
                    {
                        var newequip = new CreateEquip(tagnumber);
                        newequip.Show();
                        if (checkBox1.Checked)
                        {
                            this.BringToFront();
                        }
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}
