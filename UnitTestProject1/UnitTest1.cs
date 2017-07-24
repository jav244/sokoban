using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DesignerNS;
using FilerNS;

namespace UnitTesting
{
    [TestClass]
    public class UnitTest1
    {
        private string WidthTooSmallMessage = "width has to be three or more";
        private string HeightTooSmallMessage = "height has to be three or more";
        private string LevelAreaTooSmallMessage = "level area needs to be more than 15";
        private string OutOfGridMessage = "placement is not within the grid";

        [TestMethod]
        public void Level_GivenWidth_CanGetLevelWidth()
        {
            //arrange
            int width = 10;
            int height = 12;
            IDesigner theLevel = new Designer();
            theLevel.LevelBuilder(width, height);

            //act
            int actual = theLevel.GetLevelWidth();

            //check
            Assert.AreEqual(actual, width, "The set width is not returned by GetLevelWidth");

        }

        [TestMethod]
        public void Level_GivenHeight_CanGetLevelHeight()
        {
            //arrange
            int width = 10;
            int height = 12;
            IDesigner theLevel = new Designer();
            theLevel.LevelBuilder(width, height);

            //act
            int actual = theLevel.GetLevelHeight();

            //check
            Assert.AreEqual(actual, height, "The set height is not returned by GetLevelHeight");
        }

        [TestMethod]
        public void Level_PassedAnInt_IsWidthAnInt()
        {
            //arrange
            int width = 10;
            int height = 12;
            IDesigner theLevel = new Designer();
            theLevel.LevelBuilder(width, height);

            //act
            int actual = theLevel.GetLevelWidth();

            //check
            Assert.IsInstanceOfType(actual, typeof(int), "Width is not of type integer.");
        }

        [TestMethod]
        public void Level_PassedAnInt_IsHeightAnInt()
        {
            //arrange
            int width = 10;
            int height = 12;
            IDesigner theLevel = new Designer();
            theLevel.LevelBuilder(width, height);

            //act
            int actual = theLevel.GetLevelHeight();

            //check
            Assert.IsInstanceOfType(actual, typeof(int), "Height is not of type integer.");
        }
        [TestMethod]
        public void Level_PassedAnInt_IsWidthGreaterThanTwo()
        {
            //Width should be greater than two as there must be at least one playable tile between wall to play
            //arrange
            int height = 7;
            int width = 2;
            IDesigner theLevel = new Designer();

            // act
            try
            {
                theLevel.LevelBuilder(width, height);
            }
            catch (ArgumentException e)
            {
                // assert
                StringAssert.Contains(e.Message, WidthTooSmallMessage);
                return;
            }
            Assert.Fail("No exception was thrown. (Width was allowed to be less than minimum playable width.)");
        }

        [TestMethod]
        public void Level_PassedAnInt_IsHeightGreaterThanTwo()
        {
            //Height should be greater than two as there must be at least one playable tile between wall to play
            //arrange
            int height = 2;
            int width = 6;
            IDesigner theLevel = new Designer();

            // act
            try
            {
                theLevel.LevelBuilder(width, height);
            }
            catch (ArgumentException e)
            {
                // assert
                StringAssert.Contains(e.Message, HeightTooSmallMessage);
                return;
            }
            Assert.Fail("No exception was thrown. (Height was allowed to be less than minimum playable width.)");
        }

        [TestMethod]
        public void Level_WhenGameAreaTooSmall_ShouldThrowError()
        {
            //In order to play, need a minimum of 3 usable tiles (block/box, player, target/goal)
            //Space must be encased in wall, therefore minimum playable area = 15
            // arrange
            int height = 3;
            int width = 4;
            IDesigner theLevel = new Designer();

            // act
            try
            {
                theLevel.LevelBuilder(width, height);
            }
            catch (ArgumentException e)
            {
                // assert
                StringAssert.Contains(e.Message, LevelAreaTooSmallMessage);
                return;
            }
            Assert.Fail("No exception was thrown. (Area was allowed to be less than minimum playable area.)");
        }

        [TestMethod]
        public void AddPlayer()
        {
            int width = 10;
            int height = 12;
            IDesigner theLevel = new Designer();
            theLevel.LevelBuilder(width, height);

            //act
            theLevel.AddPlayer(0, 0);

            //check
            Assert.AreEqual(theLevel.GetPartAtIndex(0, 0), Parts.Player);

        }

