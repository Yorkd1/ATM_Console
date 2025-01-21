public class NewUserAccount
{
    public void NewAccountScreen()
    {
        string userInput = "";
        Console.WriteLine("Thank you for wanting to create an account with us.");
        Console.WriteLine("On average about 90% of new users become very happy by the fact you won't recieve emails from us.");
        Console.WriteLine();
        Console.WriteLine("Please fill out the following questions:");

        while (userInput != "Yes"){
            Console.Write("What is your first name? ");
            string firstName = Console.ReadLine();
            Console.Write("What is your last name? ");
            string lastName = Console.ReadLine();
            Console.Write("What would you like your 4 digit pin number to be? ");
            int pinNumber = int.Parse(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("To create an account we ask that new users make an initial deposit of at least $25.");
            Console.Write("Please indicate how much you would like deposit: ");
            double balance  = double.Parse(Console.ReadLine());

            // Display user information to make sure all is in order before continuing.
            Console.WriteLine("Here is the information you gave us to start your account:");
            Console.WriteLine($"Your name: {firstName} {lastName}");
            Console.WriteLine($"Your pin: {pinNumber}");
            Console.WriteLine($"Your initial deposit is: {balance}");

            Console.Write("Would you like to continue to create your account using this information? ");
            userInput = Console.ReadLine().ToLower();

            if  (userInput == "yes")
            {
                // Establish the customer information with the setters in Users.
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
}