using System.Text;
using NUnit.Framework;

namespace BowlingKata.Tests
{
    [TestFixture]
    public class FrameTests
    {
        [Test]
        public void Frame_total_should_be_total_of_rolls()
        {
            var frame = new Frame();
            frame.Roll('1');
            Assert.AreEqual(1, frame.Score);
        }

        [Test]
        public void Frame_total_should_sum_rolls()
        {
            var frame = new Frame();
            frame.Roll('1');
            frame.Roll('1');
            Assert.AreEqual(2, frame.Score);
        }

        [Test]
        public void two_rolls_should_close_frame()
        {
            var frame = new Frame();
            frame.Roll('1');
            frame.Roll('1');
            Assert.AreEqual(false, frame.IsOpen);
        }

        [Test]
        public void spare_should_leave_frame_open()
        {
            var frame = new Frame();
            frame.Roll('1');
            frame.Roll('/');
            Assert.AreEqual(true, frame.IsOpen);
        }

        [Test]
        public void spare_should_close_after_one_ball()
        {
            var frame = new Frame();
            frame.Roll('1');
            frame.Roll('/');
            frame.Roll('1');
            Assert.AreEqual(false, frame.IsOpen);
        }

        [Test]
        public void spare_should_sum_one_extra_ball()
        {
            var frame = new Frame();
            frame.Roll('1');
            frame.Roll('/');
            frame.Roll('1');
            Assert.AreEqual(11, frame.Score);
        }

        [Test]
        public void strike_should_leave_frame_open()
        {
            var frame = new Frame();
            frame.Roll('X');
            Assert.AreEqual(true, frame.IsOpen);
        }

        [Test]
        public void ball_after_strike_should_leave_frame_open()
        {
            var frame = new Frame();
            frame.Roll('X');
            frame.Roll('1');
            Assert.AreEqual(true, frame.IsOpen);
        }

        [Test]
        public void two_balls_after_strike_should_close_frame()
        {
            var frame = new Frame();
            frame.Roll('X');
            frame.Roll('1');
            frame.Roll('1');
            Assert.AreEqual(false, frame.IsOpen);
        }
        [Test]
        public void two_balls_after_strike_should_sum_2()
        {
            var frame = new Frame();
            frame.Roll('X');
            frame.Roll('X');
            frame.Roll('X');
            Assert.AreEqual(30, frame.Score);
        }

        [Test]
        public void strike_should_sum_two_extra_balls()
        {
            var frame = new Frame();
            frame.Roll('X');
            frame.Roll('1');
            frame.Roll('1');
            Assert.AreEqual(12, frame.Score);
        }

        

    }
}

