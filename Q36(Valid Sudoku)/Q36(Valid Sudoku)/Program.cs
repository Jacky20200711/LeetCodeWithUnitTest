﻿using System;
using System.Collections.Generic;

namespace Q36_Valid_Sudoku_
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public bool IsValidSudoku(char[][] board)
        {
            // 檢查每一列
            for(int i = 0; i < 9; i++)
            {
                HashSet<char> charSet = new HashSet<char>();

                for (int j = 0; j < 9; j++)
                {
                    if (board[i][j] == '.') continue;

                    // 檢查數字是否重複
                    if (charSet.Contains(board[i][j]))
                    {
                        return false;
                    }
                    else
                    {
                        charSet.Add(board[i][j]);
                    }
                }
            }

            // 檢查每一行
            for (int j = 0; j < 9; j++)
            {
                HashSet<char> charSet = new HashSet<char>();

                for (int i = 0; i < 9; i++)
                {
                    if (board[i][j] == '.') continue;

                    // 檢查數字是否重複
                    if (charSet.Contains(board[i][j]))
                    {
                        return false;
                    }
                    else
                    {
                        charSet.Add(board[i][j]);
                    }
                }
            }

            // 檢查每一個九宮格，檢查順序為 box[0] box[3] box[6] box[1] box[4] box[7] ...
            for (int i = 0; i < 9; i+=3)
            {
                for (int j = 0; j < 9; j+=3)
                {
                    // 檢查當前的 box，檢查順序為 box[i][j] box[i][j+1] ...
                    HashSet<char> charSet = new HashSet<char>();

                    for(int x = i; x < i + 3; x++)
                    {
                        for(int y = j; y < j + 3; y++)
                        {
                            if (board[x][y] == '.') continue;

                            // 檢查數字是否重複
                            if (charSet.Contains(board[x][y]))
                            {
                                return false;
                            }
                            else
                            {
                                charSet.Add(board[x][y]);
                            }
                        }
                    }
                }
            }
            return true;
        }
    }
}
