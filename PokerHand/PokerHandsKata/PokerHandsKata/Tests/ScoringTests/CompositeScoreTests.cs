using System.Linq;
using System.Text;
using NUnit.Framework;
using PokerHandsKata.Scoring;

namespace PokerHandsKata.Tests.ScoringTests
{
    [TestFixture]
    public class CompositeScoreTests
    {
        [Test]
        public void DefineClass()
        {
            HighCardScore twoHigh = new HighCardScore(CardValue.Two);
            HighCardScore threeHigh = new HighCardScore(CardValue.Three);
            CompositeScore scoreTwo = new CompositeScore();
            scoreTwo.Add(twoHigh);
            CompositeScore scoreThree = new CompositeScore();
            scoreThree.Add(threeHigh);

            Assert.AreEqual(1, scoreThree.CompareTo(scoreTwo));


            

        }
    }
}
