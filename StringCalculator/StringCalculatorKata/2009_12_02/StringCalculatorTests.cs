using System;
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
	}
}
