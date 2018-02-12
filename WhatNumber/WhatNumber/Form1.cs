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
        public Button[,] but;
        Game game;
        bool buttonsBlocked = false;
        Stopwatch sw;
        public string NameGamer;
        public Form1(int size, frmSelectDifficulty difficultyForm, string nameGamer)
        {
            InitializeComponent();
            InitializeButton(size);
            StartGame(size);
            sw = new Stopwatch();
            sw.Start();
            NameGamer = nameGamer;
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
            but = new Button[count,count];
            for (int i = 0; i < count; ++i)
            {
                for (int j = 0; j < count; ++j)
                {
                    but[i, j] = new Button();
                    but[i, j].Size = new Size(60, 60);
                    but[i, j].Location = new Point(i * 60, j * 60);
                    but[i, j].Text ="?";
                    int x = i;
                    int y = j;
                    but[i, j].Click += (sender, but_event) =>
                    {
                        but_MouseClick(x, y);
                    };
                    this.Controls.Add(but[i, j]);
                }
            }
        }
        void but_MouseClick(int i, int j) //обработчик щелчка кнопки
        {
            if (buttonsBlocked)
                return;

            bool closeAllCells;
            int number = game.OpenCell(i, j, out closeAllCells);
            but[i, j].Enabled = false;
            but[i, j].Text = number.ToString();
            if (closeAllCells == true)
            {
                buttonsBlocked = true;
                timer1.Start();
            }
            if (game.IsWin())
            {
                sw.Stop();
                
                Record record = new Record();
                record.Difficult = but.GetLength(0);
                record.Minutes = sw.Elapsed.Minutes;
                record.Seconds = sw.Elapsed.Seconds;
                record.Name = NameGamer;

                Scores scores = new Scores(record);
                scores.Show();
                this.Close();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            buttonsBlocked = false;
            timer1.Stop();
            for(int i=0;i<but.GetLength(0);i++)
            {
                for(int j=0;j< but.GetLength(1); j++)
                {
                    but[i, j].Enabled = true;
                    but[i, j].Text = "?";
                }
            }
        }

    }

}
