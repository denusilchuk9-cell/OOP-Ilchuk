using System;

namespace Lab21
{
    public class PersonalPlanStrategy : IStoragePlanStrategy
    {
        public decimal CalculateCost(decimal dataVolumeGB, int usersCount)
        {
            decimal gbCost;
            if (dataVolumeGB <= 100)
                gbCost = dataVolumeGB * 0.10m;
            else if (dataVolumeGB <= 500)
                gbCost = 100 * 0.10m + (dataVolumeGB - 100) * 0.08m;
            else
                gbCost = 100 * 0.10m + 400 * 0.08m + (dataVolumeGB - 500) * 0.05m;

            decimal userCost = Math.Max(0, usersCount - 1) * 20m;
            return gbCost + userCost;
        }
    }
}