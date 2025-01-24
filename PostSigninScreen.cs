using System;

public class PostSignInScreen
{
    public void PostSignIn(User signedInUser)
    {
        bool isRunning = true;

        while (isRunning)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine(" ******************************** ");
            Console.WriteLine("| What can I help you with today? |");
            Console.WriteLine("|                                 |");
            Console.WriteLine("| 1. Withdrawal                   |");
            Console.WriteLine("| 2. Deposit                      |");
            Console.WriteLine("| 3. Balance                      |");
            Console.WriteLine("| 4. Logout                       |");
            Console.WriteLine("|                                 |");
            Console.WriteLine(" ******************************** ");

            Console.Write("Please select an option (1-4): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Withdrawal(signedInUser);
                    break;
                case "2":
                    Deposit(signedInUser);
                    break;
                case "3":
                    DisplayBalance(signedInUser);
                    break;
                case "4":
                    Console.WriteLine("Thank you for using our service. Goodbye!");
                    isRunning = false;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    Console.ReadLine();
                    break;
            }
        }
    }

    private void Withdrawal(User user)
    {
        Console.Clear();
        Console.WriteLine(" ******************************** ");
        Console.WriteLine("| Withdrawal                      |");
        Console.WriteLine(" ******************************** ");
        Console.Write("Enter the amount to withdraw: ");
        double amount = double.Parse(Console.ReadLine());

        if (amount > 0 && amount <= user.GetBalance())
        {
            // Deduct the amount from the user's balance
            double newBalance = user.GetBalance() - amount;
            Console.WriteLine($"Withdrawal successful! Your new balance is: ${newBalance:F2}");
            user.SetBalance(newBalance);
        }
        else
        {
            Console.WriteLine("Invalid amount or insufficient balance.");
        }
        Console.ReadLine();
    }

    private void Deposit(User user)
    {
        Console.Clear();
        Console.WriteLine(" ******************************** ");
        Console.WriteLine("| Deposit                         |");
        Console.WriteLine(" ******************************** ");
        Console.Write("Enter the amount to deposit: ");
        double amount = double.Parse(Console.ReadLine());

        if (amount > 0)
        {
            // Add the amount to the user's balance
            double newBalance = user.GetBalance() + amount;
            Console.WriteLine($"Deposit successful! Your new balance is: ${newBalance:F2}");
            user.SetBalance(newBalance);
        }
        else
        {
            Console.WriteLine("Invalid amount. Please try again.");
        }
        Console.ReadLine();
    }

    private void DisplayBalance(User user)
    {
        Console.Clear();
        Console.WriteLine(" ******************************** ");
        Console.WriteLine("| Account Balance                 |");
        Console.WriteLine(" ******************************** ");
        Console.WriteLine($"Your current balance is: ${user.GetBalance():F2}");
        Console.ReadLine();
    }
}

