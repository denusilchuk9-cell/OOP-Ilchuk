using System;

namespace lab24v7
{
    public class CubeOperationStrategy : INumericOperationStrategy
    {
        public double Execute(double value)
        {
            return value * value * value;
        }
    }
}