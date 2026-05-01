/*
Copyright (c) 2021-2026, Rob Docherty
All rights reserved.

This source code is licensed under the BSD-style license found in the
LICENSE file in the root directory of this source tree. 
*/

using Xunit;

namespace ElevensLib.Test
{
    public class SessionTests
    {
        // ── Win count is within [0, iterations] ──────────────────────────────

        [Theory]
        [InlineData(MovePreference.Numbers,     10)]
        [InlineData(MovePreference.Pictures,    10)]
        [InlineData(MovePreference.Alternating, 10)]
        public void Session_Start_WinsAreWithinIterationBounds(MovePreference preference, int iterations)
        {
            var session = new Session(iterations, preference);
            var wins = session.Start();

            Assert.InRange(wins, 0, iterations);
        }

        // ── Zero iterations always returns zero wins ──────────────────────────

        [Theory]
        [InlineData(MovePreference.Numbers)]
        [InlineData(MovePreference.Pictures)]
        [InlineData(MovePreference.Alternating)]
        public void Session_Start_ZeroIterationsReturnsZeroWins(MovePreference preference)
        {
            var session = new Session(0, preference);
            Assert.Equal(0, session.Start());
        }

        // ── Single iteration returns 0 or 1 ──────────────────────────────────

        [Theory]
        [InlineData(MovePreference.Numbers)]
        [InlineData(MovePreference.Pictures)]
        [InlineData(MovePreference.Alternating)]
        public void Session_Start_SingleIterationReturnsZeroOrOne(MovePreference preference)
        {
            var session = new Session(1, preference);
            var wins = session.Start();
            Assert.InRange(wins, 0, 1);
        }

        // ── Larger iteration count produces a plausible win rate ─────────────
        // Win rate for Elevens is roughly 1-in-3, so 100 games should
        // produce at least 1 win and fewer than 100 wins.

        [Theory]
        [InlineData(MovePreference.Numbers)]
        [InlineData(MovePreference.Pictures)]
        [InlineData(MovePreference.Alternating)]
        public void Session_Start_LargeIterationCountProducesReasonableWinRate(MovePreference preference)
        {
            const int iterations = 100;
            var session = new Session(iterations, preference);
            var wins = session.Start();

            Assert.True(wins > 0,          $"Expected at least one win in {iterations} games ({preference})");
            Assert.True(wins < iterations, $"Expected at least one loss in {iterations} games ({preference})");
        }
    }
}
