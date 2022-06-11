/*
Copyright (c) 2021-2022, Rob Docherty
All rights reserved.

This source code is licensed under the BSD-style license found in the
LICENSE file in the root directory of this source tree. 
*/

using System.Diagnostics;
using ElevensLib;

namespace ElevensRig
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Console.Clear();

            if (args.Length != 2)
            {
                DisplayHelper.ShowUsage();

                return;
            }

            long totalWins = 0;
            long iterations = 0;
            var best = 0;
            var hi = int.MinValue;
            var lo = int.MaxValue;
            var option = args[1].ToUpper();
            MovePreference movePreference = MovePreference.Unknown;

            bool gotDrawsPerRound = int.TryParse(args[0], out int drawsPerRound);

            switch (option)
            {
                case "N":
                    movePreference = MovePreference.Numbers;
                    break;
                case "P":
                    movePreference = MovePreference.Pictures;
                    break;
                case "T":
                    movePreference = MovePreference.Alternating;
                    break;
            }

            if (movePreference == MovePreference.Unknown || !gotDrawsPerRound)
            {
                DisplayHelper.ShowUsage();

                return;
            }

            if (movePreference == MovePreference.Numbers || movePreference == MovePreference.Pictures)
            {
                DisplayHelper.ShowWarning();
            }

            var sw = new Stopwatch();
            sw.Start();

            while (true)
            {
                iterations++;
                var s = new Session(drawsPerRound, movePreference);
                var newWin = s.Start();
                totalWins += newWin;

                var avgWins = Convert.ToInt32(totalWins / iterations);

                if (avgWins <= best && option != "T") continue;

                if (newWin > hi)
                {
                    hi = newWin;
                }

                if (newWin < lo)
                {
                    lo = newWin;
                }

                best = avgWins;

                DisplayHelper.ShowStats(avgWins, drawsPerRound, hi, lo, sw.ElapsedMilliseconds, iterations, newWin, movePreference);

                if (option == "T")
                    break;
            }
        }
    }
}
