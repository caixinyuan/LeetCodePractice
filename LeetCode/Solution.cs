using System;
using System.Collections.Generic;
using System.Text;

namespace Solution
{
    public class Solution
    {

        #region 两数之和

        /// <summary>
        /// 1.两数之和
        /// 哈希表
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> keyValues = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (keyValues.ContainsKey(target - nums[i]))
                {
                    return new[] { i, keyValues[target - nums[i]] };
                }
                keyValues.Add(nums[i], i);
            }
            return new[] { 0, 0 };
        }

        /// <summary>
        /// 暴力破解法
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] TwoSum2(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[j] == target - nums[i])
                    {
                        return new[] { i, j };
                    }
                }
            }
            return new[] { 0, 0 };
        }
        #endregion

        #region 两数相加


        // Definition for singly-linked list.
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }
        /// <summary>
        /// 两数相加
        /// </summary>
        /// <param name="l1"></param>
        /// <param name="l2"></param>
        /// <returns></returns>
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode resultListNode = new ListNode(0);
            ListNode nowListNode = resultListNode;
            int carry = 0;
            do
            {
                int l1now = l1 == null ? 0 : l1.val;
                int l2now = l2 == null ? 0 : l2.val;
                int sum = l1now + l2now + carry;
                carry = sum / 10;
                nowListNode.next = new ListNode(sum % 10);
                nowListNode = nowListNode.next;
                l1 = l1?.next;
                l2 = l2?.next;

            } while (l1 != null || l2 != null || carry != 0);
            return resultListNode.next;
        }
        #endregion

        #region 无重复字符的最长子串
        /// <summary>
        /// 无重复字符的最长子串
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int LengthOfLongestSubstring(string s)
        {
            int maxLenght = 0;
            List<char> list = new List<char>();
            foreach (var item in s)
            {
                if (list.Contains(item))
                {
                    //查到有匹配的子字符串,便移除之前出现的子字符串
                    if (list.Count > maxLenght)
                        maxLenght = list.Count;
                    list.RemoveRange(0, list.IndexOf(item) + 1);
                }
                list.Add(item);
            }
            return list.Count > maxLenght ? list.Count : maxLenght;
        }
        #endregion

    }
}
