internal class Program
{
    private static void Main(string[] args)
    {
        
       Trie.insert("apple");
        Trie.insert("apple");
        Trie.insert("apps");
        Trie.insert("bac");
        Trie.insert("bat");
        Console.WriteLine(Trie.search("apple"));   // return True
        Console.WriteLine(Trie.search("app"));     // return False
        Console.WriteLine(Trie.startsWith("app")); // return True
        Trie.insert("app");
        Console.WriteLine(Trie.search("app"));
        Console.WriteLine(Trie.CountStartWith("appl"));
        Console.WriteLine(Trie.CountWord("ap"));
        Trie.EraseWord("apple");
        Console.WriteLine(Trie.CountStartWith("appl"));

    }
}

public class Node
{
    Node[] links ;
    bool flag ;
    public  int countPrefix ;
    public int countEnd ;
    public Node()
    {
        links=new Node[26];
        flag = false;
        countPrefix = 0;
        countEnd = 0;

    }
    public bool ContainsKey(char ch)
    {
        return links[ch-'a'] != null;
    }
    public Node get(char ch)
    {
        return links[ch - 'a'];

    }
    public void put(char ch, Node node)
    {
        links[ch-'a'] = node;
        countPrefix = 1;
        
    }
    public void setEnd()
    {
        flag = true;
        countEnd++;
    }
    public bool isEnd()
    {
        return flag;
    }
    public void SetPrefixCount()
    {
        countPrefix++;
    }
    public void ReducePrefixCount()
    {
        countPrefix--;
    }
   public void ReduceEndCount()
    {
        countEnd--;
    }
}
public class Trie
{
    private static Node root;
     static Trie()
    {
        root = new Node();
    }
    public static void insert(string word)
    {
        Node node= root;
        for(int i=0;i<word.Length; i++)
        {
            if (!node.ContainsKey(word[i]))
            {
                node.put(word[i], new Node());
                node.SetPrefixCount();
            }
            
            node = node.get(word[i]);
        }
        node.setEnd();
        
    }
    public static bool search(string word)
    {
        Node node= root;
        for(int i=0;i< word.Length; i++)
        {
            if (!node.ContainsKey(word[i]))
            {
                return false;
            }
            node = node.get(word[i]);
        }
        if (node.isEnd())
        {
            return true;
        }
        return false;
    }

    public static bool startsWith(string prefix)
    {
        Node node= root;
        for(int i=0;i< prefix.Length; i++)
        {
            if (!node.ContainsKey(prefix[i]))
            {
                return false;
            }
            node = node.get(prefix[i]);

        }
        //no need to check for end, just prefix is required

        return true;
    }
    public static int CountStartWith(string prefix)
    {
        Node node= root;
        for(int i=0;i< prefix.Length; i++)
        {
            if (node.ContainsKey(prefix[i]))
            {
                node= node.get(prefix[i]);
                /*if (node.get(prefix[i]) == null)
                {
                    return node.countPrefix;
                }*/
            }
            else
            {
                return 0;
            }
            
            
        }
        return node.countPrefix;
    }

    public static int CountWord(string word)
    {
        Node node= root;
        for(int i=0;i< word.Length; i++)
        {
            if (node.ContainsKey(word[i]))
            {
                node = node.get(word[i]);
            }
            else
            {
                return 0;
            }
        }
        return node.countEnd;
    }
    public static void EraseWord(string word)
    {
        Node node= root;
        for (int i = 0; i < word.Length; i++)
        {
            if (node.ContainsKey(word[i]))
            {
                node = node.get(word[i]);
                node.ReducePrefixCount();
            }
            else
            {
                //word does not exits
                return;
            }
        }
        //at the end delete the connection
        node.ReduceEndCount();
    }


}