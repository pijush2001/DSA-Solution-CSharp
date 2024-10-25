internal class Program
{
    private static void Main(string[] args)
    {
        int[][] grid = [[1, 2, 1, 1, 1], [1, 2, 1, 2, 1], [1, 2, 1, 2, 1], [1, 2, 1, 2, 1], [1, 1, 1, 2, 1]];

        Solution solution = new Solution();
        var ans = solution.MinimumEffortPath(grid);
    }
}
public class Solution
{
    public int MinimumEffortPath(int[][] grid)
    {

        int n = grid.Length;
        if (n == 0) return -1;
        int m = grid[0].Length;
        var source = Tuple.Create(0, 0);
        var destination = Tuple.Create(n - 1, m - 1);

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
            int diff = pair.Distance;
            int row = pair.Item.Item1;
            int col = pair.Item.Item2;


            if (row == n - 1 && col == m - 1) return diff;

            for (int i = 0; i < 4; i++)
            {
                int newRow = row + rowList[i];
                int newCol = col + colList[i];
                

                if (newRow >= 0 && newRow < n && newCol >= 0 && newCol < m)
                {
                    var absDiff = Math.Abs(grid[newRow][newCol] - grid[row][col]);
                    var newEffort = Math.Max(absDiff, diff);
                    if (newEffort < distance[newRow][newCol])
                    {
                        //pq.Remove(new Pair(distance[newRow][newCol], Tuple.Create(newRow, newCol)));
                        distance[newRow][newCol] = absDiff;
                        pq.Add(new Pair(newEffort, Tuple.Create(newRow, newCol)));
                    }
                }
            }
        }
        return distance[n - 1][m - 1];

        //return -1;
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