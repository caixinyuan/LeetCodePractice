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
        public void Reverse(int[] nums, int start, int end)
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


    }
}
