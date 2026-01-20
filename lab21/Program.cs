using System;

namespace Lab21
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Розрахунок вартості хмарного сховища (варіант 7) ===");
            Console.Write("Введіть тип плану (Personal / Business / Enterprise / Student): ");
            string planType = Console.ReadLine();

            Console.Write("Введіть обсяг даних (ГБ): ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal dataVolume))
                dataVolume = 0;

            Console.Write("Введіть кількість користувачів: ");
            if (!int.TryParse(Console.ReadLine(), out int users))
                users = 1;

            try
            {
                var strategy = StoragePlanFactory.CreateStrategy(planType);
                var service = new StorageService();
                decimal cost = service.CalculateStorageCost(dataVolume, users, strategy);

                Console.WriteLine($"\nЗагальна вартість: {cost:F2} USD");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка: {ex.Message}");
            }

            Console.WriteLine("\nДемонстрація OCP:");
            Console.WriteLine("Додавання нового плану Student не торкнулося класу StorageService.");
            Console.WriteLine("Зміни тільки в фабриці — принцип відкритості/закритості дотримано.");

            Console.WriteLine("\nНатисніть будь-яку клавішу для виходу...");
            Console.ReadKey();
        }
    }
}