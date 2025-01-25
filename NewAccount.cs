public class NewUserAccount
{
    public static List<User> users { get; private set; } = new List<User>();

    public void NewAccountScreen()
    {
        string userInput = "";

        Console.Clear();
        Console.WriteLine("Thank you for wanting to create an account with us.");
        Console.WriteLine("On average about 90% of new users become very happy by the fact you won't receive emails from us.");
        Console.WriteLine();
        Console.WriteLine("Please fill out the following questions:");

        while (userInput != "Yes")
        {
            // First name input
            Console.Write("What is your first name? ");
            string firstName = Console.ReadLine();

            // Last name input
            Console.Write("What is your last name? ");
            string lastName = Console.ReadLine();

            // Pin number input with error handling
            int pinNumber = 0;
            bool validPin = false;
            while (!validPin)
            {
                Console.Write("What would you like your 4 digit pin number to be? ");
                string pinInput = Console.ReadLine();
                if (int.TryParse(pinInput, out pinNumber) && pinNumber.ToString().Length == 4)
                {
                    validPin = true;
                }
                else
                {
                    Console.WriteLine("Invalid pin. Please enter a valid 4 digit pin.");
                }
            }

            Console.Clear();
            Console.WriteLine("To create an account we ask that new users make an initial deposit of at least $25.");
            double balance = 0;
            bool validBalance = false;

            // Balance input with error handling
            while (!validBalance)
            {
                Console.Write("Please indicate how much you would like to deposit: $");
                string balanceInput = Console.ReadLine();
                if (double.TryParse(balanceInput, out balance) && balance >= 25)
                {
                    validBalance = true;
                }
                else
                {
                    Console.WriteLine("Invalid amount. Please enter a valid deposit amount of at least $25.");
                }
            }

            // Display user information to make sure all is in order before continuing.
            Console.WriteLine("Here is the information you gave us to start your account:");
            Console.WriteLine($"Your name: {firstName} {lastName}");
            Console.WriteLine($"Your pin: {pinNumber}");
            Console.WriteLine($"Your initial deposit is: ${balance}");

            // Confirm account creation
            Console.Write("Would you like to continue to create your account using this information? ");
            userInput = Console.ReadLine().ToLower();

            if (userInput == "yes")
            {
                // Establish the customer information with the setters in Users.
                Random rand = new Random();
                int accountNumber = rand.Next(10000000, 100000000);
                User user = new User(firstName, lastName, accountNumber, pinNumber, balance);
                users.Add(user);
                Console.WriteLine($"Your account number is: {accountNumber}");
                Console.ReadLine();
                break;
            }
            else if (userInput == "no")
            {
                continue;
            }
            else
            {
                Console.WriteLine("Please type your response (yes/no).");
            }
        }
    }



    // Manual testing: Display user list...
    public void DisplayUsers()
    {
        foreach (var user in users)
        {
            Console.WriteLine($"Name: {user.GetFirstName()} {user.GetLastName()}, " +
                              $"Account Number: {user.GetAccountNumber()}, " +
                              $"Balance: ${user.GetBalance():0.00}");
        }
    }
}