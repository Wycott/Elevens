/*
Copyright (c) 2021, Rob Docherty
All rights reserved.

This source code is licensed under the BSD-style license found in the
LICENSE file in the root directory of this source tree. 
*/

namespace ElevensLib
{
    public class Session
    {
        private int Iterations { get; }

        private string Option { get; }

        public Session(int iterations, string option)
        {
            Iterations = iterations;
            Option = option;
        }

        public int Start()
        {
            var wins = 0;

            for (var i = 0; i < Iterations; i++)
            {
                var g = new Game(Option);
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