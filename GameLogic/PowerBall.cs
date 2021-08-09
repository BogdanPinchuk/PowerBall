using System;
using System.Collections.Generic;
using System.Linq;

namespace GameLogic
{
    /// <summary>
    /// Base logic of power ball
    /// </summary>
    public class PowerBall
    {

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
