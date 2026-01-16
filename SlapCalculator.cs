namespace Microsoft;

static class SlapCalculator
{
    private record struct Pos(int x, int y);

    // Verify that Grid is Non-empty square grib with even rows and get dimentions.
    private static void VerifySquareGrid(char[][] grid, out int n, out int m)
    {
        n = grid.Length;
        if (n == 0)
            throw new ArgumentException("grid must have at least one row");

        m = grid[0].Length;
        for (int i = 0; i < m; i++)
        {
            int j = grid[0].Length;
            if (j == 0)
                throw new ArgumentException("grid should not have empty row");
            if (j != m)
                throw new ArgumentException("grid has unevent rows");
        }
    }

    // Calculate days to spread the news
    public static int DaysToSpread(char[][] grid)
    {
        // Get Dimentions and setup data structures.
        int n, m;
        VerifySquareGrid(grid, out n, out m);
        Dictionary<Pos, bool> board =  new Dictionary<Pos, bool>();
        List<Pos> points =  new List<Pos>();

        // Populate data structures.
        for (int i = 0; i < n; i++)
        for (int j = 0; j < m; j++)
            switch (grid[i][j])
            {
                case '0': board.Add(new Pos(i, j), false); break;
                case '1': board.Add(new Pos(i, j), true); break;
                case '2': points.Add(new Pos(i, j)); board.Add(new Pos(i, j), false) ; break;
                default: throw new ArgumentException("Unknow value at the grid");
            }

        int days = 0;
        while(true)
        {
            List<Pos> temp =  new List<Pos>();
            void Process(int x, int y)
            {
                var point = new Pos(x, y);
                if (board[point])
                {
                    board[point] = false;
                    temp.Add(point);
                }
            }

            foreach (var p in points)
            {
                if (p.x > 0) Process(p.x-1, p.y);
                if (p.y > 0) Process(p.x, p.y-1);
                if (p.x < n-1) Process(p.x+1, p.y);
                if (p.y < m-1) Process(p.x, p.y+1);
            }


            if (temp.Count == 0) break;
            days++;
            points = temp;
        }

        // If any one's remain then it is disjoint set, so return -1 else return days.
        foreach (KeyValuePair<Pos, bool> entry in board)
            if (entry.Value) return -1;

        return days;
    }
}
