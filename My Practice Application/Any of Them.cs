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
    public partial class Any_of_Them : Form
    {
        public bool checking1, checking2, checking3, checking4, checking5, checking8, checking9;
        string average, median, min, max, variance,
            standard, range; public bool checking_7; string mode; double[] colData;
        public Any_of_Them(bool chck1, bool chck2, bool chck3, bool chck4, bool chck5, bool chck8, bool chck9, string avrg,
            string mdn, string mn, string mx, string vrnce, string std, string rng, bool checking7, string modee, double[] columnData)
        {
            InitializeComponent();
            checking1 = chck1; checking2 = chck2; checking3 = chck3; checking4 = chck4; checking5 = chck5;
            checking8 = chck8; checking9 = chck9; average = avrg; min = mn; max = mx; standard = std; variance = vrnce; range = rng; median = mdn;
            checking_7 = checking7; mode = modee; colData = columnData;
        }
        public Any_of_Them()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            SecondPage backoption = new SecondPage(average, min, max,variance,standard, median, mode,range , colData); backoption.Show(); this.Visible = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (checking3 == false)
            {
                textBox4.Enabled = false;
            }
            else
            {
                textBox4.Text = standard;
            }
        }

        public void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (checking4 == false)
            {
                textBox3.Enabled = false;
            }
            else
            {
                textBox3.Text = variance;
            }
        }

        public void textBox5_TextChanged(object sender, EventArgs e)
        {
            if(checking5 == false)
            {
                textBox5.Enabled = false;
            }
            else
            {
                textBox5.Text = range;
            }
        }

        public void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (checking8 == false)
            {
                textBox6.Enabled = false;
            }
            else
            {
                textBox6.Text = min;
            }
        }

        public void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (checking9 == false)
            {
                textBox7.Enabled = false;
            }
            else
            {
                textBox7.Text = max;
            }
        }

        public void label6_Click(object sender, EventArgs e)
        {
            if (checking9 == false)
            {
                label6.Enabled = false;
            }
        }

        public void label5_Click(object sender, EventArgs e)
        {
            if (checking8 == false)
            {
                label5.Enabled = false;
            }
        }

        public void label7_Click(object sender, EventArgs e)
        {
            if (checking5 == false)
            {
                label7.Enabled = false;
            }
        }

        public void label3_Click(object sender, EventArgs e)
        {
            if (checking4 == false)
            {
                label3.Enabled = false;
            }
        }

        public void label4_Click(object sender, EventArgs e)
        {
            if (checking3 == false)
            {
                label4.Enabled = false;
            }
        }

        public void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (checking1 == false)
            {
                textBox1.Enabled = false;
            }
            else
            {
                textBox1.Text = average;
            }
        }

        public void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (checking2 == false)
            {
                textBox2.Enabled = false;
            }
            else
            {
                textBox2.Text = median;
            }
        }

        public void textBox8_TextChanged(object sender, EventArgs e)
        {
            if (checking_7 == false)
            {
                textBox8.Enabled = false;
            }
            else
            {
                textBox8.Text = mode;
            }
        }

        public void label8_Click(object sender, EventArgs e)
        {
            if (checking_7 == false)
            {
                label8.Enabled = false;
            }
        }

        public void label2_Click(object sender, EventArgs e)
        {
            if (checking2 == false)
            {
                label2.Enabled = false;
            }
        }

        public void label1_Click(object sender, EventArgs e)
        {
            if (checking1 == false)
            {
                label1.Enabled = false;
            }
        }

        public void chart1_Click(object sender, EventArgs e)
        {

        }

        public void chart3_Click(object sender, EventArgs e)
        {

        }

        public void chart2_Click(object sender, EventArgs e)
        {

        }
        int len; int[] freqDis;
        public void TabularForm_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Valids", typeof(string));
            table.Columns.Add("Frequency", typeof(int));
            table.Columns.Add("Cumulative Frequency", typeof(int));
            table.Columns.Add("Relative Frequency", typeof(int)); int length = 0; int[] frequecny_distribution = new int[colData.Length];
            int[] relativeFrequency = new int[colData.Length]; int[] cumFrequency = new int[colData.Length];
            while (length < colData.Length)
            {
                frequecny_distribution[Convert.ToInt32(colData[length])]++; length++;
            } length = 0;
            while (length < colData.Length)
            {
                if ((frequecny_distribution[length]) == 0) { length++; continue; }
                else
                {
                    cumFrequency[length] += frequecny_distribution[length]; length++;
                }
            } length = 0;
            while (length < colData.Length)
            {
                if ((frequecny_distribution[length]) == 0) { length++; continue; }
                else { relativeFrequency[length] = frequecny_distribution[Convert.ToInt32(colData[length])] / cumFrequency[length]; length++; }
            } length = 0;
            while (length < colData.Length)
            {
                if ((frequecny_distribution[length]) == 0) { length++; continue; }
                else { table.Rows.Add(Convert.ToString(length), frequecny_distribution[length], cumFrequency[length], relativeFrequency[length]); length++; }
            }
            freqDis = frequecny_distribution; len = length;
            table.Rows.Add("Total", cumFrequency.Sum());
            TabularForm.DataSource = table;
        }
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            FirstPage FirstForm = new FirstPage(); FirstForm.Close(); this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(comboBox1.Text == "Bar Chart")
            {
                Graphs obj = new Graphs(comboBox1.Text, freqDis, len); obj.Show(); this.Visible = false;
                obj.chart3_Click(sender, e);
            }
            else if(comboBox1.Text == "Pie Chart")
            {
                Graph2 obj = new Graph2(comboBox1.Text, freqDis, len); obj.Show(); this.Visible = false;
                obj.chart1_Click(sender, e);
            }
            else if (comboBox1.Text == "Normal Line")
            {
                Graph3 obj = new Graph3(comboBox1.Text, freqDis, len); obj.Show(); this.Visible = false;
                obj.chart1_Click(sender, e);
            }
        }
    }
}
