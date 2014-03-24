/*This Class contains the formulas used to simulate a matchup between two teams.
 * The simulation automatically runs when the classs is constructed using two teams*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketSimulator
{
    public class GameSimulator
    {
        private decimal probabilityToWin;
        private double estimatedTempo;
        private double averageTempo = 66.45;
        private double averageOffEff = 104.36;
        private double teamAoutput;
        private double teamBoutput;
        private Team _winner = new Team();

        public GameSimulator()
        { }

        public GameSimulator(List<Team> teamList)
        {
            SimBracket(teamList);
        }

        private void SimBracket(List<Team> teamList)
        {
            List<Team> nextRoundList = new List<Team>();   
            for (int i = 0; i < teamList.Count; i++)
            {
               probabilityToWin = CalculateWinProbability(teamList[i].pythagoran, teamList[i + 1].pythagoran);
               estimatedTempo = CalculateEstimatedTempo(teamList[i].tempo, teamList[i+1].tempo);
               SimulateGame(teamList[i].offensiveEfficiency, teamList[i].defensiveEfficiency, teamList[i + 1].offensiveEfficiency, teamList[i + 1].defensiveEfficiency);
               PrintResults(teamAoutput, teamBoutput, probabilityToWin, teamList[i], teamList[i+1]);
               if (teamAoutput > teamBoutput)
                   nextRoundList.Add(teamList[i]);
               else if (teamBoutput > teamAoutput)
                   nextRoundList.Add(teamList[i + 1]);
               else
                   throw new Exception("Error: Neither team has a higher score");

               i++;
             }
            if (nextRoundList.Count > 1)
            {
                Console.WriteLine("=====NEXT ROUND=====");
                Console.WriteLine();
                SimBracket(nextRoundList);
            }
            else
                _winner = nextRoundList[0];
                           
        }

        private decimal CalculateWinProbability(decimal pythA, decimal pythB)
        {
            decimal winProb = ((pythA - pythA*pythB) / (pythA + pythB - 2 * pythA * pythB));
            return winProb;
        }

        private double CalculateEstimatedTempo(double tempoA, double tempoB)
        {
            double estTempo = ((tempoA / averageTempo) * (tempoB / averageTempo) * averageTempo);
            return estTempo;
        }

        private void SimulateGame(double teamAoff, double teamAdef, double teamBoff, double teamBdef)
        {
            teamAoutput = ((teamAoff / averageOffEff) * (teamBdef / averageOffEff) * averageOffEff);
            teamAoutput = teamAoutput * (estimatedTempo / 100);
            teamBoutput = ((teamBoff / averageOffEff) * (teamAdef / averageOffEff) * averageOffEff);
            teamBoutput = teamBoutput * (estimatedTempo / 100);
        }

        private void PrintResults(double teamAoutput, double teamBOutput, decimal winProb, Team teamA, Team teamB)
        {
            Console.WriteLine(teamA.seed + " " + teamA.name + "\t \t" +  teamAoutput.ToString("F") + "\t" + winProb.ToString("F") );
            Console.WriteLine(teamB.seed + " " + teamB.name + "\t \t" + teamBoutput.ToString("F"));
            Console.WriteLine();
        }

        public Team Winner
        {
            get { return _winner; }
        }
        

    }
}
