/*
Copyright (c) 2021, Rob Docherty
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
        public string? Identity { get; set; }

        private static string DecodeRank(int rank)
        {
            switch (rank)
            {
                case 1:
                    return "A";
                case 10:
                    return "T";
                case 11:
                    return "J";
                case 12:
                    return "Q";
                case 13:
                    return "K";
                default:
                    return rank.ToString();
            }
        }

        private static string DecodeSuit(int suit)
        {
            switch (suit)
            {
                case 1:
                    return "H";
                case 2:
                    return "C";
                case 3:
                    return "D";
                default:
                    return "S";
            }
        }
    }
}