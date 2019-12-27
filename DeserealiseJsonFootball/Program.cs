using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DeserealiseJsonFootball
{
    class Program
    {
        static Football football = new Football();
        static void Main(string[] args)
        {
            // Uncomment the below if reading the file from a local perspective
            /*using (StreamReader r = new StreamReader("C:\\Users\\FootballTeams.json"))
            {
                string json = r.ReadToEnd();
                var football = JsonConvert.DeserializeObject<Football>(json);
            }*/

            Task<string> result = GetResponseString();
            var jsonResult = result.Result;

            football = JsonConvert.DeserializeObject<Football>(jsonResult);

            var numberOfGoals = Run("manutd");
            Console.WriteLine(numberOfGoals);
            Console.ReadLine();
        }

        static public int Run(string teamKey)
        {
            int goals = 0;

            foreach (var round in football.rounds)
            {
                foreach (var match in round.matches)
                {
                    if (match.team1.key == teamKey)
                    {
                        goals += match.score1;
                    }

                    if (match.team2.key == teamKey)
                    {
                        goals += match.score2;
                    }

                }
            }

            return goals;
        }

        static public async Task<string> GetResponseString()
        {
            var httpClient = new HttpClient();

            var response = await httpClient.GetAsync("https://raw.githubusercontent.com/openfootball/football.json/master/2014-15/en.1.json");
            var contents = await response.Content.ReadAsStringAsync();

            return contents;
        }
    }
}
