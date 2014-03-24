/*The BracketSimulator program reads a .csv fil
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketSimulator
{
    class Program
    {
        static void Main()
        {
            //read CSV file and load in all teams and information
            ReadTeamData newReader = new ReadTeamData();
            
            Console.WriteLine("**********Midwest Region**********");
            GameSimulator Midwest = new GameSimulator(newReader.MidwestList);

            Console.WriteLine("**********West Region*************");
            GameSimulator West = new GameSimulator(newReader.WestList);

            Console.WriteLine("**********East Region*************");
            GameSimulator East = new GameSimulator(newReader.EastList);

            Console.WriteLine("**********South Region************");
            GameSimulator South = new GameSimulator(newReader.SouthList);

            List<Team> FinalFourTeams = new List<Team>() {Midwest.Winner, West.Winner, East.Winner, South.Winner} ;
            Console.WriteLine("**********Final Four**************");
            GameSimulator FinalFour = new GameSimulator(FinalFourTeams);

            Console.WriteLine("National Champs: " + FinalFour.Winner.name);
            Console.WriteLine();

            CustomList(newReader);
            Console.Read();
        }

        static void CustomList(ReadTeamData reader)
        {
            string team1="";
            string team2="";
            

            while (team1 != "x" || team1 != "X" || team2 != "x" || team2 != "X")
            {
                List<Team> customList = new List<Team>();
                Console.WriteLine("Customize Matchup - enter X to exit");
                Console.Write("Enter team 1: ");
                team1 = Console.ReadLine();
                if (team1 == "x" || team1 == "X")
                    break;
                customList.Add(reader.TeamList.Find(t => t.name == team1));

                Console.Write("Enter team 2: ");
                team2 = Console.ReadLine();
                if (team2 == "x" || team2 == "X")
                    break;
                customList.Add(reader.TeamList.Find(t => t.name == team2));

                GameSimulator customSim = new GameSimulator(customList);
            }
        }
    }
}
