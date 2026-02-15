# FilmFestival-Tournament-
A C# console engine for managing international film festivals, featuring a dynamic tournament elimination system and manual multi-criteria sorting logic
# International Film Festival Manager (C#)

A robust console application designed to manage film festival participants, conduct evaluation rounds, and determine a winner through a dynamic tournament-style elimination process.

## 🚀 Key Features
* **Tournament Logic:** Implements a phase-based elimination system that dynamically halves the field until a winner is crowned.
* **Multi-Criteria Sorting:** A manual Bubble Sort implementation handling primary (Score) and secondary (Number of Votes) tie-breaking logic.
* **Defensive Programming:** Extensive use of `int.TryParse`, range validation (0-100), and null-coalescing operators to ensure system stability against invalid user input.
* **Object-Oriented Design:** Utilizes composition with `Film`, `Actor`, and `ReleaseTeam` classes.

## 🧠 Design Decisions & Learning Path
This project was a 12-hour deep dive into C# fundamentals.
* **Why Manual Sorting?** I intentionally avoided LINQ (`OrderBy`) and `List.Sort()` to demonstrate a deep understanding of index manipulation and swap logic.
* **Nullability:** Implemented C# Nullable Reference Types (`string?`) while handling console inputs with the null-coalescing operator (`?? ""`) to maintain a "fail-safe" environment.
* **Iterative Process:** The code includes comments on "Failed Trials," documenting the architectural challenges faced during the development of the elimination loop.

## 🛠️ Technologies
* **Language:** C# 11 / .NET 
* **Paradigm:** Object-Oriented Programming (OOP)
