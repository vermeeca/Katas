using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Greed.Tests
{
	[TestFixture]
	public class ScoringTests
	{

		private ScoreCalculator Sut()
		{
			return new ScoreCalculator();
		}

		[Test]
		public void should_score_three_ones_as_1000()
		{
			var rolls = new[] {1, 1, 1};
			Assert.AreEqual(1000, Sut().Score(rolls));
		}

		[Test]
		public void should_score_three_twos_as_200()
		{
			var rolls = new[] {2, 2, 2};
			Assert.AreEqual(200, Sut().Score(rolls));
		}

		[Test]
		public void should_score_individual_ones_as_100()
		{
			var rolls = new[] {1};
			Assert.AreEqual(100, Sut().Score(rolls));
		}

	
		[Test]
		public void should_score_individual_ones_as_100_part_2()
		{
			var rolls = new[] { 1,1 };
			Assert.AreEqual(200, Sut().Score(rolls));
		}

		[Test]
		public void should_score_individual_fives_as_50()
		{
			var rolls = new[] {5};
			Assert.AreEqual(50, Sut().Score(rolls));
		}

		[Test]
		public void four_ones_and_five_should_be_1150()
		{
			var rolls = new[] {1, 1, 1, 5, 1};
			Assert.AreEqual(1150, Sut().Score(rolls));
		}

		[Test]
		public void zero_point_testcase()
		{
			var rolls = new[] {2, 3, 4, 6, 2};
			Assert.AreEqual(0, Sut().Score(rolls));
		}
		[Test]
		public void should_score_3_3_5_4_as_350()
		{
			var rolls = new[] {3, 4, 5, 3, 3};
			Assert.AreEqual(350, Sut().Score(rolls));
		}

		[Test]
		public void should_score_1_5_1_2_4_as_250()
		{
			var rolls = new[] { 1, 5, 1, 2, 4};
			Assert.AreEqual(250, Sut().Score(rolls));
		}


		[Test]
		public void everything_else_should_be_zero()
		{
			var rolls = new[] {2, 2, 3};
			Assert.AreEqual(0, new ScoreCalculator().Score(rolls));
		}
	}
}
