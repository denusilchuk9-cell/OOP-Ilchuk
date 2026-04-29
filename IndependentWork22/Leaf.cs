using System;

namespace IndependentWork22
{
    public class Guitar : IComponent
    {
        private string _model;

        public Guitar(string model)
        {
            _model = model;
        }

        public void Play()
        {
            Console.WriteLine($"Guitar ({_model}): Strumming chords");
        }
    }

    public class Drum : IComponent
    {
        private string _type;

        public Drum(string type)
        {
            _type = type;
        }

        public void Play()
        {
            Console.WriteLine($"Drum ({_type}): Boom-boom-boom!");
        }
    }

    public class Piano : IComponent
    {
        private string _brand;

        public Piano(string brand)
        {
            _brand = brand;
        }

        public void Play()
        {
            Console.WriteLine($"Piano ({_brand}): Playing beautiful melody");
        }
    }
}