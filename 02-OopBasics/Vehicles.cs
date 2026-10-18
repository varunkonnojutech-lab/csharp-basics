// IVehicle is an interface: a contract that says "any vehicle must
// provide a Name, a Wheels count, and Start()/Stop() behavior".
// Interfaces enable polymorphism: code can work with IVehicle without
// knowing whether the concrete object is a Car or a Bike.
public interface IVehicle
{
    string Name { get; }
    int Wheels { get; }
    void Start();
    void Stop();
}

public class Car : IVehicle
{
    public string Name => "Car";
    public int Wheels => 4;

    public void Start() => Console.WriteLine("Car: turning the key... vroom!");
    public void Stop() => Console.WriteLine("Car: applying the brakes. Stopped.");
}

public class Bike : IVehicle
{
    public string Name => "Bike";
    public int Wheels => 2;

    public void Start() => Console.WriteLine("Bike: pushing off the pedals... rolling!");
    public void Stop() => Console.WriteLine("Bike: squeezing the brakes. Stopped.");
}
