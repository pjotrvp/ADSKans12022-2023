namespace Opdracht1
{

    class Program
    {
        public static void Main()
        {
            var train = new Train();
            var shallowTrain = train.ShallowCopy();
            var middleTrain = train.MiddleCopy();
            var deepTrain = train.DeepCopy();

            // Deze moeten allemaal True geven
            // Let op: de ! staan er dus expres
            // Je kan ook eigen testen schrijven of de debugger gebruiken
            // om je uitwerking te controleren.
            Console.WriteLine(!ReferenceEquals(train, shallowTrain));
            Console.WriteLine(!ReferenceEquals(train, middleTrain));
            Console.WriteLine(!ReferenceEquals(train, deepTrain));

            Console.WriteLine(train.Cars.Count == 5);
            Console.WriteLine(shallowTrain.Cars.Count == 5);
            Console.WriteLine(middleTrain.Cars.Count == 5);
            Console.WriteLine(deepTrain.Cars.Count == 5);

            Console.WriteLine(ReferenceEquals(train.Cars, shallowTrain.Cars));
            Console.WriteLine(!ReferenceEquals(train.Cars, middleTrain.Cars));
            Console.WriteLine(!ReferenceEquals(train.Cars, deepTrain.Cars));

            Console.WriteLine(ReferenceEquals(train.Cars[3], shallowTrain.Cars[3]));
            Console.WriteLine(ReferenceEquals(train.Cars[3], middleTrain.Cars[3]));
            Console.WriteLine(!ReferenceEquals(train.Cars[3], deepTrain.Cars[3]));
        }
    }
}
