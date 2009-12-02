using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace StringCalculatorKata._2009_12_02
{
    [TestFixture]
	public class StringCalculatorTests
	{
        private StringCalculator sut;

        [SetUp]
        public void Setup()
        {
            sut = new StringCalculator();
        }

        [Test]
        public void EmptyString_Should_Be_Zero()
        {
            Assert.That(0 == sut.Sum(string.Empty));
        }

        [Test]
        public void SumOne()
        {
            Assert.AreEqual(1, sut.Sum("1"));
        }

        [Test]
        public void SumOneTwo()
        {
            Assert.AreEqual(3, sut.Sum("1,2"));
        }

        [Test]
        public void SumOneTwoThree()
        {
            Assert.AreEqual(6, sut.Sum("1,2,3"));
        }

        [Test]
        public void SupportNewLines()
        {
            Assert.AreEqual(3, sut.Sum("1\n2"));
        }

        [Test]
        public void SupportDifferentDeliiter()
        {
            Assert.AreEqual(3, sut.Sum("//;\n1;2"));
        }

        [Test]
        public void ShouldNotSupportNegatives()
        {
            Assert.Throws(typeof (NegativeNumbersNotSupportedException), () => sut.Sum("-1,2"));
        }

        [Test]
        public void NegativeNumberExceptionShouldShowAllNegatives()
        {
            try
            {
                sut.Sum("-1,-2,3");
            }
            catch(NegativeNumbersNotSupportedException ex)
            {
                Assert.AreEqual("negatives not allowed - -1,-2", ex.Message);
                return;
            }

            Assert.Fail();
        }
	}
}
