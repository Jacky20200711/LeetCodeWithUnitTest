﻿using System;
using System.Collections.Generic;

namespace Q49_Group_Anagrams_
{
    public class Program
    {
        static void Main(string[] args)
        {
            
        }

        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            IList<IList<string>> AnagramGroups = new List<IList<string>>();

            // Key 為各字元排序後轉成的哈希字串，Value 為該哈希字串對應到的群組索引
            Dictionary<string, int> IndexGroups = new Dictionary<string, int>();
            int GroupNum = 0;

            for (int i = 0; i < strs.Length; i++)
            {
                // 重點:具有同樣字元頻率的兩個字串，各自對內部的字元進行排序後其結果會一樣
                // 利用這個特性，我們將當前字串的內部進行排序後，放入字典當 Hash Key
                char[] CharArrayOfStr = strs[i].ToCharArray();
                Array.Sort(CharArrayOfStr);
                string FreqStr = string.Join("", CharArrayOfStr);

                // 若該哈希字串已經存在對應的群組則加入
                if (IndexGroups.ContainsKey(FreqStr))
                {
                    AnagramGroups[IndexGroups[FreqStr]].Add(strs[i]);
                }
                // 若不存在則建立新的群組並加入
                else
                {
                    IndexGroups[FreqStr] = GroupNum;
                    AnagramGroups.Add(new List<string> { strs[i] });
                    GroupNum++;
                }
            }
            return AnagramGroups;
        }
    }
}
