using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Liera.Aurora.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/classifier")]
    [ApiController]
    public class ClassifierController : ControllerBase
    {
        #region Private Static Properties
        
        private static JsonResult CachedPublicCategoriesJsonResult { get; set; } = null;
        private static Dictionary<string, JsonResult> CachedDicesResultsScoredCategoriesJsonResult
        { get; set; } = new Dictionary<string, JsonResult>();
        private static Dictionary<string, JsonResult> CachedDicesResultsHighScoredCategoriesJsonResult
        { get; set; } = new Dictionary<string, JsonResult>();

        #endregion

        #region Private Properties

        private Domain.Classifier.IClassifier Classifier { get; set; }

        #endregion

        #region Public Constructors

        /// <summary>
        /// Provides a new instance of ClassifierController.
        /// </summary>
        public ClassifierController()
        {
            Business.Classifier.ClassifierFactory classifierFactory = new Business.Classifier.ClassifierFactory();
            Classifier = classifierFactory.CreateClassifier();
        }

        #endregion

        #region Public JsonResult Action Methods

        /// <summary>
        /// Retrieve the public categories available.
        /// </summary>
        /// <returns></returns>
        [Route("categories")]
        [HttpGet]
        public JsonResult GetCategories()
        {
            if (CachedPublicCategoriesJsonResult == null)
            {
                Domain.Enumerators.Category[] categories = Classifier.FindPublicCategories();
                CachedPublicCategoriesJsonResult = new JsonResult(categories
                    .Select(c => c.ToString()));
            }

            return CachedPublicCategoriesJsonResult;
        }

        /// <summary>
        /// Retrieve the scored categories and its score for the given dices results.
        /// </summary>
        /// <param name="dicesResults"></param>
        /// <returns></returns>
        [Route("dices-results/{dicesResults}/scored-categories")]
        [HttpGet]
        public JsonResult GetDicesResultsScoredCategories(string dicesResults)
        {
            if (!CachedDicesResultsScoredCategoriesJsonResult.ContainsKey(dicesResults))
            {
                KeyValuePair<Domain.Enumerators.Category, int>[] scoredCategories =
                    Classifier.FindScoredCategories(dicesResults);

                CachedDicesResultsScoredCategoriesJsonResult.Add(dicesResults, new JsonResult(new
                {
                    dicesResults,
                    scoredCategories = scoredCategories
                        .OrderBy(sc => (int)sc.Key)
                        .Select(sc => new { category = sc.Key.ToString(), scored = sc.Value })
                }));
            }

            return CachedDicesResultsScoredCategoriesJsonResult[dicesResults];
        }

        /// <summary>
        /// Retrieve the high scored categories and its score for the given dices results.
        /// </summary>
        /// <param name="dicesResults"></param>
        /// <returns></returns>
        [Route("dices-results/{dicesResults}/high-scored-categories")]
        [HttpGet]
        public JsonResult GetDicesResultsHighScoredCategories(string dicesResults)
        {
            if (!CachedDicesResultsHighScoredCategoriesJsonResult.ContainsKey(dicesResults))
            {
                KeyValuePair<Domain.Enumerators.Category, int>[] highScoredCategories =
                    Classifier.FindHighScoredCategories(dicesResults);

                CachedDicesResultsHighScoredCategoriesJsonResult.Add(dicesResults, new JsonResult(new
                {
                    dicesResults,
                    highScoredCategories = highScoredCategories
                        .Select(hsc => new { category = hsc.Key.ToString(), scored = hsc.Value })
                }));
            }

            return CachedDicesResultsHighScoredCategoriesJsonResult[dicesResults];
        }

        #endregion
    }
}