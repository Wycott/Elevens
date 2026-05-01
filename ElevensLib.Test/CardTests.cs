/*
Copyright (c) 2021-2022, Rob Docherty
All rights reserved.

This source code is licensed under the BSD-style license found in the
LICENSE file in the root directory of this source tree. 
*/

using Xunit;

namespace ElevensLib.Test
{
    public class CardTests
    {
        // ── Name formatting ──────────────────────────────────────────────────

        [Theory]
        [InlineData(1,  0, "A♠")]
        [InlineData(1,  1, "A♥")]
        [InlineData(1,  2, "A♣")]
        [InlineData(1,  3, "A♦")]
        [InlineData(2,  0, "2♠")]
        [InlineData(9,  0, "9♠")]
        [InlineData(10, 0, "T♠")]
        [InlineData(11, 0, "J♠")]
        [InlineData(12, 0, "Q♠")]
        [InlineData(13, 0, "K♠")]
        public void Card_Name_ReturnsCorrectRankAndSuitSymbol(int rank, int suit, string expected)
        {
            var card = new Card { Rank = rank, Suit = suit };
            Assert.Equal(expected, card.Name);
        }

        // ── Rank is readable ─────────────────────────────────────────────────

        [Theory]
        [InlineData(1)]
        [InlineData(7)]
        [InlineData(13)]
        public void Card_Rank_ReturnsValueSetOnConstruction(int rank)
        {
            var card = new Card { Rank = rank, Suit = 0 };
            Assert.Equal(rank, card.Rank);
        }

        // ── Name is never null or empty ───────────────────────────────────────

        [Fact]
        public void Card_Name_IsNeverNullOrEmpty()
        {
            for (var suit = 0; suit < 4; suit++)
            {
                for (var rank = 1; rank <= 13; rank++)
                {
                    var card = new Card { Rank = rank, Suit = suit };
                    Assert.False(string.IsNullOrEmpty(card.Name));
                }
            }
        }
    }
}
