namespace CompositeDecoratorDemo.Decorator
{
    public class MilkDecorator : CoffeeDecorator
    {
        public MilkDecorator(ICoffee coffee) : base(coffee) { }

        public override string GetDescription()
        {
            return _decoratedCoffee.GetDescription() + ", Milk";
        }

        public override double GetCost()
        {
            return _decoratedCoffee.GetCost() + 1.5;
        }
    }
}