using Xunit;

namespace ElevensLib.Test
{
    public class BoardTests
    {
        [Fact]
        public void Board_WhenCreate_ThenNoErrorShouldBeThrown()
        {
            // Arrange
            var board = new Board('T');

            // Act 

            //Assert
            Assert.NotNull(board);

        }
    }
}