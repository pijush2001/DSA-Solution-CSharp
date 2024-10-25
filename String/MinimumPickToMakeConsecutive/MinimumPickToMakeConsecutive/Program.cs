internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        Solution solution = new Solution();
        Console.WriteLine(solution.MinimumCardPickup([3, 4, 2, 3, 4, 7]));
    }
}
public class Solution
{
    public int MinimumCardPickup(int[] cards)
    {
        int ans = Int32.MaxValue ;
        var map=new Dictionary<int, int>();
        for(int i = 0;i<cards.Length;i++)
        {
            if (!map.ContainsKey(cards[i]))
            {
                map.Add(cards[i], i);
            }
            else
            {
                int currentLength = i - map[cards[i]]+1;
                if (currentLength < ans)
                {
                    ans= currentLength;
                }
                 map[cards[i]] = i;
            }
        }
        if (ans == Int32.MaxValue) return -1;

        return ans;

    }
}