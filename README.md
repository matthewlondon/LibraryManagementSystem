# LibraryManagementSystem

## Description

LibraryManagementSystem is a C# Console application that stores a users library of content and its associated data, currently only accepting inputted books.
The user enters a master loop and will be prompted to enter a book, remove a book, list the books, see progress on books, or exit the program. Input is 
validated using several helper methods to keep entires standardized, and will reject invalid inputs. Properties of book will be be populated with user entry 
and stored in a list called Library. Library is written to a file "library.txt" upon exiting the program, and the next time the user runs the console application
those entries will repopulate their library list. 

## Technologies
-   C#
-   .Net

## Features
- Master Loop
- Class Inheritance
- Uses a List<T> to store books
- Reads from and writes to a .txt file

## How to Run
-   Clone Repo from Github
-   Open Solution in .Net
-   Run Program.cs




