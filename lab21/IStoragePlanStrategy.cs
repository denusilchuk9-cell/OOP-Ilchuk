using System;

namespace Lab21
{
    public interface IStoragePlanStrategy
    {
        decimal CalculateCost(decimal dataVolumeGB, int usersCount);
    }
}