using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketSimulator
{
    public class Team
    {
        public string name;
        public decimal pythagoran;
        public double offensiveEfficiency;
        public double defensiveEfficiency;
        public double tempo;
        public string region;
        public int seed;

        public Team()
        { }

        public Team(string name, decimal pyth, double offEff, double defEff, double tempo, string region, int seed)
        {
            this.name = name;
            pythagoran = pyth;
            offensiveEfficiency = offEff;
            defensiveEfficiency = defEff;
            this.tempo = tempo;
            this.region = region;
            this.seed = seed;
        }
    }
}
