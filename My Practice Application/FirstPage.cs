using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExcelLibrary.SpreadSheet;
using ExcelLibrary.CompoundDocumentFormat;
using System.Data.OleDb;

namespace My_Practice_Application
{
    public partial class FirstPage : Form
    {
        public FirstPage()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
     
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if(ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.textBox1.Text = ofd.FileName;
            }
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "" && textBox2.Text != "")
            {
                string PathConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + textBox1.Text + ";Extended Properties=\"Excel 8.0;HDR=Yes;\";";
                OleDbConnection conn = new OleDbConnection(PathConn);
                OleDbDataAdapter myDataAdapter = new OleDbDataAdapter("Select * from [" + textBox2.Text + "$]", conn);
                DataTable dt = new DataTable();
                myDataAdapter.Fill(dt);
                dataGridView1.DataSource = dt;
                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    this.comboBox1.Items.Add(dataGridView1.Columns[i].Name);
                }
            }
            else
            {
                MessageBox.Show("Please enter the missing value.");
            }
        }

        public void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;
            if (dataGridView1.Columns.Count != 0)
            {
                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    if (dataGridView1.Columns[i].Name == comboBox1.Text)
                    {
                        double[] columnData = (from DataGridViewRow row in dataGridView1.Rows
                                            where row.Cells[i].FormattedValue.ToString() != string.Empty
                                            select Convert.ToDouble(row.Cells[i].FormattedValue)).ToArray();
                        string average = columnData.Average().ToString();
                        string min = columnData.Min().ToString();
                        string max = columnData.Max().ToString();
                        double sum = Convert.ToDouble(columnData.Sum(d => Math.Pow((d - Convert.ToDouble(average)), 2)));
                        string standard_Deviation = Convert.ToString(Math.Sqrt((sum) / (columnData.Count() - 1)));
                        string range = Convert.ToString(Convert.ToDouble(max) - Convert.ToDouble(min));
                        // Median
                        string median; double[] tempArray = columnData;
                        int count = tempArray.Length; Array.Sort(tempArray);
                        if (count % 2 == 0)
                        {
                            double middleElement1 = tempArray[(count / 2) - 1]; double middleElement2 = tempArray[(count / 2)];
                            median = Convert.ToString((middleElement1 + middleElement2) / 2);
                        }
                        else
                        {
                            median = Convert.ToString(columnData[(count / 2)]);
                        }
                        var mode = tempArray.GroupBy(n => n).
                        OrderByDescending(g => g.Count()).
                        Select(g => g.Key).FirstOrDefault();
                        // MOdd
                        string mod = Convert.ToString(mode);
                        double sumOfSquares = 0.0;
                        foreach (int num in tempArray)
                        {
                            sumOfSquares += Math.Pow((num - Convert.ToDouble(average)), 2.0);
                        }
                        // Varience
                        string varience = Convert.ToString(sumOfSquares / (double)(tempArray.Length - 1));
                        SecondPage open = new SecondPage(average, min, max, varience, standard_Deviation, median, mod, range,columnData); open.Show(); Visible = false;
                    }
                }
            }
            else
            {
                MessageBox.Show("Please First Choose any Excel File.");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
