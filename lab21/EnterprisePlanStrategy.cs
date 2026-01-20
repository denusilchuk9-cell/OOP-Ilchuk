using System;

namespace Lab21
{
    public class EnterprisePlanStrategy : IStoragePlanStrategy
    {
        public decimal CalculateCost(decimal dataVolumeGB, int usersCount)
        {
            decimal gbCost;
            if (dataVolumeGB <= 1000)
                gbCost = dataVolumeGB * 0.04m;
            else if (dataVolumeGB <= 10000)
                gbCost = 1000 * 0.04m + (dataVolumeGB - 1000) * 0.03m;
            else
                gbCost = 1000 * 0.04m + 9000 * 0.03m + (dataVolumeGB - 10000) * 0.02m;

            decimal userCost = usersCount * 10m;
            return gbCost + userCost + 300m;
        }
    }
}