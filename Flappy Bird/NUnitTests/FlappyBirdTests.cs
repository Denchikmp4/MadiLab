using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flappy_Bird_Windows_Form;
using NUnit.Framework;

namespace NUnitTests
{
    [TestFixture]
    public class FlappyBirdGameTests
    {
        [Test]
        public void FlappyBird_GameOverOnCollision()
        {
            // Arrange
            var gameForm = new Form1();

            // Act
            // Simulate collision with pipes or ground
            gameForm.flappyBird.Bounds = new System.Drawing.Rectangle(100, 100, 50, 50); // Adjust the values as needed
            gameForm.pipeBottom.Bounds = new System.Drawing.Rectangle(100, 150, 50, 150); // Adjust the values as needed

            gameForm.endGame(); // Call the endGame method

            // Assert
            Assert.IsFalse(gameForm.gameTimer.Enabled); // Ensure that the game timer is stopped
            Assert.IsTrue(gameForm.scoreText.Text.Contains("Game over!!!")); // Ensure that the game over text is displayed
        }

        [Test]
        public void FlappyBird_ScoreIncreasesOnPipePass()
        {
            // Arrange
            var gameForm = new Form1();

            // Act
            // Simulate passing a pipe
            gameForm.pipeBottom.Left = -150; // Adjust the value so that the pipe is considered passed

            gameForm.gameTimerEvent(null, null); // Trigger the game timer event

            // Assert
            Assert.AreEqual(1, gameForm.score); // Ensure that the score is increased by 1
        }

        // Add more tests as needed to cover other scenarios in your code
    }
}