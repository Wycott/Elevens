﻿/*
Copyright (c) 2021-2022, Rob Docherty
All rights reserved.

This source code is licensed under the BSD-style license found in the
LICENSE file in the root directory of this source tree. 
*/

namespace ElevensLib
{
    public class Game
    {
        private Board GameBoard { get; }
        private MovePreference MovePreference { get; }

        public Game(MovePreference movePreference)
        {
            MovePreference = movePreference;
            GameBoard = new Board(MovePreference);
        }

        public bool Play()
        {
            var cardsLeft = GameBoard.Move();

            while (cardsLeft > 0)
            {
                var dummy = cardsLeft;

                cardsLeft = GameBoard.Move();

                if (dummy == cardsLeft)
                {
                    return false;
                }
            }

            GameBoard.DumpBoard();

            return true;
        }
    }
}