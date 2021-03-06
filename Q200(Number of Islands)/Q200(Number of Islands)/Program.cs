﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Q200_Number_of_Islands_
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public void SetRegionByDFS(char[][] board, int row, int col)
        {
            // 標記這個新到達的點
            board[row][col] = '0';

            // 測試可否往上
            int i = row - 1;
            int j = col;
            if (i > -1 && board[i][j] == '1')
            {
                SetRegionByDFS(board, i, j);
            }

            // 測試可否往下
            i = row + 1;
            j = col;
            if (i < board.Length && board[i][j] == '1')
            {
                SetRegionByDFS(board, i, j);
            }

            // 測試可否往左
            i = row;
            j = col - 1;
            if (j > -1 && board[i][j] == '1')
            {
                SetRegionByDFS(board, i, j);
            }

            // 測試可否往右
            i = row;
            j = col + 1;
            if (j < board[0].Length && board[i][j] == '1')
            {
                SetRegionByDFS(board, i, j);
            }
        }

        public int NumIslands(char[][] grid)
        {
            int num_land = 0;

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    // 搜尋沒有拜訪過的1字元
                    if (grid[i][j] == '1')
                    {
                        // 從該字元做DFS以標記所屬的整個區域
                        SetRegionByDFS(grid, i, j);
                        num_land++;
                    }
                }
            }
            return num_land;
        }
    }
}
