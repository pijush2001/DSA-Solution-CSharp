internal class Program
{
    private static void Main(string[] args)
    {

        var ans = FindRedundantConnection([[1, 2], [1, 3], [2, 3]]);
    }

    public static int[] FindRedundantConnection(int[][] edges)
    {
        DSU dsu = new DSU(edges.Length);
        for (int i = 0; i < edges.Length; i++)
        {
            int ans = dsu.UnionByRank(edges[i][0], edges[i][1]);
            if (ans == -1)
            {
                return edges[i];
            }
        }
        //int[] res=new int[2];
        return new int[0];

    }
}
public class DSU
{
    List<int> rank, parent, size;

    public DSU(int n)
    {
        rank = new List<int>(new int[n + 1]);
        parent = new List<int>(new int[n + 1]);
        size = new List<int>(new int[n + 1]);

        for(int i = 0; i <= n; i++)
        {
            parent[i]= i;
            size[i] = 1;
            rank[i] = 1;
        }

    }
    public int FindParent(int node)
    {
        if (node == parent[node]) return node;
        return parent[node] = FindParent(parent[node]);//path compression
    }

    public int UnionByRank(int u,int v)
    {
        int parent_U = FindParent(u);
        int parent_V = FindParent(v);

        if (parent_U == parent_V) return -1; //same parent no need to connect

        if (rank[parent_U] < rank[parent_V])
        {
            parent[parent_U] = parent_V;
        }
        else if (rank[parent_U] > rank[parent_V])
        {
            parent[parent_V] = parent_U;
        }
        else
        {
            parent[parent_V] = parent_U;
            rank[parent_U]++;
        }
        return 1;
    }

    public void UnionBySize(int u, int v)
    {
        int parent_U = FindParent(u);
        int parent_V = FindParent(v);

        if(parent_U == parent_V)
        {
            return;
        }

        if (size[parent_U] < size[parent_V])
        {
            parent[parent_U] = parent_V;
            size[parent_V] += size[parent_U];
        }
        else
        {
            parent[parent_V] = parent_U;
            size[parent_U] += size[parent_V];
        }

    }
}