internal class Program
{
    private static void Main(string[] args)
    {
        Solution solution = new Solution();
       int[] ans= solution.SingleNumber([1, 2, 1, 3, 2, 5]);
    }
}
public class Solution
{
    public int[] SingleNumber(int[] nums)
    {
        int xor = 0;
        int[] ans = { 0, 0 };
        for (int i = 0; i < nums.Length; i++)
        {
            xor = xor ^ nums[i];
        }
        int lastBitSet = (xor & (xor - 1)) ^ xor;
        //check which bit is 1
        int j = 0;

        while ((lastBitSet & (1 << j)) == 0)
        {
            j++;
        }
        int bitNumber = j;

        //now lets create two bucket for separating them 
        List<int> bucket1 = new List<int>();
        List<int> bucket2 = new List<int>();
        for (int i = 0; i < nums.Length; i++)
        {
            if ((nums[i] & (1 << bitNumber)) == 0)
            {
                bucket2.Add(nums[i]);
            }
            else
            {
                bucket1.Add(nums[i]);
            }
        }
        for (int i = 0; i < bucket1.Count; i++)
        {
            ans[0] ^= bucket1[i];
        }
        for (int i = 0; i < bucket2.Count; i++)
        {
            ans[1] ^= bucket2[i];
        }
        return ans;


    }
}