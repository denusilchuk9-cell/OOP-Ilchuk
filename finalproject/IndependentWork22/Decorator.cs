namespace IndependentWork22
{
    public abstract class InstrumentDecorator : IComponent
    {
        protected IComponent _decoratedInstrument;

        protected InstrumentDecorator(IComponent instrument)
        {
            _decoratedInstrument = instrument;
        }

        public virtual void Play()
        {
            _decoratedInstrument.Play();
        }
    }
}