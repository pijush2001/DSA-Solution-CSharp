internal class Program
{
    private static void Main(string[] args)
    {
        Solution solution = new Solution();

        Console.WriteLine(solution.MinOperations(4));
    }
}
public class Solution
{
    public int MinOperations(int k)
    {
        if (k == 1) return 0;
        int ans = Int32.MaxValue;
        for (int i = 1; i <= k / 2; i++)
        {
            if (k == i + 1)
            {
                ans = Math.Min(ans, i);
                break;
            }
            else
            {
                int j;
                if (k % (i + 1) == 0)
                {
                    j = k / (i + 1) - 1;
                }
                else
                {
                    j = k / (i + 1);
                }
                
                if (i + j < ans)
                {
                    ans = i + j;
                }
                else
                {
                    break;
                }

            }

        }
        return ans;

    }
}