using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Liera.Aurora.ApplicationTest
{
    [TestClass]
    public class ClassifierTest
    {
        #region Higher Value Tests

        [TestMethod]
        public void HigherValueTest_Ones_1()
        {
            Domain.Enumerators.DiceResult[] input =
                new Domain.Enumerators.DiceResult[] {
                    Domain.Enumerators.DiceResult.One
                };
            Domain.Enumerators.Category[] expectedOutput = {
                Domain.Enumerators.Category.Ones
            };
            Domain.Enumerators.Category[] obtaionedOutput =
                Application.Classifier.FindHighScoredCategories(input);

            CollectionAssert.AreEquivalent(expectedOutput, obtaionedOutput);
        }

        [TestMethod]
        public void HigherValueTest_Twos_1()
        {
            Domain.Enumerators.DiceResult[] input =
                new Domain.Enumerators.DiceResult[] {
                    Domain.Enumerators.DiceResult.One,
                    Domain.Enumerators.DiceResult.Two
                };
            Domain.Enumerators.Category[] expectedOutput = {
                Domain.Enumerators.Category.Twos
            };
            Domain.Enumerators.Category[] obtaionedOutput =
                Application.Classifier.FindHighScoredCategories(input);

            CollectionAssert.AreEquivalent(expectedOutput, obtaionedOutput);
        }

        [TestMethod]
        public void HigherValueTest_Threes_1()
        {
            Domain.Enumerators.DiceResult[] input =
                new Domain.Enumerators.DiceResult[] {
                    Domain.Enumerators.DiceResult.One,
                    Domain.Enumerators.DiceResult.One,
                    Domain.Enumerators.DiceResult.Two,
                    Domain.Enumerators.DiceResult.Three
                };
            Domain.Enumerators.Category[] expectedOutput = {
                Domain.Enumerators.Category.Threes
            };
            Domain.Enumerators.Category[] obtaionedOutput = 
                Application.Classifier.FindHighScoredCategories(input);

            CollectionAssert.AreEquivalent(expectedOutput, obtaionedOutput);
        }

        [TestMethod]
        public void HigherValueTest_Threes_2()
        {
            Domain.Enumerators.DiceResult[] input =
                new Domain.Enumerators.DiceResult[] {
                    Domain.Enumerators.DiceResult.One,
                    Domain.Enumerators.DiceResult.One,
                    Domain.Enumerators.DiceResult.Two,
                    Domain.Enumerators.DiceResult.Three
                };
            Domain.Enumerators.Category[] expectedOutput = {
                Domain.Enumerators.Category.Threes
            };
            Domain.Enumerators.Category[] obtaionedOutput =
                Application.Classifier.FindHighScoredCategories(input);

            CollectionAssert.AreEquivalent(expectedOutput, obtaionedOutput);
        }

        [TestMethod]
        public void HigherValueTest_Fours_1()
        {
            Domain.Enumerators.DiceResult[] input =
                new Domain.Enumerators.DiceResult[] {
                    Domain.Enumerators.DiceResult.One,
                    Domain.Enumerators.DiceResult.One,
                    Domain.Enumerators.DiceResult.Two,
                    Domain.Enumerators.DiceResult.Four,
                    Domain.Enumerators.DiceResult.One
                };
            Domain.Enumerators.Category[] expectedOutput = {
                Domain.Enumerators.Category.Fours
            };
            Domain.Enumerators.Category[] obtaionedOutput =
                Application.Classifier.FindHighScoredCategories(input);

            CollectionAssert.AreEquivalent(expectedOutput, obtaionedOutput);
        }

        [TestMethod]
        public void HigherValueTest_Fours_2()
        {
            Domain.Enumerators.DiceResult[] input =
                new Domain.Enumerators.DiceResult[] {
                    Domain.Enumerators.DiceResult.Two,
                    Domain.Enumerators.DiceResult.Two,
                    Domain.Enumerators.DiceResult.Four,
                    Domain.Enumerators.DiceResult.One,
                    Domain.Enumerators.DiceResult.Three
                };
            Domain.Enumerators.Category[] expectedOutput = {
                Domain.Enumerators.Category.Twos,
                Domain.Enumerators.Category.Pair,
                Domain.Enumerators.Category.Fours
            };
            Domain.Enumerators.Category[] obtaionedOutput =
                Application.Classifier.FindHighScoredCategories(input);

            CollectionAssert.AreEquivalent(expectedOutput, obtaionedOutput);
        }

        [TestMethod]
        public void HigherValueTest_Fives_1()
        {
            Domain.Enumerators.DiceResult[] input =
                new Domain.Enumerators.DiceResult[] {
                    Domain.Enumerators.DiceResult.One,
                    Domain.Enumerators.DiceResult.Five,
                    Domain.Enumerators.DiceResult.Two,
                    Domain.Enumerators.DiceResult.Two,
                    Domain.Enumerators.DiceResult.Three
                };
            Domain.Enumerators.Category[] expectedOutput = {
                Domain.Enumerators.Category.Fives
            };
            Domain.Enumerators.Category[] obtaionedOutput =
                Application.Classifier.FindHighScoredCategories(input);

            CollectionAssert.AreEquivalent(expectedOutput, obtaionedOutput);
        }

        [TestMethod]
        public void HigherValueTest_Fives_2()
        {
            Domain.Enumerators.DiceResult[] input =
                new Domain.Enumerators.DiceResult[] {
                    Domain.Enumerators.DiceResult.One,
                    Domain.Enumerators.DiceResult.Five,
                    Domain.Enumerators.DiceResult.One,
                    Domain.Enumerators.DiceResult.One,
                    Domain.Enumerators.DiceResult.Three
                };
            Domain.Enumerators.Category[] expectedOutput = {
                Domain.Enumerators.Category.Fives
            };
            Domain.Enumerators.Category[] obtaionedOutput =
                Application.Classifier.FindHighScoredCategories(input);

            CollectionAssert.AreEquivalent(expectedOutput, obtaionedOutput);
        }

        #endregion

        #region Combinated Values Tests

        [TestMethod]
        public void CombinatedValuesTest_Pair_1()
        {
            Domain.Enumerators.DiceResult[] input =
                new Domain.Enumerators.DiceResult[] {
                    Domain.Enumerators.DiceResult.One,
                    Domain.Enumerators.DiceResult.Five,
                    Domain.Enumerators.DiceResult.Four,
                    Domain.Enumerators.DiceResult.Three,
                    Domain.Enumerators.DiceResult.Three
                };
            Domain.Enumerators.Category[] expectedOutput = {
                Domain.Enumerators.Category.Threes,
                Domain.Enumerators.Category.Pair
            };
            Domain.Enumerators.Category[] obtaionedOutput =
                Application.Classifier.FindHighScoredCategories(input);

            CollectionAssert.AreEquivalent(expectedOutput, obtaionedOutput);
        }

        [TestMethod]
        public void CombinatedValuesTest_Pair_2()
        {
            Domain.Enumerators.DiceResult[] input =
                new Domain.Enumerators.DiceResult[] {
                    Domain.Enumerators.DiceResult.Six,
                    Domain.Enumerators.DiceResult.Four,
                    Domain.Enumerators.DiceResult.Two,
                    Domain.Enumerators.DiceResult.Four,
                    Domain.Enumerators.DiceResult.Five
                };
            Domain.Enumerators.Category[] expectedOutput = {
                Domain.Enumerators.Category.Fours,
                Domain.Enumerators.Category.Pair
            };
            Domain.Enumerators.Category[] obtaionedOutput =
                Application.Classifier.FindHighScoredCategories(input);

            CollectionAssert.AreEquivalent(expectedOutput, obtaionedOutput);
        }

        [TestMethod]
        public void CombinatedValuesTest_Pair_3()
        {
            Domain.Enumerators.DiceResult[] input =
                new Domain.Enumerators.DiceResult[] {
                    Domain.Enumerators.DiceResult.One,
                    Domain.Enumerators.DiceResult.Six,
                    Domain.Enumerators.DiceResult.Two,
                    Domain.Enumerators.DiceResult.Three,
                    Domain.Enumerators.DiceResult.Three
                };
            Domain.Enumerators.Category[] expectedOutput = {
                Domain.Enumerators.Category.Threes,
                Domain.Enumerators.Category.Sixes,
                Domain.Enumerators.Category.Pair
            };
            Domain.Enumerators.Category[] obtaionedOutput =
                Application.Classifier.FindHighScoredCategories(input);

            CollectionAssert.AreEquivalent(expectedOutput, obtaionedOutput);
        }

        [TestMethod]
        public void CombinatedValuesTest_TwoPairs_1()
        {
            Domain.Enumerators.DiceResult[] input =
                new Domain.Enumerators.DiceResult[] {
                    Domain.Enumerators.DiceResult.One,
                    Domain.Enumerators.DiceResult.Five,
                    Domain.Enumerators.DiceResult.Five,
                    Domain.Enumerators.DiceResult.Three,
                    Domain.Enumerators.DiceResult.Three
                };
            Domain.Enumerators.Category[] expectedOutput = {
                Domain.Enumerators.Category.TwoPairs
            };
            Domain.Enumerators.Category[] obtaionedOutput =
                Application.Classifier.FindHighScoredCategories(input);

            CollectionAssert.AreEquivalent(expectedOutput, obtaionedOutput);
        }

        [TestMethod]
        public void CombinatedValuesTest_TwoPairs_2()
        {
            Domain.Enumerators.DiceResult[] input =
                new Domain.Enumerators.DiceResult[] {
                    Domain.Enumerators.DiceResult.One,
                    Domain.Enumerators.DiceResult.Six,
                    Domain.Enumerators.DiceResult.One,
                    Domain.Enumerators.DiceResult.Two,
                    Domain.Enumerators.DiceResult.Two
                };
            Domain.Enumerators.Category[] expectedOutput = {
                Domain.Enumerators.Category.Sixes,
                Domain.Enumerators.Category.TwoPairs
            };
            Domain.Enumerators.Category[] obtaionedOutput =
                Application.Classifier.FindHighScoredCategories(input);

            CollectionAssert.AreEquivalent(expectedOutput, obtaionedOutput);
        }

        [TestMethod]
        public void CombinatedValuesTest_ThreeOfAKind_1()
        {
            Domain.Enumerators.DiceResult[] input =
                new Domain.Enumerators.DiceResult[] {
                    Domain.Enumerators.DiceResult.One,
                    Domain.Enumerators.DiceResult.Six,
                    Domain.Enumerators.DiceResult.Two,
                    Domain.Enumerators.DiceResult.Two,
                    Domain.Enumerators.DiceResult.Two
                };
            Domain.Enumerators.Category[] expectedOutput = {
                Domain.Enumerators.Category.Sixes,
                Domain.Enumerators.Category.Twos,
                Domain.Enumerators.Category.ThreeOfAKind
            };
            Domain.Enumerators.Category[] obtaionedOutput =
                Application.Classifier.FindHighScoredCategories(input);

            CollectionAssert.AreEquivalent(expectedOutput, obtaionedOutput);
        }

        [TestMethod]
        public void CombinatedValuesTest_ThreeOfAKind_2()
        {
            Domain.Enumerators.DiceResult[] input =
                new Domain.Enumerators.DiceResult[] {
                    Domain.Enumerators.DiceResult.Six,
                    Domain.Enumerators.DiceResult.Six,
                    Domain.Enumerators.DiceResult.Six,
                    Domain.Enumerators.DiceResult.One,
                    Domain.Enumerators.DiceResult.Two
                };
            Domain.Enumerators.Category[] expectedOutput = {
                Domain.Enumerators.Category.Sixes,
                Domain.Enumerators.Category.ThreeOfAKind
            };
            Domain.Enumerators.Category[] obtaionedOutput =
                Application.Classifier.FindHighScoredCategories(input);

            CollectionAssert.AreEquivalent(expectedOutput, obtaionedOutput);
        }

        [TestMethod]
        public void CombinatedValuesTest_FourOfAKind_1()
        {
            Domain.Enumerators.DiceResult[] input =
                new Domain.Enumerators.DiceResult[] {
                    Domain.Enumerators.DiceResult.Two,
                    Domain.Enumerators.DiceResult.Six,
                    Domain.Enumerators.DiceResult.Two,
                    Domain.Enumerators.DiceResult.Two,
                    Domain.Enumerators.DiceResult.Two
                };
            Domain.Enumerators.Category[] expectedOutput = {
                Domain.Enumerators.Category.Twos,
                Domain.Enumerators.Category.FourOfAKind
            };
            Domain.Enumerators.Category[] obtaionedOutput =
                Application.Classifier.FindHighScoredCategories(input);

            CollectionAssert.AreEquivalent(expectedOutput, obtaionedOutput);
        }

        [TestMethod]
        public void CombinatedValuesTest_FourOfAKind_2()
        {
            Domain.Enumerators.DiceResult[] input =
                new Domain.Enumerators.DiceResult[] {
                    Domain.Enumerators.DiceResult.One,
                    Domain.Enumerators.DiceResult.Four,
                    Domain.Enumerators.DiceResult.One,
                    Domain.Enumerators.DiceResult.One,
                    Domain.Enumerators.DiceResult.One
                };
            Domain.Enumerators.Category[] expectedOutput = {
                Domain.Enumerators.Category.Ones,
                Domain.Enumerators.Category.Fours,
                Domain.Enumerators.Category.FourOfAKind
            };
            Domain.Enumerators.Category[] obtaionedOutput =
                Application.Classifier.FindHighScoredCategories(input);

            CollectionAssert.AreEquivalent(expectedOutput, obtaionedOutput);
        }

        [TestMethod]
        public void CombinatedValuesTest_MinorStraight_1()
        {
            Domain.Enumerators.DiceResult[] input =
                new Domain.Enumerators.DiceResult[] {
                    Domain.Enumerators.DiceResult.One,
                    Domain.Enumerators.DiceResult.Four,
                    Domain.Enumerators.DiceResult.Three,
                    Domain.Enumerators.DiceResult.One,
                    Domain.Enumerators.DiceResult.Two
                };
            Domain.Enumerators.Category[] expectedOutput = {
                Domain.Enumerators.Category.MinorStraight
            };
            Domain.Enumerators.Category[] obtaionedOutput =
                Application.Classifier.FindHighScoredCategories(input);

            CollectionAssert.AreEquivalent(expectedOutput, obtaionedOutput);
        }

        [TestMethod]
        public void CombinatedValuesTest_MinorStraight_2()
        {
            Domain.Enumerators.DiceResult[] input =
                new Domain.Enumerators.DiceResult[] {
                    Domain.Enumerators.DiceResult.Five,
                    Domain.Enumerators.DiceResult.Four,
                    Domain.Enumerators.DiceResult.Three,
                    Domain.Enumerators.DiceResult.Two,
                    Domain.Enumerators.DiceResult.Two
                };
            Domain.Enumerators.Category[] expectedOutput =
                { Domain.Enumerators.Category.MinorStraight };
            Domain.Enumerators.Category[] obtaionedOutput =
                Application.Classifier.FindHighScoredCategories(input);

            CollectionAssert.AreEquivalent(expectedOutput, obtaionedOutput);
        }

        [TestMethod]
        public void CombinatedValuesTest_MajorStraight_1()
        {
            Domain.Enumerators.DiceResult[] input =
                new Domain.Enumerators.DiceResult[] {
                    Domain.Enumerators.DiceResult.Five,
                    Domain.Enumerators.DiceResult.One,
                    Domain.Enumerators.DiceResult.Three,
                    Domain.Enumerators.DiceResult.Two,
                    Domain.Enumerators.DiceResult.Four
                };
            Domain.Enumerators.Category[] expectedOutput =
                { Domain.Enumerators.Category.MajorStraight };
            Domain.Enumerators.Category[] obtaionedOutput = 
                Application.Classifier.FindHighScoredCategories(input);

            CollectionAssert.AreEquivalent(expectedOutput, obtaionedOutput);
        }

        [TestMethod]
        public void CombinatedValuesTest_FullHouse_1()
        {
            Domain.Enumerators.DiceResult[] input =
                new Domain.Enumerators.DiceResult[] {
                    Domain.Enumerators.DiceResult.Five,
                    Domain.Enumerators.DiceResult.Three,
                    Domain.Enumerators.DiceResult.Three,
                    Domain.Enumerators.DiceResult.Three,
                    Domain.Enumerators.DiceResult.Five
                };
            Domain.Enumerators.Category[] expectedOutput = {
                Domain.Enumerators.Category.FullHouse
            };
            Domain.Enumerators.Category[] obtaionedOutput =
                Application.Classifier.FindHighScoredCategories(input);

            CollectionAssert.AreEquivalent(expectedOutput, obtaionedOutput);
        }

        [TestMethod]
        public void CombinatedValuesTest_FullHouse_2()
        {
            Domain.Enumerators.DiceResult[] input =
                new Domain.Enumerators.DiceResult[] {
                    Domain.Enumerators.DiceResult.Six,
                    Domain.Enumerators.DiceResult.One,
                    Domain.Enumerators.DiceResult.Six,
                    Domain.Enumerators.DiceResult.One,
                    Domain.Enumerators.DiceResult.One
                };
            Domain.Enumerators.Category[] expectedOutput = {
                Domain.Enumerators.Category.FullHouse
            };
            Domain.Enumerators.Category[] obtaionedOutput =
                Application.Classifier.FindHighScoredCategories(input);

            CollectionAssert.AreEquivalent(expectedOutput, obtaionedOutput);
        }

        [TestMethod]
        public void CombinatedValuesTest_Aurora_1()
        {
            Domain.Enumerators.DiceResult[] input =
                new Domain.Enumerators.DiceResult[] {
                    Domain.Enumerators.DiceResult.One,
                    Domain.Enumerators.DiceResult.One,
                    Domain.Enumerators.DiceResult.One,
                    Domain.Enumerators.DiceResult.One,
                    Domain.Enumerators.DiceResult.One
                };
            Domain.Enumerators.Category[] expectedOutput = {
                Domain.Enumerators.Category.Aurora
            };
            Domain.Enumerators.Category[] obtaionedOutput = 
                Application.Classifier.FindHighScoredCategories(input);

            CollectionAssert.AreEquivalent(expectedOutput, obtaionedOutput);
        }

        [TestMethod]
        public void CombinatedValuesTest_Aurora_2()
        {
            Domain.Enumerators.DiceResult[] input =
                new Domain.Enumerators.DiceResult[] {
                    Domain.Enumerators.DiceResult.Two,
                    Domain.Enumerators.DiceResult.Two,
                    Domain.Enumerators.DiceResult.Two,
                    Domain.Enumerators.DiceResult.Two,
                    Domain.Enumerators.DiceResult.Two
                };
            Domain.Enumerators.Category[] expectedOutput = {
                Domain.Enumerators.Category.Aurora
            };
            Domain.Enumerators.Category[] obtaionedOutput =
                Application.Classifier.FindHighScoredCategories(input);

            CollectionAssert.AreEquivalent(expectedOutput, obtaionedOutput);
        }

        [TestMethod]
        public void CombinatedValuesTest_Aurora_3()
        {
            Domain.Enumerators.DiceResult[] input =
                new Domain.Enumerators.DiceResult[] {
                    Domain.Enumerators.DiceResult.Six,
                    Domain.Enumerators.DiceResult.Six,
                    Domain.Enumerators.DiceResult.Six,
                    Domain.Enumerators.DiceResult.Six,
                    Domain.Enumerators.DiceResult.Six
                };
            Domain.Enumerators.Category[] expectedOutput = {
                Domain.Enumerators.Category.Aurora
            };
            Domain.Enumerators.Category[] obtaionedOutput = 
                Application.Classifier.FindHighScoredCategories(input);

            CollectionAssert.AreEquivalent(expectedOutput, obtaionedOutput);
        }

        #endregion
    }
}
