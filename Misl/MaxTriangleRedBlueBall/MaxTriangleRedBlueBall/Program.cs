internal class Program
{
    private static void Main(string[] args)
    {
       Solution solution = new Solution();
        Console.WriteLine(solution.MaxHeightOfTriangle(4,4));
    }
}
/*public class Solution
{
    public int MaxHeightOfTriangle(int red, int blue)
    {
        // int minValue=Math.Min(red,blue);
        // int maxValue=Math.Max(red,blue);
        int count1 = 0, count2 = 0;
        int b = blue;
        int r = red;

        int i = 1, j = 2;
        //lets say red bal top
        while (i <= r && j <= b)
        {
            r -= i;
            b-= j;
            i += 2;
            j += 2;
            
            count1+=2;
        }
        if (i <= r)
        {
            count1++;
        }

        i = 1; j = 2;b = blue;r= red;
        while (i <= b && j <= r)
        {
            b-= i;
            r-= j;
            i += 2;
            j += 2;
            count2+=2;
        }
        if (i <= b)
        {
            count2++;
        }
        return Math.Max(count1, count2);




    }
}*/
public class Solution
{
    public int MaxHeightOfTriangle(int red, int blue)
    {
        return Math.Max(Helper(red, blue), Helper(blue, red));
    }

    int Helper(int a, int b)
    {
        int ans = 0;
        bool isFirst = true;
        int row = 1;
        //the trick here is no of ball=row number , with the same variable we can move on
        while (true)
        {
            if (isFirst)
            {
                if (a >= row)
                    a -= row;
                else
                    break;
            }
            else
            {
                if (b >= row)
                    b -= row;
                else
                    break;
            }
            ans++;
            row++;
            isFirst = !isFirst;
        }
        return ans;
    }
}