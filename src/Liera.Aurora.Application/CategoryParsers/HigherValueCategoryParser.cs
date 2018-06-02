namespace Liera.Aurora.Application.CategoryParsers
{
    /// <summary>
    /// Parser for categories of higher value result
    /// </summary>
    public class HigherValueCategoryParser
    {
        #region Private Static Methods

        /// <summary>
        /// Sums the given dice result as points accordingly to its ocurrency
        /// </summary>
        /// <param name="diceResultList"></param>
        /// <param name="diceValue"></param>
        /// <returns></returns>
        private static int SumDiceValue(int[] diceResultList, int diceValue)
        {
            int result = 0;

            foreach (int diceResult in diceResultList)
            {
                if (diceResult == diceValue)
                {
                    result += diceValue;
                }
            }

            return result;
        }

        #endregion

        #region Public Static Methods

        /// <summary>
        /// Sums the 1 dice result as points accordingly to its ocurrency
        /// </summary>
        /// <param name="diceResultList"></param>
        /// <returns></returns>
        [Domain.Attributes.CategoryParserMethod(Domain.Enumerators.Category.Ones)]
        public static int OnesCategoryValue(int[] diceResultList)
        {
            return SumDiceValue(diceResultList, 1);
        }

        /// <summary>
        /// Sums the 2 dice result as points accordingly to its ocurrency
        /// </summary>
        /// <param name="diceResultList"></param>
        /// <returns></returns>
        [Domain.Attributes.CategoryParserMethod(Domain.Enumerators.Category.Twos)]
        public static int TwosCategoryValue(int[] diceResultList)
        {
            return SumDiceValue(diceResultList, 2);
        }

        /// <summary>
        /// Sums the 3 dice result as points accordingly to its ocurrency
        /// </summary>
        /// <param name="diceResultList"></param>
        /// <returns></returns>
        [Domain.Attributes.CategoryParserMethod(Domain.Enumerators.Category.Threes)]
        public static int ThreesCategoryValue(int[] diceResultList)
        {
            return SumDiceValue(diceResultList, 3);
        }

        /// <summary>
        /// Sums the 4 dice result as points accordingly to its ocurrency
        /// </summary>
        /// <param name="diceResultList"></param>
        /// <returns></returns>
        [Domain.Attributes.CategoryParserMethod(Domain.Enumerators.Category.Fours)]
        public static int FoursCategoryValue(int[] diceResultList)
        {
            return SumDiceValue(diceResultList, 4);
        }

        /// <summary>
        /// Sums the 5 dice result as points accordingly to its ocurrency
        /// </summary>
        /// <param name="diceResultList"></param>
        /// <returns></returns>
        [Domain.Attributes.CategoryParserMethod(Domain.Enumerators.Category.Fives)]
        public static int FivesCategoryValue(int[] diceResultList)
        {
            return SumDiceValue(diceResultList, 5);
        }

        /// <summary>
        /// Sums the 6 dice result as points accordingly to its ocurrency
        /// </summary>
        /// <param name="diceResultList"></param>
        /// <returns></returns>
        [Domain.Attributes.CategoryParserMethod(Domain.Enumerators.Category.Sixes)]
        public static int SixesCategoryValue(int[] diceResultList)
        {
            return SumDiceValue(diceResultList, 6);
        }

        #endregion
    }
}
