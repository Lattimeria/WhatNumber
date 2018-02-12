using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WhatNumber
{
    public partial class Scores  : Form
    {
        
        public Scores(Record record)
        {
            
            InitializeComponent();

            var stream = File.OpenRead(Application.StartupPath + "\\filename");

            var reader = new BinaryReader(stream);
            int num = reader.ReadInt32();

            var items = new Record[num];

            for (int i = 0; i < num; i++)
            {
                items[i] = new Record(reader);
            }

            var item = listView1.Items.Add(record.Name);
            item.SubItems.Add(record.Difficult.ToString());
            item.SubItems.Add($"{record.Minutes}:{record.Seconds}");

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form difficulty = Application.OpenForms[0];
            difficulty.Show();
            this.Hide();
        }
        
    }
}
