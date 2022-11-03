namespace Opdracht3;
class Program
{
    public static void Main()
    {
        // Dit is niet nodig om te weten om de vraag te beantwoorden,
        // maar deze dictionary bevat de informatie welke node welke
        // kinderen heeft. De key in de dict is een coordinaat, met x
        // oplopend naar rechts en y oplopend naar beneden. Op (0,0) 
        // is de ingang van de maze en op (3,3) de uitgang. De value
        // geeft aan of er een kind in de vier windrichtingen is:
        // (north, south, east, west).
        var neighbors = new Dictionary<(int, int), (bool, bool, bool, bool)>();
        neighbors[(0, 0)] = (false, true, true, false);

        neighbors[(0, 1)] = (false, true, false, false);
        neighbors[(1, 1)] = (false, false, true, false);
        neighbors[(1, 0)] = (false, true, false, false);

        neighbors[(0, 2)] = (false, true, false, false);
        neighbors[(1, 2)] = (false, false, false, false);
        neighbors[(2, 2)] = (false, false, true, false);
        neighbors[(2, 1)] = (true, false, true, false);
        neighbors[(2, 0)] = (false, false, true, false);

        neighbors[(0, 3)] = (false, false, true, false);
        neighbors[(1, 3)] = (true, false, true, false);
        neighbors[(2, 3)] = (true, false, false, false);
        neighbors[(3, 3)] = (false, false, false, false);
        neighbors[(3, 2)] = (false, true, false, false);
        neighbors[(3, 1)] = (false, false, false, false);
        neighbors[(3, 0)] = (false, false, false, false);

        // dictionary wordt meegegeven 
        var root = new MazeTree(0, 0, neighbors);

        // gebruik dit om te testen
        Console.WriteLine(root.CountEnds()); // 4
        Console.WriteLine(root.FindRouteTo(3, 3)); // 8

        var printer = new MazePrinter(root);
        Console.WriteLine(printer); // print de juiste route
    }
}