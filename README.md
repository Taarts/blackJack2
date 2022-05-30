# blackJack2

Objectives

    Practice the skills and ideas you have learned so far.
    Effectively use loops, conditionals, and other control structures to implement control flows
    Demonstrate usage of data structures to model resources.

Requirements

Create a single-player blackjack game that plays against the house, i.e., a human player and computer dealer. You are free to create the user interface however you want, but keep it simple for Explorer Mode.

General Rules:

    The game should be played with a standard deck of playing cards (52).

    The house should be dealt two cards, hidden from the player until the house reveals its hand.

    The player should be dealt two cards, visible to the player.

    The player should have a chance to hit (i.e. be dealt another card) until they decide to stop or they bust (i.e. their total is over 21). At which point they lose regardless of the dealer's hand.

    When the player stands, the house reveals its hand and hits (i.e. draw cards) until they have 17 or more.

    If dealer goes over 21 the dealer loses.

    The player should have two choices: "Hit" and "Stand."

    Consider Aces to be worth 11, never 1.

    The app should display the winner. For this mode, the winner is who is closer to a blackjack (21) without going over.

    Ties go to the DEALER

    There should be an option to play again. This should start a new game with a new full deck of 52 shuffled cards and new empty hands for the dealer and the player.

Explorer Mode

    Generate a PEDA plan for your game. Don't worry about the "C"ode yet.
        Redescribe the "P"roblem.
        Demonstrate some "E"xamples of various player and dealer card situations. For example, if the player started with the 4 of clubs and the 5 of diamonds but then hit once to get the ten of spades before staying. Then the dealer revealed the 8 of clubs and the ten of diamonds. What happens, who wins. Do at least six of these types of examples
        Figure out your "D"ata structure
            This should list all of the classes you think you will create and their STATE (properties) and BEHAVIOR (methods). Here is a first hint. You will likely have a Card class that has two properties, a Face and a Suit and one method, Value that will compute how many points the card is worth.
            Read the rest of the problem and figure out what other real world things you want to represent. They should have distinct properties and behaviors.
        Figure out the "A"lgorithm for playing.
            Can you write a step by step algorithm for playing the game?
            You should be able to turn these instructions over to someone else and have them follow them step-by step like a recipe.


            When the dealer has served every player, the dealers face-down card is turned up. If the total is 17 or more, it must stand. If the total is 16 or under, they must take a card. The dealer must continue to take cards until the total is 17 or more, at which point the dealer must stand.

-------------------------------------/ /-------------------------------------------

## P:roblem:

      1. Create a standard deck of playing cards
          - Ace = 11
          - Jack, Queen, King = 10
      2. the house and each player gets dealt two cards each
        - Dealer hand is remain secret

      3. the face value of the cards should exceed 21 for all the players

      4. Dealer & players should have the chance to do these things:
        a) ask for additional cards, until they decide to stop (2 choices)
        b) ask to stick at a value between 17 & 21
      5. if player or dealer scores 21 they win
      6. if a player or dealer goes over 21 they lose
      7. If the player scores higher than the dealer they win
      8. if the dealer and play draw the house wins
      9. there should be an option to play again
      10. the cards should be shuffled for each new hand

      Create a Card Class
      Create a Deck
      Create a Shuffle
      Create a Hand
      Create Dealer
      Create Player

## E:xamples

      1. player: A, 2, req 5 - 18 stick
         dealer: 9, 8, 2 - 19
         dealer wins
      2. P: 10, 6, 5 - 21
         D: 6, 6, 8 - 20
         Player wins
      3. P: 9, 9 - 18 stick
         D: A, 9
         Dealer wins
      4. P: 9, 8 - stick
         D: 7, 10
         D wins

## D:ata Structures

| FACE  | VALUE |
| ----- | ----- |
| 2     | 2     |
| 3     | 3     |
| 4     | 4     |
| 5     | 5     |
| 6     | 6     |
| 7     | 7     |
| 8     | 8     |
| 9     | 9     |
| 10    | 10    |
| JACK  | 10    |
| QUEEN | 10    |
| KING  | 10    |
| ACE   | 11    |

    Nouns in  the P:roblem:
    #DECK
    #CARD
    #HAND
    #PLAYER
    #DEALER

    STATES & BEHAVIORS:
    #CARD
    - Face + Suit
    - Value (behavior)
    #HAND
    - List of cards
    - TotalValue (sum of the list)
    - start with 0
        - return totalValue
        - add card as per instruction from the player/dealer
    Player/Dealer are instances of the class #HAND

#SHUFFLE

- Fisher Yates

  Classes:
  Card - Rank, suit, value
  Deck - 52 cards, 4 suits - Hearts, Spades, Diamonds Clubs in that value order, 13 faces & 10 distinct values
  Behaviour - Deal a card
  <!-- - so 9 of Hearts is worth more than the 9 of clubs -->

  Hands - receive a card (additional to deal) - Dealer - keep track of hands and compare ( each other: >=, == ) ( 21 <=, >< )

## A:lgorithm - grouping IDEAS

    #START
    Create a #CARD class includes suit, face, value
    - allCardsOnDeck
    #DECK - consolidate the #CARDs (can remain a list)
    #SHUFFLE cards (#CARDs Fisher Yates) - allCardsOnDeck (Behavior)
    Behavior - #VALUE
    - if faceValue == 2 - 10 then assign face as value
    - if Jack || Queen || King (faceValue == 10)
    - if Ace (faceValue == 11)

    #Deal (behavior)
      one card to a player
      second card to a player

    #HAND - has to receive 2 cards,
          - add the  value of the cards
          - add card as per instruction from Player/Dealer

    Ask Player if they want to "stick or hit"
    #HIT (behavior)
    - player gets a new card
      - card ++
    - <= 21 && > 16

    #STICK (behavior)
    - decides to stay with current hand

    Dealer: (state)
    - turns face down cards, up
    - if < 16 dealer must take another card
    - If #DEALERHAND >= 17, it must stand.

    #PLAYERWIN
    - if > DEALERHAND <= 21

    #DEALERWIN
    - if >= 17 && <=21 && > #PLAYERHAND
    - else if #DEALERHAND == #PLAYERHAND

    is good While <= 21
    ToLower == "stick"
    Shuffle the deck
    drawn cards are no longer counted in the deck until the hand is finished
    #tie == house win
