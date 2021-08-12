using System;
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


    }
}
