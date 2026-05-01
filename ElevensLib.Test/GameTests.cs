/*
Copyright (c) 2021-2026, Rob Docherty
All rights reserved.

This source code is licensed under the BSD-style license found in the
LICENSE file in the root directory of this source tree. 
*/

using Xunit;

namespace ElevensLib.Test
{
    public class GameTests
    {
        // ── Play returns a bool ───────────────────────────────────────────────

        [Theory]
        [InlineData(MovePreference.Numbers)]
        [InlineData(MovePreference.Pictures)]
        [InlineData(MovePreference.Alternating)]
        public void Game_Play_ReturnsBoolWithoutThrowing(MovePreference preference)
        {
            var game = new Game(preference);
            var exception = Record.Exception(() => game.Play());
            Assert.Null(exception);
        }

        // ── Over many games, at least some are won and some are lost ──────────
        // (statistical: the probability of all 50 games having the same outcome
        //  is astronomically small for a fair shuffle)

        [Theory]
        [InlineData(MovePreference.Numbers)]
        [InlineData(MovePreference.Pictures)]
        [InlineData(MovePreference.Alternating)]
        public void Game_Play_ProducesBothWinsAndLossesOverManyGames(MovePreference preference)
        {
            const int runs = 50;
            var wins = 0;

            for (var i = 0; i < runs; i++)
            {
                var game = new Game(preference);
                if (game.Play()) wins++;
            }

            Assert.True(wins > 0,  $"Expected at least one win in {runs} games ({preference})");
            Assert.True(wins < runs, $"Expected at least one loss in {runs} games ({preference})");
        }
    }
}
