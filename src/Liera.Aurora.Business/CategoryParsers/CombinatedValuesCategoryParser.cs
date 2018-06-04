using System;
using System.Collections.Generic;
using System.Linq;

namespace Liera.Aurora.Business.CategoryParsers
{
    /// <summary>
    /// Parser for categories of combined result values
    /// </summary>
    public class CombinatedValuesCategoryParser
    {
        #region Private Static Methods

        /// <summary>
        /// Gets the dice results ocurrency
        /// </summary>
        /// <param name="diceResultList"></param>
        /// <returns></returns>
        private static Dictionary<int, int> GetResultValueOccurencies(int[] diceResultList)
        {
            Dictionary<int, int> diceResultOcurrencies = new Dictionary<int, int>();

            foreach (int diceResult in diceResultList)
            {
                if (!diceResultOcurrencies.ContainsKey(diceResult))
                {
                    diceResultOcurrencies.Add(diceResult, 0);
                }

                diceResultOcurrencies[diceResult]++;
            }

            return diceResultOcurrencies;
        }

        /// <summary>
        /// Sums repeated dice result as points accordingly to given ocurrency
        /// </summary>
        /// <param name="diceResultList"></param>
        /// <param name="occurs"></param>
        /// <param name="multiple"></param>
        /// <returns></returns>
        private static int[] GetRepeatedValueCategoryValue(int[] diceResultList, int occurs,
            bool multiple = false)
        {
            Dictionary<int, int> diceResultOcurrencies = GetResultValueOccurencies(diceResultList);
            IEnumerable<KeyValuePair<int, int>> diceResultsMatchingOcurrencies;
            List<int> result = new List<int>() { 0 };
            
            diceResultsMatchingOcurrencies = diceResultOcurrencies.Where(i => i.Value == occurs);

            if ((diceResultsMatchingOcurrencies.Count() > 0 && !multiple)
                || (diceResultsMatchingOcurrencies.Count() > 1 && multiple))
            {
                result = new List<int>();

                foreach (KeyValuePair<int, int> pair
                    in diceResultsMatchingOcurrencies)
                {
                    result.Add(pair.Key * pair.Value);

                    if (!multiple) break;
                }
            }

            return result.ToArray();
        }

        /// <summary>
        /// Gets the max size of a sequence in dice result values
        /// </summary>
        /// <param name="diceResultList"></param>
        /// <returns></returns>
        private static int GetSequenceMaxLength(int[] diceResultList)
        {
            int[] orderedDiceResultValues = new int[diceResultList.Length];
            int sequencyCount = 0;
            int maxSequence = 0;

            Array.Copy(diceResultList, orderedDiceResultValues, diceResultList.Length);
            Array.Sort(orderedDiceResultValues);

            for (int i = 1; i < orderedDiceResultValues.Length; i++)
            {
                int diceResult = orderedDiceResultValues[i];
                int previousDiceResult = orderedDiceResultValues[i - 1];
                
                if (diceResult - previousDiceResult == 1)
                {
                    sequencyCount++;
                    maxSequence = Math.Max(maxSequence, sequencyCount);
                }
                else
                {
                    sequencyCount = 0;
                }
            }

            if (maxSequence > 0) maxSequence++;

            return maxSequence;
        }

        #endregion

        #region Public Static Methods

        /// <summary>
        /// Sums the value of a pair in dice result as points
        /// </summary>
        /// <param name="diceResultList"></param>
        /// <returns></returns>
        [Domain.Attributes.CategoryParserMethod(Domain.Enumerators.Category.Pair)]
        public static int GetPairCategoryValue(int[] diceResultList)
        {
            return GetRepeatedValueCategoryValue(diceResultList, 2)[0];
        }

        /// <summary>
        /// Sums the value of pairs in dice result as points
        /// </summary>
        /// <param name="diceResultList"></param>
        /// <returns></returns>
        [Domain.Attributes.CategoryParserMethod(Domain.Enumerators.Category.TwoPairs)]
        public static int GetTwoPairsCategoryValue(int[] diceResultList)
        {
            return GetRepeatedValueCategoryValue(diceResultList, 2, true).Sum();
        }

        /// <summary>
        /// Sums the value of three of a kind in dice result as points
        /// </summary>
        /// <param name="diceResultList"></param>
        /// <returns></returns>
        [Domain.Attributes.CategoryParserMethod(Domain.Enumerators.Category.ThreeOfAKind)]
        public static int GetThreeOfAKindCategoryValue(int[] diceResultList)
        {
            return GetRepeatedValueCategoryValue(diceResultList, 3)[0];
        }

        /// <summary>
        /// Sums the value of four of a kind in dice result as points
        /// </summary>
        /// <param name="diceResultList"></param>
        /// <returns></returns>
        [Domain.Attributes.CategoryParserMethod(Domain.Enumerators.Category.FourOfAKind)]
        public static int GetFourOfAKindCategoryValue(int[] diceResultList)
        {
            return GetRepeatedValueCategoryValue(diceResultList, 4)[0];
        }

        /// <summary>
        /// Sums the value of a minor straight in dice result as points
        /// </summary>
        /// <param name="diceResultList"></param>
        /// <returns></returns>
        [Domain.Attributes.CategoryParserMethod(Domain.Enumerators.Category.MinorStraight)]
        public static int GetMinorStraightValue(int[] diceResultList)
        {
            int sequenceLength = GetSequenceMaxLength(diceResultList);
            int result = 0;

            if (sequenceLength == 4)
            {
                result = 15;
            }

            return result;
        }

        /// <summary>
        /// Sums the value of a major straight in dice result as points
        /// </summary>
        /// <param name="diceResultList"></param>
        /// <returns></returns>
        [Domain.Attributes.CategoryParserMethod(Domain.Enumerators.Category.MajorStraight)]
        public static int GetMajorStraightValue(int[] diceResultList)
        {
            int sequenceLength = GetSequenceMaxLength(diceResultList);
            int result = 0;

            if (sequenceLength == 5)
            {
                result = 20;
            }

            return result;
        }

        /// <summary>
        /// Sums the value of a full house in dice result as points
        /// </summary>
        /// <param name="diceResultList"></param>
        /// <returns></returns>
        [Domain.Attributes.CategoryParserMethod(Domain.Enumerators.Category.FullHouse)]
        public static int GetFullHouseValue(int[] diceResultList)
        {
            Dictionary<int, int> diceResultOcurrencies = GetResultValueOccurencies(diceResultList);
            IEnumerable<KeyValuePair<int, int>> diceResultsPair;
            IEnumerable<KeyValuePair<int, int>> diceResultsThreeOfAKind;
            int result = 0;

            diceResultsPair = diceResultOcurrencies.Where(i => i.Value == 2);
            diceResultsThreeOfAKind = diceResultOcurrencies.Where(i => i.Value == 3);

            if (diceResultsPair.Count() == 1 && diceResultsThreeOfAKind.Count() == 1)
            {
                result = diceResultList.Sum();
            }

            return result;
        }

        /// <summary>
        /// Sums the value of an Aurora in dice result as points
        /// </summary>
        /// <param name="diceResultList"></param>
        /// <returns></returns>
        [Domain.Attributes.CategoryParserMethod(Domain.Enumerators.Category.Aurora)]
        public static int GetAuroraCategoryValue(int[] diceResultList)
        {
            int result = 0;
            int simpleRepeatedValuesPoints = GetRepeatedValueCategoryValue(diceResultList, 5)[0];

            if (simpleRepeatedValuesPoints > 0)
            {
                result = 50;
            }

            return result;
        }

        #endregion
    }
}
