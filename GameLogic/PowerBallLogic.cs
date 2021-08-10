using System;
using System.Collections.Generic;
using System.Linq;

namespace GameLogic
{
    /// <summary>
    /// Base logic of power ball
    /// </summary>
    public class PowerBallLogic
    {
        /// <summary>
        /// Numner of maximum value for white balls
        /// </summary>
        private int maxOfWhite;
        /// <summary>
        /// Numner of maximum value for red balls
        /// </summary>
        private int maxOfRed;
        ///// <summary>
        ///// Array values for white balls
        ///// </summary>
        //private List<int> arrayValueForWhiteBall;
        ///// <summary>
        ///// Array values for red balls
        ///// </summary>
        //private List<int> arrayValueForRedBall;
        /// <summary>
        /// value of max multiplier
        /// </summary>
        private int maxMultiplier;
        /// <summary>
        /// for get random numbers
        /// </summary>
        private Random rnd = new Random();

        /// <summary>
        /// Max value of white balls
        /// </summary>
        public int MaxOfWhite
        {
            get { return maxOfWhite; }
            set
            {
                if (1 < value)
                {
                    maxOfWhite = value;
                }
                else
                {
                    new Exception("Error of input value for max value white balls");
                }
            }
        }
        /// <summary>
        /// Max value of red ball
        /// </summary>
        public int MaxOfRed
        {
            get { return maxOfRed; }
            set
            {
                if (1 < value)
                {
                    maxOfRed = value;
                }
                else
                {
                    new Exception("Error of input value for max value red ball");
                }
            }
        }

        /// <summary>
        /// Get sorted values for white balls
        /// </summary>
        private List<int> GetSortArrayForWhiteBall
            => GetSortArray(MaxOfWhite);
        /// <summary>
        /// Get sorted values for red balls
        /// </summary>
        private List<int> GetSortArrayForRedBall
            => GetSortArray(MaxOfRed);

        public PowerBallLogic()
        {

        }

        /// <summary>
        /// Create constructor with limitation
        /// </summary>
        /// <param name="maxOfWhite">max value for white balls</param>
        /// <param name="maxOfRed">max value for red ball</param>
        public PowerBallLogic(int maxOfWhite, int maxOfRed, int maxMultiplier)
        {
            this.maxOfWhite = maxOfWhite;
            this.maxOfRed = maxOfRed;
            this.maxMultiplier = maxMultiplier;
        }

        /// <summary>
        /// Get sorted array of integer values for balls
        /// </summary>
        /// <param name="number">max value of balls</param>
        /// <returns></returns>
        private List<int> GetSortArray(int number)
            => Enumerable.Range(1, number + 1).ToList();

        /// <summary>
        /// Return random values for autocomplate ticket
        /// </summary>
        /// <returns></returns>
        public Dictionary<List<int>, int> GetRandomValues()
        {
            return default;
        }

        /// <summary>
        /// Return random value for power play game
        /// </summary>
        /// <returns></returns>
        public int GetRandomMultiplier()
        {
            // create base list
            List<int> array0 = new List<int>(),
                array1 = new List<int>();

            #region add elements (balls) for get multiplier
            // x2
            array0.AddRange(Enumerable
                .Range(1, 24)
                .Select(i => 0 * i + 2)
                .ToList());

            // x3
            array0.AddRange(Enumerable
                .Range(1, 13)
                .Select(i => 0 * i + 3)
                .ToList());

            // x4
            array0.AddRange(Enumerable
                .Range(1, 3)
                .Select(i => 0 * i + 4)
                .ToList());

            // x5
            array0.AddRange(Enumerable
                .Range(1, 2)
                .Select(i => 0 * i + 5)
                .ToList());

            // x10
            if (maxMultiplier == 10)
                array0.Add(10);
            #endregion

            // count of balls in virtual capacity
            int capacity = array0.Count;

            // temp value for index of element
            int index;

            // mixing balls
            for (int i = 0; i < capacity; i++)
            {
                // get random ball from all balls
                index = rnd.Next(0, array0.Count);

                // put this ball in other virtual capacity
                array1.Add(array0[index]);

                // remove this index in first virtual capacity
                array0.RemoveAt(index);
            }

            // extract random ball from mixing balls
            index = rnd.Next(0, array1.Count);

            // return value of random ball
            return array1[index];
        }

    }

    /// <summary>
    /// Ticket
    /// </summary>
    public struct Ticket
    {
        /// <summary>
        /// list of values numbers white balls
        /// </summary>
        private List<int> whiteBalls;
        /// <summary>
        /// value number of red ball
        /// </summary>
        private int redBall;
        /// <summary>
        /// use multiplier
        /// </summary>
        private bool powerPlay;
        /// <summary>
        /// Numner of maximum value for white balls
        /// </summary>
        private int maxOfWhite;
        /// <summary>
        /// Numner of maximum value for red balls
        /// </summary>
        private int maxOfRed;

        /// <summary>
        /// Max value of white balls
        /// </summary>
        public int MaxOfWhite
        {
            get { return maxOfWhite; }
            set
            {
                if (1 < value)
                {
                    maxOfWhite = value;
                }
                else
                {
                    new Exception("Error of input value for max value white balls");
                }
            }
        }

        /// <summary>
        /// Max value of red ball
        /// </summary>
        public int MaxOfRed
        {
            get { return maxOfRed; }
            set
            {
                if (1 < value)
                {
                    maxOfRed = value;
                }
                else
                {
                    new Exception("Error of input value for max value red ball");
                }
            }
        }

        /// <summary>
        /// use multiplier
        /// </summary>
        public bool PowerPlay
        {
            get { return powerPlay; }
            set { powerPlay = value; }
        }

        /// <summary>
        /// Values of white balls
        /// </summary>
        public List<int> WhiteBalls
        {
            get { return whiteBalls; }
            set
            {
                int max = value.Max(),
                    min = value.Min();

                if (1 <= min && max <= maxOfWhite)
                {
                    whiteBalls = value;
                    whiteBalls.Sort();
                }
                else
                {
                    new Exception("Error of input values of white balls");
                }

            }
        }

        /// <summary>
        /// Values of red ball
        /// </summary>
        public int RedBall
        {
            get { return redBall; }
            set
            {
                if (1 <= value && value <= maxOfRed)
                {
                    redBall = value;
                }
                else
                {
                    new Exception("Error of input values of red ball");
                }
            }
        }

        /// <summary>
        /// Create base ticket
        /// </summary>
        /// <param name="maxOfWhite">Numner of maximum value for white balls</param>
        /// <param name="maxOfRed">Numner of maximum value for red balls</param>
        public Ticket(int maxOfWhite, int maxOfRed)
        {
            this.maxOfWhite = maxOfWhite;
            this.maxOfRed = maxOfRed;

            powerPlay = false;
            redBall = 1;
            whiteBalls = Enumerable
                .Range(1, 5)
                .ToList();
        }

        /// <summary>
        /// Checking this ticket with win numbers
        /// </summary>
        public void ValidateTicket()
        {
            // TODO: validator of ticket
        }

    }
}
