using System;

namespace IndependentWork22
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Independent Work #22: Composite + Decorator ===\n");
            Console.WriteLine("Scenario: Musical Instruments and Orchestra\n");

            Console.WriteLine(new string('=', 60));
            Console.WriteLine("PART 1: CREATING LEAF INSTRUMENTS");
            Console.WriteLine(new string('=', 60));

            Guitar guitar1 = new Guitar("Fender Stratocaster");
            Guitar guitar2 = new Guitar("Gibson Les Paul");
            Drum drum1 = new Drum("Bass Drum");
            Drum drum2 = new Drum("Snare Drum");
            Piano piano1 = new Piano("Yamaha");

            Console.WriteLine("\nLeaf instruments playing:");
            guitar1.Play();
            drum1.Play();
            piano1.Play();

            Console.WriteLine("\n" + new string('=', 60));
            Console.WriteLine("PART 2: APPLYING DECORATORS TO LEAF");
            Console.WriteLine(new string('=', 60));

            Console.WriteLine("\n--- Decorated Guitar ---");
            IComponent volumeGuitar = new VolumeDecorator(guitar1, 75);
            volumeGuitar.Play();

            Console.WriteLine("\n--- Decorated Guitar with Reverb ---");
            IComponent reverbGuitar = new ReverbDecorator(guitar1, "Hall");
            reverbGuitar.Play();

            Console.WriteLine("\n--- Multiple Decorators (Volume + Reverb) ---");
            IComponent multiDecorated = new ReverbDecorator(new VolumeDecorator(guitar2, 90), "Cathedral");
            multiDecorated.Play();

            Console.WriteLine("\n--- Decorated Drum with Distortion ---");
            IComponent distortedDrum = new DistortionDecorator(drum1);
            distortedDrum.Play();

            Console.WriteLine("\n" + new string('=', 60));
            Console.WriteLine("PART 3: CREATING COMPOSITE (ORCHESTRA)");
            Console.WriteLine(new string('=', 60));

            Orchestra rockOrchestra = new Orchestra("Rock Symphony");
            rockOrchestra.Add(guitar1);
            rockOrchestra.Add(guitar2);
            rockOrchestra.Add(drum1);
            rockOrchestra.Add(drum2);
            rockOrchestra.Play();

            Console.WriteLine("\n" + new string('=', 60));
            Console.WriteLine("PART 4: APPLYING DECORATORS TO COMPOSITE");
            Console.WriteLine(new string('=', 60));

            Console.WriteLine("\n--- Orchestra with Volume Effect ---");
            IComponent volumeOrchestra = new VolumeDecorator(rockOrchestra, 60);
            volumeOrchestra.Play();

            Console.WriteLine("\n--- Orchestra with Reverb Effect ---");
            IComponent reverbOrchestra = new ReverbDecorator(rockOrchestra, "Concert Hall");
            reverbOrchestra.Play();

            Console.WriteLine("\n--- Orchestra with Multiple Effects ---");
            IComponent fullEffectOrchestra = new DelayDecorator(
                new ReverbDecorator(
                    new VolumeDecorator(rockOrchestra, 80), "Stadium"), 500);
            fullEffectOrchestra.Play();

            Console.WriteLine("\n" + new string('=', 60));
            Console.WriteLine("PART 5: NESTED COMPOSITE (ORCHESTRA INSIDE ORCHESTRA)");
            Console.WriteLine(new string('=', 60));

            Orchestra stringSection = new Orchestra("String Section");
            stringSection.Add(new Guitar("Classical Guitar"));
            stringSection.Add(new Piano("Steinway"));

            Orchestra windSection = new Orchestra("Wind Section");
            windSection.Add(new Guitar("Acoustic Guitar"));

            Orchestra festivalOrchestra = new Orchestra("Music Festival Orchestra");
            festivalOrchestra.Add(stringSection);
            festivalOrchestra.Add(windSection);
            festivalOrchestra.Add(new Drum("Timpani"));

            Console.WriteLine("\nNested Orchestra playing:");
            festivalOrchestra.Play();

            Console.WriteLine("\n" + new string('=', 60));
            Console.WriteLine("PART 6: DECORATED NESTED COMPOSITE");
            Console.WriteLine(new string('=', 60));

            IComponent decoratedFestival = new ReverbDecorator(
                new VolumeDecorator(festivalOrchestra, 70), "Arena");
            decoratedFestival.Play();

            Console.WriteLine("\n" + new string('=', 60));
            Console.WriteLine("DEMONSTRATION SUMMARY");
            Console.WriteLine(new string('=', 60));

            Console.WriteLine("\nComposite Pattern Benefits:");
            Console.WriteLine("  - Unified interface for leaf and composite");
            Console.WriteLine("  - Recursive structure (orchestra can contain orchestras)");
            Console.WriteLine("  - Simple client code (treat single and group the same)");

            Console.WriteLine("\nDecorator Pattern Benefits:");
            Console.WriteLine("  - Dynamic addition of effects at runtime");
            Console.WriteLine("  - Multiple decorators can be combined");
            Console.WriteLine("  - No need to create hundreds of subclasses");

            Console.WriteLine("\nCombined Benefits:");
            Console.WriteLine("  - Can decorate both leaf and composite objects");
            Console.WriteLine("  - Effects cascade through the hierarchy");
            Console.WriteLine("  - Flexible and extensible architecture");

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}