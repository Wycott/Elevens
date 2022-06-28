# Elevens

<!-- <a href="https://dotnet.microsoft.com/download" alt=".NET target"><img alt=".NET target" src="https://img.shields.io/badge/dynamic/xml?color=%23512bd4&label=.NET%20target&query=%2F%2FTargetFramework%5B1%5D&url=https%3A%2F%2Fraw.githubusercontent.com%2FWycott%2FElevens%2Fmain%2FElevens%2FElevensRig.csproj" title="Go To .NET Download"></a> -->
<a href="https://docs.microsoft.com/en-us/dotnet/csharp/"><img src="https://raw.githubusercontent.com/Wycott/RepositoryResources/main/Graphics/language-csharp.svg" title="Language C#" alt="Language C#"></a>
<a href="https://en.wikipedia.org/wiki/BSD_licenses#3-clause_license_(%22BSD_License_2.0%22,_%22Revised_BSD_License%22,_%22New_BSD_License%22,_or_%22Modified_BSD_License%22)"><img src="https://raw.githubusercontent.com/Wycott/RepositoryResources/main/Graphics/license-BSD--3-green.svg" title="BSD-3" alt="BSD-3"></a>
<a href="https://github.com/Wycott/RepositoryResources/blob/main/REPOTYPE.md"><img src="https://raw.githubusercontent.com/Wycott/RepositoryResources/main/Graphics/repo%20type-Game-yellow.svg" title="Game" alt="Game"></a>

Engine for checking the odds of an Elevens solitaire game being won. It is believed that the game comes out (i.e. the player wins) about 10% of the time. 

## Rules

For the rules of Elevens, see here:
https://en.wikipedia.org/wiki/Elevens

## Parameters

Two positional parameters are supported:

1) The number of games to play in each iteration
2) The mode (P, N or T) - see below

Example:

```
ElevensRig.exe 100 P

ElevensRig.exe 5000 N

ElevensRig.exe 250 T
```
## Modes

P - Picture cards are checked first

N - Non-picture cards are checked first

T - Test mode. See the game being played. Stops at the end of the iteration. Alternates between P & N mode.

**N.B. modes P & N run forever!** Press CTRL-C to stop. Suggest using at least 10 games for each of these modes.

_Last updated: 10 June 2022_


