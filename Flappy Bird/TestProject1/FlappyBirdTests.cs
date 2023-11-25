using Flappy_Bird_Windows_Form;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
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
            gameForm.flappyBird.Bounds = new System.Drawing.Rectangle(100, 100, 50, 50); 
            gameForm.pipeBottom.Bounds = new System.Drawing.Rectangle(100, 150, 50, 150); 

            gameForm.endGame(); 

            // Assert
            Assert.IsFalse(gameForm.gameTimer.Enabled); 
            Assert.IsTrue(gameForm.scoreText.Text.Contains("Game over!!!")); 
        }

        [Test]
        public void FlappyBird_ScoreIncreasesOnPipePass()
        {
            // Arrange
            var gameForm = new Form1();

            // Act
            gameForm.pipeBottom.Left = -150; 

            gameForm.gameTimerEvent(null, null); 

            // Assert
            Assert.AreEqual(1, gameForm.score); 
        }

        [Test]
        public void FlappyBird_GravityIncreasesOnSpaceKeyPress()
        {
            // Arrange
            var gameForm = new Form1();
            var initialGravity = gameForm.gravity;

            // Act
            gameForm.gamekeyisdown(null, new System.Windows.Forms.KeyEventArgs(System.Windows.Forms.Keys.Space));

            // Assert
            Assert.AreEqual(- 10, gameForm.gravity);
        }

        [Test]
        public void FlappyBird_GravityResetsOnSpaceKeyRelease()
        {
            // Arrange
            var gameForm = new Form1();
            gameForm.gamekeyisdown(null, new System.Windows.Forms.KeyEventArgs(System.Windows.Forms.Keys.Space));

            // Act
            gameForm.gamekeyisup(null, new System.Windows.Forms.KeyEventArgs(System.Windows.Forms.Keys.Space));

            // Assert
            Assert.AreEqual(10, gameForm.gravity);
        }

        [Test]
        public void FlappyBird_PipeSpeedIncreasesAfterScoreGreaterThanFive()
        {
            // Arrange
            var gameForm = new Form1();
            gameForm.score = 6;

            // Act
            gameForm.gameTimerEvent(null, null);

            // Assert
            Assert.AreEqual(15, gameForm.pipeSpeed);
        }

    }
}

