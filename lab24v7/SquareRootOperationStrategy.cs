using System;

namespace lab24v7
{
    public class SquareRootOperationStrategy : INumericOperationStrategy
    {
        public double Execute(double value)
        {
            if (value < 0)
                throw new ArgumentException("Cannot calculate square root of negative number");
            return Math.Sqrt(value);
        }
    }
}