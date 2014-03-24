/*SortSeeding class accepts a list of Teams with a given tournament seed
 * and sorts them in order of their corresponding matchups.
 * The highest seeded team will always play the lowest possible seeded team in every round.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketSimulator
{
    public class SortSeeding
    {
        private int _numTeams;
        private List<int> _teams;
        
        //Constructors
        public SortSeeding()
        {}

        //Automatically calls methods to sort teams when constructed with a given parameter
        public SortSeeding(List<Team> regionList)
        {
            _numTeams = regionList.Count;
            Teams = Seeding(_numTeams);
        }

        //Finds how many tournament rounds are needed and calls NextLayer to order teams
        private List<int> Seeding(int numTeams)
        {
            int rounds = Convert.ToInt32(Math.Log(numTeams) / Math.Log(2) - 1);
            List<int> teams = new List<int>() { 1, 2 };
            
            for (int i=0; i<rounds; i++)
            {
                teams = NextLayer(teams);
            }
            return teams;
        }

        //Orders Teams in a list according to seed. (ex. 1 v. 8, 2 v. 7, 3 v.6 ...)
        private List<int> NextLayer(List<int> teams)
        {
            List<int> outPut = new List<int>();
            int length = teams.Count()*2+1;

            foreach(int i in teams )
            {
                outPut.Add(i);
                outPut.Add(length - i);
            }
            return outPut;
        }

        public void printTeams(List<int> teams)
        {
           for(int i=0; i < teams.Count; i++)
           {
               Console.WriteLine(teams[i]);
               
           }
            Console.Read();
        }

        //Properties
        public List<int> Teams
        {
            get { return _teams; }
            set { _teams = value; }
    }
    }
}
