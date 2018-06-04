using System.Collections.Generic;

namespace Liera.Aurora.Domain.Classifier
{
    public interface IClassifier
    {
        Enumerators.Category[] FindPublicCategories();
        KeyValuePair<Enumerators.Category, int>[] FindScoredCategories(Enumerators.DiceResult[] diceResultList);
        KeyValuePair<Enumerators.Category, int>[] FindHighScoredCategories(Enumerators.DiceResult[] diceResultList);
        KeyValuePair<Enumerators.Category, int>[] FindScoredCategories(int[] diceResultList);
        KeyValuePair<Enumerators.Category, int>[] FindHighScoredCategories(int[] diceResultList);
        KeyValuePair<Enumerators.Category, int>[] FindScoredCategories(string dicesResults);
        KeyValuePair<Enumerators.Category, int>[] FindHighScoredCategories(string dicesResults);
    }
}
