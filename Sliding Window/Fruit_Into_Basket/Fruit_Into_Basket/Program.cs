internal class Program
{
    private static void Main(string[] args)
    {
        Solution solution = new Solution();
        int ans=solution.totalFruits(11, [0, 1, 2, 2, 2, 2]);
    }
}
public class Solution
{
    //Complete this function
    public int totalFruits(int N, List<int> fruits)
    {
        //Your code here

        int st = 0, end = 0, maxFruits = 0;
        /*Dictionary<int, int> baskets = new Dictionary<int, int>
        {
            { -1, -1 },
            { -1, -1 }
        };*/
        int key1=-1,key2=-1,val1=0,val2=0;

        if (fruits.Count <= 2) { return fruits.Count; }

        while(end < fruits.Count)
        {
            if (key1 ==-1 && key2 != fruits[end])
            {
                key1 = fruits[end];
                val1 = 1;

            }
            else if (key2 == -1 && key1 != fruits[end])
            {
                key2 = fruits[end];
                val2 = 1;
            }
            
              else if(key1 == fruits[end])
            {
                val1++;
            }
            else if(key2 == fruits[end])
            {
                val2++;
            }
            //if new type of fruit
            else
            {
                maxFruits = Math.Max(maxFruits, end - st);
                while(st<end && val1 !=0 && val2 !=0)
                {
                    if(key1 == fruits[st])
                    {
                        val1--;
                    }
                    else
                    {
                        val2--;
                    }
                    st++;

                }
                if (val1 == 0)
                {
                    key1 = fruits[end];
                    val1 = 1;
                }
                else
                {
                    key2 = fruits[end]  ;
                    val2 = 1;
                }
            }
            end++;
            
        }
        maxFruits=Math.Max(maxFruits,end-st);
        return maxFruits;
    }
}