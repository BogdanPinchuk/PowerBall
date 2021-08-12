using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using factorial = Factorial.Factorial;

// Note: Пояснення на укр.мові щоб простіще було пояснити розбіжності і навести 2 різні варіанти
// найбільш відомих методів розразунку:
// 1. (Представляється на офіційних сайтах лоторей)
// # кластична ймовірність з врахуванням ймовірності витягнути прогашну кулю
// https://www.thelotter.com/ru/ekskurs-i-pravila-igry-v-powerball/
// https://www.thelotter.com/ru/nomer-power-play/
// https://www.lotto.net/ru/powerball/prizy
// шанси на виграш / (обернена величина) ймовірність виграшу
// 5 + PB   1 in 292,201,338    Jackpot
// 5        1 in 11,688,054     $1 million
// 4 + PB   1 in 913,130        $50,000
// 4        1 in 36,525         $100.00
// 3 + PB   1 in 14,494         $100.00
// 3        1 in 580            $7.00
// 2 + PB   1 in 701            $7.00
// 1 + PB   1 in 92             $4.00
// 0 + PB   1 in 38             $4.00
// 2. Представляється на значній частині сайтів і частіше зустрічаєтьс яу збірниках
// 2.1. базується на основі максимально можливої кількості комбінацій
// 2.2. базується на основі частоти випадіння виграшних куль
// https://timelottery.ru/loto-vidzhety/raschet-veroyatnosti-vyigrysha/
// шанси на виграш / (обернена величина) ймовірність виграшу
// 5 + PB   1 in 292,201,338    Jackpot
// 5        1 in 11,238,513     $1 million
// 4 + PB   1 in 22,477,026     $50,000
// 4        1 in 864,501        $100.00
// 3 + PB   1 in 1,362,244      $100.00
// 3        1 in 52,394         $7.00
// 2 + PB   1 in 60,996         $7.00
// 1 + PB   1 in 1,794          $4.00
// 0 + PB   1 in 26             $4.00
// Це також можна перевірити на вище вказаному сайті
// Як помітно з аналізу двоїх різних методів розрахунку ймовірностей,
// результати можуть суттєво відрізнятися

namespace GameLogic.Test
{
    /// <summary>
    /// Ймовірності
    /// </summary>
    class Probability
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
        private int countChoseWhiteBalls;
        /// <summary>
        /// Count of chose red numbers
        /// </summary>
        private int countChoseRedBalls;

        public Probability() { }

        /// <summary>
        /// Create instance
        /// </summary>
        /// <param name="maxOfWhite">max value of white balls</param>
        /// <param name="maxOfRed">max value of red balls</param>
        /// <param name="countChoseWhiteBalls">count white balls for choise</param>
        /// <param name="countChoseRedBalls">count red balls for choise</param>
        public Probability(int maxOfWhite, int maxOfRed,
            int countChoseWhiteBalls, int countChoseRedBalls)
        {
            this.maxOfWhite = maxOfWhite;
            this.maxOfRed = maxOfRed;
            this.countChoseWhiteBalls = countChoseWhiteBalls;
            this.countChoseRedBalls = countChoseRedBalls;
        }

        /// <summary>
        /// General classical probability
        /// </summary>
        /// <param name="countWB">count needed white balls</param>
        /// <param name="countRB">count needed red balls</param>
        /// <returns>count of combinations that can be</returns>
        public long ClassicalProbability_General(int countWB, int countRB)
        {
            // all actives
            long C_all_comb = CalcComb(countWB, maxOfWhite);

            return default;
        }

        /// <summary>
        /// Calculate combinations
        /// </summary>
        /// <param name="m">get elements</param>
        /// <param name="n">all elements</param>
        /// <returns>count of combitation</returns>
        private long CalcComb(int m, int n)
        {
            // validate input data
            if (n < m)
                _ = new Exception("Not corect input data, needed n >= m!");

            // fast answer
            if (n == m)
                return 1;

            // other variants
            #region slow realization, because we have big number
            /*
                var result = factorial.FactorialFast(n) / (factorial.FactorialFast(m) * 
                    factorial.FactorialFast(n - m));
                */
            #endregion

            // more faster variant

            // list for up part of divide
            List<int> up_list = Enumerable
                .Range(1, m)
                .Select(i => n - m + i)
                .ToList();

            // product for up part, hope that values will be small
            double product = 1;

            foreach (var i in up_list)
                product *= i;

            double down_part = (double)factorial.FactorialFast(m);

            long result = (long)(product / down_part);

            return result;
        }

    }
}
