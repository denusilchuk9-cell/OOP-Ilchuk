namespace ISP_Solution
{
    public class Tester : IWorkable, IEatable, ISleepable
    {
        public void Work()
        {
            Console.WriteLine("Tester is working");
        }

        public void Eat()
        {
            Console.WriteLine("Tester is eating");
        }

        public void Sleep()
        {
            Console.WriteLine("Tester is sleeping");
        }
    }
}