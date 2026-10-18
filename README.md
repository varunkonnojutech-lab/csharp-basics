# C# Basics

[![Build](https://github.com/varunkonnojutech-lab/csharp-basics/actions/workflows/ci.yml/badge.svg)](https://github.com/varunkonnojutech-lab/csharp-basics/actions/workflows/ci.yml)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)
[![.NET 8](https://img.shields.io/badge/.NET-8.0-512BD4)](https://dotnet.microsoft.com/)
[![Open in GitHub Codespaces](https://github.com/codespaces/badge.svg)](https://codespaces.new/varunkonnojutech-lab/csharp-basics)

Learn C# from zero with 7 small, runnable console projects — from your first `Console.WriteLine` to async programming, LINQ, file handling, and two real CLI apps you'll actually use.

## Who is this for

Anyone learning C# or .NET for the first time, or developers coming from another language who want a fast, hands-on ramp.

## What you'll learn

- Console input/output, string interpolation, branching (`if`/`else`) and loops
- Object-oriented programming: classes, inheritance, encapsulation, interfaces, polymorphism
- Collections (`List<T>`, `Dictionary<TKey, TValue>`) and LINQ (`Where`, `Select`, `OrderBy`, `GroupBy`, `Join`, `Aggregate`)
- Async/await with `Task`, concurrent work with `Task.WhenAll`, timing with `Stopwatch`
- File I/O and JSON serialization with `System.Text.Json`
- How small real apps fit together: a persistent Todo CLI and an Expense Tracker

## Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) or later — or click **Open in GitHub Codespaces** above for a ready-made environment in your browser, no install needed.
- A terminal and any code editor (VS Code, Visual Studio, Rider)

Check your install:

```bash
dotnet --version
```

## Quick start

```bash
git clone https://github.com/varunkonnojutech-lab/csharp-basics.git
cd csharp-basics
dotnet run --project 01-HelloWorld
```

Each folder is a standalone console project — run any of them the same way:

```bash
dotnet run --project 02-OopBasics
dotnet run --project 03-CollectionsAndLinq
dotnet run --project 04-AsyncAwait
dotnet run --project 05-FileHandling
dotnet run --project 06-MiniProjects/TodoCli
dotnet run --project 06-MiniProjects/ExpenseTracker
```

All projects target `net8.0` with C# 12, `<Nullable>enable</Nullable>`, and `<ImplicitUsings>enable</ImplicitUsings>`.

## How it works

The projects form a ladder — work through them in order, since each one builds on the previous:

| # | Project | What you learn |
|---|---------|----------------|
| 1 | `01-HelloWorld` | Greeting the user, reading console input, string interpolation, `if`/`else`, `for` loops |
| 2 | `02-OopBasics` | Classes and properties (encapsulation), inheritance with `virtual`/`override`, interfaces, polymorphism through `List<IVehicle>` and `List<Person>` |
| 3 | `03-CollectionsAndLinq` | `List<T>` add/remove/iterate, `Dictionary<TKey, TValue>` basics, and LINQ over an in-memory `List<Product>`: `Where`, `Select`, `OrderBy`, `GroupBy`, `Join`, `Aggregate` |
| 4 | `04-AsyncAwait` | `async`/`await` with simulated I/O (`Task.Delay`), running work concurrently with `Task.WhenAll`, comparing sequential vs concurrent time with `Stopwatch` |
| 5 | `05-FileHandling` | Writing/reading text files, serializing records to JSON with `System.Text.Json` (`WriteIndented`), deserializing back |
| 6 | `06-MiniProjects/TodoCli` | An interactive menu-driven todo app (add/list/complete/delete) persisted to `todos.json` |
| 7 | `06-MiniProjects/ExpenseTracker` | An interactive expense app (add/list/monthly totals by year+month) persisted to `expenses.json` |

**Tip:** read each `Program.cs` first, run it, then try breaking something and fixing it — that's where the learning happens.

## Project structure

```
csharp-basics/
├── 01-HelloWorld/              # First program: input, interpolation, if/else, loops
├── 02-OopBasics/               # Classes, inheritance, interfaces, polymorphism
├── 03-CollectionsAndLinq/      # List<T>, Dictionary<TKey,TValue>, LINQ queries
├── 04-AsyncAwait/              # async/await, Task.WhenAll, Stopwatch timing
├── 05-FileHandling/            # Text files + System.Text.Json
├── 06-MiniProjects/
│   ├── TodoCli/                # Menu-driven todo app, persisted to todos.json
│   └── ExpenseTracker/         # Expense tracking with monthly totals
├── .devcontainer/              # One-click GitHub Codespaces setup
├── .github/workflows/ci.yml    # CI: builds every project on push
└── LICENSE
```

## Next steps

Finished the ladder? Continue with [design-patterns-dotnet](https://github.com/varunkonnojutech-lab/design-patterns-dotnet) — the classic Gang of Four patterns in modern C#, each with a runnable demo and tests.

## License

MIT — see [LICENSE](LICENSE).
