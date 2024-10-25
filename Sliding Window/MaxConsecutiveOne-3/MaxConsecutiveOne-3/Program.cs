internal class Program
{
    private static void Main(string[] args)
    {
        Solution solution = new Solution();
        int ans = solution.LongestOnes([0, 0, 1, 1, 0, 0, 1, 1, 1, 0, 1, 1, 0, 0, 0, 1, 1, 1, 1], 3);

    }
}
public class Solution
{
    /*public int LongestOnes(int[] nums, int k)
    {
        int maxLength = 0;
        int i = 0, j = 0, zeroCount = 0;

        while (j < nums.Length)
        {
            if (nums[j] == 0)
            {
                zeroCount++;
            }

            while (zeroCount > k)
            {
                if (nums[i] == 0)
                {
                    zeroCount--;
                }
                i++;
            }

            maxLength = Math.Max(maxLength, j - i + 1);
            j++;
        }

        return maxLength;
    }*/
    //using Queue to maintain the next zero easily to avoid the inner while loop
    public int LongestOnes(int[] nums, int k)
    {
        int maxLength = 0;
        int i = 0, j = 0;
        Queue<int> zeroIndices = new Queue<int>();

        while (j < nums.Length)
        {
            if (nums[j] == 0)
            {
                zeroIndices.Enqueue(j);
            }

            if (zeroIndices.Count > k)
            {
                i = zeroIndices.Dequeue() + 1;
            }

            maxLength = Math.Max(maxLength, j - i + 1);
            j++;
        }

        return maxLength;
    }

}