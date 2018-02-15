using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WhatNumber
{
    public partial class Form1 : Form
    {
        Button[,] btns;
        Game game;
        bool buttonsBlocked = false;
        Stopwatch sw;
        string GamerName;
        public Form1(int size, string gamerName)
        {
            InitializeComponent();
            InitializeButton(size);
            StartGame(size);
            sw = new Stopwatch();
            sw.Start();
            GamerName = gamerName;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void StartGame(int size) //создание новой игры
        {
            game = new Game();
            game.Start(size);

        }

        void InitializeButton(int count) //инициализация ячеек (отрисовка)
        {
            btns = new Button[count, count];
            for (int i = 0; i < count; ++i)
            {
                for (int j = 0; j < count; ++j)
                {
                    btns[i, j] = new Button();
                    btns[i, j].Size = new Size(60, 60);
                    btns[i, j].Location = new Point(i * 60, j * 60);
                    btns[i, j].Text = "?";
                    int x = i;
                    int y = j;
                    btns[i, j].Click += (sender, but_event) =>
                    {
                        button_MouseClick(x, y);
                    };
                    this.Controls.Add(btns[i, j]);
                }
            }
        }
        void button_MouseClick(int i, int j) //обработчик щелчка кнопки
        {
            if (buttonsBlocked)
                return;

            bool closeAllCells;
            int number = game.OpenCell(i, j, out closeAllCells);
            btns[i, j].Enabled = false;
            btns[i, j].Text = number.ToString();
            if (closeAllCells == true)
            {
                buttonsBlocked = true;
                timer1.Start();
            }
            if (game.IsWin())
            {
                sw.Stop();

                Record record = new Record();
                record.Difficult = btns.GetLength(0);
                record.Minutes = sw.Elapsed.Minutes;
                record.Seconds = sw.Elapsed.Seconds;
                record.Name = GamerName;

                Scores scores = new Scores(record);
                scores.Show();
                this.Close();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            buttonsBlocked = false;
            timer1.Stop();
            for (int i = 0; i < btns.GetLength(0); i++)
            {
                for (int j = 0; j < btns.GetLength(1); j++)
                {
                    btns[i, j].Enabled = true;
                   // btns[i, j].Text = "?";
                }
            }
        }

    }

}
