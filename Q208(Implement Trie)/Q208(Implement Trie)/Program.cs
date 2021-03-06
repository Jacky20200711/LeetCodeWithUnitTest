﻿using System;

namespace Q208_Implement_Trie_
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public Trie GetTrie()
        {
            return new Trie();
        }

        public class Trie
        {
            // 每個節點都包含 26 個子節點，分別表示對應的小寫字母
            public class Node 
            {
                public bool IsStringEnd { get; set; }

                public Node[] ChrPointers { get; set; }

                public Node()
                {
                    IsStringEnd = false;
                    ChrPointers = new Node[26];
                }
            }

            private readonly Node rootOfTrie = null;

            public Trie()
            {
                rootOfTrie = new Node();
            }

            public void Insert(string word)
            {
                Node CurrentNode = rootOfTrie;

                foreach(char chr in word)
                {
                    int ModifyIndex = chr - 97;

                    // 若該字母不存在則建立對應的節點
                    if (CurrentNode.ChrPointers[ModifyIndex] == null)
                    {
                        CurrentNode.ChrPointers[ModifyIndex] = new Node();
                    }

                    // 將當前的指針移動到下一個節點
                    CurrentNode = CurrentNode.ChrPointers[ModifyIndex];
                }

                // 標記最後的節點(若要查詢儲存的某字串，就是以這個標記作為搜尋的結尾)
                CurrentNode.IsStringEnd = true;
            }

            public bool Search(string word)
            {
                Node CurrentNode = rootOfTrie;

                // 走訪對應的節點
                foreach (char chr in word)
                {
                    int ModifyIndex = chr - 97;

                    if (CurrentNode.ChrPointers[ModifyIndex] == null)
                    {
                        return false;
                    }

                    // 將當前的指針移動到下一個節點
                    CurrentNode = CurrentNode.ChrPointers[ModifyIndex];
                }

                // 查看當前節點的標記，確認是否為儲存過的字串尾端
                return CurrentNode.IsStringEnd;
            }

            public bool StartsWith(string Prefix)
            {
                Node CurrentNode = rootOfTrie;

                // 走訪對應的節點
                foreach (char chr in Prefix)
                {
                    int ModifyIndex = chr - 97;

                    if (CurrentNode.ChrPointers[ModifyIndex] == null)
                    {
                        return false;
                    }

                    // 將當前的指針移動到下一個節點
                    CurrentNode = CurrentNode.ChrPointers[ModifyIndex];
                }

                return true;
            }
        }
    }
}
