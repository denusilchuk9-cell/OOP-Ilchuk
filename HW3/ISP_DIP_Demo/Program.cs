using System;

namespace ISP_DIP_Demo
{
    // 1. ISP VIOLATION
    public interface IWorkerBad
    {
        void Work();
        void Eat();
        void Sleep();
        void Code();
        void Test();
    }

    public class ProgrammerBad : IWorkerBad
    {
        public void Work() => Console.WriteLine("Bad: Programmer working");
        public void Eat() => Console.WriteLine("Bad: Programmer eating");
        public void Sleep() => Console.WriteLine("Bad: Programmer sleeping");
        public void Code() => Console.WriteLine("Bad: Programmer coding");
        public void Test() => Console.WriteLine("Bad: Programmer testing (but shouldnt)");
    }

    // 2. ISP SOLUTION
    public interface IWorkable { void Work(); }
    public interface IEatable { void Eat(); }
    public interface ISleepable { void Sleep(); }
    public interface ICodeable { void Code(); }
    public interface ITestable { void Test(); }

    public class ProgrammerGood : IWorkable, IEatable, ISleepable, ICodeable
    {
        public void Work() => Console.WriteLine("Good: Programmer working");
        public void Eat() => Console.WriteLine("Good: Programmer eating");
        public void Sleep() => Console.WriteLine("Good: Programmer sleeping");
        public void Code() => Console.WriteLine("Good: Programmer coding");
    }

    public class TesterGood : IWorkable, IEatable, ISleepable, ITestable
    {
        public void Work() => Console.WriteLine("Good: Tester working");
        public void Eat() => Console.WriteLine("Good: Tester eating");
        public void Sleep() => Console.WriteLine("Good: Tester sleeping");
        public void Test() => Console.WriteLine("Good: Tester testing");
    }

    // 3. DIP DEMO
    public interface ILogger
    {
        void Log(string message);
    }

    public class ConsoleLogger : ILogger
    {
        public void Log(string message) => Console.WriteLine($"LOG: {message}");
    }

    public class UserService
    {
        private readonly ILogger _logger;

        public UserService(ILogger logger)
        {
            _logger = logger;
        }

        public void CreateUser(string name)
        {
            _logger.Log($"Creating user: {name}");
            Console.WriteLine($"User {name} created!");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== ISP та DIP ПРИНЦИПИ ===");
            
            Console.WriteLine("\n1. ISP порушення:");
            IWorkerBad bad = new ProgrammerBad();
            bad.Work();
            bad.Test();
            
            Console.WriteLine("\n2. ISP рішення:");
            ProgrammerGood good = new ProgrammerGood();
            good.Work();
            good.Code();
            
            TesterGood tester = new TesterGood();
            tester.Work();
            tester.Test();
            
            Console.WriteLine("\n3. DIP Dependency Injection:");
            ILogger logger = new ConsoleLogger();
            UserService service = new UserService(logger);
            service.CreateUser("Тестовий Користувач");
            
            Console.WriteLine("\nДемонстрація завершена!");
            Console.ReadKey();
        }
    }
}