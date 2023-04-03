namespace mp1
{

    public class Player
    {
        string name;
        int? opcjonalny { get; set; } // Atrybut opcjonalny
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
        private float salary { get; set; }
        int birthdayYear;
        int age // Atrybut pochodny
        {
            get => DateTime.Now.Year - birthdayYear;
        }
        private List<string> previousClubList = new List<string>(); // Atrybut powtarzalny
        private static List<Player> playersList = new(); // Ekstensja
        public Player(string name, int opcjonalny, Contract contract, float salary, int birthdayYear, List<string> clubList)
        {
            this.name = name;
            this.opcjonalny = opcjonalny;
            this.PlayerContract = contract;
            this.salary = salary;
            this.birthdayYear = birthdayYear;
            this.previousClubList = clubList;
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
            return this.name + this.birthdayYear;
        }
    }

}