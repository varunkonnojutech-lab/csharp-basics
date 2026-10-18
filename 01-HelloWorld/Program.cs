// 01 - Hello World: your first C# program.
// Covers: Console output, reading input, string interpolation, if/else, for loops.

Console.WriteLine("=== C# Hello World ===");
Console.WriteLine();

Console.Write("What is your name? ");
string name = Console.ReadLine() ?? "friend";

Console.Write("How old are you? ");
string? ageInput = Console.ReadLine();

Console.WriteLine();
Console.WriteLine($"Hello, {name}! Welcome to C#.");

if (int.TryParse(ageInput, out int age))
{
    Console.WriteLine($"You are {age} years old.");

    if (age >= 18)
    {
        Console.WriteLine("You are an adult.");
    }
    else
    {
        Console.WriteLine("You are not an adult yet.");
    }
}
else
{
    Console.WriteLine("I couldn't understand that age, but that's okay!");
}

Console.WriteLine();
Console.WriteLine("Counting to 5 with a for loop:");
for (int i = 1; i <= 5; i++)
{
    Console.WriteLine($"  {i}");
}

Console.WriteLine();
Console.WriteLine("Done! You just ran your first C# program.");
