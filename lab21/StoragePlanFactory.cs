using System;

namespace Lab21
{
    public static class StoragePlanFactory
    {
        public static IStoragePlanStrategy CreateStrategy(string planType)
        {
            if (string.IsNullOrEmpty(planType))
                throw new ArgumentException("Тип плану не може бути порожнім");

            string type = planType.ToLower();

            switch (type)
            {
                case "personal":
                    return new PersonalPlanStrategy();
                case "business":
                    return new BusinessPlanStrategy();
                case "enterprise":
                    return new EnterprisePlanStrategy();
                case "student":
                    return new StudentPlanStrategy();
                default:
                    throw new ArgumentException("Невідомий тип плану. Доступні: Personal, Business, Enterprise, Student");
            }
        }
    }
}