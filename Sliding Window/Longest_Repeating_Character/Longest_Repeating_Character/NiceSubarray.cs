using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Longest_Repeating_Character
{
    public class NiceSubarray
    {
        public static int NumberOfSubarrays(int[] nums, int k)
        {
            return NumberOfSubarraysCountLessThanK(nums, k) - NumberOfSubarraysCountLessThanK(nums, k - 1);


        }
        public static  int NumberOfSubarraysCountLessThanK(int[] nums, int k)
        {
            if(k<0) return 0;
            int st = 0, end = 0, ans = 0, count = 0;
            while(end< nums.Length)
            {
                count =count + (nums[end] % 2);
                while (count > k)
                {
                    count =count- (nums[st] % 2);
                    st++;
                }
                ans += end - st + 1;
                end++;
                
            }
            return ans;


        }
    }
}
