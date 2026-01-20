using System;

namespace Lab21
{
    public class StorageService
    {
        public decimal CalculateStorageCost(decimal dataVolumeGB, int usersCount, IStoragePlanStrategy strategy)
        {
            if (strategy == null)
                throw new ArgumentNullException(nameof(strategy));

            return strategy.CalculateCost(dataVolumeGB, usersCount);
        }
    }
}