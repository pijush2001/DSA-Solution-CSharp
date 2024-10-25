internal class Program
{
    private static void Main(string[] args)
    {
        Solution solution = new Solution();
        Console.WriteLine(solution.Divide(-2147483648, -1));
    }
}
public class Solution
{
    public int Divide(int dividend, int divisor)
    {

        if (dividend == divisor) return 1;
        bool sign = true;
        if ((dividend >= 0 && divisor < 0) || (dividend < 0 && divisor >= 0)) sign = false;
        long sum = Math.Abs((long)dividend);
        long d = Math.Abs((long)divisor);
        long ans = 0;
        while (sum >= d)
        {
            int i = 0;
            //means we can till take one more -checking next item to keep track of i
            while (sum >= (d << (i + 1)))
            {

                i++;

            }
            sum -= (d << i);
            ans += 1 << i;
        }
        if ((ans == (long)(1 << 31)) && sign)
        {
            return Int32.MaxValue;
        }
        else if (ans == (long)(1 << 31) && !sign)
        {
            return Int32.MinValue;
        }
        else return sign ? (int)ans : -(int)ans;

    }
}
/*public class Solution
{
    public int Divide(int dividend, int divisor)
    {
        // Handle the case where dividend is equal to divisor
        if (dividend == divisor) return 1;

        uint ans = 0;
        int sign = 1;

        // Determine the sign of the result
        if ((dividend < 0 && divisor > 0) || (dividend > 0 && divisor < 0))
            sign = -1;

        // Convert both dividend and divisor to positive integers
        uint n = (uint)Math.Abs(dividend);
        uint d = (uint)Math.Abs(divisor);

        // Perform the division
        while (n >= d)
        {
            int count = 0;
            while (n > (d << (count + 1)))
                count++;
            n -= d << count;
            ans += (uint)1 << count;
        }

        // Handle overflow case
        if (ans > (1 << 31) && sign == 1) return int.MaxValue;

        return sign * (int)ans;
    }
}*/
