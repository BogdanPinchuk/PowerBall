using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        /// coefficient of multiplier for power play
        /// </summary>
        private int multiplier;
        /// <summary>
        /// sum of jackpot
        /// </summary>
        private readonly long jackpot;
        /// <summary>
        /// for get random numbers
        /// </summary>
        private readonly Random rnd = new();
        /// <summary>
        /// List of winners with their prizes
        /// </summary>
        private List<int> prizes = new();
        /// <summary>
        /// List after analisys tickets with report winners values
        /// </summary>
        private List<KeyValuePair<bool, List<bool>>> winValues = new();
        /// <summary>
        /// Size of winning money each ticket
        /// </summary>
        private List<long> winMoneys = new();

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
        /// List of winners with their prizes
        /// </summary>
        public List<int> Prizes
        {
            get { return prizes; }
        }
        /// <summary>
        /// List after analisys tickets with report winners values
        /// </summary>
        public List<KeyValuePair<bool, List<bool>>> WinValues
        {
            get { return winValues; }
        }
        /// <summary>
        /// Size of winning money each ticket
        /// </summary>
        public List<long> WinMoneys
        {
            get { return winMoneys; }
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
        /// <param name="jackpot">sum of jackpot</param>
        public PowerBallLogic(int maxOfWhite, int maxOfRed, int maxMultiplier,
            int countChoseWhiteBalls, long jackpot)
        {
            this.maxOfWhite = maxOfWhite;
            this.maxOfRed = maxOfRed;
            this.maxMultiplier = maxMultiplier;
            this.countChoseWhiteBalls = countChoseWhiteBalls;
            this.jackpot = jackpot;
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

            // save result
            multiplier = array1[index];

            // return value of random ball
            return multiplier;
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

        /// <summary>
        /// Get full sorted array white balls
        /// </summary>
        /// <returns></returns>
        public List<int> GetArrayWhiteBalls()
            => Enumerable
            .Range(1, MaxOfWhite)
            .ToList();

        /// <summary>
        /// Get full sorted array red balls
        /// </summary>
        /// <returns></returns>
        public List<int> GetArrayRedBalls()
            => Enumerable
            .Range(1, MaxOfRed)
            .ToList();

        /// <summary>
        /// Cheking bought tikets to win
        /// </summary>
        /// <param name="tickets">bought tickets</param>
        /// <param name="win">winning ticket/combination</param>
        public void CheckingTickets(List<Ticket> tickets, KeyValuePair<int, List<int>> win)
        {
            // temp array for to follow the order, because if important

            // result of every values
            KeyValuePair<bool, List<bool>>[] winValues =
                new KeyValuePair<bool, List<bool>>[tickets.Count];
            // prizes
            int[] prizes = new int[tickets.Count];
            // winning moneys
            long[] winMoneys = new long[tickets.Count];

            // cheking to win, use multithreding for fast calculating
            Parallel.For(0, tickets.Count, i =>
            {
                winValues[i] = tickets[i].ValidateTicket(win);
                prizes[i] = AnalisysPrize(tickets[i].CountWhite, tickets[i].CountRed);
                winMoneys[i] = ConvertPrizeIntoMoney(prizes[i], tickets[i].PowerPlay);
            });

            #region old version
            /*
            for (int i = 0; i < tickets.Count; i++)
            {
                winValues[i] = tickets[i].ValidateTicket(win);
                prizes[i] = AnalisysPrize(tickets[i].CountWhite, tickets[i].CountRed);
                winMoneys[i] = ConvertPrizeIntoMoney(prizes[i], tickets[i].PowerPlay);
            } 
            */
            #endregion

            // if we have more then 1 winners jackpot we mast divide on this count
            int countJackpoter = prizes.Where(i => i == 1).Count();

            if (countJackpoter > 1)
            {
                // we divide evently, without coins
                long partJackpot = jackpot / countJackpoter;

                // corected prizes
                for (int i = 0; i < winMoneys.Length; i++)
                    if (winMoneys[i] == jackpot)
                        winMoneys[i] = partJackpot;
            }

            // save results, important to follow the order
            this.winValues = winValues.ToList();
            this.prizes = prizes.ToList();
            this.winMoneys = winMoneys.ToList();
        }

        /// <summary>
        /// Analisys type if prise
        /// </summary>
        /// <param name="countWhite">count of winning values</param>
        /// <param name="countRed">count of winning values</param>
        /// <returns></returns>
        private static int AnalisysPrize(int countWhite, int countRed)
        {
            // type of prize, 0 - absent prize
            int result;

            if (countWhite == 5 && countRed == 1)   // jackpot
                result = 1;
            else if (countWhite == 5 && countRed == 0)
                result = 2;
            else if (countWhite == 4 && countRed == 1)
                result = 3;
            else if (countWhite == 4 && countRed == 0)
                result = 4;
            else if (countWhite == 3 && countRed == 1)
                result = 5;
            else if (countWhite == 3 && countRed == 0)
                result = 6;
            else if (countWhite == 2 && countRed == 1)
                result = 7;
            else if (countWhite == 1 && countRed == 1)
                result = 8;
            else if (countWhite == 0 && countRed == 1)
                result = 9;
            else
                result = 0;

            return result;
        }

        /// <summary>
        /// Convert type of prize  
        /// </summary>
        /// <param name="prize">type of prize</param>
        /// <param name="powerPlay">is gamer use power play</param>
        /// <returns></returns>
        private long ConvertPrizeIntoMoney(int prize, bool powerPlay)
        {
            var result = prize switch
            {
                1 => jackpot,
                2 => 1_000_000 * (powerPlay ? 2 : 1),
                3 => 50_000 * (powerPlay ? multiplier : 1),
                4 or 5 => 100 * (powerPlay ? multiplier : 1),
                6 or 7 => 7 * (powerPlay ? multiplier : 1),
                8 or 9 => 4 * (powerPlay ? multiplier : 1),
                _ => 0,
            };

            #region old version
            /*
            switch (prize)
            {
                case 1:
                    result = jackpot;
                    break;
                case 2:
                    result = 1_000_000 * (powerPlay ? 2 : 1);
                    break;
                case 3:
                    result = 50_000 * (powerPlay ? multiplier : 1);
                    break;
                case 4:
                case 5:
                    result = 100 * (powerPlay ? multiplier : 1);
                    break;
                case 6:
                case 7:
                    result = 7 * (powerPlay ? multiplier : 1);
                    break;
                case 8:
                case 9:
                    result = 4 * (powerPlay ? multiplier : 1);
                    break;
                default:
                    result = 0;
                    break;
            } 
            */
            #endregion

            return result;
        }

    }

    /// <summary>
    /// Ticket
    /// </summary>
    public class Ticket
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
        /// Winninig result
        /// </summary>
        private KeyValuePair<bool, List<bool>> resultOfWin;

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
        /// Winninig result
        /// </summary>
        public KeyValuePair<bool, List<bool>> ResultOfWin
        {
            get { return resultOfWin; }
        }

        /// <summary>
        /// Count winning values white balls
        /// </summary>
        public int CountWhite
        {
            get { return ResultOfWin.Value.Where(i => i == true).Count(); }
        }

        /// <summary>
        /// Count winning values red balls
        /// </summary>
        public int CountRed
        {
            get { return (ResultOfWin.Key == true) ? 1 : 0; }
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

            resultOfWin = new();
        }

        /// <summary>
        /// Change current ticket
        /// </summary>
        /// <param name="whiteBalls">values for white balls</param>
        /// <param name="redBall">value for red ball</param>
        public void ChangeTicket(List<int> whiteBalls, int redBall,
            bool powerPlay)
        {
            WhiteBalls = whiteBalls;
            RedBall = redBall;
            PowerPlay = powerPlay;
        }

        /// <summary>
        /// Checking this ticket with win numbers
        /// </summary>
        /// <param name="winValues">winning combination</param>
        public KeyValuePair<bool, List<bool>> ValidateTicket(KeyValuePair<int, List<int>> winValues)
        {
            // winning combination
            List<int> win = winValues.Value;
            win.Sort();
            // curent combination
            List<int> cur = WhiteBalls;
            cur.Sort();

            // checking white color
            List<bool> checkWC = new();

            for (int i = 0; i < cur.Count; i++)
                checkWC.Add(win.Contains(cur[i]));

            // checking red color
            bool checkRC = winValues.Key == RedBall;

            // save result
            resultOfWin = new KeyValuePair<bool, List<bool>>(checkRC, checkWC);

            return resultOfWin;
        }

    }
}
