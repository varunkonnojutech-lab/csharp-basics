// 04 - Async/Await: doing slow work without blocking.
// Top-level statements can use 'await' directly — no explicit Main needed.

using System.Diagnostics;

Console.WriteLine("=== Async / Await ===");
Console.WriteLine();

// Each "service" pretends to do slow I/O (like a database or web API call).
async Task<List<string>> GetOrdersAsync()
{
    await Task.Delay(1000); // simulate 1 second of I/O
    return new List<string> { "Order #101", "Order #102" };
}

async Task<List<string>> GetCustomersAsync()
{
    await Task.Delay(1000);
    return new List<string> { "Alice", "Bob" };
}

async Task<List<string>> GetProductsAsync()
{
    await Task.Delay(1000);
    return new List<string> { "Laptop", "Mouse" };
}

// ---------- Sequential: one call after another (~3 seconds) ----------
Console.WriteLine("Fetching sequentially...");
var stopwatch = Stopwatch.StartNew();

List<string> orders = await GetOrdersAsync();
List<string> customers = await GetCustomersAsync();
List<string> products = await GetProductsAsync();

stopwatch.Stop();
Console.WriteLine($"  Orders:    {string.Join(", ", orders)}");
Console.WriteLine($"  Customers: {string.Join(", ", customers)}");
Console.WriteLine($"  Products:  {string.Join(", ", products)}");
Console.WriteLine($"  Sequential took: {stopwatch.ElapsedMilliseconds} ms");
Console.WriteLine();

// ---------- Concurrent: start all three, then await them together (~1 second) ----------
Console.WriteLine("Fetching concurrently with Task.WhenAll...");
stopwatch.Restart();

Task<List<string>> ordersTask = GetOrdersAsync();
Task<List<string>> customersTask = GetCustomersAsync();
Task<List<string>> productsTask = GetProductsAsync();

await Task.WhenAll(ordersTask, customersTask, productsTask);

stopwatch.Stop();
Console.WriteLine($"  Orders:    {string.Join(", ", ordersTask.Result)}");
Console.WriteLine($"  Customers: {string.Join(", ", customersTask.Result)}");
Console.WriteLine($"  Products:  {string.Join(", ", productsTask.Result)}");
Console.WriteLine($"  Concurrent took: {stopwatch.ElapsedMilliseconds} ms");
Console.WriteLine();
Console.WriteLine("Same work, roughly 3x faster: independent async work should run concurrently.");
