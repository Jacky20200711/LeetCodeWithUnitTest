﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Q745_Prefix_and_Suffix_Search_
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public class Trie
        {
            public Node rootOfTrie = null;

            public Trie()
            {
                rootOfTrie = new Node();
            }

            // 每個節點都包含 26 個子節點，分別表示對應的小寫字母
            // 每個節點都擁有一個字典，用來儲存路過此節點的字串其對應的索引(以字串做為 key 以避免紀錄重複的資訊)
            public class Node
            {
                public Node[] ChrPointers { get; set; }

                public Dictionary<string, int> IndexHashTable;

                public Node()
                {
                    ChrPointers = new Node[26];
                    IndexHashTable = new Dictionary<string, int>();
                }
            }

            public void Insert(string key, int index)
            {
                Node CurrentNode = rootOfTrie;

                foreach (char chr in key)
                {
                    int ModifyIndex = chr - 97;

                    // 若該字母不存在則建立對應的節點
                    if (CurrentNode.ChrPointers[ModifyIndex] == null)
                    {
                        CurrentNode.ChrPointers[ModifyIndex] = new Node();
                    }

                    // 將當前的指針移動到下一個節點
                    CurrentNode = CurrentNode.ChrPointers[ModifyIndex];

                    // 儲存路過此節點的字串與對應的索引(若字串重複出現則覆蓋其索引)
                    CurrentNode.IndexHashTable[key] = index;
                }
            }

            public Dictionary<string, int> GetMatchResult(string prefix)
            {
                Node CurrentNode = rootOfTrie;

                // 搜尋 Trie 是否存在該 prefix
                foreach (char chr in prefix)
                {
                    int ModifyIndex = chr - 97;

                    // 字元匹配失敗，結束任務
                    if (CurrentNode.ChrPointers[ModifyIndex] == null)
                    {
                        return null;
                    }

                    // 字元匹配成功，將當前的指針移動到下一個節點
                    CurrentNode = CurrentNode.ChrPointers[ModifyIndex];
                }

                // 匹配 prefix 成功後，當前的指針會指向 prefix 的尾端節點
                // 返回此節點儲存的索引
                return CurrentNode.IndexHashTable;
            }
        }

        public class WordFilter
        {
            public Trie PrefixTree = new Trie();

            // 用來儲存已經搜尋過的配對，其中 Key = prefix & value = set of suffix and answer
            public Dictionary<string, Dictionary<string, int>> CheckedPair = new Dictionary<string, Dictionary<string, int>>();

            public WordFilter(string[] words)
            {
                // 將所有的字串插入到 Trie
                for (int i = 0; i < words.Length; i++)
                {
                    PrefixTree.Insert(words[i], i);
                }
            }

            public int F(string prefix, string suffix)
            {
                // 若曾經搜尋過這個配對則直接返回答案
                if (CheckedPair.ContainsKey(prefix) && CheckedPair[prefix].ContainsKey(suffix))
                {
                    return CheckedPair[prefix][suffix];
                }

                // 取得匹配 prefix 的結果(是一個 HashTable，包含匹配成功的字串與對應的索引)
                Dictionary<string, int> MatchResult = PrefixTree.GetMatchResult(prefix);
                if(MatchResult == null)
                {
                    // 紀錄搜尋過的配對
                    if (!CheckedPair.ContainsKey(prefix))
                    {
                        CheckedPair[prefix] = new Dictionary<string, int>();
                    }
                    CheckedPair[prefix][suffix] = -1;
                    return -1;
                }

                // 檢查 HashTable 儲存的各個字串與對應的索引
                int MaxMatchingIndex = -1;
                foreach (KeyValuePair<string, int> pair in MatchResult)
                {
                    if (pair.Value > MaxMatchingIndex && IsMatchingSuffix(pair.Key, suffix))
                    {
                        MaxMatchingIndex = pair.Value;
                    }
                }

                // 紀錄搜尋過的配對
                if (!CheckedPair.ContainsKey(prefix))
                {
                    CheckedPair[prefix] = new Dictionary<string, int>();
                }
                CheckedPair[prefix][suffix] = MaxMatchingIndex;

                return MaxMatchingIndex;
            }

            public bool IsMatchingSuffix(string Target, string Suffix)
            {
                if (Suffix.Length > Target.Length)
                {
                    return false;
                }

                int CurrentIndexOfTarget = Target.Length - 1;

                for (int i = Suffix.Length - 1; i > -1; i--)
                {
                    if (Target[CurrentIndexOfTarget--] != Suffix[i])
                    {
                        return false;
                    }
                }

                return true;
            }
        }

        public WordFilter GetWordFilter(string[] words)
        {
            return new WordFilter(words);
        }

        public static void PrintList(List<int> IndexList)
        {
            foreach (int index in IndexList)
            {
                Console.Write($"{index} ");
            }
            Console.WriteLine();
        }
    }
}