        [TestMethod]
        public void GetMoveablePlayerAtIndex()
        {
            int width = 10;
            int height = 12;
            IDesigner theLevel = new Designer();
            theLevel.LevelBuilder(width, height);

            //act
            theLevel.AddPlayer(1, 1);
            // X is player
            Assert.AreEqual(theLevel.GetPartAtIndex(1, 1), Parts.Player);
        }

        [TestMethod]
        public void GetMoveableBlockAtIndex()
        {
            int width = 10;
            int height = 12;
            IDesigner theLevel = new Designer();
            theLevel.LevelBuilder(width, height);

            //act
            theLevel.AddBlock(1, 5);

            Assert.AreEqual(theLevel.GetPartAtIndex(1, 5), Parts.Block);
        }

        [TestMethod]
        public void SaveMeIsNotNull()
        {
            int width = 10;
            int height = 12;
            IDesigner theLevel = new Designer();
            theLevel.LevelBuilder(width, height);
            //SaveMe method needs to convert Grid to string
            //Convert Grid to string and assert it isn't empty
            string testing = theLevel.SaveMe(theLevel.GridIndex);
            Assert.IsNotNull(testing);
        }

        [TestMethod]
        public void SaveMeIsString()
        {
            int width = 10;
            int height = 12;
            IDesigner theLevel = new Designer();
            theLevel.LevelBuilder(width, height);
            //SaveMe method needs to convert Grid to string
            //Convert Grid to string and assert it isn't empty
            string actual = theLevel.SaveMe(theLevel.GridIndex);
            Assert.IsInstanceOfType(actual, typeof(string), "is not of type string.");
        }

        [TestMethod]
        public void AddBlock()
        {
            int width = 10;
            int height = 12;
            IDesigner theLevel = new Designer();
            theLevel.LevelBuilder(width, height);

            theLevel.AddBlock(2, 5);
            Assert.AreEqual(theLevel.GetPartAtIndex(2, 5), Parts.Block);
        }

        [TestMethod]
        public void AddGoal()
        {
            int width = 10;
            int height = 12;
            IDesigner theLevel = new Designer();
            theLevel.LevelBuilder(width, height);

            theLevel.AddGoal(2, 5);
            Assert.AreEqual(theLevel.GetPartAtIndex(2, 5), Parts.Goal);
        }

        [TestMethod]
        public void AddWall()
        {
            int width = 10;
            int height = 12;
            IDesigner theLevel = new Designer();
            theLevel.LevelBuilder(width, height);

            theLevel.AddWall(1, 1);
            Assert.AreEqual(theLevel.GetPartAtIndex(1, 1), Parts.Wall);
        }

        [TestMethod]
        public void AddEmpty()
        {
            int width = 10;
            int height = 12;
            IDesigner theLevel = new Designer();
            theLevel.LevelBuilder(width, height);

            theLevel.AddEmpty(1, 1);
            Assert.AreEqual(theLevel.GetPartAtIndex(1, 1), Parts.Empty);
        }

        [TestMethod]

        public void Level_WhenHeightRequested_ShouldBeNonNull()
        {
            //Check GetLevelHeight returns something.
            // arrange
            int height = 10;
            int width = 10;
            IDesigner theLevel = new Designer();
            theLevel.LevelBuilder(height, width);

            // act
            int actual = theLevel.GetLevelHeight();

            // assert 
            Assert.IsNotNull(actual, "GetLevelHeight should return an integer (returned null)");
        }

        [TestMethod]

        public void Level_WhenWidthRequested_ShouldBeNonNull()
        {
            //Check GetLevelWidth returns something.
            // arrange
            int height = 10;
            int width = 10;
            IDesigner theLevel = new Designer();
            theLevel.LevelBuilder(height, width);

            // act
            int actual = theLevel.GetLevelWidth();

            // assert
            Assert.IsNotNull(actual, "GetLevelWidth should return an integer (returned null)");
        }

        [TestMethod]
        public void Level_WhenAddingPlayerTwice_ShouldRemoveFirst()
        {
            //Can't have two players, if there is already one when method called, the method should get rid of the first
            //arrange
            int height = 10;
            int width = 10;
            IDesigner theLevel = new Designer();
            theLevel.LevelBuilder(height, width);
            theLevel.AddPlayer(1, 2);

            //act
            theLevel.AddPlayer(2, 2);

            //assert
            Assert.AreEqual(theLevel.GetPartAtIndex(1, 2), Parts.Empty);
        }

