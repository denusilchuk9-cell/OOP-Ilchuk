using System;

namespace ISP_Violation
{
    public class Programmer : IWorker
    {
        public void Work()
        {
            Console.WriteLine("Programmer is working");
        }

        public void Eat()
        {
            Console.WriteLine("Programmer is eating");
        }

        public void Sleep()
        {
            Console.WriteLine("Programmer is sleeping");
        }

        public void Code()
        {
            Console.WriteLine("Programmer is coding");
        }

        public void Design()
        {
            throw new NotImplementedException();
        }

        public void Test()
        {
            throw new NotImplementedException();
        }

        public void Deploy()
        {
            throw new NotImplementedException();
        }
    }
}