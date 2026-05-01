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
        // ── Construction ─────────────────────────────────────────────────────

        [Theory]
        [InlineData(MovePreference.Alternating)]
        [InlineData(MovePreference.Numbers)]
        [InlineData(MovePreference.Pictures)]
        public void Board_WhenCreated_ThenNoErrorShouldBeThrown(MovePreference preference)
        {
            var board = new Board(preference);
            Assert.NotNull(board);
        }

        // ── Move returns a non-negative deck count ────────────────────────────

        [Theory]
        [InlineData(MovePreference.Numbers)]
        [InlineData(MovePreference.Pictures)]
        [InlineData(MovePreference.Alternating)]
        public void Board_Move_ReturnsNonNegativeDeckCount(MovePreference preference)
        {
            var board = new Board(preference);
            var remaining = board.Move();
            Assert.True(remaining >= 0);
        }

        // ── Deck shrinks (or stays the same when no moves are possible) ───────

        [Theory]
        [InlineData(MovePreference.Numbers)]
        [InlineData(MovePreference.Pictures)]
        [InlineData(MovePreference.Alternating)]
        public void Board_Move_DeckCountDoesNotIncrease(MovePreference preference)
        {
            var board = new Board(preference);
            var first = board.Move();
            var second = board.Move();
            Assert.True(second <= first);
        }

        // ── Repeated moves eventually exhaust the deck or stall ──────────────

        [Theory]
        [InlineData(MovePreference.Numbers)]
        [InlineData(MovePreference.Pictures)]
        [InlineData(MovePreference.Alternating)]
        public void Board_Move_EventuallyReachesStableState(MovePreference preference)
        {
            var board = new Board(preference);
            var previous = int.MaxValue;
            var current = board.Move();

            // Keep moving until no progress is made or deck is empty
            while (current < previous && current > 0)
            {
                previous = current;
                current = board.Move();
            }

            Assert.True(current >= 0);
        }

        // ── DumpBoard does not throw for any preference ───────────────────────

        [Theory]
        [InlineData(MovePreference.Alternating)]
        [InlineData(MovePreference.Numbers)]
        [InlineData(MovePreference.Pictures)]
        public void Board_DumpBoard_DoesNotThrow(MovePreference preference)
        {
            var board = new Board(preference);
            var exception = Record.Exception(() => board.DumpBoard());
            Assert.Null(exception);
        }
    }
}