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
            //     --- MP1 ----
            // // // Assign sample data
            // // SampleData();


            // // Read from file
            // string jsonInput = File.ReadAllText("/Users/maciejzelias/Development/MAS/MP1/players.json");
            // JsonConvert.DeserializeObject<List<Player>>(jsonInput);

            // List<Player> players = Player.getPlayers();

            // foreach (Player player in players)
            // {
            //     Console.WriteLine("Zawodnik: " + player);
            //     Console.WriteLine("Zarobki: " + player.getSalary());
            //     Console.WriteLine("Zarobki na reke: " + player.getSalary(10));
            //     Console.Write("Poprzednie kluby : ");
            //     foreach (string s in player.previousClubList.ToList())
            //     {
            //         Console.Write(s + " ");
            //     }
            //     Console.WriteLine();
            //     Console.WriteLine();

            // }


            // //Save to file
            // var options = new JsonSerializerOptions
            // {
            //     WriteIndented = true,
            //     Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
            // };
            // string jsonPlayers = System.Text.Json.JsonSerializer.Serialize(players, options);

            // File.WriteAllText("/Users/maciejzelias/Development/MAS/MP1/players.json", jsonPlayers);

            //  --- MP2 ---

            // Asocjacja zwykła
            Player player1 = new Player("Lionel Messi");
            PlayerContract playerContract1 = new PlayerContract(2137.55f, new List<string> { "attend trainings" });

            player1.signContract(playerContract1);


            Console.WriteLine("Asocjacja zwykła : \n");
            Console.WriteLine("kontrakt zawodnika : " + player1.name + " " + player1.PlayerContractList.Find(e => e == playerContract1));
            Console.WriteLine("Zawodnik przypisany do kontraktu : " + playerContract1 + " " + playerContract1.player);

            Console.WriteLine();
            // Asocjacja z atrybutem
            Administrator administrator1 = new Administrator(3, ManagerStatus.manager);
            SponsorContract sponsorContract1 = new SponsorContract(2137.0f);

            AdministratorSponsorContract administratorSponsorContract = new AdministratorSponsorContract(administrator1, sponsorContract1, "Ryanair", SponsorContractType.airlanes);
            Console.WriteLine("Asocjacja z atrybutem : \n");
            Console.WriteLine("Administrator :  " + administratorSponsorContract.Administrator);
            Console.WriteLine("Kotrakt sponsorski: " + administratorSponsorContract.SponsorContract);
            Console.WriteLine("Back refference");
            Console.WriteLine("Administrator : " + sponsorContract1.AdministratorSponsorContract.Administrator);
            Console.WriteLine("Podpisany kontrakt :  " + administrator1.AdministratorSponsorContracts.Find(e => e == administratorSponsorContract));

            Console.WriteLine();
            // Asocjacja kwalifikowana

            PageOfContract pageOfContract1 = new PageOfContract("Introduction");
            PageOfContract pageOfContract2 = new PageOfContract("Termination details");

            playerContract1.addPageOfContract(playerContract1.Pages.Count + 1, pageOfContract1);
            playerContract1.addPageOfContract(playerContract1.Pages.Count + 1, pageOfContract2);

            Console.WriteLine("Asoacjacja kwalifikowana : \n");
            Console.WriteLine("konrakt : " + playerContract1);
            Console.WriteLine("Strony kontraktu : ");
            var listOfPagesPlayerContract1 = playerContract1.Pages;
            foreach (var element in listOfPagesPlayerContract1)
            {
                Console.WriteLine("Strona nr : " + element.Key + "  zawiera : " + element.Value);
            }
            Console.WriteLine("Back reference");
            Console.WriteLine("Strona zawierajaca : " + pageOfContract1 + " jest przypisana do kontraktu : " + pageOfContract1.PlayerContract + " jest to strona nr : " + pageOfContract1.PlayerContract.Pages.FirstOrDefault(key => key.Value == pageOfContract1).Key);
            Console.WriteLine("Strona zawierajaca : " + pageOfContract2 + " jest przypisana do kontraktu : " + pageOfContract2.PlayerContract + " jest to strona nr : " + pageOfContract2.PlayerContract.Pages.FirstOrDefault(key => key.Value == pageOfContract2).Key);

            Console.WriteLine();

            // Kompozycja

            Console.WriteLine("Kompozycja: \n");

            PlayerContract playerContract2 = new PlayerContract(1234.0f, new List<String> { "attend trainings", "attend in sponsored campaigns" });
            Console.WriteLine("Kontrakt : " + playerContract2 + " składa się z listy zadań : ");
            var requiredTasksContract2 = playerContract2.RequiredTasks;
            foreach (Task task in requiredTasksContract2)
            {
                Console.WriteLine(task);
            }
            Task task1 = requiredTasksContract2.First();
            Console.WriteLine("Zadanie :  " + task1 + " jest przypisane do kontraktu : " + task1.PlayerContract);

            Console.WriteLine("Back reference");

            Task task2 = new Task(playerContract2, "very hard task nr 3");
            Console.WriteLine("Kontrakt : " + task2.PlayerContract + " składa się z listy zadań : ");
            requiredTasksContract2 = task2.PlayerContract.RequiredTasks;
            foreach (Task task in requiredTasksContract2)
            {
                Console.WriteLine(task);
            }
            Console.WriteLine("Zadanie : " + task2 + " jest przypisane do kontraktu : " + task2.PlayerContract);
        }

        // static void SampleData()
        // {
        //     Contract contract1 = new Contract(5, new DateTime(2020, 2, 1));
        //     Contract contract2 = new Contract(2, new DateTime(2021, 1, 1));
        //     Contract contract3 = new Contract(1, new DateTime(2024, 2, 1));
        //     Contract contract4 = new Contract(4, new DateTime(2019, 5, 1));

        //     List<String> prevClubs1 = new List<String> { "Legia" };
        //     Player player1 = new Player("Lionel Messi", contract1, 5000.0f, 1986, prevClubs1, 10);

        //     List<String> prevClubs2 = new List<String> { "Wisla Sandomierz", "Legia Warszawa" };
        //     Player player2 = new Player("Cristiano Ronaldo", contract2, 6500.0f, 1984, prevClubs2, 7);

        //     List<String> prevClubs3 = new List<String> { "FC Barcelona", "Real Madryt" };
        //     Player player3 = new Player("Neymar Jr", contract3, 5000.0f, 1986, prevClubs3);
        // }
    }

}