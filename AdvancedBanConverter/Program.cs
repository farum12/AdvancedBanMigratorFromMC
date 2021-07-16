using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;

namespace AdvancedBanConverter
{
    

    class Program
    {
        static void Main(string[] args)
        {
            // Replace with paths to your banned-players and banned-ips jsons
            var pathToBannedPlayers = @"C:\YOUR\PATH\TO\banned-players.json";
            var pathToBannedIps = @"C:\YOUR\PATH\TO\banned-ips.json";


            // Replace these strings with names of corresponding tables, if something has changed; below are default names
            var punishementsTableName = "Punishements";
            var punishmentHistoryTableName = "PunishmentHistory";

            // Change that if your server is runninng in online mode; if offline mode - keep this variable as true;
            var populateUUIDwithName = true;


            // Don't touch that.
            generateInsert(punishementsTableName, pathToBannedPlayers, pathToBannedIps, populateUUIDwithName);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            generateInsert(punishmentHistoryTableName, pathToBannedPlayers, pathToBannedIps, populateUUIDwithName);
        }


        public static void generateInsert(String tableName, String PathToBannedPlayers, String PathToBannedIps, bool populateUUIDwithName)
        {
            
            JArray players = JArray.Parse(File.ReadAllText(PathToBannedPlayers));
            JArray ips = JArray.Parse(File.ReadAllText(PathToBannedIps));


            Console.WriteLine("INSERT INTO `"+tableName+"`(`name`, `uuid`, `reason`, `operator`, `punishmentType`, `start`, `end`, `calculation`) VALUES ");

            // banned-players
            foreach (var ban in players)
            {
                var parsedDate = DateTime.Parse((string)ban["created"]);
                var date = new DateTime(1970, 1, 1, 0, 0, 0, 0, parsedDate.Kind);
                var unixTimestamp = Convert.ToInt64((parsedDate - date).TotalMilliseconds);
                if (populateUUIDwithName)
                {
                    var playerBan = new Punishment((string)ban["name"], ((string)ban["uuid"]).ToLower(), (string)ban["reason"], (string)ban["source"], "BAN", unixTimestamp, -1);
                    playerBan.ToStr();
                } else
                {
                    var playerBan = new Punishment((string)ban["name"], ((string)ban["name"]).ToLower(), (string)ban["reason"], (string)ban["source"], "BAN", unixTimestamp, -1);
                    playerBan.ToStr();
                }
                
                
                Console.Write(",\n");
            }
            var iteration = 0;
            // banned ips
            foreach (var ban in ips)
            {
                iteration++;
                var parsedDate = DateTime.Parse((string)ban["created"]);
                var date = new DateTime(1970, 1, 1, 0, 0, 0, 0, parsedDate.Kind);
                var unixTimestamp = Convert.ToInt64((parsedDate - date).TotalMilliseconds);
                var playerBan = new Punishment((string)ban["ip"], ((string)ban["ip"]).ToLower(), (string)ban["reason"], (string)ban["source"], "IP_BAN", unixTimestamp, -1);
                playerBan.ToStr();
                if (iteration < ips.Count)
                {
                    Console.Write(",\n");
                }
                else
                {
                    Console.Write(";");
                }
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
