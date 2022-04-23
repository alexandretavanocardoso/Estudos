using Builder.Components;
using Builder.Products;

namespace Builder.Builders
{
    interface iBuilder
    {
        void Reset();
        Vehicle GetVehicle();

        void SetSeats(int seats);
        void SetEngine(Motor motor);
        void SetTransmission(Transmission transmission);
        void SetVehicleType(VehicleType vehicleType);
    }
}
