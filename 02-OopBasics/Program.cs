// 02 - OOP Basics: classes, inheritance, encapsulation, interfaces, polymorphism.

Console.WriteLine("=== OOP Basics ===");
Console.WriteLine();

// --- Inheritance: Employee derives from Person ---
// A List<Person> can hold both Person and Employee objects.
List<Person> people = new()
{
    new Person("Alice", 30),
    new Employee("Bob", 35, "Software Developer", "Engineering"),
    new Employee("Carol", 28, "QA Engineer", "Quality")
};

Console.WriteLine("--- People (inheritance + virtual/override) ---");
foreach (Person person in people)
{
    // The correct Introduce() runs for each object, even though
    // the variable is typed as Person. That is polymorphism.
    Console.WriteLine(person.Introduce());
}

Console.WriteLine();

// --- Polymorphism: one interface, many implementations ---
List<IVehicle> vehicles = new()
{
    new Car(),
    new Bike()
};

Console.WriteLine("--- Vehicles (interface polymorphism) ---");
foreach (IVehicle vehicle in vehicles)
{
    Console.WriteLine($"{vehicle.Name} has {vehicle.Wheels} wheels.");
    vehicle.Start();
    vehicle.Stop();
    Console.WriteLine();
}
