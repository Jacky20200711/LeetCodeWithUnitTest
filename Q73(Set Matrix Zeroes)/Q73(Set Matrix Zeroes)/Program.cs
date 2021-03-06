﻿using System;
using System.Collections.Generic;

namespace Q73_Set_Matrix_Zeroes_
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public void SetZeroes(int[][] matrix)
        {
            HashSet<int> rowToZero = new HashSet<int>();
            HashSet<int> colToZero = new HashSet<int>();

            // 紀錄需要設成零的 row 和 col
            for(int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[0].Length; j++)
                {
                    if(matrix[i][j] == 0)
                    {
                        rowToZero.Add(i);
                        colToZero.Add(j);
                    }
                }
            }

            // 將紀錄的 row 設成 0
            foreach(int row in rowToZero)
            {
                for (int i = 0; i < matrix[0].Length; i++)
                {
                    matrix[row][i] = 0;
                }
            }

            // 將紀錄的 col 設成 0
            foreach (int col in colToZero)
            {
                for (int i = 0; i < matrix.Length; i++)
                {
                    matrix[i][col] = 0;
                }
            }
        }
    }
}