        [TestMethod]
        public void Level_WhenAddingPlayerOnGoal_ShouldHavePlayerOnGoal()
        {
            //arrange
            int height = 10;
            int width = 10;
            IDesigner theLevel = new Designer();
            theLevel.LevelBuilder(height, width);
            theLevel.AddGoal(1, 2);

            //act
            theLevel.AddPlayer(1, 2);

            //assert

            Assert.AreEqual(theLevel.GetPartAtIndex(1, 2), Parts.PlayerOnGoal);
        }


        [TestMethod]
        public void Level_WhenAddingGoalOnPlayer_ShouldHavePlayerOnGoal()
        {
            //arrange
            int height = 10;
            int width = 10;
            IDesigner theLevel = new Designer();
            theLevel.LevelBuilder(height, width);
            theLevel.AddPlayer(1, 2);

            //act
            theLevel.AddGoal(1, 2);

            //assert

            Assert.AreEqual(theLevel.GetPartAtIndex(1, 2), Parts.PlayerOnGoal);
        }

        [TestMethod]
        public void Level_WhenAddingBlockOnGoal_ShouldHaveBlockOnGoal()
        {
            //arrange
            int height = 10;
            int width = 10;
            IDesigner theLevel = new Designer();
            theLevel.LevelBuilder(height, width);
            theLevel.AddGoal(1, 2);

            //act
            theLevel.AddBlock(1, 2);

            //assert

            Assert.AreEqual(theLevel.GetPartAtIndex(1, 2), Parts.BlockOnGoal);
        }

        [TestMethod]
        public void Level_WhenAddingGoalOnBlock_ShouldHaveBlockOnGoal()
        {
            //arrange
            int height = 10;
            int width = 10;
            IDesigner theLevel = new Designer();
            theLevel.LevelBuilder(height, width);
            theLevel.AddBlock(1, 2);

            //act
            theLevel.AddGoal(1, 2);

            //assert

            Assert.AreEqual(theLevel.GetPartAtIndex(1, 2), Parts.BlockOnGoal);
        }

        [TestMethod]
        public void ThrowAssertForAddingPLayerOutsideAGrid()
        {
            //arrange
            int height = 5;
            int width = 8;
            IDesigner theLevel = new Designer();
            theLevel.LevelBuilder(height, width);

            //Check that IndexOutOfRangeException is thrown if
            //attempting to add something outside of the grid

            try
            {
                theLevel.AddPlayer(5, 9);
            }
            catch (ArgumentException e)
            {
                // assert
                StringAssert.Contains(e.Message, OutOfGridMessage);
                return;
            }
            Assert.Fail("No exception was thrown. (Was allowed to place Player outside of Grid)");
        }

        [TestMethod]
        public void ThrowAssertForAddingBlockOutsideAGrid()
        {
            //arrange
            int height = 5;
            int width = 8;
            IDesigner theLevel = new Designer();
            theLevel.LevelBuilder(height, width);

            //Check that IndexOutOfRangeException is thrown if
            //attempting to add something outside of the grid

            try
            {
                theLevel.AddBlock(5, 9);
            }
            catch (ArgumentException e)
            {
                // assert
                StringAssert.Contains(e.Message, OutOfGridMessage);
                return;
            }
            Assert.Fail("No exception was thrown. (Was allowed to place Block outside of Grid)");
        }

        [TestMethod]
        public void ThrowAssertForAddingGoalOutsideAGrid()
        {
            //arrange
            int height = 5;
            int width = 8;
            IDesigner theLevel = new Designer();
            theLevel.LevelBuilder(height, width);

            //Check that IndexOutOfRangeException is thrown if
            //attempting to add something outside of the grid

            try
            {
                theLevel.AddGoal(5, 9);
            }
            catch (ArgumentException e)
            {
                // assert
                StringAssert.Contains(e.Message, OutOfGridMessage);
                return;
            }
            Assert.Fail("No exception was thrown. (Was allowed to place Goal outside of Grid)");
        }

        [TestMethod]
        public void ThrowAssertForAddingWallOutsideAGrid()
        {
            //arrange
            int height = 5;
            int width = 8;
            IDesigner theLevel = new Designer();
            theLevel.LevelBuilder(height, width);

            //Check that IndexOutOfRangeException is thrown if
            //attempting to add something outside of the grid

            try
            {
                theLevel.AddWall(5, 9);
            }
            catch (ArgumentException e)
            {
                // assert
                StringAssert.Contains(e.Message, OutOfGridMessage);
                return;
            }
            Assert.Fail("No exception was thrown. (Was allowed to place Wall outside of Grid)");
        }

