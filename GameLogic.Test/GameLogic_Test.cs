using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace GameLogic.Test
{
    [TestClass]
    public class GameLogic_Test
    {
        #region stub objects
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
        /// Base logig of game
        /// </summary>
        private PowerBallLogic powerBall;
        /// <summary>
        /// random balls (red and white) for "Perform draw"
        /// </summary>
        private KeyValuePair<int, List<int>> randomBalls;

        /// <summary>
        /// Count of bought titkets for analisys
        /// </summary>
        private readonly int countsOfTickets = 100_000;

        /// <summary>
        /// Calculate probability of all variants of prizes
        /// </summary>
        [TestInitialize]
        public void InitializeBeforeMethods()
        {
            // create instanse
            probability = new(69, 26, 5, 1);

            // base logi of game
            powerBall = new(69, 26, 10, 5, 20_000_000);

            // get random values for wins balls
            randomBalls = powerBall.GetRandomValues();
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
            #region old varian - slow
            /*
            for (int i = 0; i < actual.Length; i++)
                actual[i] = 1 / probability.ClassicalProbability(whiteB[i], redB[i]); 
            */
            #endregion

            // faster variant - using multithreading
            Parallel.For(0, actual.Length,
                i => actual[i] = 1 / probability.ClassicalProbability(whiteB[i], redB[i]));

            // assert
            for (int i = 0; i < actual.Length; i++)
                Assert.AreEqual(expectedCP[i], actual[i], 1.0);

            // present result
            foreach (var i in actual)
                Trace.WriteLine($"{i:N2}");
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
            #region old varian - slow
            /*
            for (int i = 0; i < actual.Length; i++)
                actual[i] = 1 / probability.FreaquencyProbability(whiteB[i], redB[i]); 
            */
            #endregion

            // faster variant - using multithreading
            Parallel.For(0, actual.Length,
                i => actual[i] = 1 / probability.FreaquencyProbability(whiteB[i], redB[i]));

            // assert
            for (int i = 0; i < actual.Length; i++)
                Assert.AreEqual(expectedFP[i], actual[i], 1.0);

            // present result
            foreach (var i in actual)
                Trace.WriteLine($"{i:N2}");
        }

        /// <summary>
        /// Analisys tolerance of classical probability with expected data
        /// </summary>
        [TestMethod]
        public void ClassicalProbability_Tickets_AlalisysTolerance()
            => AnalisysOfProbability(expectedCP);

        /// <summary>
        /// Analisys tolerance of freaquency probability with expected data
        /// </summary>
        [TestMethod]
        public void FreaquencyProbability_Tickets_AlalisysTolerance()
            => AnalisysOfProbability(expectedFP);

        /// <summary>
        /// General analisys of probability
        /// </summary>
        /// <param name="expectedData">expected data for analisys</param>
        private void AnalisysOfProbability(double[] expectedData)
        {
            // avarrage
            // create list with relative values
            List<double> expected = new(expectedData.Select(i => 1 / i));
            // create dictionary for calculate number of prizes
            Dictionary<int, double> prizesData = new();
            // 0 - absent prize
            for (int i = 0; i <= expected.Count; i++)
                prizesData.Add(i, 0.0);

            // act
            // buying a lot of tickets,
            // rule "Big numbers" give more tolerance, but takes more time

            // ObjectPool for oblects
            ObjectPool<PowerBallLogic> poolGame = new(() => new(69, 26, 10, 5, 20_000_000));
            ObjectPool<Ticket> poolTicket = new(() => new(69, 26));

            // analisys tickets
            Parallel.For(0, countsOfTickets, i =>
            {
                // create game and ticket
                var powerBall = poolGame.Get();
                var ticket = poolTicket.Get();

                // get random values for ticket
                var randomValues = powerBall.GetRandomValues();

                // wtite random values in ticket
                ticket.ChangeTicket(randomValues.Value, randomValues.Key, true);

                // analisys of ticket
                powerBall.CheckingTicket(ticket, randomBalls);

                // return objects
                poolGame.Return(powerBall);
                poolTicket.Return(ticket);

                // save data
                prizesData[powerBall.Prizes[0]] += 1;
            });

            // convert data to array of actual data
            List<double> actual = new();

            for (int i = 1; i < prizesData.Count; i++)
                actual.Add(prizesData[i] / countsOfTickets);

            // assert
            for (int i = 0; i < actual.Count; i++)
                Assert.AreEqual(expected[i], actual[i], 0.015);

            // present result
            Trace.WriteLine("\nRelative values of difference: [%]");
            for (int i = 0; i < actual.Count; i++)
                Trace.WriteLine($"{i + 1} - {100 * Math.Abs(expected[i] - actual[i]):F9}");
            
            Trace.WriteLine("\nRelative values that calculate math: [%]");
            for (int i = 0; i < expected.Count; i++)
                Trace.WriteLine($"{i + 1} - {100 * expected[i]:F9}");

            Trace.WriteLine("\nRelative values that were get experimental: [%]");
            for (int i = 0; i < actual.Count; i++)
                Trace.WriteLine($"{i + 1} - {100 * actual[i]:F9}");
        }

    }
}
