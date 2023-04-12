using System.Text.Json.Serialization;

namespace mp1
{

    public class Player
    {
        private string _name;
        public string name
        {
            get => _name;
            set
            {
                if (value == null)
                {
                    throw new ArgumentException("name null exception");
                }
                _name = value;
            }
        }
        public int? tshirtNumber { get; set; } // Atrybut opcjonalny
        private Contract _playerContract; // Atrybut złozony
        public Contract PlayerContract
        {
            get => _playerContract;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("playerContract");
                }
                _playerContract = value;
            }
        }
        public float salary { get; }
        public int birthdayYear;
        public int age // Atrybut pochodny
        {
            get => DateTime.Now.Year - birthdayYear;
        }
        public List<string> previousClubList { get; set; } // Atrybut powtarzalny
        // Ekstensja
        private static List<Player> playersList = new();
        // [JsonConstructor]
        public Player(string name, Contract PlayerContract, float salary, int birthdayYear, List<string> clubList, int? tshirtNumber = null)
        {
            this.name = name;
            this.PlayerContract = PlayerContract;
            this.salary = salary;
            this.birthdayYear = birthdayYear;
            this.previousClubList = clubList;
            this.tshirtNumber = tshirtNumber;
            playersList.Add(this);
        }
        // public Player(string name, Contract contract, float salary, int birthdayYear, List<string> clubList)
        // {
        //     this.name = name;
        //     this.PlayerContract = contract;
        //     this.salary = salary;
        //     this.birthdayYear = birthdayYear;
        //     this.previousClubList = clubList;
        //     playersList.Add(this);

        // }

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

        public float getSalary(int incomeTax)
        {
            return salary - salary * (incomeTax / 100.0f);
        }

        // Przesłonięcie
        public override string ToString()
        {
            return this.name + " " + this.tshirtNumber;
        }
    }

}