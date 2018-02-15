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
    public partial class Scores : Form
    {

        public Scores(Record record)
        {
            InitializeComponent();
            AddRecords(record);


        }
        public void AddRecords(Record currentRecord)
        {
            var startPath = Application.StartupPath + "\\records.txt";
          
            var records = ReadFromFile(startPath);

            foreach(var record in records)
            {
                var itm = listView1.Items.Add(record.Name);
                itm.SubItems.Add(record.Difficult.ToString());
                itm.SubItems.Add($"{record.Minutes}:{record.Seconds}");
            }

            var item = listView1.Items.Add(currentRecord.Name);
            item.SubItems.Add(currentRecord.Difficult.ToString());
            item.SubItems.Add($"{currentRecord.Minutes}:{currentRecord.Seconds}");

            WriteToFile(startPath, records, currentRecord);       
            

        }
        Record[] ReadFromFile(string startPath)
        {
            var items = new Record[] { };

            if (File.Exists(startPath) == true)
            {
                var stream = File.OpenRead(startPath);
                var reader = new BinaryReader(stream);
                int num = reader.ReadInt32();

                items = new Record[num];

                for (int i = 0; i < num; i++)
                {
                    items[i] = new Record(reader);
                    
                }
                stream.Close();
            }

            return items;
        }
        void WriteToFile(string startPath, Record[] items, Record currentRecord)
        {
            var stream = File.Open(startPath, FileMode.OpenOrCreate);
            var writer = new BinaryWriter(stream);
            var length = 1;

            if (items != null && items.Length > 0)
                length += items.Length;
            writer.Write(length);
            currentRecord.WriteToStream(writer);

            if (length > 1)
                foreach (var item in items)
                {
                    item.WriteToStream(writer);
                }
            stream.Close();
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
