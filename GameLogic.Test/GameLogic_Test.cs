using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Diagnostics;

namespace GameLogic.Test
{
    [TestClass]
    public class GameLogic_Test
    {
        #region create arrays for calculate all prizes
        // probability to win
        // 5 + PB   - Jackpot
        // 5        - $1 million
        // 4 + PB   - $50,000
        // 4        - $100.00
        // 3 + PB   - $100.00
        // 3        - $7.00
        // 2 + PB   - $7.00
        // 1 + PB   - $4.00
        // 0 + PB   - $4.00 
        #endregion
        /// <summary>
        /// array of count white balls that needed to get for each prizes
        /// </summary>
        private readonly int[] whiteB = new int[] { 5, 5, 4, 4, 3, 3, 2, 1, 0 };
        /// <summary>
        /// array of count red balls that needed to get for each prizes
        /// </summary>
        private readonly int[] redB = new int[] { 1, 0, 1, 0, 1, 0, 1, 1, 1 };

        #region stub objects
        /// <summary>
        /// Expected result for classical probability
        /// </summary>
        private readonly double[] expectedCP = new double[]
        {
            292_201_338,
            11_688_054,
            913_130,
            36_525,
            14_494,
            580,
            701,
            92,
            38,
        };
        /// <summary>
        /// Expected result for freaquency probability
        /// </summary>
        private readonly double[] expectedFP = new double[]
        {
            292_201_338,
            11_238_513,
            22_477_026,
            864_501,
            1_362_244,
            52_394,
            60_996,
            1_794,
            26,
        }; 
        #endregion

        /// <summary>
        /// Instance of probability fot testing
        /// </summary>
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

        /// <summary>
        /// Checking classical probability
        /// </summary>
        [TestMethod]
        public void ClassicalProbability_CheckOutputResult()
        {
            // avarrage
            double[] actual = new double[expectedCP.Length];

            // act
            for (int i = 0; i < actual.Length; i++)
                actual[i] = 1 / probability.ClassicalProbability(whiteB[i], redB[i]);

            // assert
            for (int i = 0; i < actual.Length; i++)
                Assert.AreEqual(expectedCP[i], actual[i], 1.0);

            // present result
            foreach (var i in actual)
                Trace.WriteLine(i);
        }

        /// <summary>
        /// Checking freaquency probability
        /// </summary>
        [TestMethod]
        public void FreaquencyProbability_CheckOutputResult()
        {
            // avarrage
            double[] actual = new double[expectedFP.Length];

            // act
            for (int i = 0; i < actual.Length; i++)
                actual[i] = 1 / probability.FreaquencyProbability(whiteB[i], redB[i]);

            // assert
            for (int i = 0; i < actual.Length; i++)
                Assert.AreEqual(expectedFP[i], actual[i], 1.0);

            // present result
            foreach (var i in actual)
                Trace.WriteLine(i);
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
