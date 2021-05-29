# Intel-WarGame
Game rules reference: [Wikipedia](https://en.wikipedia.org/wiki/War_(card_game))

## Build and run the program

### Setup
Download and install the .NET 5 SDK
https://dotnet.microsoft.com/download/dotnet/5.0

### Run the release build (recommended)
From root directory with `.sln` file.
```shell
dotnet publish -c Release -o publish
dotnet publish/WarGame.dll
```

### Run development environment
From root directory with `.sln` file.
```shell
dotnet run --project ./src/WarGame/WarGame.csproj
```

## Docker
From root directory with `Dockerfile` file.
```shell
docker build . -t wargame
docker run -it wargame
```

## Notes

### Assumptions Made
* Total of exactly two players according to Wikipedia.
* Exactly 52 standard cards are dealt with no Jokers.
* A player immediately loses if they do not have enough cards for war.
* Cards added to the board during war are in alternating order with player 1 first.
  * ie. P1, P2, P1, P2, P1, P2 where P1 is player 1 and P2 is player 2.
* Game is played for both players automatically from program start to finish.

### Corner cases
* The game can potentially last indefinitely depending on how the cards are shuffled. This is handled by ending the game after 2000 turns.

### If given more time
I would have liked to allow for more than two players. At first this was how I attempted to start the assignment but I soon realized that it adds too much complexity and decided to stick with only two players.

Additionally, I think it would be possible to add a GUI for the game with card images.

### Remarks
* For the Dealer class, I wanted to separate Initialization and Shuffle to allow testing of both methods. However, elements in a Queue cannot be directly accessed so I need to convert it to a List first before shuffling. When converting the shuffled List to a Queue, the old Queue is thrown away for garbage collection which may introduce additional memory usage. This can be avoided by skipping the initialization with a Queue and going directly to a shuffled List to Queue.
