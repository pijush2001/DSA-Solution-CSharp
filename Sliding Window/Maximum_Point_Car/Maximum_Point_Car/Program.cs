internal class Program
{
    private static void Main(string[] args)
    {
        Solution solution = new Solution();
        int ans = solution.MaxScore([1, 2, 3, 4, 5, 6, 1], 3);
    }

}
public class Solution
{
    public int MaxScore(int[] cardPoints, int k)
    {
        int n = cardPoints.Length;
        int left = k - 1, right = n - 1;
        int leftSum = 0, rightSum = 0;
        for (int i = 0; i <= left; i++)
        {
            leftSum += cardPoints[i];
        }
        int ans = leftSum;
        while (left >=0 && right >=n-k)
        {
            leftSum -= cardPoints[left];
            rightSum += cardPoints[right];
            ans = Math.Max(ans, leftSum + rightSum);
            left--;
            right--;

        }
        return ans;




    }
}