        [TestMethod]
        public void ThrowAssertForAddingEmptyOutsideAGrid()
        {
            //arrange
            int height = 5;
            int width = 8;
            IDesigner theLevel = new Designer();
            theLevel.LevelBuilder(height, width);

            //Check that IndexOutOfRangeException is thrown if
            //attempting to add something outside of the grid

            try
            {
                theLevel.AddEmpty(6, 4);
            }
            catch (ArgumentException e)
            {
                // assert
                StringAssert.Contains(e.Message, OutOfGridMessage);
                return;
            }
            Assert.Fail("No exception was thrown. (Was allowed to place Empty outside of Grid)");
        }

        [TestMethod]
        public void ThrowAssertForMoreGoalsThanBlocks()
        {
            //arrange
            int height = 15;
            int width = 15;
            IDesigner theLevel = new Designer();
            theLevel.LevelBuilder(height, width);

            theLevel.AddBlock(2, 3);
            theLevel.AddBlock(2, 4);
            theLevel.AddBlock(2, 5);

            theLevel.AddGoal(3, 3);
            theLevel.AddGoal(3, 4);
            theLevel.AddGoal(3, 5);
            theLevel.AddGoal(4, 5);

            theLevel.AddPlayer(1, 1);

            try
            {
                theLevel.checkValid();
            }
            catch (ArgumentException e)
            {
                // assert
                StringAssert.Contains(e.Message, "more goals than blocks");
                return;
            }
            Assert.Fail("No exception was thrown. (Was allowed to have more goals than blocks)");
        }

        [TestMethod]
        public void ThrowAssertForMoreBlocksThanGoals()
        {
            //arrange
            int height = 15;
            int width = 15;
            IDesigner theLevel = new Designer();
            theLevel.LevelBuilder(height, width);

            theLevel.AddBlock(2, 3);
            theLevel.AddBlock(2, 4);
            theLevel.AddBlock(2, 5);

            theLevel.AddGoal(3, 3);
            theLevel.AddGoal(3, 4);

            theLevel.AddPlayer(1, 1);


            try
            {
                theLevel.checkValid();
            }
            catch (ArgumentException e)
            {
                // assert
                StringAssert.Contains(e.Message, "more blocks than goals");
                return;
            }
            Assert.Fail("No exception was thrown. (Was allowed to have more blocks than goals)");
        }

        [TestMethod]
        public void ThrowAssertForHavingNoPlayer()
        {
            //arrange
            int height = 15;
            int width = 15;
            IDesigner theLevel = new Designer();
            theLevel.LevelBuilder(height, width);

            theLevel.AddBlock(2, 3);
            theLevel.AddGoal(3, 5);


            try
            {
                theLevel.checkValid();
            }
            catch (ArgumentException e)
            {
                // assert
                StringAssert.Contains(e.Message, "No player");
                return;
            }
            Assert.Fail("No exception was thrown. (Was allowed to have no player)");
        }

        [TestMethod]
        public void TestIfBlockReturnsString()
        {

            //arrange
            int height = 15;
            int width = 15;
            IDesigner theLevel = new Designer();
            theLevel.LevelBuilder(height, width);

            theLevel.AddBlock(2, 2);

            string theType = theLevel.GetPartAtIndex(2, 2).ToString();

            Assert.IsInstanceOfType(theType, typeof(string), "Expected a string but got  something else. Please check!");

            Assert.AreEqual(theType, "Block");

        }

        [TestMethod]
        public void TestIfWallReturnsString()
        {

            //arrange
            int height = 15;
            int width = 15;
            IDesigner theLevel = new Designer();
            theLevel.LevelBuilder(height, width);

            theLevel.AddWall(2, 2);

            string theType = theLevel.GetPartAtIndex(2, 2).ToString();

            Assert.IsInstanceOfType(theType, typeof(string), "Expected a string but got  something else. Please check!");

            Assert.AreEqual(theType, "Wall");

        }

        [TestMethod]
        public void TestIfPlayerReturnsString()
        {

            //arrange
            int height = 15;
            int width = 15;
            IDesigner theLevel = new Designer();
            theLevel.LevelBuilder(height, width);

            theLevel.AddPlayer(2, 2);

            string theType = theLevel.GetPartAtIndex(2, 2).ToString();

            Assert.IsInstanceOfType(theType, typeof(string), "Expected a string but got  something else. Please check!");

            Assert.AreEqual(theType, "Player");

        }

