using Builder.Components;

namespace Builder.Products
{
    internal class Vehicle
    {
        private VehicleType vehicleType;
        private Transmission transmission;
        private int seats;
        private Motor Motor;

        public VehicleType VehicleType
        {
            get => vehicleType;
            set => vehicleType = value;
        }

        public int Seats
        {
            get => seats;
            set => seats = value;
        }

        public Motor Moto
        {
            get => Motor;
            set => Motor = value;
        }

        public Transmission Transmission
        {
            get => transmission;
            set => transmission = value;
        }
    }
}
