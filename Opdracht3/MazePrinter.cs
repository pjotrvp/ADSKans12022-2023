namespace Opdracht3;

using System.Text;

class MazePrinter
{
    private char[,] _grid;
    private int SizeX;
    private int SizeY;

    public MazePrinter(MazeTree root)
    {
        if (root == null) throw new InvalidDataException();

        (SizeX, SizeY) = Size(root);

        _grid = new char[Coord(SizeX), Coord(SizeY)];

        for (int y = 0; y < Coord(SizeY); y++)
        {
            if (y % 2 == 0)
            {
                for (int x = 0; x < Coord(SizeX); x++)
                {
                    _grid[x, y] = x % 2 == 0 ? '+' : '-';
                }
            }
            else
            {
                for (int x = 0; x < Coord(SizeX); x++)
                {
                    _grid[x, y] = x % 2 == 0 ? '|' : ' ';
                }
            }
        }

        _grid[0, 1] = 'o';
        _grid[Coord(SizeX) - 1, Coord(SizeY) - 2] = 'o';

        Fill(root);
    }

    private static int Coord(int c)
    {
        return 2 * c + 1;
    }

    private static (int, int) Size(MazeTree? node, int maxX = 0, int maxY = 0)
    {
        if (node == null) return (maxX, maxY);

        if (node.X + 1 > maxX) maxX = node.X + 1;
        if (node.Y + 1 > maxY) maxY = node.Y + 1;

        (maxX, maxY) = Size(node.North, maxX, maxY);
        (maxX, maxY) = Size(node.South, maxX, maxY);
        (maxX, maxY) = Size(node.East, maxX, maxY);
        (maxX, maxY) = Size(node.West, maxX, maxY);

        return (maxX, maxY);
    }

    private void Fill(MazeTree node)
    {
        if (node.IsWayOut)
        {
            _grid[Coord(node.X), Coord(node.Y)] = 'o';
        }

        if (node.North != null)
        {
            _grid[Coord(node.X), Coord(node.Y) - 1] = node.IsWayOut && node.North!.IsWayOut ? 'o' : ' ';
            Fill(node.North!);
        }
        if (node.South != null)
        {
            _grid[Coord(node.X), Coord(node.Y) + 1] = node.IsWayOut && node.South!.IsWayOut ? 'o' : ' ';
            Fill(node.South!);
        }
        if (node.East != null)
        {
            _grid[Coord(node.X) + 1, Coord(node.Y)] = node.IsWayOut && node.East!.IsWayOut ? 'o' : ' ';
            Fill(node.East!);
        }
        if (node.West != null)
        {
            _grid[Coord(node.X) - 1, Coord(node.Y)] = node.IsWayOut && node.West!.IsWayOut ? 'o' : ' ';
            Fill(node.West!);
        }
    }

    public override string ToString()
    {
        var sb = new StringBuilder();

        for (int y = 0; y < 2 * SizeY + 1; y++)
        {
            for (int x = 0; x < 2 * SizeX + 1; x++)
            {
                sb.Append(_grid[x, y]);
            }
            sb.Append('\n');
        }

        return sb.ToString();
    }
}