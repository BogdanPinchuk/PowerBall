using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Diagnostics;

namespace GameLogic.Test
{
    [TestClass]
    public class GameLogic_Test
    {
        /// <summary>
        /// type of prizes (hard code), W - white, R - red balls
        /// </summary>
        enum TypePrizes
        {
            /// <summary>
            /// 1-st - jackpot
            /// </summary>
            W5_R1,
            /// <summary>
            /// 2-nd - $1 million
            /// </summary>
            W5_R0,
            /// <summary>
            /// 3-rd - $50,000
            /// </summary>
            W4_R1,
            /// <summary>
            /// 4-th - $100
            /// </summary>
            W4_R0,
            /// <summary>
            /// 5-th - $100
            /// </summary>
            W3_R1,
            /// <summary>
            /// 6-th - $7
            /// </summary>
            W3_R0,
            /// <summary>
            /// 7-th - $7
            /// </summary>
            W2_R1,
            /// <summary>
            /// 8-th - $4
            /// </summary>
            W1_R1,
            /// <summary>
            /// 9-th - $4
            /// </summary>
            W0_R1,
        }

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
            var a = probability.ClassicalProbability(5, 1);
            // using Freaquency Probability
            var b = probability.FreaquencyProbability(5, 1);

            Trace.WriteLine(1 / a);
            Trace.WriteLine(1 / b);
        }
    }
}
