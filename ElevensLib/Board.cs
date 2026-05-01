/*
Copyright (c) 2021-2026, Rob Docherty
All rights reserved.

This source code is licensed under the BSD-style license found in the
LICENSE file in the root directory of this source tree. 
*/

using static System.Console;

namespace ElevensLib
{
    public class Board
    {
        private const int NumberOfCells = 9;

        private List<Card> Deck { get; set; }
        private readonly Card[] theBoard = new Card[NumberOfCells];
        private MovePreference MovePreference { get; }
        private bool ChooseNumbers { get; set; }

        public Board(MovePreference movePreference)
        {
            MovePreference = movePreference;
            Deck = [];
            Init();
        }

        public int Move()
        {
            FindNextMove();

            return Deck.Count;
        }

        private void Init()
        {
            MakeDeck();
            Deal();
        }

        private void MakeDeck()
        {
            Deck = new List<Card>(52);

            for (var currentSuit = 0; currentSuit < 4; currentSuit++)
                for (var currentRank = 1; currentRank < 14; currentRank++)
                    Deck.Add(new Card { Rank = currentRank, Suit = currentSuit });

            // Fisher-Yates shuffle — O(n) instead of O(n²)
            var rng = Random.Shared;
            for (var i = Deck.Count - 1; i > 0; i--)
            {
                var j = rng.Next(i + 1);
                (Deck[i], Deck[j]) = (Deck[j], Deck[i]);
            }
        }

        private void Deal()
        {
            for (var b = 0; b < NumberOfCells; b++)
            {
                var cardToPlay = DealCard();

                if (cardToPlay != null)
                {
                    theBoard[b] = cardToPlay;
                }
            }
        }

        private Card? DealCard()
        {
            if (Deck.Count == 0)
            {
                return null;
            }

            // Remove from end — O(1) instead of O(n)
            var last = Deck.Count - 1;
            var card = Deck[last];
            Deck.RemoveAt(last);
            return card;
        }

        private void FindNextMove()
        {
            if (MovePreference == MovePreference.Alternating)
            {
                DumpBoard();
            }

            switch (MovePreference)
            {
                case MovePreference.Pictures:
                    var retVal1 = AnalysePictures();
                    if (!retVal1)
                    {
                        AnalyseNumbers();
                    }
                    break;
                case MovePreference.Numbers:
                    var retVal2 = AnalyseNumbers();
                    if (!retVal2)
                    {
                        AnalysePictures();
                    }
                    break;
                default:
                    if (ChooseNumbers)
                    {
                        var retVal3 = AnalyseNumbers();
                        if (!retVal3)
                        {
                            AnalysePictures();
                        }
                    }
                    else
                    {
                        var retVal4 = AnalysePictures();

                        if (!retVal4)
                        {
                            AnalyseNumbers();
                        }
                    }
                    ChooseNumbers = !ChooseNumbers;
                    break;
            }
        }

        public void DumpBoard()
        {
            if (MovePreference != MovePreference.Alternating)
            {
                return;
            }

            for (var c = 0; c < NumberOfCells; c++)
            {
                Write($"[{theBoard[c].Name}]");

                if ((c + 1) % 3 == 0)
                {
                    WriteLine();
                }
            }

            WriteLine();
            WriteLine($"{Deck.Count} cards left");
            WriteLine();
        }

        private bool AnalyseNumbers()
        {
            var retVal = false;

            for (var b = 0; b < NumberOfCells; b++)
            {
                var rank = theBoard[b].Rank;

                if (rank >= 11)
                {
                    continue;
                }

                // Start at b+1 to avoid processing each pair twice
                for (var o = b + 1; o < NumberOfCells; o++)
                {
                    var otherRank = theBoard[o].Rank;

                    if (otherRank >= 11)
                    {
                        continue;
                    }

                    if (rank + otherRank != 11)
                    {
                        continue;
                    }

                    DealCardAtPosition(o);
                    DealCardAtPosition(b);

                    retVal = true;
                }
            }

            return retVal;
        }

        private bool AnalysePictures()
        {
            int jacks = 0, queens = 0, kings = 0;

            // Single pass instead of three separate LINQ scans
            foreach (var card in theBoard)
            {
                if (card.Rank == 11) jacks++;
                else if (card.Rank == 12) queens++;
                else if (card.Rank == 13) kings++;
            }

            if (jacks == 0 || queens == 0 || kings == 0)
            {
                return false;
            }

            DealOverRank(11, 1);
            DealOverRank(12, 1);
            DealOverRank(13, 1);

            return true;
        }

        private void DealOverRank(int rank, int times)
        {
            for (var b = 0; b < NumberOfCells; b++)
            {
                if (theBoard[b].Rank != rank)
                {
                    continue;
                }

                DealCardAtPosition(b);
                times--;

                if (times == 0)
                {
                    break;
                }
            }
        }

        private void DealCardAtPosition(int pos)
        {
            var newCard = DealCard();
            if (newCard != null)
            {
                theBoard[pos] = newCard;
            }
        }
    }
}
