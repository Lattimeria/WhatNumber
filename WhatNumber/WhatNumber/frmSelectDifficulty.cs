using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WhatNumber
{
    public partial class frmSelectDifficulty : Form
    {
        public frmSelectDifficulty()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 gameForm = new Form1(4, this);
            gameForm.Show();

            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 gameForm = new Form1(6, this);
            gameForm.Show();

            this.Hide();
        }
    }
}
