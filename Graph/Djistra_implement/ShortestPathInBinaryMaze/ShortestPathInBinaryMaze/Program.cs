using System.Xml.Linq;

internal class Program
{
    private static void Main(string[] args)
    {
        int[][] grid = [[1, 1, 1, 1],
                        [1, 1, 0, 1],
                        [1, 1, 1, 1],
                        [1, 1, 0, 0],
                        [1, 0, 0, 1]
                       ];
        var source = Tuple.Create(0, 1);
        var destinatio = Tuple.Create(2,2);
        Solution solution = new Solution();
       var ans= solution.shortestPath(grid, source, destinatio);
    }
}

class Solution
{
    public int shortestPath(int[][] grid, Tuple<int, int> source, Tuple<int, int> destination)
    {
        int n = grid.Length;
        if (n == 0) return -1;
        int m = grid[0].Length;

        var distance = new int[n][];
        for (int i = 0; i < n; i++)
        {
            distance[i] = new int[m];
            for (int j = 0; j < m; j++)
            {
                distance[i][j] = int.MaxValue;
            }
        }

        distance[source.Item1][source.Item2] = 0;

        var pq = new SortedSet<Pair>();
        pq.Add(new Pair(0, Tuple.Create(source.Item1, source.Item2)));

        var rowList = new int[4] { -1, 0, 1, 0 };
        var colList = new int[4] { 0, 1, 0, -1 };

        while (pq.Count > 0)
        {
            var pair = pq.Min;
            pq.Remove(pair);
            int dist = pair.Distance;
            int row = pair.Item.Item1;
            int col = pair.Item.Item2;

            if (row == destination.Item1 && col == destination.Item2)
            {
                return dist;
            }

            for (int i = 0; i < 4; i++)
            {
                int newRow = row + rowList[i];
                int newCol = col + colList[i];

                if (newRow >= 0 && newRow < n && newCol >= 0 && newCol < m && grid[newRow][newCol] == 1)
                {
                    if (distance[newRow][newCol] > dist + 1)
                    {
                        pq.Remove(new Pair(distance[newRow][newCol], Tuple.Create(newRow, newCol)));
                        distance[newRow][newCol] = dist + 1;
                        pq.Add(new Pair(dist + 1, Tuple.Create(newRow, newCol)));
                    }
                }
            }
        }

        return -1;
    }
}

public class Pair : IComparable<Pair>
{
    public int Distance { get; }
    public Tuple<int, int> Item { get; }

    public Pair(int distance, Tuple<int, int> item)
    {
        this.Distance = distance;
        this.Item = item;
    }

    public int CompareTo(Pair other)
    {
        int result = this.Distance.CompareTo(other.Distance);
        if (result == 0)
        {
            result = this.Item.Item1.CompareTo(other.Item.Item1);
            if (result == 0)
            {
                result = this.Item.Item2.CompareTo(other.Item.Item2);
            }
        }
        return result;
    }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        Pair other = (Pair)obj;
        return Item.Item1 == other.Item.Item1 && Item.Item2 == other.Item.Item2 && Distance == other.Distance;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Item.Item1, Item.Item2, Distance);
    }
}