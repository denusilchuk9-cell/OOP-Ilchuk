using System;
using System.Collections.Generic;

namespace IndependentWork22
{
    public class Orchestra : IComponent
    {
        private string _name;
        private List<IComponent> _instruments;

        public Orchestra(string name)
        {
            _name = name;
            _instruments = new List<IComponent>();
        }

        public void Add(IComponent instrument)
        {
            _instruments.Add(instrument);
        }

        public void Remove(IComponent instrument)
        {
            _instruments.Remove(instrument);
        }

        public void Play()
        {
            Console.WriteLine($"\n=== Orchestra '{_name}' starts playing ===");
            foreach (var instrument in _instruments)
            {
                instrument.Play();
            }
            Console.WriteLine($"=== Orchestra '{_name}' finished ===\n");
        }
    }
}