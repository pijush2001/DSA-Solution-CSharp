internal class Program
{
    private static void Main(string[] args)
    {
        //char[][] board = [['X', 'X', 'X', 'X'], ['X', 'O', 'O', 'X'], ['X', 'X', 'O', 'X'], ['X', 'O', 'X', 'X']];
        char[][] board = [['O', 'O'], ['O', 'O']];
        Solution solution = new Solution();
        solution.Solve(board);


        Console.WriteLine("Hello, World!");
    }
}

public class Solution
{
    public void Solve( char[][] board)
    {

        int n=board.Length;
        int m = board[0].Length;
        //i=0,j=0 to m
        var visited=new int[n][];
        for(int i = 0; i < n; i++)
        {
            visited[i]=new int[m];

        }

        for(int j=0; j<m; j++) {
            if (board[0][j]=='O' && visited[0][j]!=1) {
                DFS(0, j, board, ref visited,n,m);
            
            }
        
        }

        //i=0 to n,j=0
        for (int i = 0; i < n; i++)
        {
            if (board[i][0] == 'O' && visited[i][0] != 1)
            {
                DFS(i, 0, board, ref visited,n,m);

            }

        }

        //i=n, j=0 to m
        for (int j = 0; j < m; j++)
        {
            if (board[n-1][j] == 'O' && visited[n-1][j] != 1)
            {
                DFS(n-1, j, board, ref visited,n,m);

            }

        }

        //j=m. i= 0 to n
        for (int i = 0; i < n; i++)
        {
            if (board[i][m-1] == 'O' && visited[i][m-1] != 1)
            {
                DFS(i, m-1, board, ref visited,n,m);

            }

        }
        for(int  i = 0; i < n; i++)
        {
            for(int j=0; j < m; j++)
            {
                if (visited[i][j] != 1 && board[i][j]=='O')
                {
                    board[i][j] = 'X';

                }
                Console.Write(board[i][j] +" ");
            }
            Console.WriteLine();
        }


    }
    public void DFS(int row, int col, char[][] board,ref int[][] visited,int n,int m)
    {
        visited[row][col] = 1;
        var delRow =new int[] { -1, 1, 0, 0 };
        var delCol = new int[] { 0, 0, -1, 1 };

        for(int i = 0; i < 4; i++)
        {
            int newRow = row + delRow[i];
            int newCol = col + delCol[i];
            if(newRow>=0 && newCol>=0 && newRow<n && newCol<m && board[newRow][newCol]=='O' && visited[newRow][newCol]!=1)
            {
                DFS(newRow,newCol, board, ref visited,n, m);
            }

        }


    }
}