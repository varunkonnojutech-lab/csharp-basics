// Todo CLI: a tiny interactive todo list persisted to todos.json.

using System.Text.Json;

const string DataFile = "todos.json";
var jsonOptions = new JsonSerializerOptions { WriteIndented = true };

List<TodoItem> Load()
{
    if (!File.Exists(DataFile))
    {
        return new List<TodoItem>();
    }

    string json = File.ReadAllText(DataFile);
    return JsonSerializer.Deserialize<List<TodoItem>>(json, jsonOptions) ?? new List<TodoItem>();
}

void Save(List<TodoItem> todos)
{
    File.WriteAllText(DataFile, JsonSerializer.Serialize(todos, jsonOptions));
}

int NextId(List<TodoItem> todos) => todos.Count == 0 ? 1 : todos.Max(t => t.Id) + 1;

void ListTodos(List<TodoItem> todos)
{
    if (todos.Count == 0)
    {
        Console.WriteLine("No todos yet. Add one!");
        return;
    }

    Console.WriteLine();
    Console.WriteLine("Your todos:");
    foreach (TodoItem todo in todos.OrderBy(t => t.Id))
    {
        string status = todo.IsCompleted ? "[x]" : "[ ]";
        Console.WriteLine($"  {status} #{todo.Id} {todo.Title}");
    }
    Console.WriteLine();
}

Console.WriteLine("=== Todo CLI ===");
Console.WriteLine($"(saved to {DataFile} in the current folder)");
Console.WriteLine();

List<TodoItem> todos = Load();

while (true)
{
    Console.WriteLine("1) Add todo");
    Console.WriteLine("2) List todos");
    Console.WriteLine("3) Mark complete");
    Console.WriteLine("4) Delete todo");
    Console.WriteLine("5) Exit");
    Console.Write("Choose an option: ");
    string? choice = Console.ReadLine();
    Console.WriteLine();

    switch (choice)
    {
        case "1":
            Console.Write("Title: ");
            string title = Console.ReadLine() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(title))
            {
                Console.WriteLine("Title can't be empty.");
                break;
            }

            todos.Add(new TodoItem
            {
                Id = NextId(todos),
                Title = title.Trim(),
                IsCompleted = false,
                CreatedAt = DateTime.Now
            });
            Save(todos);
            Console.WriteLine("Added!");
            break;

        case "2":
            ListTodos(todos);
            break;

        case "3":
            Console.Write("Id to mark complete: ");
            if (int.TryParse(Console.ReadLine(), out int completeId))
            {
                TodoItem? item = todos.FirstOrDefault(t => t.Id == completeId);
                if (item is null)
                {
                    Console.WriteLine("No todo with that id.");
                }
                else
                {
                    item.IsCompleted = true;
                    Save(todos);
                    Console.WriteLine($"#{completeId} marked complete.");
                }
            }
            else
            {
                Console.WriteLine("Please enter a number.");
            }
            break;

        case "4":
            Console.Write("Id to delete: ");
            if (int.TryParse(Console.ReadLine(), out int deleteId))
            {
                int removed = todos.RemoveAll(t => t.Id == deleteId);
                if (removed > 0)
                {
                    Save(todos);
                    Console.WriteLine($"#{deleteId} deleted.");
                }
                else
                {
                    Console.WriteLine("No todo with that id.");
                }
            }
            else
            {
                Console.WriteLine("Please enter a number.");
            }
            break;

        case "5":
            Console.WriteLine("Bye!");
            return;

        default:
            Console.WriteLine("Please choose 1-5.");
            break;
    }

    Console.WriteLine();
}
