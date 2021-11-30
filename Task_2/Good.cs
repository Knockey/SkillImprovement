using System;

namespace Task_2
{
    public class Good
    {
        public string Name { get; init; }

        public Good (string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new NullReferenceException(nameof(name));

            Name = name;
        }
    }
}
