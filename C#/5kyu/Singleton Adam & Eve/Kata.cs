using System;

namespace Kata
{
    public sealed class Adam : Male
    {
        private static Adam _adam = null;

        private Adam() : base("Adam") { }

        public static Adam GetInstance()
        {
            return _adam ?? (_adam = new Adam());
        }
    }

    public sealed class Eve : Female
    {
        private static Eve _eve = null;

        private Eve() : base("Eve") { }

        public static Eve GetInstance(Adam adam)
        {
            return adam == null ?
                throw new ArgumentNullException() :
                _eve ?? (_eve = new Eve());
        }
    }

    public class Male : Human
    {
        public Male(string name, Female mother, Male father) : base(name, mother, father) { }

        protected Male(string name) : base(name) { }
    }
    public class Female : Human
    {
        public Female(string name, Female mother, Male father) : base(name, mother, father) { }

        protected Female(string name) : base(name) { }
    }

    public abstract class Human
    {
        public string Name { get; }
        public Female Mother { get; }
        public Male Father { get; }

        protected Human(string name, Female mother, Male father)
        {
            if (mother == null || father == null)
                throw new ArgumentNullException();

            Name = name;
            Mother = mother;
            Father = father;
        }

        protected Human(string name)
        {
            Name = name;
        }
    }
}