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
        public string NameGamer;
        public frmSelectDifficulty()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NameGamer = textBox1.Text;
            Form1 gameForm = new Form1(4, this, NameGamer);
            gameForm.Show();

            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NameGamer = textBox1.Text;
            Form1 gameForm = new Form1(6, this,NameGamer);
            gameForm.Show();

            this.Hide();
        }
        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            NameGamer = "NotIdentified";
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
