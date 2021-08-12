using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Diagnostics;

namespace GameLogic.Test
{
    [TestClass]
    public class GameLogic_Test
    {
        private Probability probability;

        /// <summary>
        /// Calculate probability of all variants of prizes
        /// </summary>
        [TestInitialize]
        public void InitializeBeforeMethods()
        {
            // create instanse
            probability = new(69, 26, 5, 1);

        }

        [TestMethod]
        public void Calc_Probability_AllPrizes()
        {
            // using Classical Probability
            var a = probability.ClassicalProbability_General(5, 1);

            Trace.WriteLine(a);
        }
    }
}
