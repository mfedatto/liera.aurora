using Liera.Aurora.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Liera.Aurora.Business.Classifier
{
    public class Classifier : Domain.Classifier.IClassifier
    {
        #region Private Static Properties

        private static MethodInfo[] CategoryParsingMethods { get; set; } = null;
        private static Domain.Enumerators.Category[] CategoriesList { get; set; } = null;
        private static Dictionary<int[], List<KeyValuePair<Domain.Enumerators.Category, int>>>
            ParsedCategoriesScoresDictionary
        { get; set; } = new Dictionary<int[], List<KeyValuePair<Domain.Enumerators.Category, int>>>();
        private static Dictionary<int[], KeyValuePair<Domain.Enumerators.Category, int>[]>
            ParsedHighScoredCategoriesDictionary
        { get; set; } = new Dictionary<int[], KeyValuePair<Domain.Enumerators.Category, int>[]>();
        private static Dictionary<int[], KeyValuePair<Domain.Enumerators.Category, int>[]>
            ParsedScoredCategoriesDictionary
        { get; set; } = new Dictionary<int[], KeyValuePair<Domain.Enumerators.Category, int>[]>();

        #endregion

        #region Public Methods

        /// <summary>
        /// Finds the public categories available.
        /// </summary>
        /// <returns></returns>
        public Domain.Enumerators.Category[] FindPublicCategories()
        {
            if (CategoriesList == null)
            {
                CategoriesList = GetPublicCategories();
            }

            return CategoriesList;
        }

        /// <summary>
        /// Finds the scored categories parsed with its score.
        /// </summary>
        /// <param name="diceResultList"></param>
        /// <returns></returns>
        public KeyValuePair<Domain.Enumerators.Category, int>[] FindScoredCategories(
            Domain.Enumerators.DiceResult[] diceResultList)
        {
            return FindScoredCategories(diceResultList
                .Select(d => (int)d)
                .ToArray())
                .Distinct()
                .ToArray();
        }

        /// <summary>
        /// Finds the high score categories parsed.
        /// </summary>
        /// <param name="diceResultList"></param>
        /// <returns></returns>
        public KeyValuePair<Domain.Enumerators.Category, int>[] FindHighScoredCategories(
            Domain.Enumerators.DiceResult[] diceResultList)
        {
            return FindHighScoredCategories(diceResultList
                .Select(i => Convert.ToInt32(i))
                .ToArray())
                .Distinct()
                .ToArray();
        }

        /// <summary>
        /// Finds the scored categories parsed with its score.
        /// </summary>
        /// <param name="diceResultList"></param>
        /// <returns></returns>
        public KeyValuePair<Domain.Enumerators.Category, int>[] FindScoredCategories(int[] diceResultList)
        {
            if (!ParsedScoredCategoriesDictionary.ContainsKey(diceResultList))
            {
                // Category parsing methods list
                MethodInfo[] parsingCategoryMethodsList = GetCategoryParsingMethods();
                // Parsed categories list with its score
                List<KeyValuePair<Domain.Enumerators.Category, int>> parsedCategoriesScore =
                    GetParsedCategoriesScore(diceResultList, parsingCategoryMethodsList);

                ParsedScoredCategoriesDictionary.Add(diceResultList, parsedCategoriesScore.ToArray());
            }

            return ParsedScoredCategoriesDictionary[diceResultList];
        }

        /// <summary>
        /// Finds the high score categories parsed.
        /// </summary>
        /// <param name="diceResultList"></param>
        /// <returns></returns>
        public KeyValuePair<Domain.Enumerators.Category, int>[] FindHighScoredCategories(int[] diceResultList)
        {
            if (!ParsedHighScoredCategoriesDictionary.ContainsKey(diceResultList))
            {
                // Category parsing methods list
                MethodInfo[] parsingCategoryMethodsList = GetCategoryParsingMethods();
                // Parsed categories list with its score
                KeyValuePair<Domain.Enumerators.Category, int>[] parsedCategoriesScore =
                    FindScoredCategories(diceResultList);
                // Max score parsed
                int maxScore = parsedCategoriesScore.Max(s => s.Value);
                // High scored categories list with its score
                IEnumerable<KeyValuePair<Domain.Enumerators.Category, int>> highScoreCategoriesScore =
                    parsedCategoriesScore.Where(p => p.Value == maxScore);

                ParsedHighScoredCategoriesDictionary.Add(diceResultList, highScoreCategoriesScore.ToArray());
            }

            return ParsedHighScoredCategoriesDictionary[diceResultList];
        }

        /// <summary>
        /// Finds the scored categories parsed with its score.
        /// </summary>
        /// <param name="dicesResults">Dices results separeted by coma.</param>
        /// <returns></returns>
        public KeyValuePair<Domain.Enumerators.Category, int>[] FindScoredCategories(string dicesResults)
        {
            string[] stringDiceResultsList = dicesResults.Split(',');
            int[] intDiceResultsList = stringDiceResultsList
                .Select(i => Convert.ToInt32(i))
                .ToArray();

            return FindScoredCategories(intDiceResultsList);
        }

        /// <summary>
        /// Finds the high score categories parsed.
        /// </summary>
        /// <param name="dicesResults">Dices results separeted by coma.</param>
        /// <returns></returns>
        public KeyValuePair<Domain.Enumerators.Category, int>[] FindHighScoredCategories(string dicesResults)
        {
            string[] stringDiceResultsList = dicesResults.Split(',');
            int[] intDiceResultsList = stringDiceResultsList
                .Select(i => Convert.ToInt32(i))
                .ToArray();

            return FindHighScoredCategories(intDiceResultsList);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Gets a dictionary with parsed categories score.
        /// </summary>
        /// <param name="diceResultList"></param>
        /// <param name="methodInfosList"></param>
        /// <returns></returns>
        private List<KeyValuePair<Domain.Enumerators.Category, int>> GetParsedCategoriesScore(
            int[] diceResultList, MethodInfo[] methodInfosList)
        {
            if (!ParsedCategoriesScoresDictionary.ContainsKey(diceResultList))
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

                ParsedCategoriesScoresDictionary.Add(diceResultList, parsedCategoriesScore);
            }

            return ParsedCategoriesScoresDictionary[diceResultList];
        }

        /// <summary>
        /// Gets an array of Aurora category parsing methods.
        /// </summary>
        /// <returns></returns>
        private MethodInfo[] GetCategoryParsingMethods()
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

        /// <summary>
        /// Finds the public categories available.
        /// </summary>
        /// <returns></returns>
        public Domain.Enumerators.Category[] GetPublicCategories()
        {
            Domain.Enumerators.Category[] publicCategories = Enum.GetValues(typeof(Domain.Enumerators.Category))
                .Cast<Domain.Enumerators.Category>()
                .Where(i => (int)i > 0)
                .ToArray();

            return publicCategories;
        }

        #endregion
    }
}
