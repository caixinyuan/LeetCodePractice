using System;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution.Solution solution = new Solution.Solution();
            Primary primary = new Primary();

            //var result = solution.TwoSum2(new[] { 2,5,5,11 }, 10);

            //Solution.Solution.ListNode l1 = new Solution.Solution.ListNode(2, new Solution.Solution.ListNode(4, new Solution.Solution.ListNode(3)));
            //Solution.Solution.ListNode l2 = new Solution.Solution.ListNode(5, new Solution.Solution.ListNode(6, new Solution.Solution.ListNode(4)));
            //var result = solution.AddTwoNumbers(l1,l2);

            //var result = solution.LengthOfLongestSubstring(""dvdf"");
            var result = primary.RemoveDuplicates(new[] { 1, 1, 2 });
        }



    }
}
