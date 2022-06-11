/*
Copyright (c) 2021-2022, Rob Docherty
All rights reserved.

This source code is licensed under the BSD-style license found in the
LICENSE file in the root directory of this source tree. 
*/

using Xunit;

namespace ElevensLib.Test
{
    public class BoardTests
    {
        [Fact]
        public void Board_WhenCreate_ThenNoErrorShouldBeThrown()
        {
            // Arrange
            var board = new Board(MovePreference.Alternating);

            // Act 

            //Assert
            Assert.NotNull(board);

        }
    }
}