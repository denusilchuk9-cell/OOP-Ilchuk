using System;
using System.Collections.Generic;

namespace lab21v7
{
    public interface IStoragePricingStrategy
    {
        decimal CalculateCost(decimal storageGb, int users);
    }

    public class PersonalPlan : IStoragePricingStrategy
    {
        public decimal CalculateCost(decimal storageGb, int users)
        {
            return storageGb * 0.5m;
        }
    }

    public class BusinessPlan : IStoragePricingStrategy
    {
        public decimal CalculateCost(decimal storageGb, int users)
        {
            return storageGb * 0.8m + users * 5;
        }
    }

    public class EnterprisePlan : IStoragePricingStrategy
    {
        public decimal CalculateCost(decimal storageGb, int users)
        {
            return storageGb * 1.2m + users * 10 + 100;
        }
    }

    public class EducationalPlan : IStoragePricingStrategy
    {
        public decimal CalculateCost(decimal storageGb, int users)
        {
            return storageGb * 0.3m + users * 2;
        }
    }

    public static class StorageStrategyFactory
    {
        public static IStoragePricingStrategy CreateStrategy(string planType)
        {
            switch (planType.ToLower())
            {
                case "personal":
                    return new PersonalPlan();
                case "business":
                    return new BusinessPlan();
                case "enterprise":
                    return new EnterprisePlan();
                case "educational":
                    return new EducationalPlan();
                default:
                    throw new ArgumentException("Невідомий тарифний план");
            }
        }
    }

    public class CloudStorageService
    {
        private IStoragePricingStrategy _strategy;

        public CloudStorageService(IStoragePricingStrategy strategy)
        {
            _strategy = strategy;
        }

        public decimal CalculateCost(decimal storageGb, int users)
        {
            return _strategy.CalculateCost(storageGb, users);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("==========================================");
            Console.WriteLine("Лабораторна робота №21");
            Console.WriteLine("Тема: OCP - Принцип відкритості/закритості");
            Console.WriteLine("Варіант 7: Хмарне сховище");
            Console.WriteLine("==========================================\n");

            Console.WriteLine("Доступні тарифні плани:");
            Console.WriteLine("  personal   - особистий (0.50 грн/ГБ)");
            Console.WriteLine("  business   - бізнес (0.80 грн/ГБ + 5 грн/користувача)");
            Console.WriteLine("  enterprise - корпоративний (1.20 грн/ГБ + 10 грн/користувача + 100 грн)");
            Console.WriteLine("  educational - навчальний (0.30 грн/ГБ + 2 грн/користувача)");
            Console.WriteLine();

            Console.Write("Введіть тип тарифу: ");
            string planType = Console.ReadLine();

            Console.Write("Введіть обсяг сховища (ГБ): ");
            decimal storageGb = decimal.Parse(Console.ReadLine());

            Console.Write("Введіть кількість користувачів: ");
            int users = int.Parse(Console.ReadLine());

            try
            {
                IStoragePricingStrategy strategy = StorageStrategyFactory.CreateStrategy(planType);
                CloudStorageService service = new CloudStorageService(strategy);
                decimal cost = service.CalculateCost(storageGb, users);

                Console.WriteLine($"\nРозрахунок вартості:");
                Console.WriteLine($"Тариф: {planType}");
                Console.WriteLine($"Обсяг: {storageGb} ГБ");
                Console.WriteLine($"Користувачів: {users}");
                Console.WriteLine($"Загальна вартість: {cost:F2} грн");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nПомилка: {ex.Message}");
            }

            Console.WriteLine("\n==========================================");
            Console.WriteLine("Натисніть будь-яку клавішу для виходу...");
            Console.ReadKey();
        }
    }
}
