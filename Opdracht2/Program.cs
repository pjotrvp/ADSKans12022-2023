
class Program
{
    static void Main(string[] args)
    {
        PriorityStack<Dog> pstack = new PriorityStack<Dog>();

        pstack.Push(new Dog("Fikkie", 4));
        pstack.Push(new Dog("Fido", 3));
        pstack.Push(new Dog("Rufus", 4));

        Console.WriteLine(pstack.Pop()); // Fido (3)
        Console.WriteLine(pstack.Pop()); // Rufus (4)
        Console.WriteLine(pstack.Pop()); // Fikkie (4)
    }
}



