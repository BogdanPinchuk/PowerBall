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
        /// <summary>
        /// Count of chose white numbers
        /// </summary>
        private readonly int countChoseWhiteBalls;
        /// <summary>
        /// value of max multiplier
        /// </summary>
        private readonly int maxMultiplier;
        /// <summary>
        /// for get random numbers
        /// </summary>
        private readonly Random rnd = new();

        /// <summary>
        /// Max value of white balls
        /// </summary>
        public int MaxOfWhite
        {
            get { return maxOfWhite; }
            set
            {
                if (1 < value)
                    maxOfWhite = value;
                else
                    _ = new Exception("Error of input value for max value white balls");
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
                    maxOfRed = value;
                else
                    _ = new Exception("Error of input value for max value red ball");
            }
        }

        public PowerBallLogic()
        {

        }

        /// <summary>
        /// Create constructor with limitation
        /// </summary>
        /// <param name="maxOfWhite">max value for white balls</param>
        /// <param name="maxOfRed">max value for red ball</param>
        /// <param name="maxMultiplier">max value for multiplier</param>
        /// <param name="countChoseWhiteBalls">count of chose white balls</param>
        public PowerBallLogic(int maxOfWhite, int maxOfRed, int maxMultiplier,
            int countChoseWhiteBalls)
        {
            this.maxOfWhite = maxOfWhite;
            this.maxOfRed = maxOfRed;
            this.maxMultiplier = maxMultiplier;
            this.countChoseWhiteBalls = countChoseWhiteBalls;
        }

        /// <summary>
        /// Return random values for autocomplate ticket
        /// </summary>
        /// <returns></returns>
        public KeyValuePair<int, List<int>> GetRandomValues()
            => new(GetRandomRedBall(), GetRandomWhiteBalls());

        /// <summary>
        /// Return random value for power play game
        /// </summary>
        /// <returns></returns>
        public int GetRandomMultiplier()
        {
            // create base list
            List<int> array0 = new(),
                array1 = new();

            #region add elements (balls) for get multiplier
            // now moment hardcode for count of balls with different multiplier
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

        /// <summary>
        /// Return random value for red ball in powerball
        /// </summary>
        /// <returns></returns>
        private int GetRandomRedBall()
        {
            // create base list
            List<int> array0 = new(),
                array1 = new();

            // add elements (balls) for get red ball
            array0.AddRange(Enumerable
                .Range(1, MaxOfRed)
                .ToList());

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

        /// <summary>
        /// Return random value for white balls in powerball
        /// </summary>
        /// <returns></returns>
        private List<int> GetRandomWhiteBalls()
        {
            // create base list and list with array balls
            List<int> array0 = new(),
                array1 = new(),
                result = new();

            // add elements (balls) for get red ball
            array0.AddRange(Enumerable
                .Range(1, MaxOfWhite)
                .ToList());

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

            // extract random balls from mixing balls
            for (int i = 0; i < countChoseWhiteBalls; i++)
            {
                // get random ball from all balls
                index = rnd.Next(0, array1.Count);

                // put this ball in other virtual capacity
                result.Add(array1[index]);

                // remove this index in first virtual capacity
                array1.RemoveAt(index);
            }

            // sort values
            result.Sort();

            return result;
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
                    maxOfWhite = value;
                else
                    _ = new Exception("Error of input value for max value white balls");
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
                    maxOfRed = value;
                else
                    _ = new Exception("Error of input value for max value red ball");
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
                    _ = new Exception("Error of input values of white balls");
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
                    redBall = value;
                else
                    _ = new Exception("Error of input values of red ball");
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
        /// Change current ticket
        /// </summary>
        /// <param name="whiteBalls">values for white balls</param>
        /// <param name="redBall">value for red ball</param>
        public void ChangeTicket(List<int> whiteBalls, int redBall, bool powerPlay)
        {
            WhiteBalls = whiteBalls;
            RedBall = redBall;
            PowerPlay = powerPlay;
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
