/*ReadTeamData class reads a .csv file and creates a list of teams ordered by seeded match-ups.
 * .csv file format - Team,Pythagoran,AdjOff,AdjDef,AdjTempo,Region,Seed
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BracketSimulator
{
    public class ReadTeamData
    {
        private string inputString;
        private StreamReader reader;
        private string inputFile = "ncaa_teams_new.csv";
        private List<Team> teamList;    //"Master" list used - contains all teams read from .csv file.

        //Lists of teams grouped by region (for simulating NCAA Tournament)
        private List<Team> midwestList = new List<Team>();
        private List<Team> westList = new List<Team>();
        private List<Team> eastList = new List<Team>();
        private List<Team> southList = new List<Team>();
  
        //Constructors
        public ReadTeamData()
        {
            reader = new StreamReader(inputFile);
            LoadTeams(reader);
            GroupTeamRegions(teamList);
            midwestList = SortTeamRegions(midwestList);
            westList = SortTeamRegions(westList);
            eastList = SortTeamRegions(eastList);
            southList = SortTeamRegions(southList);
        }

        public ReadTeamData(string inputFile)
        {
            reader = new StreamReader(inputFile);
            LoadTeams(reader);
            GroupTeamRegions(teamList);
            midwestList = SortTeamRegions(midwestList);
            westList = SortTeamRegions(westList);
            eastList = SortTeamRegions(eastList);
            southList = SortTeamRegions(southList);
        }

        //Reads input file and loads teams and stats into teamList
        private void LoadTeams(StreamReader reader)
        {
            reader.ReadLine(); //skip first line of column headers
            teamList = new List<Team>();
            string[] inputArray = new string[7];

            while ((inputString = reader.ReadLine()) != null)
            {
                inputArray = inputString.Split(',');
                Team newTeam = new Team();

                newTeam.name = inputArray[0];
                newTeam.pythagoran = Convert.ToDecimal(inputArray[1]);
                newTeam.offensiveEfficiency = Convert.ToDouble(inputArray[2]);
                newTeam.defensiveEfficiency = Convert.ToDouble(inputArray[3]);
                newTeam.tempo = Convert.ToDouble(inputArray[4]);
                newTeam.region = inputArray[5];
                newTeam.seed = Convert.ToInt32(inputArray[6]);

                teamList.Add(newTeam);
            }
        }

        //Adds each team to appropriate Region List
        private void GroupTeamRegions(List<Team> teamList)
        {
            foreach (Team t in teamList)
            {
                if (t.region == "Midwest")
                    midwestList.Add(t);
                else if (t.region == "West")
                    westList.Add(t);
                else if (t.region == "East")
                    eastList.Add(t);
                else if (t.region == "South")
                    southList.Add(t);
                else
                    throw new ArgumentNullException();
            }
        }

        //uses SortSeeding Class to sort seeds into matchups in a given Region
        private List<Team> SortTeamRegions(List<Team> regionList)
        {
            SortSeeding newsort = new SortSeeding(regionList);
            List<Team> tempList = new List<Team>();

            for (int i = 0; i< newsort.Teams.Count; i++)
            {
                tempList.Add(regionList.Find(t => t.seed == newsort.Teams[i]));
            }

            return tempList;
        }


        //Properties
        public List<Team> MidwestList
        {
            get { return midwestList; }
        }

        public List<Team> WestList
        {
            get { return westList; }
        }

        public List<Team> EastList
        {
            get { return eastList; }
        }

        public List<Team> SouthList
        {
            get { return southList; }
        }

        public List<Team> TeamList
        {
            get { return teamList; }
        }
    }
}
