using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace My_Practice_Application
{
    public partial class SecondPage : Form
    {
        string  average, min, max, mode, varience, standard_devation, range, median; double[] colData;
        public SecondPage(string avrg,string mn,string mx,string varnc,string std,string mdn,string md,string rng,double[] columnData)
        {
            InitializeComponent();
            average = avrg; min = mn; max = mx; varience = varnc; standard_devation = std; median = mdn;
            range = rng; mode = md; colData = columnData;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FirstPage FirstForm = new FirstPage(); FirstForm.Close(); this.Close();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.Text == "Quantitative")
            {
                checkBox7.Enabled = false; 
                checkBox1.Enabled = true; checkBox2.Enabled = true; 
                checkBox3.Enabled = true; checkBox4.Enabled = true; checkBox5.Enabled = true;
                checkBox9.Enabled = true; checkBox8.Enabled = true;
            }
            else if(comboBox1.Text == "Qualitative")
            {
                checkBox1.Enabled = false; checkBox2.Enabled = false; 
                checkBox3.Enabled = false; checkBox4.Enabled = false; checkBox5.Enabled = false; 
                checkBox9.Enabled = false; checkBox8.Enabled = false;
                checkBox7.Enabled = true; 
            }
            else if (comboBox1.Text == "Or, any")
            {
                checkBox1.Enabled = true; checkBox2.Enabled = true;
                checkBox3.Enabled = true; checkBox4.Enabled = true; checkBox5.Enabled = true;
                checkBox9.Enabled = true; checkBox8.Enabled = true; checkBox7.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "") { MessageBox.Show("Please Select any Type of the Data..!"); }
            else if (comboBox1.Text == "Or, any" || comboBox1.Text == "Quantitative" || comboBox1.Text == "Qualitative")
            {
                if (checkBox7.Checked == false && checkBox1.Checked == false && checkBox2.Checked == false && checkBox4.Checked == false &&
                                 checkBox3.Checked == false && checkBox8.Checked == false && checkBox9.Checked == false &&
                                 checkBox5.Checked == false)
                {
                    MessageBox.Show("Please Select any of these..!");
                }
                else
                {
                    Any_of_Them newForm = new Any_of_Them(checkBox1.Checked, checkBox2.Checked, checkBox3.Checked
                       , checkBox4.Checked, checkBox5.Checked, checkBox8.Checked, checkBox9.Checked, average, median, min, max, varience, standard_devation
                       , range, checkBox7.Checked, mode, colData); newForm.Show(); this.Visible = false;
                    if (checkBox1.Checked == false) { newForm.label1_Click(sender, e); newForm.textBox1_TextChanged(sender, e); }
                    else { newForm.label1_Click(sender, e); newForm.textBox1_TextChanged(sender, e); }
                    if (checkBox2.Checked == false) { newForm.label2_Click(sender, e); newForm.textBox2_TextChanged(sender, e); }
                    else { newForm.label2_Click(sender, e); newForm.textBox2_TextChanged(sender, e); }
                    if (checkBox4.Checked == false) { newForm.label3_Click(sender, e); newForm.textBox3_TextChanged(sender, e); }
                    else { newForm.label3_Click(sender, e); newForm.textBox3_TextChanged(sender, e); }
                    if (checkBox3.Checked == false) { newForm.label4_Click(sender, e); newForm.textBox4_TextChanged(sender, e); }
                    else { newForm.label4_Click(sender, e); newForm.textBox4_TextChanged(sender, e); }
                    if (checkBox5.Checked == false) { newForm.label7_Click(sender, e); newForm.textBox5_TextChanged(sender, e); }
                    else { newForm.label7_Click(sender, e); newForm.textBox5_TextChanged(sender, e); }
                    if (checkBox8.Checked == false) { newForm.label5_Click(sender, e); newForm.textBox6_TextChanged(sender, e); }
                    else { newForm.label5_Click(sender, e); newForm.textBox6_TextChanged(sender, e); }
                    if (checkBox9.Checked == false) { newForm.label6_Click(sender, e); newForm.textBox7_TextChanged(sender, e); }
                    else { newForm.label6_Click(sender, e); newForm.textBox7_TextChanged(sender, e); }
                    if (checkBox7.Checked == false) { newForm.label8_Click(sender, e); newForm.textBox8_TextChanged(sender, e); }
                    else { newForm.label8_Click(sender, e); newForm.textBox8_TextChanged(sender, e); } DataGridViewCellEventArgs e1 = null;
                    newForm.TabularForm_CellContentClick(sender, e1);
                }
            }
        }

        public void checkBox2_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        public void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            FirstPage backoption = new FirstPage(); backoption.Show(); this.Visible = false;
        }
    }
}
