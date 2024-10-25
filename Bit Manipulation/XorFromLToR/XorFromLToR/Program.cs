internal class Program
{
    private static void Main(string[] args)
    {
        Solution solution = new Solution();
       Console.WriteLine( solution.findXOR(4, 8));
    }
}
class Solution
{
    //Complete this function
    //Function to find XOR of two numbers.
    public int findXOR(int l, int r)
    {
        //int count=r-l+1;
        int ans = (XorFromOne(l - 1)) ^ (XorFromOne(r));
        return ans;
        //Your code here
    }
    public int XorFromOne(int n)
    {
        if (n % 4 == 0) return n;
        else if (n % 4 == 1) return 1;
        else if (n % 4 == 2) return n+1;
        else return 0;
    }

}