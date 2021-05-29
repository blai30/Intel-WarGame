# Intel-WarGame
Reference: [Wikipedia](https://en.wikipedia.org/wiki/War_(card_game))

## Setup

## Build

## Run

## Docker
```bash
docker compose up
```

## Assumptions Made
* Total of exactly two players according to Wikipedia.
* Exactly 52 standard cards are dealt with no Jokers.
* A player immediately loses if they do not have enough cards for war.
* Cards added to the board during war are in alternating order with player 1 first.
    * ie. 1A, 2A, 1B, 2B, 1C, 2C where 1 and 2 are the player and A, B, and C are that player's card.

## Corner cases
* The game can potentially last indefinitely depending on how the cards are shuffled. This is handled by ending the game after 2000 turns.

## If given more time
I would have liked to allow for more than two players. At first this was how I attempted to start the assignment but I soon realized that it adds too much complexity and decided to stick with only two players.

## Notes
* For the Dealer class, I wanted to separate Initialization and Shuffle to allow testing of both methods. However, elements in a Queue cannot be directly accessed so I need to convert it to a List first before shuffling. When converting the shuffled List to a Queue, the old Queue is thrown away for garbage collection which may introduce additional memory usage. This can be avoided by skipping the initialization with a Queue and going directly to a shuffled List to Queue.
