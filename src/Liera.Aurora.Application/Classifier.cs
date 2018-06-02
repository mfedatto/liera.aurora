using Liera.Aurora.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Liera.Aurora.Application
{
    public class Classifier
    {
        #region Private Static Properties

        private static MethodInfo[] CategoryParsingMethods { get; set; } = null;

        #endregion

        #region Public Static Methods

        /// <summary>
        /// Finds the high score categories parsed
        /// </summary>
        /// <param name="diceResultList"></param>
        /// <returns></returns>
        public static Domain.Enumerators.Category[] FindHighScoredCategories(
            Domain.Enumerators.DiceResult[] diceResultList)
        {
            return FindHighScoredCategories(diceResultList
                .Select(d => (int)d)
                .ToArray())
                .Distinct()
                .ToArray();
        }

        #endregion

        #region Private Static Methods

        /// <summary>
        /// Finds the high score categories parsed
        /// </summary>
        /// <param name="diceResultList"></param>
        /// <returns></returns>
        private static Domain.Enumerators.Category[] FindHighScoredCategories(int[] diceResultList)
        {
            // Default result
            Domain.Enumerators.Category[] result = { Domain.Enumerators.Category.None };
            // Category parsing methods list
            MethodInfo[] parsingCategoryMethodsList = GetCategoryParsingMethods();
            // Parsed categories list with its score
            List<KeyValuePair<Domain.Enumerators.Category, int>> parsedCategoriesScore =
                GetParsedCategoriesScore(diceResultList, parsingCategoryMethodsList);
            // Max score parsed
            int maxScore = parsedCategoriesScore.Max(s => s.Value);
            // High scored categories list with its score
            IEnumerable<KeyValuePair<Domain.Enumerators.Category, int>> highScoreCategoriesScore =
                parsedCategoriesScore.Where(p => p.Value == maxScore);
            // High scored categories
            IEnumerable<Domain.Enumerators.Category> highScoreCategories = highScoreCategoriesScore
                .Select(p => p.Key);

            result = highScoreCategories.ToArray();

            return result;
        }

        /// <summary>
        /// Gets a dictionary with parsed categories score
        /// </summary>
        /// <param name="diceResultList"></param>
        /// <param name="methodInfosList"></param>
        /// <returns></returns>
        private static List<KeyValuePair<Domain.Enumerators.Category, int>> GetParsedCategoriesScore(
            int[] diceResultList, MethodInfo[] methodInfosList)
        {
            List<KeyValuePair<Domain.Enumerators.Category, int>> parsedCategoriesScore = 
                new List<KeyValuePair<Domain.Enumerators.Category, int>>();

            foreach (MethodInfo methodInfo in methodInfosList)
            {
                CategoryParserMethodAttribute categoryParserAttribute =
                    (CategoryParserMethodAttribute)methodInfo
                    .GetCustomAttributes(typeof(CategoryParserMethodAttribute), true)[0];
                Domain.Enumerators.Category targetCategory = categoryParserAttribute.TargetCategory;
                int categoryScore = -1;

                categoryScore = (int)methodInfo.Invoke(null, new object[] { diceResultList });
                
                parsedCategoriesScore
                    .Add(new KeyValuePair<Domain.Enumerators.Category, int>(targetCategory, categoryScore));
            }

            return parsedCategoriesScore;
        }

        /// <summary>
        /// Gets an array of Aurora category parsing methods
        /// </summary>
        /// <returns></returns>
        private static MethodInfo[] GetCategoryParsingMethods()
        {
            if (CategoryParsingMethods == null)
            {
                CategoryParsingMethods = AppDomain.CurrentDomain
                .GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .SelectMany(t => t.GetMethods())
                .Where(m => m.GetCustomAttributes(typeof(CategoryParserMethodAttribute), true)
                .Length > 0)
                .ToArray();
            }

            return CategoryParsingMethods;
        }
    }

    #endregion
}
