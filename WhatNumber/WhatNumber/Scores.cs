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
    public partial class Scores : Form
    {
        public Scores()
        {
            InitializeComponent();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form difficulty = Application.OpenForms[0];
            difficulty.Show();
            this.Hide();
            //frmSelectDifficulty.ActiveForm.Show();

        }
    }
}
