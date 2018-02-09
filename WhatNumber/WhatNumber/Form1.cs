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
    public partial class Form1 : Form
    {
        int size = 4;
        public Button[,] but;
        Game game;
        bool buttonsBlocked = false;
        public Form1(int size, frmSelectDifficulty difficultyForm)
        {
            InitializeComponent();
            InitializeButton(size);
            StartGame();

            
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        public void StartGame() //создание новой игры
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
                Scores scores = new Scores();
                scores.Show();
                this.Close();
                //Scores.ActiveForm.Show();
            }
        }

        private void timer1_Tick(object sender, EventArgs e) //таймер закрытие ячеек
        {
            buttonsBlocked = false;
            timer1.Stop();
            for(int i=0;i<size;i++)
            {
                for(int j=0;j<size;j++)
                {
                    but[i, j].Enabled = true;
                    but[i, j].Text = "?";
                }
            }
        }
    }

}