        [TestMethod]
        public void TestIfGoalReturnsString()
        {

            //arrange
            int height = 15;
            int width = 15;
            IDesigner theLevel = new Designer();
            theLevel.LevelBuilder(height, width);

            theLevel.AddGoal(2, 2);

            string theType = theLevel.GetPartAtIndex(2, 2).ToString();

            Assert.IsInstanceOfType(theType, typeof(string), "Expected a string but got  something else. Please check!");

            Assert.AreEqual(theType, "Goal");

        }

        public void TestIfEmptyReturnsString()
        {

            //arrange
            int height = 15;
            int width = 15;
            IDesigner theLevel = new Designer();
            theLevel.LevelBuilder(height, width);

            theLevel.AddEmpty(2, 2);

            string theType = theLevel.GetPartAtIndex(2, 2).ToString();

            Assert.IsInstanceOfType(theType, typeof(string), "Expected a string but got  something else. Please check!");

            Assert.AreEqual(theType, "Empty");

        }

        [TestMethod]
        public void TestIfPlayerOnGoalReturnsString()
        {

            //arrange
            int height = 14;
            int width = 15;
            IDesigner theLevel = new Designer();
            theLevel.LevelBuilder(height, width);

            theLevel.AddPlayer(2, 2);
            theLevel.AddGoal(2, 2);

            string theType = theLevel.GetPartAtIndex(2, 2).ToString();

            Assert.IsInstanceOfType(theType, typeof(string), "Expected a string but got  something else. Please check!");

            Assert.AreEqual(theType, "PlayerOnGoal");

        }

        [TestMethod]
        public void TestIfBlockOnGoalReturnsString()
        {

            //arrange
            int height = 15;
            int width = 15;
            IDesigner theLevel = new Designer();
            theLevel.LevelBuilder(height, width);

            theLevel.AddBlock(2, 2);
            theLevel.AddGoal(2, 2);

            string theType = theLevel.GetPartAtIndex(2, 2).ToString();

            Assert.IsInstanceOfType(theType, typeof(string), "Expected a string but got  something else. Please check!");

            Assert.AreEqual(theType, "BlockOnGoal");

        }

        [TestMethod]
        public void DeletePlayerGetsRidOfPlayer()
        {
            //arrange
            int height = 15;
            int width = 14;
            IDesigner theLevel = new Designer();
            theLevel.LevelBuilder(height, width);
            theLevel.AddPlayer(2, 2);

            //act
            theLevel.deletePlayer();

            //assert
            Assert.AreEqual(theLevel.GetPartAtIndex(2, 2), Parts.Empty);
        }


        [TestMethod]
        public void FindPlayerIndex()
        {
            //arrange
            int height = 15;
            int width = 15;
            IDesigner theLevel = new Designer();
            theLevel.LevelBuilder(height, width);
            theLevel.AddPlayer(2, 2);

            //act
            string testing = theLevel.LocateParts(Parts.Player);

            //assert
            Assert.AreEqual(testing, "Player at 2,2. ");
        }

        [TestMethod]
        public void FindGoalIndex()
        {
            //arrange
            int height = 15;
            int width = 15;
            IDesigner theLevel = new Designer();
            theLevel.LevelBuilder(height, width);
            theLevel.AddGoal(2, 2);
            theLevel.AddGoal(3, 2);
            theLevel.AddGoal(4, 2);

            //act
            string testing = theLevel.LocateParts(Parts.Goal);

            //assert
            Assert.AreEqual(testing, "Goal at 2,2. Goal at 3,2. Goal at 4,2. ");
        }

        [TestMethod]
        public void FindWallIndex()
        {
            //arrange
            int height = 15;
            int width = 15;
            IDesigner theLevel = new Designer();
            theLevel.LevelBuilder(height, width);
            theLevel.AddWall(2, 2);
            theLevel.AddWall(3, 2);
            theLevel.AddWall(4, 2);

            //act
            string testing = theLevel.LocateParts(Parts.Wall);

            //assert
            Assert.AreEqual(testing, "Wall at 2,2. Wall at 3,2. Wall at 4,2. ");
        }

        [TestMethod]
        public void FindBlockIndex()
        {
            //arrange
            int height = 15;
            int width = 15;
            IDesigner theLevel = new Designer();
            theLevel.LevelBuilder(height, width);
            theLevel.AddBlock(2, 2);
            theLevel.AddBlock(3, 2);

            //act
            string testing = theLevel.LocateParts(Parts.Block);

            //assert
            Assert.AreEqual(testing, "Block at 2,2. Block at 3,2. ");
        }
    }
}
