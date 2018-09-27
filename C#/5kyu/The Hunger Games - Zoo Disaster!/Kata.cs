using System.Collections.Generic;
using System.Linq;

namespace Kata
{
    public class Animal
    {
        public string Name;
        public List<string> Food;

        public Animal(string name, List<string> food)
        {
            Name = name;
            Food = food;
        }

        public bool HasName(string name)
        {
            return Name.Equals(name);
        }

        public bool IsAbleToEat(string food)
        {
            return Food.Contains(food);
        }

        public int EatNearby(ref List<string> thingsInZoo, int animalIndex)
        {
            string leftThing = thingsInZoo.ElementAtOrDefault(animalIndex - 1);
            string rightThing = thingsInZoo.ElementAtOrDefault(animalIndex + 1);

            if (this.IsAbleToEat(leftThing))
            {
                ZooLogger.Eating(this.Name, leftThing);
                thingsInZoo.RemoveAt(animalIndex - 1);
                animalIndex -= 2;
            }
            else
            {
                while (this.IsAbleToEat(rightThing))
                {
                    ZooLogger.Eating(this.Name, rightThing);
                    thingsInZoo.RemoveAt(animalIndex + 1);
                    rightThing = thingsInZoo.ElementAtOrDefault(animalIndex + 1);
                }
                animalIndex++;
            }

            return animalIndex;
        }
    }

    public static class ZooLogger
    {
        private static List<string> _log;

        public static void Init(string value)
        {
            _log = new List<string> { value };
        }

        public static void Add(string value)
        {
            if (value.Length > 0)
                _log.Add(value);
        }

        public static string[] GetAndFlush()
        {
            var logs = _log.ToArray();
            _log.Clear();
            return logs;
        }

        public static void Eating(string animal, string food)
        {
            _log.Add($"{animal} eats {food}");
        }
    }

    public class Dinglemouse
    {
        public static string[] WhoEatsWho(string zoo)
        {
            List<Animal> animals = new List<Animal>()
            {
                new Animal("antelope", new List<string> {"grass"}),
                new Animal("bug", new List<string> {"leaves"}),
                new Animal("bear", new List<string> {"leaves", "big-fish", "bug", "chicken", "cow", "sheep"}),
                new Animal("chicken", new List<string> {"bug"}),
                new Animal("cow", new List<string> {"grass"}),
                new Animal("fox", new List<string> {"chicken", "sheep"}),
                new Animal("giraffe", new List<string> {"leaves"}),
                new Animal("lion", new List<string> {"antelope", "cow"}),
                new Animal("panda", new List<string> {"leaves"}),
                new Animal("sheep", new List<string> {"grass"}),
                new Animal("big-fish", new List<string> {"little-fish"})
            };

            ZooLogger.Init(zoo);

            List<string> thingsInZoo = zoo.Split(',').ToList();

            int index = 0;
            while (index < thingsInZoo.Count)
            {
                Animal animal = animals.Find(anim => anim.HasName(thingsInZoo.ElementAtOrDefault(index)));

                index = animal?.EatNearby(ref thingsInZoo, index) ?? index + 1;
            }

            ZooLogger.Add(string.Join(",", thingsInZoo));

            return ZooLogger.GetAndFlush();
        }
    }
}