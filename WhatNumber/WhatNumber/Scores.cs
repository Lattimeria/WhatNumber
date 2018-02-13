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
            AddRecords();
            // проверить существует ли файл. Если нет, создать.
            // если да, переписать из него данные в листвью
            // после этого записать в файл (последним итемом) данные name,diff,time из Record
            // сохранить файл
            // 
            var item = listView1.Items.Add(record.Name);
            item.SubItems.Add(record.Difficult.ToString());
            item.SubItems.Add($"{record.Minutes}:{record.Seconds}");

        }
        public void AddRecords()
        {
            if (File.Exists(Application.StartupPath + "\\records.txt") == false)
                File.Create(Application.StartupPath + "\\records.txt");
            
            /*if (File.Exists(Application.StartupPath + "\\records.txt"))
            {
                var stream  = File.OpenRead(Application.StartupPath + "\\records.txt");
                var reader = new BinaryReader(stream);
                int num = reader.ReadInt32();

                var items = new Record[num];

                for (int i = 0; i < num; i++)
                {
                    items[i] = new Record(reader);
                }
            }
            else
            {
                File.Create(Application.StartupPath + "\\record.txt");
                var stream = FileMode.OpenOrCreate(Application.StartupPath + "\\recors=ds.txt");
                var writer = new BinaryWriter(stream);

                

            }     */

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
