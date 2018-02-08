﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// количество ходов(счет), сложность, 
// привести код в порядок (явно прописать модификаторы доступа)
namespace WhatNumber
{
    class Game
    {
        Cell[,] Cells;
        public void Start(int size)
        {
            InitializeNumber(size);
        }
        void InitializeNumber(int size)
        {
            Cells = new Cell[size, size];
            var numberList = new List<int>();
            for (int i = 0; i < size * size; i += 2)
            {
                numberList.Add(i / 2 + 1);
                numberList.Add(i / 2 + 1);
            }

            var random = new Random();

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    var r = random.Next(numberList.Count);
                    Cells[i, j] = new Cell(numberList[r]);
                    numberList.RemoveAt(r);
                }
            }
        }
        public int OpenCell(int x, int y, out bool closeAllCells)
        {
            var cellToCheck = Cells[x, y];

            if (IsAnythingOpened())
            {
                var alreadyOpenedCellWithoutPair = GetOpenedCellWithoutPair();
                if (alreadyOpenedCellWithoutPair != null &&
                    alreadyOpenedCellWithoutPair.Value != cellToCheck.Value)
                {
                    closeAllCells = true;
                    CloseAllCells();
                    return cellToCheck.Value;
                }
            }

            cellToCheck.IsOpened = true;
            closeAllCells = false;
            return cellToCheck.Value;
        }

        public bool IsWin()
        {
            return false;       // дописать логику
        }
        void CloseAllCells()
        {
            for (int i = 0; i < Cells.GetLength(0); i++)
            {
                for (int j = 0; j < Cells.GetLength(1); j++)
                {
                    Cells[i, j].IsOpened = false;
                }
            }
        }

        // TODO: поменять аргументы на Cell
        bool IsPairOpened(int valueToCheck, int x, int y)
        {
            for (int i = 0; i < Cells.GetLength(0); i++)
            {
                for (int j = 0; j < Cells.GetLength(1); j++)
                {
                    if (Cells[i, j].IsOpened && Cells[i, j].Value == valueToCheck && (x != i || y != j))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        Cell GetOpenedCellWithoutPair()
        {
            for (int i = 0; i < Cells.GetLength(0); i++)
            {
                for (int j = 0; j < Cells.GetLength(1); j++)
                {
                    Cell cell = Cells[i, j];
                    if (cell.IsOpened && !IsPairOpened(cell.Value, i, j))
                    {
                        return cell;
                    }
                }
            }

            return null;
        }

        bool IsAnythingOpened()
        {
            for (int i = 0; i < Cells.GetLength(0); i++)
            {
                for (int j = 0; j < Cells.GetLength(1); j++)
                {
                    if (Cells[i, j].IsOpened)
                        return true;
                }
            }

            return false;
        }

    }

    public class Cell
    {
        public int Value;
        public bool IsOpened;

        public Cell(int value)
        {
            Value = value;
        }
    }
}
