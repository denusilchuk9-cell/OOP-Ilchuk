namespace CompositeDecoratorDemo.Decorator
{
    public abstract class CoffeeDecorator : ICoffee
    {
        protected ICoffee _decoratedCoffee;

        public CoffeeDecorator(ICoffee coffee)
        {
            _decoratedCoffee = coffee;
        }

        public virtual string GetDescription()
        {
            return _decoratedCoffee.GetDescription();
        }

        public virtual double GetCost()
        {
            return _decoratedCoffee.GetCost();
        }
    }
}