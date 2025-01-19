public class User
{
    String _firstName;
    String _lastName;
    int _cardNumber;
    int _pinNumber;
    double _balance;

    // Utilize a constructor and instantiate User variables
    public User(String firstName, String lastName, int cardNumber, int pinNumber, double balance) 
    {
        this._firstName = firstName;
        this._lastName = lastName;
        this._cardNumber = cardNumber;
        this._pinNumber = pinNumber;
        this._balance = balance;
    }

    // Create getters to more easily retrieve User information.
    public String getFirstName() 
    {
        return _firstName;
    }

    public String getLastName()
    {
        return _lastName;
    }

    public int getCardNumber()
    {
        return _cardNumber;
    }

    public int getPin()
    {
        return _pinNumber;
    }

    public double getBalance()
    {
        return _balance;
    }

    // Create setters for better updating User information.
    public void setFirstName(String newFirstName)
    {
        _firstName = newFirstName;
    }

    public void setLastName(String newLastName)
    {
        _lastName = newLastName;
    }

    public void setCardNumber(int newCardNumber)
    {
        _cardNumber = newCardNumber;
    }

    public void setPinNumber(int newPinNumber)
    {
        _pinNumber = newPinNumber;
    }

    public void setBalance(double newBalance)
    {
        _balance = newBalance;
    }


}