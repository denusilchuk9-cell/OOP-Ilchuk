using System;

namespace IndependentWork22
{
    public class VolumeDecorator : InstrumentDecorator
    {
        private int _volumeLevel;

        public VolumeDecorator(IComponent instrument, int volumeLevel) : base(instrument)
        {
            _volumeLevel = volumeLevel;
        }

        public override void Play()
        {
            Console.Write($"[VOLUME {_volumeLevel}%] ");
            base.Play();
        }
    }

    public class ReverbDecorator : InstrumentDecorator
    {
        private string _reverbType;

        public ReverbDecorator(IComponent instrument, string reverbType) : base(instrument)
        {
            _reverbType = reverbType;
        }

        public override void Play()
        {
            base.Play();
            Console.WriteLine($"  + Reverb effect: {_reverbType} (echoing...)");
        }
    }

    public class DistortionDecorator : InstrumentDecorator
    {
        public DistortionDecorator(IComponent instrument) : base(instrument)
        {
        }

        public override void Play()
        {
            Console.Write("[DISTORTION] ");
            base.Play();
            Console.WriteLine("  *** CRUNCHY TONE ***");
        }
    }

    public class DelayDecorator : InstrumentDecorator
    {
        private int _delayMs;

        public DelayDecorator(IComponent instrument, int delayMs) : base(instrument)
        {
            _delayMs = delayMs;
        }

        public override void Play()
        {
            base.Play();
            Console.WriteLine($"  + Delay effect: {_delayMs}ms (repeating)");
        }
    }
}