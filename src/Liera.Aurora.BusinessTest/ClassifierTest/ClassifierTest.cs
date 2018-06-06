using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Liera.Aurora.BusinessTest.ClassifierTest
{
    [TestClass]
    public class ClassifierTest
    {
        #region Private Variables

        Business.Classifier.ClassifierFactory _classifierFactory = null;
        Domain.Classifier.IClassifier _classifier = null;

        #endregion

        #region Private Properties

        public Business.Classifier.ClassifierFactory ClassifierFactory
        {
            get
            {
                if (_classifierFactory == null)
                {
                    _classifierFactory = new Business.Classifier.ClassifierFactory();
                }

                return _classifierFactory;
            }
            set
            {
                _classifierFactory = value;
            }
        }

        public Domain.Classifier.IClassifier Classifier
        {
            get
            {
                if (_classifier == null)
                {
                    _classifier = ClassifierFactory.CreateClassifier();
                }

                return _classifier;
            }
            set
            {
                _classifier = value;
            }
        }

        #endregion

        #region Higher Value Tests

        [TestMethod]
        public void HigherValueTest_Ones_1()
        {
            Domain.Enumerators.DiceResult[] input =
                new Domain.Enumerators.DiceResult[] {
                    Domain.Enumerators.DiceResult.One
                };
            KeyValuePair<Domain.Enumerators.Category, int>[] expectedOutput = {
                new KeyValuePair<Domain.Enumerators.Category, int>(Domain.Enumerators.Category.Ones, 1)
            };
            KeyValuePair<Domain.Enumerators.Category, int>[] obtaionedOutput =
                Classifier.FindHighScoredCategories(input);

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
            KeyValuePair<Domain.Enumerators.Category, int>[] expectedOutput = {
                new KeyValuePair<Domain.Enumerators.Category, int>(Domain.Enumerators.Category.Twos, 2)
            };
            KeyValuePair<Domain.Enumerators.Category, int>[] obtaionedOutput =
                Classifier.FindHighScoredCategories(input);

            CollectionAssert.AreEquivalent(expectedOutput, obtaionedOutput);
        }

        [TestMethod]
        public void HigherValueTest_Threes_1()
        {
            Domain.Enumerators.DiceResult[] input =
                new Domain.Enumerators.DiceResult[] {
                    Domain.Enumerators.DiceResult.One,
                    Domain.Enumerators.DiceResult.Two,
                    Domain.Enumerators.DiceResult.Three
                };
            KeyValuePair<Domain.Enumerators.Category, int>[] expectedOutput = {
                new KeyValuePair<Domain.Enumerators.Category, int>(Domain.Enumerators.Category.Threes, 3)
            };
            KeyValuePair<Domain.Enumerators.Category, int>[] obtaionedOutput =
                Classifier.FindHighScoredCategories(input);

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
            KeyValuePair<Domain.Enumerators.Category, int>[] expectedOutput = {
                new KeyValuePair<Domain.Enumerators.Category, int>(Domain.Enumerators.Category.Threes, 3)
            };
            KeyValuePair<Domain.Enumerators.Category, int>[] obtaionedOutput =
                Classifier.FindHighScoredCategories(input);

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
            KeyValuePair<Domain.Enumerators.Category, int>[] expectedOutput = {
                new KeyValuePair<Domain.Enumerators.Category, int>(Domain.Enumerators.Category.Fours, 4)
            };
            KeyValuePair<Domain.Enumerators.Category, int>[] obtaionedOutput =
                Classifier.FindHighScoredCategories(input);

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
            KeyValuePair<Domain.Enumerators.Category, int>[] expectedOutput = {
                new KeyValuePair<Domain.Enumerators.Category, int>(Domain.Enumerators.Category.Twos, 4),
                new KeyValuePair<Domain.Enumerators.Category, int>(Domain.Enumerators.Category.Pair, 4),
                new KeyValuePair<Domain.Enumerators.Category, int>(Domain.Enumerators.Category.Fours, 4)
            };
            KeyValuePair<Domain.Enumerators.Category, int>[] obtaionedOutput =
                Classifier.FindHighScoredCategories(input);

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
            KeyValuePair<Domain.Enumerators.Category, int>[] expectedOutput = {
                new KeyValuePair<Domain.Enumerators.Category, int>(Domain.Enumerators.Category.Fives, 5)
            };
            KeyValuePair<Domain.Enumerators.Category, int>[] obtaionedOutput =
                Classifier.FindHighScoredCategories(input);

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
            KeyValuePair<Domain.Enumerators.Category, int>[] expectedOutput = {
                new KeyValuePair<Domain.Enumerators.Category, int>(Domain.Enumerators.Category.Fives, 5)
            };
            KeyValuePair<Domain.Enumerators.Category, int>[] obtaionedOutput =
                Classifier.FindHighScoredCategories(input);

            CollectionAssert.AreEquivalent(expectedOutput, obtaionedOutput);
        }

        #endregion

        #region Combinated Values Tests

        [TestMethod]
        public void CombinedValuesTest_Pair_1()
        {
            Domain.Enumerators.DiceResult[] input =
                new Domain.Enumerators.DiceResult[] {
                    Domain.Enumerators.DiceResult.One,
                    Domain.Enumerators.DiceResult.Five,
                    Domain.Enumerators.DiceResult.Four,
                    Domain.Enumerators.DiceResult.Three,
                    Domain.Enumerators.DiceResult.Three
                };
            KeyValuePair<Domain.Enumerators.Category, int>[] expectedOutput = {
                new KeyValuePair<Domain.Enumerators.Category, int>(Domain.Enumerators.Category.Threes, 6),
                new KeyValuePair<Domain.Enumerators.Category, int>(Domain.Enumerators.Category.Pair, 6)
            };
            KeyValuePair<Domain.Enumerators.Category, int>[] obtaionedOutput =
                Classifier.FindHighScoredCategories(input);

            CollectionAssert.AreEquivalent(expectedOutput, obtaionedOutput);
        }

        [TestMethod]
        public void CombinedValuesTest_Pair_2()
        {
            Domain.Enumerators.DiceResult[] input =
                new Domain.Enumerators.DiceResult[] {
                    Domain.Enumerators.DiceResult.Six,
                    Domain.Enumerators.DiceResult.Four,
                    Domain.Enumerators.DiceResult.Two,
                    Domain.Enumerators.DiceResult.Four,
                    Domain.Enumerators.DiceResult.Five
                };
            KeyValuePair<Domain.Enumerators.Category, int>[] expectedOutput = {
                new KeyValuePair<Domain.Enumerators.Category, int>(Domain.Enumerators.Category.Fours, 8),
                new KeyValuePair<Domain.Enumerators.Category, int>(Domain.Enumerators.Category.Pair, 8)
            };
            KeyValuePair<Domain.Enumerators.Category, int>[] obtaionedOutput =
                Classifier.FindHighScoredCategories(input);

            CollectionAssert.AreEquivalent(expectedOutput, obtaionedOutput);
        }

        [TestMethod]
        public void CombinedValuesTest_Pair_3()
        {
            Domain.Enumerators.DiceResult[] input =
                new Domain.Enumerators.DiceResult[] {
                    Domain.Enumerators.DiceResult.One,
                    Domain.Enumerators.DiceResult.Six,
                    Domain.Enumerators.DiceResult.Two,
                    Domain.Enumerators.DiceResult.Three,
                    Domain.Enumerators.DiceResult.Three
                };
            KeyValuePair<Domain.Enumerators.Category, int>[] expectedOutput = {
                new KeyValuePair<Domain.Enumerators.Category, int>(Domain.Enumerators.Category.Threes, 6),
                new KeyValuePair<Domain.Enumerators.Category, int>(Domain.Enumerators.Category.Sixes, 6),
                new KeyValuePair<Domain.Enumerators.Category, int>(Domain.Enumerators.Category.Pair, 6)
            };
            KeyValuePair<Domain.Enumerators.Category, int>[] obtaionedOutput =
                Classifier.FindHighScoredCategories(input);

            CollectionAssert.AreEquivalent(expectedOutput, obtaionedOutput);
        }

        [TestMethod]
        public void CombinedValuesTest_TwoPairs_1()
        {
            Domain.Enumerators.DiceResult[] input =
                new Domain.Enumerators.DiceResult[] {
                    Domain.Enumerators.DiceResult.One,
                    Domain.Enumerators.DiceResult.Five,
                    Domain.Enumerators.DiceResult.Five,
                    Domain.Enumerators.DiceResult.Three,
                    Domain.Enumerators.DiceResult.Three
                };
            KeyValuePair<Domain.Enumerators.Category, int>[] expectedOutput = {
                new KeyValuePair<Domain.Enumerators.Category, int>(Domain.Enumerators.Category.TwoPairs, 16)
            };
            KeyValuePair<Domain.Enumerators.Category, int>[] obtaionedOutput =
                Classifier.FindHighScoredCategories(input);

            CollectionAssert.AreEquivalent(expectedOutput, obtaionedOutput);
        }

        [TestMethod]
        public void CombinedValuesTest_TwoPairs_2()
        {
            Domain.Enumerators.DiceResult[] input =
                new Domain.Enumerators.DiceResult[] {
                    Domain.Enumerators.DiceResult.One,
                    Domain.Enumerators.DiceResult.Six,
                    Domain.Enumerators.DiceResult.One,
                    Domain.Enumerators.DiceResult.Two,
                    Domain.Enumerators.DiceResult.Two
                };
            KeyValuePair<Domain.Enumerators.Category, int>[] expectedOutput = {
                new KeyValuePair<Domain.Enumerators.Category, int>(Domain.Enumerators.Category.Sixes, 6),
                new KeyValuePair<Domain.Enumerators.Category, int>(Domain.Enumerators.Category.TwoPairs, 6)
            };
            KeyValuePair<Domain.Enumerators.Category, int>[] obtaionedOutput =
                Classifier.FindHighScoredCategories(input);

            CollectionAssert.AreEquivalent(expectedOutput, obtaionedOutput);
        }

        [TestMethod]
        public void CombinedValuesTest_ThreeOfAKind_1()
        {
            Domain.Enumerators.DiceResult[] input =
                new Domain.Enumerators.DiceResult[] {
                    Domain.Enumerators.DiceResult.One,
                    Domain.Enumerators.DiceResult.Six,
                    Domain.Enumerators.DiceResult.Two,
                    Domain.Enumerators.DiceResult.Two,
                    Domain.Enumerators.DiceResult.Two
                };
            KeyValuePair<Domain.Enumerators.Category, int>[] expectedOutput = {
                new KeyValuePair<Domain.Enumerators.Category, int>(Domain.Enumerators.Category.Sixes, 6),
                new KeyValuePair<Domain.Enumerators.Category, int>(Domain.Enumerators.Category.Twos, 6),
                new KeyValuePair<Domain.Enumerators.Category, int>(Domain.Enumerators.Category.ThreeOfAKind, 6)
            };
            KeyValuePair<Domain.Enumerators.Category, int>[] obtaionedOutput =
                Classifier.FindHighScoredCategories(input);

            CollectionAssert.AreEquivalent(expectedOutput, obtaionedOutput);
        }

        [TestMethod]
        public void CombinedValuesTest_ThreeOfAKind_2()
        {
            Domain.Enumerators.DiceResult[] input =
                new Domain.Enumerators.DiceResult[] {
                    Domain.Enumerators.DiceResult.Six,
                    Domain.Enumerators.DiceResult.Six,
                    Domain.Enumerators.DiceResult.Six,
                    Domain.Enumerators.DiceResult.One,
                    Domain.Enumerators.DiceResult.Two
                };
            KeyValuePair<Domain.Enumerators.Category, int>[] expectedOutput = {
                new KeyValuePair<Domain.Enumerators.Category, int>(Domain.Enumerators.Category.Sixes, 18),
                new KeyValuePair<Domain.Enumerators.Category, int>(Domain.Enumerators.Category.ThreeOfAKind, 18)
            };
            KeyValuePair<Domain.Enumerators.Category, int>[] obtaionedOutput =
                Classifier.FindHighScoredCategories(input);

            CollectionAssert.AreEquivalent(expectedOutput, obtaionedOutput);
        }

        [TestMethod]
        public void CombinedValuesTest_FourOfAKind_1()
        {
            Domain.Enumerators.DiceResult[] input =
                new Domain.Enumerators.DiceResult[] {
                    Domain.Enumerators.DiceResult.Two,
                    Domain.Enumerators.DiceResult.Six,
                    Domain.Enumerators.DiceResult.Two,
                    Domain.Enumerators.DiceResult.Two,
                    Domain.Enumerators.DiceResult.Two
                };
            KeyValuePair<Domain.Enumerators.Category, int>[] expectedOutput = {
                new KeyValuePair<Domain.Enumerators.Category, int>(Domain.Enumerators.Category.Twos, 8),
                new KeyValuePair<Domain.Enumerators.Category, int>(Domain.Enumerators.Category.FourOfAKind, 8)
            };
            KeyValuePair<Domain.Enumerators.Category, int>[] obtaionedOutput =
                Classifier.FindHighScoredCategories(input);

            CollectionAssert.AreEquivalent(expectedOutput, obtaionedOutput);
        }

        [TestMethod]
        public void CombinedValuesTest_FourOfAKind_2()
        {
            Domain.Enumerators.DiceResult[] input =
                new Domain.Enumerators.DiceResult[] {
                    Domain.Enumerators.DiceResult.One,
                    Domain.Enumerators.DiceResult.Four,
                    Domain.Enumerators.DiceResult.One,
                    Domain.Enumerators.DiceResult.One,
                    Domain.Enumerators.DiceResult.One
                };
            KeyValuePair<Domain.Enumerators.Category, int>[] expectedOutput = {
                new KeyValuePair<Domain.Enumerators.Category, int>(Domain.Enumerators.Category.Ones, 4),
                new KeyValuePair<Domain.Enumerators.Category, int>(Domain.Enumerators.Category.Fours, 4),
                new KeyValuePair<Domain.Enumerators.Category, int>(Domain.Enumerators.Category.FourOfAKind, 4)
            };
            KeyValuePair<Domain.Enumerators.Category, int>[] obtaionedOutput =
                Classifier.FindHighScoredCategories(input);

            CollectionAssert.AreEquivalent(expectedOutput, obtaionedOutput);
        }

        [TestMethod]
        public void CombinedValuesTest_MinorStraight_1()
        {
            Domain.Enumerators.DiceResult[] input =
                new Domain.Enumerators.DiceResult[] {
                    Domain.Enumerators.DiceResult.One,
                    Domain.Enumerators.DiceResult.Four,
                    Domain.Enumerators.DiceResult.Three,
                    Domain.Enumerators.DiceResult.One,
                    Domain.Enumerators.DiceResult.Two
                };
            KeyValuePair<Domain.Enumerators.Category, int>[] expectedOutput = {
                new KeyValuePair<Domain.Enumerators.Category, int>(Domain.Enumerators.Category.MinorStraight, 15)
            };
            KeyValuePair<Domain.Enumerators.Category, int>[] obtaionedOutput =
                Classifier.FindHighScoredCategories(input);

            CollectionAssert.AreEquivalent(expectedOutput, obtaionedOutput);
        }

        [TestMethod]
        public void CombinedValuesTest_MinorStraight_2()
        {
            Domain.Enumerators.DiceResult[] input =
                new Domain.Enumerators.DiceResult[] {
                    Domain.Enumerators.DiceResult.Five,
                    Domain.Enumerators.DiceResult.Four,
                    Domain.Enumerators.DiceResult.Three,
                    Domain.Enumerators.DiceResult.Two,
                    Domain.Enumerators.DiceResult.Two
                };
            KeyValuePair<Domain.Enumerators.Category, int>[] expectedOutput = {
                new KeyValuePair<Domain.Enumerators.Category, int>(Domain.Enumerators.Category.MinorStraight, 15)
            };
            KeyValuePair<Domain.Enumerators.Category, int>[] obtaionedOutput =
                Classifier.FindHighScoredCategories(input);

            CollectionAssert.AreEquivalent(expectedOutput, obtaionedOutput);
        }

        [TestMethod]
        public void CombinedValuesTest_MajorStraight_1()
        {
            Domain.Enumerators.DiceResult[] input =
                new Domain.Enumerators.DiceResult[] {
                    Domain.Enumerators.DiceResult.Five,
                    Domain.Enumerators.DiceResult.One,
                    Domain.Enumerators.DiceResult.Three,
                    Domain.Enumerators.DiceResult.Two,
                    Domain.Enumerators.DiceResult.Four
                };
            KeyValuePair<Domain.Enumerators.Category, int>[] expectedOutput = {
                new KeyValuePair<Domain.Enumerators.Category, int>(Domain.Enumerators.Category.MajorStraight, 20)
            };
            KeyValuePair<Domain.Enumerators.Category, int>[] obtaionedOutput =
                Classifier.FindHighScoredCategories(input);

            CollectionAssert.AreEquivalent(expectedOutput, obtaionedOutput);
        }

        [TestMethod]
        public void CombinedValuesTest_FullHouse_1()
        {
            Domain.Enumerators.DiceResult[] input =
                new Domain.Enumerators.DiceResult[] {
                    Domain.Enumerators.DiceResult.Five,
                    Domain.Enumerators.DiceResult.Three,
                    Domain.Enumerators.DiceResult.Three,
                    Domain.Enumerators.DiceResult.Three,
                    Domain.Enumerators.DiceResult.Five
                };
            KeyValuePair<Domain.Enumerators.Category, int>[] expectedOutput = {
                new KeyValuePair<Domain.Enumerators.Category, int>(Domain.Enumerators.Category.FullHouse, 19)
            };
            KeyValuePair<Domain.Enumerators.Category, int>[] obtaionedOutput =
                Classifier.FindHighScoredCategories(input);

            CollectionAssert.AreEquivalent(expectedOutput, obtaionedOutput);
        }

        [TestMethod]
        public void CombinedValuesTest_FullHouse_2()
        {
            Domain.Enumerators.DiceResult[] input =
                new Domain.Enumerators.DiceResult[] {
                    Domain.Enumerators.DiceResult.Six,
                    Domain.Enumerators.DiceResult.One,
                    Domain.Enumerators.DiceResult.Six,
                    Domain.Enumerators.DiceResult.One,
                    Domain.Enumerators.DiceResult.One
                };
            KeyValuePair<Domain.Enumerators.Category, int>[] expectedOutput = {
                new KeyValuePair<Domain.Enumerators.Category, int>(Domain.Enumerators.Category.FullHouse, 15)
            };
            KeyValuePair<Domain.Enumerators.Category, int>[] obtaionedOutput =
                Classifier.FindHighScoredCategories(input);

            CollectionAssert.AreEquivalent(expectedOutput, obtaionedOutput);
        }

        [TestMethod]
        public void CombinedValuesTest_Aurora_1()
        {
            Domain.Enumerators.DiceResult[] input =
                new Domain.Enumerators.DiceResult[] {
                    Domain.Enumerators.DiceResult.One,
                    Domain.Enumerators.DiceResult.One,
                    Domain.Enumerators.DiceResult.One,
                    Domain.Enumerators.DiceResult.One,
                    Domain.Enumerators.DiceResult.One
                };
            KeyValuePair<Domain.Enumerators.Category, int>[] expectedOutput = {
                new KeyValuePair<Domain.Enumerators.Category, int>(Domain.Enumerators.Category.Aurora, 50)
            };
            KeyValuePair<Domain.Enumerators.Category, int>[] obtaionedOutput =
                Classifier.FindHighScoredCategories(input);

            CollectionAssert.AreEquivalent(expectedOutput, obtaionedOutput);
        }

        [TestMethod]
        public void CombinedValuesTest_Aurora_2()
        {
            Domain.Enumerators.DiceResult[] input =
                new Domain.Enumerators.DiceResult[] {
                    Domain.Enumerators.DiceResult.Two,
                    Domain.Enumerators.DiceResult.Two,
                    Domain.Enumerators.DiceResult.Two,
                    Domain.Enumerators.DiceResult.Two,
                    Domain.Enumerators.DiceResult.Two
                };
            KeyValuePair<Domain.Enumerators.Category, int>[] expectedOutput = {
                new KeyValuePair<Domain.Enumerators.Category, int>(Domain.Enumerators.Category.Aurora, 50)
            };
            KeyValuePair<Domain.Enumerators.Category, int>[] obtaionedOutput =
                Classifier.FindHighScoredCategories(input);

            CollectionAssert.AreEquivalent(expectedOutput, obtaionedOutput);
        }

        [TestMethod]
        public void CombinedValuesTest_Aurora_3()
        {
            Domain.Enumerators.DiceResult[] input =
                new Domain.Enumerators.DiceResult[] {
                    Domain.Enumerators.DiceResult.Six,
                    Domain.Enumerators.DiceResult.Six,
                    Domain.Enumerators.DiceResult.Six,
                    Domain.Enumerators.DiceResult.Six,
                    Domain.Enumerators.DiceResult.Six
                };
            KeyValuePair<Domain.Enumerators.Category, int>[] expectedOutput = {
                new KeyValuePair<Domain.Enumerators.Category, int>(Domain.Enumerators.Category.Aurora, 50)
            };
            KeyValuePair<Domain.Enumerators.Category, int>[] obtaionedOutput =
                Classifier.FindHighScoredCategories(input);

            CollectionAssert.AreEquivalent(expectedOutput, obtaionedOutput);
        }

        #endregion
    }
}
