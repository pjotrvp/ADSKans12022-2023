namespace Opdracht1
{


    class TrainCar
    {
        public int Capacity { get; private set; }

        public TrainCar(int capacity)
        {
            Capacity = capacity;
        }

        public TrainCar(TrainCar other) : this(other.Capacity)
        {
        }
    }
}