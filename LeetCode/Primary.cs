using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    public class Primary
    {

        /// <summary>
        /// 删除排序数组中的重复项
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int RemoveDuplicates(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                return 0;
            }
            int left = 0;
            for (int right = 1; right < nums.Length; right++)
            {
                if (nums[left] != nums[right])
                {
                    nums[++left] = nums[right];
                }
            }
            return ++left;
        }


        /// <summary>
        /// 买卖股票的最佳时机||
        /// </summary>
        /// <param name="prices"></param>
        /// <returns></returns>
        public int MaxProfit(int[] prices)
        {
            int profit = 0;
            for (int i = 1; i < prices.Length; i++)
            {
                //今天的股票价格大于昨天的价格就计算两天的差价
                if (prices[i] > prices[i - 1])
                {
                    profit += prices[i] - prices[i - 1];
                }
            }
            return profit;
        }

        /// <summary>
        /// 旋转数组
        /// 执行用时：264  ms, 在所有 C# 提交中击败了87.93% 的用户
        /// 内存消耗：39.4  MB, 在所有 C# 提交中击败了56.11% 的用户
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        public void Rotate(int[] nums, int k)
        {
            k %= nums.Length;
            Reverse(nums, 0, nums.Length - 1);
            Reverse(nums, 0, k - 1);
            Reverse(nums, k, nums.Length - 1);
        }
        private void Reverse(int[] nums, int start, int end)
        {
            while (start < end)
            {
                int temp = nums[start];
                nums[start] = nums[end];
                nums[end] = temp;
                start += 1;
                end -= 1;
            }
        }

        /// <summary>
        /// 存在重复元素
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public bool ContainsDuplicate(int[] nums)
        {
            Dictionary<int, int> keyValues = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (keyValues.ContainsKey(nums[i]))
                {
                    return true;
                }
                keyValues.Add(nums[i], 1);
            }
            return false;
        }


        /// <summary>
        /// 只出现一次的数字
        /// 异或运算 懵
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int SingleNumber(int[] nums)
        {
            for (int i = 1; i < nums.Length; i++)
            {
                nums[0] ^= nums[i];
            }
            return nums[0];
        }


        /// <summary>
        /// 两个数组的交集 II
        /// 输入：nums1 = [1,2,2,1], nums2 = [2,2]
        /// 输出：[2,2]
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public int[] Intersect(int[] nums1, int[] nums2)
        {
            Array.Sort(nums1);
            Array.Sort(nums2);
            int length1 = nums1.Length, length2 = nums2.Length;
            int[] intersection = new int[Math.Min(length1, length2)];
            //双指针
            int index1 = 0, index2 = 0, index = 0;
            while (index1 < length1 && index2 < length2)
            {
                if (nums1[index1] < nums2[index2])
                {
                    index1++;
                }
                else if (nums1[index1] > nums2[index2])
                {
                    index2++;
                }
                else
                {
                    intersection[index] = nums1[index1];
                    index1++;
                    index2++;
                    index++;
                }
            }
            return intersection.Take(index).ToArray();
        }

        /// <summary>
        /// 加一
        /// 输入：digits = [1,2,3] 输出：[1,2,4] 解释：输入数组表示数字 123。
        /// 输入：digits = [4,3,2,1]输出：[4,3,2,2] 解释：输入数组表示数字 4321。
        /// 输入：digits = [0] 输出：[1]
        /// </summary>
        /// <param name="digits"></param>
        /// <returns></returns>
        public int[] PlusOne(int[] digits)
        {
            if (digits[^1] != 9)
            {
                digits[^1]++;
                return digits;
            }
            for (int i = digits.Length - 1; i >= 0; i--)
            {
                if (digits[i] != 9)
                {
                    digits[i]++;
                    return digits;
                }
                else
                {
                    digits[i] = 0;
                }
            }
            digits = new int[digits.Length + 1];
            digits[0] = 1;
            return digits;
        }


        /// <summary>
        /// 移动零
        /// 输入: [0,1,0,3,12] 输出: [1,3,12,0,0]
        /// </summary>
        /// <param name="nums"></param>
        public void MoveZeroes(int[] nums)
        {
            //for (int i = 0; i < nums.Length - 1; i++)
            //{
            //    for (int j = 0; j < nums.Length - 1 - i; j++)
            //    {
            //        if (nums[j] == 0)
            //        {
            //            int temp = nums[j];
            //            nums[j] = nums[j + 1];
            //            nums[j + 1] = temp;
            //        }

            //    }
            //}
            int index = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != 0)
                {
                    nums[index++] = nums[i];
                }
            }
            for (int i = index; i < nums.Length; i++)
            {
                nums[i] = 0;
            }

        }


        /// <summary>
        /// 有效的数独
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        public bool IsValidSudoku(char[][] board)
        {
            for (int i = 0; i < 9; i++)
            {
                List<int> Y = new List<int>();
                List<int> X = new List<int>();
                List<int> Z = new List<int>();
                for (int j = 0; j < 9; j++)
                {
                    if ((Y.Contains(board[i][j])) || (X.Contains(board[j][i])))
                    {
                        return false;
                    }
                    else
                    {
                        if (board[i][j] != '.')
                        {
                            Y.Add(board[i][j]);
                        }
                        if (board[j][i] != '.')
                        {
                            X.Add(board[j][i]);
                        }
                    }
                    int a = (i / 3) * 3 + j / 3;
                    int b = (i % 3) * 3 + j % 3;
                    if (board[a][b] != '.' && Z.Contains(board[a][b]))
                    {
                        return false;
                    }
                    Z.Add(board[a][b]);
                }
            }
            return true;
        }



        /// <summary>
        /// 旋转图像
        /// </summary>
        /// <param name="matrix"></param>
        public void Rotate(int[][] matrix)
        {
            int len = matrix.Length;
            // 水平翻转
            for (int i = 0; i < len / 2; ++i)
            {
                for (int j = 0; j < len; ++j)
                {
                    int temp = matrix[i][j];
                    matrix[i][j] = matrix[len - i - 1][j];
                    matrix[len - i - 1][j] = temp;
                }
            }
            // 主对角线翻转
            for (int i = 0; i < len; ++i)
            {
                for (int j = 0; j < i; ++j)
                {
                    int temp = matrix[i][j];
                    matrix[i][j] = matrix[j][i];
                    matrix[j][i] = temp;
                }
            }
        }

        /// <summary>
        /// 反转字符串
        /// </summary>
        /// <param name="s"></param>
        public void ReverseString(char[] s)
        {
            int len = s.Length;
            for (int i = 0; i < len / 2; i++)
            {
                char temp = s[i];
                s[i] = s[len - 1 - i];
                s[len - 1 - i] = temp;
            }
        }

        /// <summary>
        /// 整数反转
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public int Reverse(int x)
        {
            int rev = 0;
            while (x != 0)
            {
                if (rev < int.MinValue / 10 || rev > int.MaxValue / 10)
                {
                    return 0;
                }
                int digit = x % 10;
                x /= 10;
                rev = rev * 10 + digit;
            }
            return rev;
        }


        /// <summary>
        /// 字符串中的第一个唯一字符
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int FirstUniqChar(string s = "aabb")
        {
            int l = s.Length;
            Dictionary<char, int> keyValues = new Dictionary<char, int>();
            for (int i = 0; i < l; i++)
            {
                if (keyValues.ContainsKey(s[i]))
                {
                    keyValues[s[i]] = -1;
                }
                else
                {
                    keyValues.Add(s[i], i);
                }
            }
            foreach (var item in keyValues.Values)
            {
                if (item != -1 && item < l)
                {
                    l = item;
                }
            }
            if (l == s.Length)
            {
                return -1;
            }
            return l;
        }

        /// <summary>
        /// 有效的字母异位词
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>

        public bool IsAnagram(string s, string t)
        {
            s = "anagram";
            t = "nagaram";
            if (s.Length != t.Length)
            {
                return false;
            }
            Dictionary<char, int> keyValues = new Dictionary<char, int>();
            for (int i = 0; i < s.Length; i++)
            {
                if (keyValues.ContainsKey(s[i]))
                {
                    keyValues[s[i]] += 1;
                }
                else
                {
                    keyValues.Add(s[i], 1);
                }
            }
            for (int i = 0; i < t.Length; i++)
            {
                if (keyValues.ContainsKey(t[i]))
                {
                    keyValues[t[i]] -= 1;
                    if (keyValues[t[i]] <= 0)
                    {
                        keyValues.Remove(t[i]);
                    }
                }
            }
            if (keyValues.Count != 0)
            {
                return false;
            }
            return true;
        }



        /// <summary>
        /// 字符串转换整数 (atoi)
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int MyAtoi(string s)
        {
            s = s.Trim();
            if (string.IsNullOrEmpty(s))
            {
                return 0;
            }
            if (s[0] != '+' && s[0] != '-' && char.IsNumber(s[0]))
            {
                return 0;
            }
            bool isPositive = s[0] != '-';
            if (s[0] == '+' || s[0] == '-')
            {
                s = s[1..];
            }
            int number = 0;
            try
            {
                for (var a = 0; a < s.Length; a++)
                {
                    if (!int.TryParse(s[a].ToString(), out int nums))
                    {
                        break;
                    }
                    if (number > 214748364 || (number == 214748364 && nums > 7))
                    {
                        return isPositive ? int.MaxValue : int.MinValue;
                    }
                    number = number * 10 + nums;
                }
            }
            catch (Exception ex)
            {
            }
            return isPositive ? number : -number;
        }


        /// <summary>
        /// 实现 strStr()
        /// </summary>
        /// <param name="haystack"></param>
        /// <param name="needle"></param>
        /// <returns></returns>
        public int StrStr(string haystack, string needle)
        {
            if (haystack.Length < needle.Length)
            {
                return -1;
            }
            if (string.IsNullOrEmpty(needle))
            {
                return 0;
            }
            var index = 0;
            while (index < haystack.Length)
            {
                index = haystack.IndexOf(needle[0], index);
                if (index < 0)
                {
                    return -1;
                }
                bool isreturn = true;
                if (index + needle.Length > haystack.Length)
                {
                    return -1;
                }
                for (int i = 0; i < needle.Length; i++)
                {
                    if (needle[i] != haystack[i + index])
                    {
                        isreturn = false;
                        break;
                    }
                }
                if (isreturn)
                {
                    return index;
                }
                index++;
            }
            return -1;
        }

        /// <summary>
        /// 外观数列
        /// 1
        /// 11
        /// 21
        /// 1211
        /// 111221
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public string CountAndSay(int n)
        {
            string str = "1";
            for (int i = 2; i <= n; ++i)
            {
                StringBuilder sb = new StringBuilder();
                int start = 0;
                int pos = 0;

                while (pos < str.Length)
                {
                    while (pos < str.Length && str[pos] == str[start])
                    {
                        pos++;
                    }
                    sb.Append(pos - start).Append(str[start]);
                    start = pos;
                }
                str = sb.ToString();
            }
            return str;
        }


        /// <summary>
        /// 最长公共前缀
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        public string LongestCommonPrefix(string[] strs)
        {
            if (strs == null || strs.Length == 0)
            {
                return "";
            }
            var index = 0;
            var pre = strs[0];
            //默认第一个字符串是他们的公共前缀
            while (index <= pre.Length)
            {
                for (int i = 1; i < strs.Length; i++)
                {
                    if (strs[i].IndexOf(pre.Substring(0, index)) != 0)
                    {
                        pre = pre.Substring(0, index - 1);
                        break;
                    }
                }
                index++;
            }
            return pre;
        }



        /**
         * Definition for singly-linked list.
         * public class ListNode {
         *     public int val;
         *     public ListNode next;
         *     public ListNode(int x) { val = x; }
         * }
         */
        /// <summary>
        /// 删除链表中的节点
        /// </summary>
        /// <param name="node"></param>
        public void DeleteNode(ListNode node)
        {
            //把要删除结点的下一个结点的值赋给要删除的结点
            node.val = node.next.val;
            //然后删除下一个结点
            node.next = node.next.next;
        }





        /**
         * Definition for singly-linked list.
         * public class ListNode {
         *     public int val;
         *     public ListNode next;
         *     public ListNode(int val=0, ListNode next=null) {
         *         this.val = val;
         *         this.next = next;
         *     }
         * }
         */
        /// <summary>
        /// 删除链表的倒数第N个节点
        /// 给你一个链表，删除链表的倒数第 n 个结点，并且返回链表的头结点。
        /// </summary>
        /// <param name="head"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            ListNode dummy = new ListNode(0);
            //ListNode dummy = new ListNode(0,head);
            int length = GetLength(head);
            ListNode cur = dummy;
            for (int i = 1; i < length - n + 1; ++i)
            {
                cur = cur.next;
            }
            cur.next = cur.next.next;
            ListNode ans = dummy.next;
            return ans;
        }

        public int GetLength(ListNode head)
        {
            int length = 0;
            while (head != null)
            {
                ++length;
                head = head.next;
            }
            return length;
        }




        #region ReverseList


        /**
         * Definition for singly-linked list.
         * public class ListNode {
         *     public int val;
         *     public ListNode next;
         *     public ListNode(int val=0, ListNode next=null) {
         *         this.val = val;
         *         this.next = next;
         *     }
         * }
         */
        /// <summary>
        /// 反转链表
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode ReverseList(ListNode head = null)
        {
            ListNode TestNode = new ListNode(1)
            {
                next = new ListNode(2)
                {
                    next = new ListNode(3)
                    {
                        next = new ListNode(4)
                        {
                            next = new ListNode(5)
                        }
                    }
                }
            };

            head = TestNode;

            ListNode prev = null;
            ListNode curr = head;
            while (curr != null)
            {
                ListNode next = curr.next;
                curr.next = prev;
                prev = curr;
                curr = next;
            }
            return prev;
        }
        #endregion

        /// <summary>
        /// 合并两个有序链表
        /// </summary>
        /// <param name="list1"></param>
        /// <param name="list2"></param>
        /// <returns></returns>
        public ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            if (list1 == null)
                return list2;
            if (list2 == null)
                return list1;
            if (list1.val < list2.val)
            {
                list1.next = MergeTwoLists(list1.next, list2);
                return list1;
            }
            else
            {
                list2.next = MergeTwoLists(list1, list2.next);
                return list2;
            }

        }


        #region 回文链表

        /// <summary>
        /// 回文链表
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public bool IsPalindrome(ListNode head)
        {
            if (head == null) return true;

            ListNode reversedSecondHalf = ReverseLists(GetSecondHalf(head));

            while (reversedSecondHalf != null)
            {
                if (head.val != reversedSecondHalf.val) return false;
                head = head.next;
                reversedSecondHalf = reversedSecondHalf.next;
            }

            return true;
        }

        private ListNode GetSecondHalf(ListNode head)
        {
            ListNode fast = head, slow = head;

            while (fast.next != null && fast.next.next != null)
            {
                fast = fast.next.next;
                slow = slow.next;
            }

            return slow.next;
        }

        private ListNode ReverseLists(ListNode head)
        {
            ListNode prev = null, current = head, tmp = head;

            while (current != null)
            {
                tmp = current.next;
                current.next = prev;
                prev = current;
                current = tmp;
            }

            return prev;
        }

        #endregion


        #region 环形链表
        /// <summary>
        /// 环形链表
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>

        public bool HasCycle(ListNodes head = null)
        {
            ListNodes TestNode = new ListNodes(1);
            TestNode.next = new ListNodes(2);

            head = TestNode;
            if (head == null || head.next == null)
            {
                return false;
            }
            ListNodes slow = head;
            ListNodes fast = head.next;
            while (slow != fast)
            {
                if (fast == null || fast.next == null)
                {
                    return false;
                }
                slow = slow.next;
                fast = fast.next.next;
            }
            return true;
        }

        #endregion
    }


    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }


    public class ListNodes
    {
        public int val;
        public ListNodes next;
        public ListNodes(int x)
        {
            val = x;
            next = null;
        }
    }


}
