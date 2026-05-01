/*
Copyright (c) 2021-2022, Rob Docherty
All rights reserved.

This source code is licensed under the BSD-style license found in the
LICENSE file in the root directory of this source tree. 
*/

namespace ElevensLib
{
    public class Card
    {
        public string Name => DecodeRank(Rank) + DecodeSuit(Suit);
        public int Suit { private get; set; }
        public int Rank { get; set; }

        private static string DecodeRank(int rank)
        {
            return rank switch
            {
                1 => "A",
                10 => "T",
                11 => "J",
                12 => "Q",
                13 => "K",
                _ => rank.ToString()
            };
        }

        private static string DecodeSuit(int suit)
        {
            return suit switch
            {
                1 => "♥",
                2 => "♣",
                3 => "♦",
                _ => "♠"
            };
        }
    }
}