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
            //var result = primary.RemoveDuplicates(new[] { 1, 1, 2 });
            //primary.Rotate(new[] { 1, 2, 3, 4, 5, 6, 7 }, 3);
            //var result = primary.ContainsDuplicate(new[] { 1, 1, 1, 3, 3, 4, 3, 2, 4, 2 });
            //var result = primary.SingleNumber(new[] { 1, 1, 1, 3, 3, 4, 3, 2, 4, 2 });
            //var result = primary.PlusOne(new[] { 1, 8, 9 });
            //primary.MoveZeroes(new[] { 0, 1, 0, 3, 12 });
            primary.Rotate(new int[][] { new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 }, new int[] { 7, 8, 9 } });
        }



    }
}
