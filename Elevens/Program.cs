using System.Diagnostics;
using ElevensLib;
using static System.Console;

namespace ElevensRig
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                DisplayUsage();

                return;
            }

            long totalWins = 0;
            long iterations = 0;
            var best = 0;
            var hi = int.MinValue;
            var lo = int.MaxValue;
            var sw = new Stopwatch();
            sw.Start();
            var option = args[1].ToUpper();
            var optionName = string.Empty;            

            bool gotDrawsPerRound = int.TryParse(args[0], out int drawsPerRound);

            switch (option)
            {
                case "N":
                    optionName = "Numbers";
                    break;
                case "P":
                    optionName = "Pictures";
                    break;
                case "T":
                    optionName = "Alternating";
                    break;
            }

            if (optionName == string.Empty || !gotDrawsPerRound)
            {
                DisplayUsage();

                return;
            }

            while (true)
            {
                iterations++;
                var s = new Session(drawsPerRound, option);
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

                WriteLine($"Avg. number of wins: {avgWins}");
                WriteLine($"Deals per round    : {drawsPerRound}");
                WriteLine($"Best               : {hi}");
                WriteLine($"Worst              : {lo}");
                WriteLine($"After              : {sw.ElapsedMilliseconds / 1000} seconds");
                WriteLine($"Iterations         : {iterations}");
                WriteLine($"Last win           : {newWin}");
                WriteLine($"Prefer             : {optionName}");
                WriteLine(new string('-', 80));

                if (option == "T")
                    break;
            }            
        }

        private static void DisplayUsage()
        {
            WriteLine();
            WriteLine("Expected 2 parameters:");
            WriteLine("\t1) Number of games for each iteration and 2) The mode (P, N or T) e.g.");
            WriteLine("\t\tElevensRig.exe 100 P");
            WriteLine("\t\tElevensRig.exe 50 N");
            WriteLine("\t\tElevensRig.exe 10 T");
            WriteLine();
            WriteLine("Suggest using at least 10 games for modes N & P");
        }
    }
}
