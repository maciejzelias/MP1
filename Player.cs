using System.Text.Json.Serialization;

namespace mp1
{

    public class Player
    {

        private PlayerContract _playerContract;

        public PlayerContract PlayerContract
        {
            get => _playerContract;
            set
            {
                if (value == PlayerContract) return;
                if (value == null)
                {
                    throw new ArgumentNullException("Player contract value can not be null !");
                }
                _playerContract = value;
                value.player = this;
            }
        }
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

        public Player(string name)
        {
            this.name = name;
        }
        // public int? tshirtNumber { get; set; } // Atrybut opcjonalny
        // private Contract _playerContract; // Atrybut złozony
        // public Contract PlayerContract
        // {
        //     get => _playerContract;
        //     set
        //     {
        //         if (value == null)
        //         {
        //             throw new ArgumentNullException("playerContract");
        //         }
        //         _playerContract = value;
        //     }
        // }
        // public float salary
        // {
        //     get => salary; 
        //     set
        //     {
        //         if (value < 0)
        //         {
        //             throw new Exception("salary can't be negative");
        //         }
        //         salary = value;
        //     }
        // }
        // public int birthdayYear;
        // public int age // Atrybut pochodny
        // {
        //     get => DateTime.Now.Year - birthdayYear;
        // }
        // private List<string> _prevClubs; // Atrybut powtarzalny
        // public List<string> previousClubList
        // {
        //     get => _prevClubs.ToList();
        //     set
        //     {
        //         if (value == null)
        //         {
        //             throw new ArgumentNullException("List can't be null");
        //         }
        //         foreach (string element in value)
        //         {
        //             if (element == null)
        //             {
        //                 throw new ArgumentNullException("Values in list can't be null");
        //             }
        //         }
        //         _prevClubs = value;
        //     }
        // }
        // private static List<Player> playersList = new(); // Ekstensja
        // // [JsonConstructor]
        // public Player(string name, Contract PlayerContract, float salary, int birthdayYear, List<string> previousClubList, int? tshirtNumber = null)
        // {
        //     this.name = name;
        //     this.PlayerContract = PlayerContract;
        //     this.salary = salary;
        //     this.birthdayYear = birthdayYear;
        //     this.previousClubList = previousClubList;
        //     this.tshirtNumber = tshirtNumber;
        //     playersList.Add(this);
        // }
        // // public Player(string name, Contract contract, float salary, int birthdayYear, List<string> clubList)
        // // {
        // //     this.name = name;
        // //     this.PlayerContract = contract;
        // //     this.salary = salary;
        // //     this.birthdayYear = birthdayYear;
        // //     this.previousClubList = clubList;
        // //     playersList.Add(this);

        // // }

        // // Atrybut Klasowy
        // public static int tax = 15;

        // // Metoda klasowa
        // public static void deletePlayer(Player playerToDelete)
        // {
        //     playersList.Remove(playerToDelete);
        // }

        // public static List<Player> getPlayers()
        // {
        //     return playersList.ToList();
        // }

        // //Przeciązenie

        // public float getSalary()
        // {
        //     return salary - salary * (tax / 100.0f);
        // }

        // public float getSalary(int incomeTax)
        // {
        //     return salary - salary * (incomeTax / 100.0f);
        // }

        // Przesłonięcie
        public override string ToString()
        {
            return this.name;
        }
    }

}