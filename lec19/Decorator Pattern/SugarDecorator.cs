namespace CompositeDecoratorDemo.Decorator
{
    public class SugarDecorator : CoffeeDecorator
    {
        public SugarDecorator(ICoffee coffee) : base(coffee) { }

        public override string GetDescription()
        {
            return _decoratedCoffee.GetDescription() + ", Sugar";
        }

        public override double GetCost()
        {
            return _decoratedCoffee.GetCost() + 0.5;
        }
    }
}