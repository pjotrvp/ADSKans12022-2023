

class Dog : IComparable<Dog>
{
    public string Name { get; private set; }
    public int Age { get; private set; }

    public Dog(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public int CompareTo(Dog? other)
    {
        if (other == null)
        {
            return -1;
        }

        return this.Age - other.Age;
    }

    public override string ToString()
    {
        return $"{Name} ({Age})";
    }
}

