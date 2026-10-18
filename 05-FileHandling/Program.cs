// 05 - File Handling: reading/writing text files and JSON.

using System.Text.Json;

Console.WriteLine("=== File Handling ===");
Console.WriteLine();

// ---------- Plain text ----------
const string textFile = "welcome.txt";
File.WriteAllText(textFile, "Hello from C# file handling!\nThis file was written by File.WriteAllText.");
Console.WriteLine($"Wrote {textFile}.");

string contents = File.ReadAllText(textFile);
Console.WriteLine("Contents:");
Console.WriteLine(contents);
Console.WriteLine();

// ---------- JSON ----------
const string jsonFile = "notes.json";
List<Note> notes = new()
{
    new Note("Shopping", "Buy milk and eggs", DateTime.Now),
    new Note("Reminder", "Call the dentist", DateTime.Now)
};

var options = new JsonSerializerOptions { WriteIndented = true };
string json = JsonSerializer.Serialize(notes, options);
File.WriteAllText(jsonFile, json);
Console.WriteLine($"Saved {notes.Count} notes to {jsonFile}.");

string loadedJson = File.ReadAllText(jsonFile);
List<Note>? loaded = JsonSerializer.Deserialize<List<Note>>(loadedJson);

Console.WriteLine("Notes loaded back from JSON:");
foreach (Note note in loaded ?? new List<Note>())
{
    Console.WriteLine($"  - {note.Title}: {note.Body} (created {note.CreatedAt:g})");
}
Console.WriteLine();

// ---------- Cleanup ----------
// Keep the JSON so you can inspect it; remove the temp text file.
File.Delete(textFile);
Console.WriteLine($"Cleaned up {textFile}. ({jsonFile} was left in place for you to inspect.)");

// A record is a great fit for simple data you want to serialize.
// Type declarations must come after all top-level statements.
public record Note(string Title, string Body, DateTime CreatedAt);
