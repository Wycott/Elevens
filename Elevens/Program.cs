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
                DisplayHelper.ShowUsage();

                return;
            }

            if (optionName == "Numbers" || optionName == "Pictures")
            {
                DisplayHelper.ShowWarning();
            }

            var sw = new Stopwatch();
            sw.Start();
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

                DisplayHelper.ShowStats(avgWins, drawsPerRound, hi, lo, sw.ElapsedMilliseconds, iterations, newWin, optionName);

                if (option == "T")
                    break;
            }
        }
    }
}
