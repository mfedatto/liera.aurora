namespace Liera.Aurora.Domain.Enumerators
{
    /// <summary>
    /// Aurora result category enumeration
    /// </summary>
    public enum Category : int {
        None = -1,
        Ones = 1,
        Twos = 2,
        Threes = 3,
        Fours = 4,
        Fives = 5,
        Sixes = 6,
        Pair = 10,
        TwoPairs = 11,
        ThreeOfAKind = 20,
        FourOfAKind = 30,
        MinorStraight = 40,
        MajorStraight = 50,
        FullHouse = 60,
        Aurora = 70
    }
}
