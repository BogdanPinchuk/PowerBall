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
        /// Numner of maximum value for white balls
        /// </summary>
        private readonly int maxOfWhite;
        /// <summary>
        /// Numner of maximum value for red balls
        /// </summary>
        private readonly int maxOfRed;
        /// <summary>
        /// Count of chose white numbers
        /// </summary>
        private readonly int countChoseWhiteBalls;
        /// <summary>
        /// Count of chose red numbers
        /// </summary>
        private readonly int countChoseRedBalls;

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
        /// Classical probability
        /// </summary>
        /// <param name="countWB">count needed white balls</param>
        /// <param name="countRB">count needed red balls</param>
        /// <returns>probability</returns>
        public double ClassicalProbability(int countWB, int countRB)
        {
            // all actives for white balls
            double c_all_comb_w = CalcComb(countChoseWhiteBalls, maxOfWhite);
            // all actives for red balls
            double c_all_comb_r = CalcComb(countChoseRedBalls, maxOfRed);

            // successfull choice for white balls
            double c_positive_w = CalcComb(countWB, countChoseWhiteBalls);
            // successfull choice for white balls
            double c_positive_r = CalcComb(countRB, countChoseRedBalls);

            // unsuccessfull choice for white balls
            double c_negative_w = CalcComb(countChoseWhiteBalls - countWB,
                maxOfWhite - countChoseWhiteBalls);
            // unsuccessfull choice for white balls
            double c_negative_r = CalcComb(countChoseRedBalls - countRB,
                maxOfRed - countChoseRedBalls);

            // probability of white balls
            double p_w = c_positive_w * c_negative_w / c_all_comb_w;
            // probability of red balls
            double p_r = c_positive_r * c_negative_r / c_all_comb_r;

            // general probability (this actives is independent)
            return p_w * p_r;

            // note: for better tollerancy we can use decimal type
        }

        /// <summary>
        /// Freaquency probability
        /// </summary>
        /// <param name="countWB">count needed white balls</param>
        /// <param name="countRB">count needed red balls</param>
        /// <returns>probability</returns>
        public double FreaquencyProbability(int countWB, int countRB)
        {
            return default;
        }

        /// <summary>
        /// Calculate combinations
        /// </summary>
        /// <param name="m">get elements</param>
        /// <param name="n">all elements</param>
        /// <returns>count of combitation</returns>
        private static double CalcComb(int m, int n)
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
            
            return product / down_part;
        }

    }
}
