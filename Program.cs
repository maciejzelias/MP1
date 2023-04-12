using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using Newtonsoft.Json;

namespace mp1
{
    class main
    {
        static void Main(string[] args)
        {
            // // Assign sample data
            // SampleData();


            // Read from file
            string jsonInput = File.ReadAllText("/Users/maciejzelias/Development/MAS/MP1/players.json");
            JsonConvert.DeserializeObject<List<Player>>(jsonInput);

            List<Player> players = Player.getPlayers();

            foreach (Player player in players)
            {
                Console.WriteLine("Zawodnik: " + player);
                Console.WriteLine("Zarobki: " + player.getSalary());
                Console.WriteLine("Zarobki na reke: " + player.getSalary(10));
                Console.Write("Poprzednie kluby : ");
                foreach (string s in player.previousClubList.ToList())
                {
                    Console.Write(s + " ");
                }
                Console.WriteLine();
                Console.WriteLine();

            }


            //Save to file
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
            };
            string jsonPlayers = System.Text.Json.JsonSerializer.Serialize(players, options);

            File.WriteAllText("/Users/maciejzelias/Development/MAS/MP1/players.json", jsonPlayers);
        }

        static void SampleData()
        {
            Contract contract1 = new Contract(5, new DateTime(2020, 2, 1));
            Contract contract2 = new Contract(2, new DateTime(2021, 1, 1));
            Contract contract3 = new Contract(1, new DateTime(2024, 2, 1));
            Contract contract4 = new Contract(4, new DateTime(2019, 5, 1));

            List<String> prevClubs1 = new List<String> { };
            Player player1 = new Player("Lionel Messi", contract1, 5000.0f, 1986, prevClubs1, 10);

            List<String> prevClubs2 = new List<String> { "Wisla Sandomierz", "Legia Warszawa" };
            Player player2 = new Player("Cristiano Ronaldo", contract2, 6500.0f, 1984, prevClubs2, 7);

            List<String> prevClubs3 = new List<String> { "FC Barcelona", "Real Madryt" };
            Player player3 = new Player("Neymar Jr", contract3, 5000.0f, 1986, prevClubs3);
        }
    }

}