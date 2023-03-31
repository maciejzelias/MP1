class Player
{
    int? opcjonalny; // Atrybut opcjonalny
    private Contract _playerContract; // Atrybut złozony
    public Contract PlayerContract
    {
        get => _playerContract;
        set
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }
            _playerContract = value;
        }
    }
    float salary;
    int birthdayYear;
    int age // Atrybut pochodny
    {
        get => DateTime.Now.Year - birthdayYear;
    }
    private List<string> previousClubList = new List<string>(); // Atrybut powtarzalny
    private static List<Player> playersList = new(); // Ekstensja
    Player()
    {
        playersList.Add(this);
    }

    // Metoda klasowa
    public static void deletePlayer(Player playerToDelete)
    {
        playersList.Remove(playerToDelete);
    }

    public static List<Player> getPlayers()
    {
        return playersList.ToList();
    }

    //Przeciązenie

    public float getSalary()
    {
        return salary;
    }

    public float getSalary(float incomeTax)
    {
        return salary * (incomeTax / 100.0f);
    }

    // Przesłonięcie
    public override string ToString()
    {
        return base.ToString();
    }
}

