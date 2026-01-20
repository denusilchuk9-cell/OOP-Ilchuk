using System;

namespace Lab21
{
    public class StudentPlanStrategy : IStoragePlanStrategy
    {
        public decimal CalculateCost(decimal dataVolumeGB, int usersCount)
        {
            var baseStrategy = new PersonalPlanStrategy();
            return baseStrategy.CalculateCost(dataVolumeGB, usersCount) * 0.60m;
        }
    }
}