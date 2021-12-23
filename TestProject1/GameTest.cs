using System;
using System.Collections.Generic;
using System.Linq;
using BingoGameApp;
using Xunit;

namespace TestProject1
{
    public class GameTest
    {
        private List<int> _testBoard1 = new List<int> { 22, 13, 17, 11, 0, 8, 2, 23, 4, 24, 21, 9, 14, 16, 7, 6, 10, 3, 18, 5, 1, 12, 20, 15, 19 };
        private List<int> _testBoard2 = new List<int> { 3, 15, 0, 2, 22, 9, 18, 13, 17, 5, 19, 8, 7, 25, 23, 20, 11, 10, 24, 4, 14, 21, 16, 12, 6};
        private List<int> _testBoard3 = new List<int> { 14, 21, 17, 24, 4, 10, 16, 15, 9, 19, 18, 8, 23, 26, 20, 22, 11, 13, 6, 5, 2, 0, 12, 3, 7};
        
        [Fact]
        public void Test1()
        {
            //Arrange
            var rounds = new List<int> { 7, 4, 9, 5, 11, 17, 23, 2, 0, 14, 21, 24, 10, 16, 13, 6, 15, 25, 12, 22, 18, 20, 8, 19, 3, 26, 1 };

            var game = new BingoGame(rounds);
            game.AddBoard(_testBoard1);
            game.AddBoard(_testBoard2);
            game.AddBoard(_testBoard3);
            
            //Act
            var result = game.PlayGame();
            
            //Assert
            Assert.Equal(4512, result);
        }
        
        [Fact]
        public void Test2()
        {
            //Arrange
            var rounds = new List<int> {22, 8, 6, 1, 21, 7, 4, 9, 5, 11, 17, 23, 2, 0, 14, 24, 10, 16, 13, 15, 25, 12, 22, 18, 20, 8, 19, 3, 26 };

            var game = new BingoGame(rounds);
            game.AddBoard(_testBoard1);
            game.AddBoard(_testBoard2);
            game.AddBoard(_testBoard3);
            var expectedResult = new int[20]
                { 13, 17, 11, 0, 2, 23, 4, 24, 9, 14, 16, 7, 10, 3, 18, 5, 12, 20, 15, 19 }.Sum() * 21;
            
            //Act
            var result = game.PlayGame();
            
            //Assert
            Assert.Equal(expectedResult, result);
        }
        
        [Fact]
        public void Test3()
        {
            //Arrange
            var rounds = new List<int> { 7, 4, 9, 5, 11, 17, 23, 2, 0, 14, 21, 24, 10, 16, 13, 6, 15, 25, 12, 22, 18, 20, 8, 19, 3, 26, 1 };

            var game = new BingoGame(rounds, false);
            game.AddBoard(_testBoard1);
            game.AddBoard(_testBoard2);
            game.AddBoard(_testBoard3);
            
            //Act
            var result = game.PlayGame();
            
            //Assert
            Assert.Equal(1924, result);
        }
    }
}