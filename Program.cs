using System;
using System.Threading;


class Program
{
    static void Main(string[] args)
    {
    // Create user input for allowing the user to make choices. 
    String userInput = "";
    

    while (userInput != "3")
    {
        // Welcomes user and determines if user is member or not.
        Console.Clear();
        Console.WriteLine("----------------------------");
        Console.WriteLine("Welcome to the Bank of York!");
        Console.WriteLine("----------------------------");
        Console.WriteLine();
        Console.WriteLine(" ********************************************** ");
        Console.WriteLine("|                                               |");
        Console.WriteLine("| Please indicate if you are a member, would    |");
        Console.WriteLine("| like to create an account, or like to exit.   |");
        Console.WriteLine("|                                               |");
        Console.WriteLine("| 1. I am a member and would like to sign in.   |");
        Console.WriteLine("| 2. I would like to create an account.         |");
        Console.WriteLine("| 3. Exit                                       |");
        Console.WriteLine("|                                               |");
        Console.WriteLine(" ********************************************** ");

        Console.Write("Please write the number of the option you wish to select: ");
        userInput = Console.ReadLine();

        if (userInput == "1")
        {
            MemberSignInScreen memberSignIn = new MemberSignInScreen();
            memberSignIn.MemberSignIn();
        }

        else if (userInput == "2")
        {
            NewUserAccount newUser = new NewUserAccount();
            newUser.NewAccountScreen();
        }

        else if  (userInput == "3")
        {
            break;
        }
        
        else
        {
            Console.Clear();
            Console.WriteLine("===========================================================");
            Console.WriteLine("Please type out the number of the option you wish to select.");
            Console.WriteLine("===========================================================");
            Thread.Sleep(5000);
        }
    }
    }
}