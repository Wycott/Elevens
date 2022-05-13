# Elevens

<a href="https://dotnet.microsoft.com/download" alt=".NET target"><img alt=".NET target" src="https://img.shields.io/badge/dynamic/xml?color=%23512bd4&label=target&query=%2F%2FTargetFramework%5B1%5D&url=https%3A%2F%2Fraw.githubusercontent.com%2FZacharyPatten%2FTowel%2Fmain%2FSources%2FTowel%2FTowel.csproj&logo=.net" title="Go To .NET Download"></a>

Engine for checking the odds of an Elevens solitaire game being won. It is believed that the game comes out (i.e. the player wins) about 10% of the time. 

## Rules

For the rules of Elevens, see here:
https://en.wikipedia.org/wiki/Elevens

## Parameters

Two positional parameters are supported:

1) The number of games to play in each iteration
2) The mode (P, N or T) - see below

Example:

ElevensRig.exe 100 P

ElevensRig.exe 5000 N

ElevensRig.exe 250 T

## Modes

P - Picture cards are checked first

N - Non-picture cards are checked first

T - Test mode. See the game being played. Stops at the end of the iteration. Alternates between P & N mode.

N.B. modes P & N run forever. Press CTRL-C to stop.


