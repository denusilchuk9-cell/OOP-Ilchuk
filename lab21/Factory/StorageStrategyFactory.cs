using System;
using ConsoleApp5.Strategies;

namespace ConsoleApp5.Factory
{
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
                case "educational":  // ← ТВОЯ НОВА СТРАТЕГІЯ
                    return new EducationalPlan();
                default:
                    throw new ArgumentException("Невідомий тарифний план");
            }
        }
    }
}