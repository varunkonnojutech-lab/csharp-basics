// Person is a base class showing encapsulation:
// its data is exposed through properties instead of public fields.
public class Person
{
    // Auto-properties: the compiler creates the hidden backing fields.
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    // Virtual so derived classes can override it.
    public virtual string Introduce()
    {
        return $"Hi, I'm {Name} and I'm {Age} years old.";
    }
}

// Employee inherits from Person ("is-a" relationship) and adds its own data.
// It overrides Introduce() to extend the base behavior.
public class Employee : Person
{
    public string JobTitle { get; set; } = string.Empty;
    public string Department { get; set; } = string.Empty;

    public Employee(string name, int age, string jobTitle, string department)
        : base(name, age) // call the base class constructor
    {
        JobTitle = jobTitle;
        Department = department;
    }

    public override string Introduce()
    {
        return $"{base.Introduce()} I work as a {JobTitle} in {Department}.";
    }
}
