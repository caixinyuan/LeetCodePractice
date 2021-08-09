using System;
using System.Collections.Generic;
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
                if (prices[i]>prices[i-1])
                {
                    profit += prices[i] -prices[i - 1];
                }



            }
            return profit;
        }

    }
}
