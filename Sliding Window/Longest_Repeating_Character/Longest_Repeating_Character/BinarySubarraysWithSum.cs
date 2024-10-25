using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Longest_Repeating_Character
{
    public class BinarySubarraysWithSum
    {
        
            public int NumSubarraysWithSum(int[] nums, int goal)
            {
                //less or equal goal - less or equal (goal-1)= equal to goal
                return NumSubbarrayWithSumLessOrEqual(nums, goal) - NumSubbarrayWithSumLessOrEqual(nums, goal - 1);

            }
            //this function will calculate the count of subarray where sum is less or equal to goal
            public int NumSubbarrayWithSumLessOrEqual(int[] nums, int goal)
            {
                //when goal is zero then no need to calculate for -1,it is not possible
                if (goal < 0) return 0;
                int st = 0, end = 0, count = 0, sum = 0;
                int size = nums.Length;
                while (end < size)
                {
                    sum += nums[end];
                    //whenever sum exceeds keep increasing start untill it comes under control
                    while (sum > goal)
                    {
                        sum -= nums[st];
                        st++;
                    }
                    //for every new subarray within the limit(sum<=goal) there should be more subarray we just skipped. 
                    //that is the length of end and start
                    //e.g. 101(goal=2)--> 101,01,1 these 3 are satisfying condition of being less or equal
                    count += end - st + 1;
                    end++;
                }
                return count;
            }
        
    }
}
