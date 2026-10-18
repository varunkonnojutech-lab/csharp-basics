// 03 - Collections and LINQ: List<T>, Dictionary<TKey, TValue>, and LINQ queries.

Console.WriteLine("=== Collections and LINQ ===");
Console.WriteLine();

// ---------- List<T> ----------
List<string> fruits = new() { "Apple", "Banana" };
fruits.Add("Mango");     // add an item
fruits.Add("Apple");     // lists allow duplicates
fruits.Remove("Banana"); // remove the first matching item

Console.WriteLine("--- List<string> ---");
foreach (string fruit in fruits)
{
    Console.WriteLine($"  {fruit}");
}
Console.WriteLine($"  Count: {fruits.Count}");
Console.WriteLine();

// ---------- Dictionary<TKey, TValue> ----------
Dictionary<string, int> wordCounts = new()
{
    ["csharp"] = 3,
    ["dotnet"] = 5
};
wordCounts["linq"] = 2; // add a new key

Console.WriteLine("--- Dictionary<string, int> ---");
foreach (var pair in wordCounts)
{
    Console.WriteLine($"  {pair.Key} -> {pair.Value}");
}

if (wordCounts.TryGetValue("dotnet", out int dotnetCount))
{
    Console.WriteLine($"  'dotnet' appears {dotnetCount} times.");
}
Console.WriteLine();

// ---------- LINQ over an in-memory list ----------
List<Product> products = new()
{
    new Product(1, "Laptop",     "Electronics", 999.99m, true),
    new Product(2, "Mouse",      "Electronics",  24.99m, true),
    new Product(3, "Desk Chair", "Furniture",   149.50m, true),
    new Product(4, "Notebook",   "Stationery",    4.99m, false),
    new Product(5, "Monitor",    "Electronics", 199.99m, true),
    new Product(6, "Bookshelf",  "Furniture",    89.99m, false),
    new Product(7, "Pen Set",    "Stationery",   12.49m, true)
};

void PrintHeader(string title) => Console.WriteLine($"--- {title} ---");

// Where: filter the list
PrintHeader("Where: in-stock products under $100");
var cheapInStock = products.Where(p => p.InStock && p.Price < 100);
foreach (var p in cheapInStock)
{
    Console.WriteLine($"  {p.Name} - {p.Price:C}");
}
Console.WriteLine();

// Select: project each item into a new shape
PrintHeader("Select: product names only");
var names = products.Select(p => p.Name);
foreach (var n in names)
{
    Console.WriteLine($"  {n}");
}
Console.WriteLine();

// OrderBy: sort the list
PrintHeader("OrderBy: products sorted by price (high to low)");
var byPrice = products.OrderByDescending(p => p.Price);
foreach (var p in byPrice)
{
    Console.WriteLine($"  {p.Name} - {p.Price:C}");
}
Console.WriteLine();

// GroupBy: bucket items and summarize each bucket
PrintHeader("GroupBy: count and average price per category");
var byCategory = products.GroupBy(p => p.Category);
foreach (var group in byCategory)
{
    Console.WriteLine($"  {group.Key}: {group.Count()} items, avg {group.Average(p => p.Price):C}");
}
Console.WriteLine();

// Join: combine two lists on a matching key
List<CategoryDiscount> discounts = new()
{
    new CategoryDiscount("Electronics", 10),
    new CategoryDiscount("Furniture",   15),
    new CategoryDiscount("Stationery",   5)
};

PrintHeader("Join: price after category discount");
var discounted =
    from p in products
    join d in discounts on p.Category equals d.Category
    select new
    {
        p.Name,
        p.Price,
        SalePrice = p.Price * (1 - d.DiscountPercent / 100)
    };

foreach (var item in discounted)
{
    Console.WriteLine($"  {item.Name}: {item.Price:C} -> {item.SalePrice:C}");
}
Console.WriteLine();

// Aggregate: fold the whole list into a single value
PrintHeader("Aggregate: total inventory value of in-stock products");
decimal totalValue = products
    .Where(p => p.InStock)
    .Aggregate(0m, (total, p) => total + p.Price);
Console.WriteLine($"  Total: {totalValue:C}");
