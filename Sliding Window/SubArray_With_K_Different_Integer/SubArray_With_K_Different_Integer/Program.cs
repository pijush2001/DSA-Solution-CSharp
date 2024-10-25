internal class Program
{
    private static void Main(string[] args)
    {
        Solution solution = new Solution();
        int ans = solution.SubarraysWithKDistinct([1, 2, 1, 2, 3], 2);
    }
}
public class Solution
{
    public int SubarraysWithKDistinct(int[] nums, int k)
    {
        return SubArrayWithLessThanKDifferent(nums, k) - SubArrayWithLessThanKDifferent(nums,k-1);

    }
    public int SubArrayWithLessThanKDifferent(int[] nums, int k)
    {
        if (k < 0) return 0;
        int count = 0,start=0,end=0;
        int size=nums.Length;
        Dictionary<int,int> map = new Dictionary<int,int>();
        while(end<size)
        {
            if (!map.ContainsKey(nums[end]))
            {
                map.Add(nums[end], 1);
            }
            else
            {
                map[nums[end]]++;
            }

            while(map.Count > k)
            {
                map[nums[start]]--;
                if (map[nums[start]] == 0)
                {
                    map.Remove(nums[start]); 
                }
                start++;
                
            }
            
                count += end - start + 1;
            
            end++;
        }
        return count;

    }
}