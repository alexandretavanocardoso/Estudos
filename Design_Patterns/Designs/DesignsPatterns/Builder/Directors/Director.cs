using Builder.Builders;
using Builder.Components;

namespace Builder.Directors
{
    public class Director
    {
        iBuilder iBuilder;

        public Director(iBuilder iBuilder)
        {
            this.iBuilder = iBuilder;
        }

        public void ConstructSedanCar()
        {
            iBuilder.SetVehicleType(VehicleType.SEDAN);
            iBuilder.SetEngine(new Motor(5));
            iBuilder.SetTransmission(Transmission.AUTOMATIC);
        }

        public void ConstructTruck()
        {
            iBuilder.SetVehicleType(VehicleType.TRUCK);
            iBuilder.SetEngine(new Motor(2));
            iBuilder.SetTransmission(Transmission.MANUAL);
        }
    }
}
