# Overview

This program is a mock up of an ATM Console. This program is similar to what an ATM would normally do for a user with some other features like making and deleting a new user account.


The program will first ask the user if they are a member of the bank, or if they would like to create an account for the bank. If the former is indicated it will ask for an account number along with a pin to verify if a user is a member of the bank. Once the sign in process is verified and complete the user is free to choose features such as withdrawal, deposit, check balance, logout, or even delete their account. Like I mentioned previously, if a user chooses to make a new account then they are asked a series of questions on what they would like to set as their information. An account number is given and they are free to sign in as a user with the account number provided and the pin number they included in their given information. 

The purpose of me writting this program was to practice what I was taught in C# programming and I'm planning to improve this program to demonstrate my understanding of Object Oriented Programming. Another addition was working with SQL Server and connecting a database to a program so that information can be store and used after the program is terminated.

Here is a link to a YouTube video demonstrating how my program works:

[ATM Console](https://youtu.be/1cQGsz1gQ5o)
[Database Connection](https://youtu.be/bEk6rwpw7lo)

# Relational Database

The database I decided to use for this program was Microsoft SQL Server. I figured since C# and SQL Server were both made by Microsoft that they might have better compatibility and features for connecting the two. Ultimately this program's purpose was to help me learn how to connect a database and practice OOP concepts.

# Used Technologies

* Visual Studio Code
* C# Programming Language
* Git / GitHub
* .NET SDK
* SQL Server

The programming language utilized in this program is C# and SQL. 

# Useful Websites

Websites I found helpful for this program are the following:

- [C# Documentation](https://learn.microsoft.com/en-us/dotnet/csharp/tour-of-csharp/)
- [VS Code C# Setup](https://code.visualstudio.com/docs/csharp/get-started)
- [Features of ATMs](https://unacademy.com/content/bank-exam/study-material/general-awareness/features-of-an-atm/)
- [Microsoft.Data.SqlClient Namespace](https://learn.microsoft.com/en-us/sql/connect/ado-net/introduction-microsoft-data-sqlclient-namespace?view=sql-server-ver16)

# Future Work

Things that I need to fix, improve, and add in the future:

- Security features for pin and account numbers.
- Encapsulate member variables.
- More error handling for database connection.