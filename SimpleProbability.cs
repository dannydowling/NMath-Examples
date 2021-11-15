using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CenterSpace.NMath.Core;


namespace NMathPatterns
{
    internal class SimpleProbability
    {
        public SimpleProbability()
        {
            int number_of_trials = 10;
            double prob_of_success = 0.5;

            var dist = new BinomialDistribution();
            dist.N = number_of_trials;
            dist.P = prob_of_success;

            // Probability of landing 5 heads in 10 flips ( = 0.246)
            double five_heads = dist.PDF(5);

            // Probability of landing 3, 4, 5, or 6 heads in 10 flips ( = 0.656)
            double three_to_six_heads = dist.CDF(6) - dist.CDF(3);
        }
    }
}

