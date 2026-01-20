using System;

namespace Lab21
{
    public class BusinessPlanStrategy : IStoragePlanStrategy
    {
        public decimal CalculateCost(decimal dataVolumeGB, int usersCount)
        {
            decimal gbCost;
            if (dataVolumeGB <= 500)
                gbCost = dataVolumeGB * 0.06m;
            else if (dataVolumeGB <= 5000)
                gbCost = 500 * 0.06m + (dataVolumeGB - 500) * 0.04m;
            else
                gbCost = 500 * 0.06m + 4500 * 0.04m + (dataVolumeGB - 5000) * 0.03m;

            decimal userCost = usersCount * 15m;
            return gbCost + userCost;
        }
    }
}