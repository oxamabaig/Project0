﻿using System;
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
    public partial class Graph3 : Form
    {
        string selection; int[] freqDistribution; int length;
        public Graph3(string comboboxSelection, int[] freqDist, int len)
        {
            InitializeComponent();
            selection = comboboxSelection; freqDistribution = freqDist; length = len;
        }

        public void chart1_Click(object sender, EventArgs e)
        {
            int i = 0;
            while (i < length)
            {
                if ((freqDistribution[i]) == 0) { i++; continue; }
                else
                {
                    chart1.Series["Series1"].Points.AddXY(i, freqDistribution[i]); i++;
                }
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Any_of_Them backOption = new Any_of_Them(); backOption.Show(); this.Visible = false;
        }
    }
}
