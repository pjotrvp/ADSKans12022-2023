

using System.Reflection;

namespace Opdracht1
{



    class Train
    {
        public List<TrainCar> Cars { get; private set; }

        public Train()
        {
            Cars = new List<TrainCar>();

            Cars.Add(new TrainCar(108));
            Cars.Add(new TrainCar(108));
            Cars.Add(new TrainCar(108));
            Cars.Add(new TrainCar(108));
            Cars.Add(new TrainCar(108));


        }

        public Train ShallowCopy()
        {
            return (Train)this.MemberwiseClone();
        }

        public Train MiddleCopy()
        {
            Train ChooChooTrain = new Train();
            ChooChooTrain.Cars = this.Cars;
            return ChooChooTrain;
        }

        public Train DeepCopy()
        {
            Train chooChooTrain = Activator.CreateInstance<Train>();
            foreach (var trainCar in Cars)
            {
                chooChooTrain.Cars.Add(new TrainCar(trainCar));
            }

            return chooChooTrain;
        }
    }

}