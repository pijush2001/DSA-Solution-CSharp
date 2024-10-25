using System.Reflection.Metadata.Ecma335;

internal class Program
{
    private static void Main(string[] args)
    {
        Solution solution = new Solution();
        //Console.WriteLine(solution.FindMaximumXOR([3, 10, 5, 25, 2, 8]));
        Solution1 solution1 = new Solution1();
        var ans = solution1.MaximizeXor([5, 8, 0, 3, 2, 10, 9, 2, 4, 5], [[3, 8]]);
    }
}
public class Solution1
{
    public int[] MaximizeXor(int[] nums, int[][] queries)
    {
        var ans=new int[queries.Length];
        /*List<Trie> tries=new List<Trie>();
        Dictionary<int[],Trie> map=new Dictionary<int[], Trie> ();
        for(int i = 0; i < queries.Length; i++)
        {
            Trie trie = new Trie();
            var applicableArray = nums.Where(x => x <= queries[i][1]).ToArray();
            
            if (applicableArray.Length == 0)
            {
                ans[i] = -1;
            }
            else
            {
                if (map.ContainsKey(applicableArray))
                {
                    ans[i]= map[applicableArray].MaxXor(queries[i][0]);
                }
                else
                {
                    for (int j = 0; j < applicableArray.Length; j++)
                    {
                        trie.Insert(applicableArray[j]);
                    }
                    ans[i] = trie.MaxXor(queries[i][0]);


                }

            }
            
            
        }*/
        Array.Sort(nums);
        List<int[]> newQueries=new List<int[]>(queries.Length);
        for(int i=0; i < queries.Length; i++)
        {
            var arr = new int[3];
            arr[0] = queries[i][0];
            arr[1] = queries[i][1];
            arr[2] = i;
            newQueries.Add(arr);
        }
        newQueries = newQueries.OrderBy(x => x[1]).ToList();
        //queries = queries.OrderBy(x => x.GetValue(1)).ToArray();
        int idx = 0;
        Trie trie = new Trie();
        for(int i = 0; i < newQueries.Count; i++)
        {
            while(idx<nums.Length && nums[idx] <= newQueries[i][1])
            {
                trie.Insert(nums[idx]);
                idx++;
            }
                
            if (idx == 0) ans[newQueries[i][2]] = -1;
            else
            {
                ans[newQueries[i][2]] = trie.MaxXor(newQueries[i][0]);

            }


        }
        
            

        
        
        return ans;

    }
   
}
public class Solution
{
    public int FindMaximumXOR(int[] nums)
    {
        Trie trie =new Trie();
        for(int i = 0; i < nums.Length; i++)
        {
            trie.Insert(nums[i]);
        }
        int maxValue = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            maxValue = Math.Max(maxValue, trie.MaxXor(nums[i]));
        }
      
        return maxValue;

    }
}
public class Trie
{
    private static Node root;
    public Trie() { root = new Node(); }
    public void Insert(int val)
    {
        Node node = root;
        for(int i=31;i>=0;i--)
        {
            int bit = (val >> i) & 1;
            if (!node.IsContainsBit(bit))
            {
                node.Insert(bit, new Node());
                
            }
            node = node.GetNode(bit);
        }
    }
    public int MaxXor(int val)
    {
        int maxXorVal = 0;
        Node node = root;
        for(int i = 31; i >= 0; i--)
        {
            int bit= (val >> i) & 1;
            if (node.IsContainsBit(1 - bit))
            {
                maxXorVal = maxXorVal | (1 << i);
                node = node.GetNode(1-bit);
            }
            else
            {
                node= node.GetNode(bit);
            }
        }


        return maxXorVal;
    }
}
public class Node
{
    Node[] links = new Node[2];
    public Node() { }   
    public void Insert(int bit,Node node)
    {
        links[bit] = node;
    }
    public bool IsContainsBit(int bit)
    {
        return links[bit] != null;
    }
    public Node GetNode(int bit)
    {
        return links[bit];
    }

}