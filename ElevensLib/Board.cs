/*
Copyright (c) 2021, Rob Docherty
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
        private string Option { get; }
        private bool ChooseNumbers { get; set; }

        public Board(string option)
        {
            Option = option;
            Deck = new List<Card>();
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
            var shuffler = new List<Card>();
            for (var currentSuit = 0; currentSuit < 4; currentSuit++)
            {
                for (var currentRank = 1; currentRank < 14; currentRank++)
                {
                    var newCard = new Card() { Rank = currentRank, Suit = currentSuit, Identity = Guid.NewGuid().ToString() };
                    shuffler.Add(newCard);
                    Deck = shuffler.OrderBy(x => x.Identity).ToList();
                }
            }
        }

        private void Deal()
        {
            for (var b = 0; b < NumberOfCells; b++)
            {
                theBoard[b] = DealCard();
            }
        }

        private Card DealCard()
        {
            if (Deck.Count <= 0) return new Card { Rank = 0, Suit = 0 };

            var boardCard = Deck[0];
            Deck.RemoveAt(0);

            return boardCard;
        }

        private void FindNextMove()
        {
            DumpBoard();

            switch (Option)
            {
                case "P":
                    var retVal1 = AnalysePictures();
                    if (!retVal1)
                    {
                        AnalyseNumbers();
                    }
                    break;
                case "N":
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
            if (Option != "T") return;

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

                if (rank >= 11) continue;

                for (var o = 0; o < NumberOfCells; o++)
                {
                    if (o == b) continue;

                    var otherRank = theBoard[o].Rank;

                    if (otherRank >= 11) continue;

                    if (rank + otherRank != 11) continue;

                    DealCardAtPosition(o);
                    DealCardAtPosition(b);

                    retVal = true;
                }
            }

            return retVal;
        }

        private bool AnalysePictures()
        {
            var jacks = 0;
            var queens = 0;
            var kings = 0;

            var retVal = false;

            for (var i = 11; i < 14; i++)
            {
                var suitCount = theBoard.Count(x => x.Rank == i);

                switch (i)
                {
                    case 11:
                        jacks = suitCount;
                        break;
                    case 12:
                        queens = suitCount;
                        break;
                    case 13:
                        kings = suitCount;
                        break;
                }

                if (jacks <= 0 || queens <= 0 || kings <= 0)
                {
                    continue;
                }

                DealOverRank(11, 1);
                DealOverRank(12, 1);
                DealOverRank(13, 1);

                retVal = true;
            }

            return retVal;
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
            theBoard[pos] = DealCard();
        }
    }
}
