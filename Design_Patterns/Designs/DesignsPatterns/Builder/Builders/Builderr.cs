using Builder.Components;
using Builder.Products;

namespace Builder.Builders
{
    class Builderr : iBuilder
    {
        private Vehicle vehicle = new Vehicle();

        public Vehicle GetVehicle()
        {
            Vehicle result = vehicle;
            Reset();

            return result;
        }

        public void Reset()
        {
            vehicle = new Vehicle();
        }

        public void SetEngine(Motor motor)
        {
            vehicle.Moto = motor;
        }

        public void SetSeats(int seats)
        {
            vehicle.Seats = seats;
        }

        public void SetTransmission(Transmission transmission)
        {
            vehicle.Transmission = transmission;
        }

        public void SetVehicleType(VehicleType vehicleType)
        {
            vehicle.VehicleType = vehicleType;
        }
    }
}
