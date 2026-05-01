/*
Copyright (c) 2021-2026, Rob Docherty
All rights reserved.

This source code is licensed under the BSD-style license found in the
LICENSE file in the root directory of this source tree. 
*/

namespace ElevensLib
{
    public class Session(int iterations, MovePreference movePreference)
    {
        private int Iterations { get; } = iterations;

        private MovePreference MovePreference { get; } = movePreference;

        public int Start()
        {
            var wins = 0;

            for (var i = 0; i < Iterations; i++)
            {
                var g = new Game(MovePreference);
                var res = g.Play();

                if (res)
                {
                    wins++;
                }
            }

            return wins;
        }
    }
}