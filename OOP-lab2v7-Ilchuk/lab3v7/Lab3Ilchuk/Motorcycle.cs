using System;

namespace Lab3Ilchuk
{
    public class Motorcycle : Vehicle
    {
        private bool HasSidecar;

        public Motorcycle(string brand, int year, bool hasSidecar) : base(brand, year)
        {
            HasSidecar = hasSidecar;
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Мотоцикл: Має коляску = {(HasSidecar ? "Так" : "Ні")}");
        }
    }
}