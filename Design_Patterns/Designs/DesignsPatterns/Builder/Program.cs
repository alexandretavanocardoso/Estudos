using Builder.Builders;
using Builder.Directors;
using Builder.Products;
using System;

namespace Builder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Builderr builderr = new Builderr();
            Director director = new Director(builderr);

            director.ConstructSedanCar();
            Vehicle sedan = builderr.GetVehicle();
            Console.WriteLine(sedan);

            director.ConstructTruck();
            Vehicle truck = builderr.GetVehicle();
            Console.WriteLine(truck);

            Console.ReadLine();
        }
    }
}
