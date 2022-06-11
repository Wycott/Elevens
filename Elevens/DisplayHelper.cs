/*
Copyright (c) 2021-2022, Rob Docherty
All rights reserved.

This source code is licensed under the BSD-style license found in the
LICENSE file in the root directory of this source tree. 
*/

using static System.Console;
using ElevensLib;

namespace ElevensRig
{
    internal static class DisplayHelper
    {
        internal static void ShowStats(int avgWins, int drawsPerRound, int hi, int lo, long elapsedMilliseconds, long iterations, int newWin, MovePreference movePreference)
        {
            WriteLine($"Avg. number of wins: {avgWins}");
            WriteLine($"Deals per round    : {drawsPerRound}");
            WriteLine($"Best               : {hi}");
            WriteLine($"Worst              : {lo}");
            WriteLine($"After              : {elapsedMilliseconds / 1000} seconds");
            WriteLine($"Iterations         : {iterations}");
            WriteLine($"Last win           : {newWin}");
            WriteLine($"Prefer             : {movePreference}");
            WriteLine(new string('-', 80));
        }

        internal static void ShowWarning()
        {
            WriteLine("WARNING: This mode runs forever!");
            WriteLine("New output will only be displayed if the average number of games won per iteration changes.");
            WriteLine("Press any key to continue or CTRL-C to exit");
            ReadKey(true);
            WriteLine("");
        }        

        internal static void ShowUsage()
        {
            WriteLine();
            WriteLine("Expected 2 parameters:");
            WriteLine("\t1) Number of games for each iteration and 2) The mode (P, N or T) e.g.");
            WriteLine("\t\tElevensRig.exe 100 P");
            WriteLine("\t\tElevensRig.exe 50 N");
            WriteLine("\t\tElevensRig.exe 10 T");
            WriteLine();
            WriteLine("Suggest using at least 10 games for modes N & P.");
        }
    }
}
