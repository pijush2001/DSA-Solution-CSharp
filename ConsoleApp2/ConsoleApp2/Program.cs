Console.WriteLine(Solution.CanCross(new int[] { 0, 1, 3, 5, 6, 8, 12, 17 }));
public  class Solution
{
    public static bool CanCross(int[] stones)
    {
        List<int> stone = stones.ToList();
        var dp = new Dictionary<int, HashSet<int>>();
        int n = stones.Length;
        //dp.Add(1,new HashSet<int>{1,2});
        for (int i = 0; i < n; i++)
        {
            dp.Add(stones[i], new HashSet<int>());
        }
        dp[1].Add(1);
        dp[1].Add(2);
        for (int i = 1; i < n; i++)
        {
            if (dp[stones[i]].Count == 0) return false;
            var currentValues= dp[stones[i]].ToList();
            foreach (var v in currentValues)
            {
                int x = stones[i] + v;
                if (stone.Contains(x))
                {
                    dp[x].Add(v - 1);
                    dp[x].Add(v);
                    dp[x].Add(v + 1);
                }
            }
        }
        // if(dp[stones[n-1]].Count!=0) return true;
        return true;
        //return Crossing(1,1,1,stone,stones.Length);
    }
}

