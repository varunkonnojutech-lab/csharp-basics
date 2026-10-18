// Expense Tracker: record spending, list it, and total any month.

using System.Text.Json;

const string DataFile = "expenses.json";
var jsonOptions = new JsonSerializerOptions { WriteIndented = true };

List<Expense> Load()
{
    if (!File.Exists(DataFile))
    {
        return new List<Expense>();
    }

    string json = File.ReadAllText(DataFile);
    return JsonSerializer.Deserialize<List<Expense>>(json, jsonOptions) ?? new List<Expense>();
}

void Save(List<Expense> expenses)
{
    File.WriteAllText(DataFile, JsonSerializer.Serialize(expenses, jsonOptions));
}

int NextId(List<Expense> expenses) => expenses.Count == 0 ? 1 : expenses.Max(e => e.Id) + 1;

void ListExpenses(List<Expense> expenses)
{
    if (expenses.Count == 0)
    {
        Console.WriteLine("No expenses yet.");
        return;
    }

    Console.WriteLine();
    Console.WriteLine("All expenses:");
    foreach (Expense e in expenses.OrderBy(e => e.Date))
    {
        Console.WriteLine($"  #{e.Id} {e.Date:yyyy-MM-dd} | {e.Category,-12} | {e.Amount,8:C} | {e.Description}");
    }
    Console.WriteLine();
}

Console.WriteLine("=== Expense Tracker ===");
Console.WriteLine($"(saved to {DataFile} in the current folder)");
Console.WriteLine();

List<Expense> expenses = Load();

while (true)
{
    Console.WriteLine("1) Add expense");
    Console.WriteLine("2) List all expenses");
    Console.WriteLine("3) Monthly total");
    Console.WriteLine("4) Exit");
    Console.Write("Choose an option: ");
    string? choice = Console.ReadLine();
    Console.WriteLine();

    switch (choice)
    {
        case "1":
            Console.Write("Description: ");
            string description = (Console.ReadLine() ?? string.Empty).Trim();

            Console.Write("Amount: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal amount) || amount < 0)
            {
                Console.WriteLine("Please enter a valid non-negative amount.");
                break;
            }

            Console.Write("Category (e.g. Food, Travel, Bills): ");
            string category = (Console.ReadLine() ?? string.Empty).Trim();
            if (category.Length == 0)
            {
                category = "Other";
            }

            Console.Write("Date (yyyy-mm-dd, Enter for today): ");
            string? dateInput = Console.ReadLine();
            DateTime date = DateTime.Today;
            if (!string.IsNullOrWhiteSpace(dateInput) && !DateTime.TryParse(dateInput, out date))
            {
                Console.WriteLine("Couldn't parse that date, using today.");
                date = DateTime.Today;
            }

            if (description.Length == 0)
            {
                Console.WriteLine("Description can't be empty.");
                break;
            }

            expenses.Add(new Expense
            {
                Id = NextId(expenses),
                Description = description,
                Amount = amount,
                Category = category,
                Date = date
            });
            Save(expenses);
            Console.WriteLine("Expense added!");
            break;

        case "2":
            ListExpenses(expenses);
            break;

        case "3":
            Console.Write("Year (e.g. 2026): ");
            bool okYear = int.TryParse(Console.ReadLine(), out int year);
            Console.Write("Month (1-12): ");
            bool okMonth = int.TryParse(Console.ReadLine(), out int month);

            if (!okYear || !okMonth || month < 1 || month > 12)
            {
                Console.WriteLine("Please enter a valid year and month.");
                break;
            }

            List<Expense> monthly = expenses
                .Where(e => e.Date.Year == year && e.Date.Month == month)
                .ToList();
            decimal total = monthly.Sum(e => e.Amount);
            Console.WriteLine();
            Console.WriteLine($"Total for {year}-{month:D2}: {total:C} across {monthly.Count} expense(s).");
            break;

        case "4":
            Console.WriteLine("Bye!");
            return;

        default:
            Console.WriteLine("Please choose 1-4.");
            break;
    }

    Console.WriteLine();
}
