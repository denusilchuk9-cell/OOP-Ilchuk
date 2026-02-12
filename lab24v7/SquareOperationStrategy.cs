using System;

namespace lab24v7
{
    public class SquareOperationStrategy : INumericOperationStrategy
    {
        public double Execute(double value)
        {
            return value * value;
        }
    }
}