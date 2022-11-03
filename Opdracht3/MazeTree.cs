namespace Opdracht3;

class MazeTree
{
    public MazeTree? North, South, East, West;

    public int X, Y;

    public bool IsWayOut;

    public MazeTree(int x, int y, Dictionary<(int, int), (bool, bool, bool, bool)> neighbors)
    {

        X = x;
        Y = y;
        IsWayOut = false;

        var (north, south, east, west) = neighbors[(x, y)];

        if (north) North = new MazeTree(x, y - 1, neighbors);
        if (south) South = new MazeTree(x, y + 1, neighbors);
        if (east) East = new MazeTree(x + 1, y, neighbors);
        if (west) West = new MazeTree(x - 1, y, neighbors);
    }

    public int CountEnds()
    {
        var ends = 0;
        if (North == null && South == null && East == null && West == null)
        {
            ends++;
        }
        else
        {
            if (North != null) ends += North.CountEnds();
            if (South != null) ends += South.CountEnds();
            if (East != null) ends += East.CountEnds();
            if (West != null) ends += West.CountEnds();
        }

        return ends;
    }

    public int FindRouteTo(int x, int y)
    {
        {
            if (X == x && Y == y)
            {
                IsWayOut = true;
                return 0;
            }
            else
            {
                int steps;
                if (North != null)
                {
                    steps = North.FindRouteTo(x, y);
                    if (steps != -1)
                    {
                        IsWayOut = true;
                        return steps + 1;
                    }
                }

                if (South != null)
                {
                    steps = South.FindRouteTo(x, y);
                    if (steps != -1)
                    {
                        IsWayOut = true;
                        return steps + 1;
                    }
                }

                if (East != null)
                {
                    steps = East.FindRouteTo(x, y);
                    if (steps != -1)
                    {
                        IsWayOut = true;
                        return steps + 1;
                    }
                }

                if (West != null)
                {
                    steps = West.FindRouteTo(x, y);
                    if (steps != -1)
                    {
                        IsWayOut = true;
                        return steps + 1;
                    }
                }

                return -1;
            }
        }

    }
}