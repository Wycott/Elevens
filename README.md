# Elevens

<a href="https://docs.microsoft.com/en-us/dotnet/csharp/"><img src="https://raw.githubusercontent.com/Wycott/RepositoryResources/main/Graphics/language-csharp.svg" title="Language C#" alt="Language C#"></a>
<a href="https://github.com/Wycott/RepositoryResources/blob/main/REPOTYPE.md"><img src="https://raw.githubusercontent.com/Wycott/RepositoryResources/main/Graphics/repo%20type-Game-yellow.svg" title="Game" alt="Game"></a>
<img src="https://img.shields.io/badge/.NET_Core-8-red">

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

---

*Last updated: 4 December 2023*



