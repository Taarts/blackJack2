using System;
using System.Collections.Generic;

class Card
{
    public string Suit { get; }
    public string Face { get; }
    // public int Value { get; }

    public int Value()
    {
        switch (Face)
        {
            case "2":
            case "3":
            case "4":
            case "5":
            case "6":
            case "7":
            case "8":
            case "9":
            case "10":
                return int.Parse(Face);

            case "Jack":
            case "Queen":
            case "King":
                return 10;

            case "Ace":
                return 11;

            default:
                return 0;
        }
    }
    public Card(string newSuit, string newFace)
    {
        Suit = newSuit;
        Face = newFace;
        // Value = Convert.ToInt32(value);
    }
    public string Description()
    {
        return $"{Face} of {Suit}";
    }
}
class Deck
{
    public List<Card> Cards { get; set; }

    public Deck()
    {
        //       Create a deck of 52 cards.
        Cards = new List<Card>();
        var suits = new List<string>() { "Hearts", "Spades", "Diamonds", "Clubs" };
        var faces = new List<string>() { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };
        // var values = new List<int>() { 11, 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10 };

        //        Shuffle the Deck 
        foreach (var suit in suits)
        {
            //   Make a loop that goes through all the 'faces'
            //   add newly formed string to the end of the deck list - For Suit = Clubs

            foreach (var face in faces)
            {
                //   Make a loop that goes through all the faces
                //   for each faces, make a new string of the form $"{face} of spades"
                //   add newly formed string to the end of the deck list
                var card = new Card(suit, face);
                // Console.WriteLine(card);
                Cards.Add(card);
            }
        }
    }

    public void Shuffle() /* - method to shuffle the deck  */
    {
        var numberOfCards = Cards.Count; /*<---works*/

        //   // for rightIndex from numberOfCards - 1 down to 1 do:
        for (var rightIndex = numberOfCards - 1; rightIndex >= 1; rightIndex--)
        {
            //  // leftIndex = random integer that is greater than or equal to 0 and LESS than rightIndex. 
            // var randomNumberGenerator = new Random();
            // var randomNumber = randomNumberGenerator.Next(956);
            var randomNumberGenerator = new Random();
            var leftIndex = randomNumberGenerator.Next(rightIndex);
            // // See the section "How do we get a random integer")

            // // Now swap the values at rightIndex and leftIndex by doing this:
            // leftCard = the value from deck[leftIndex]
            var leftCard = Cards[leftIndex];
            // rightCard = the value from deck[rightIndex]
            var rightCard = Cards[rightIndex];
            Cards[rightIndex] = leftCard;
            Cards[leftIndex] = rightCard;
        }
    }
    public Card Deal()
    {
        var card = Cards[0];
        Cards.Remove(card);

        return card;

    }
    // public class Hand
    // {
    //     public List<Card> newHand { get; }
    //     public Hand()
    //     {
    //         newHand = new List<Card>();
    // newHand.Add(deck.card());
    // }
    // Hand = new List<Card>();
    // Console.WriteLine()
    // playerHand.Insert(0, card);
    // var dealerHand = new List<Card>();

    // }
    // public void AddCard()
}

namespace blackJack2
{

    class Program
    {
        static void Main(string[] args)
        {
            var continueGame = true;
            while (continueGame)
            {

                var deck = new Deck();

                deck.Shuffle();
                // Console.WriteLine(deck.Deal().Description());
                // Console.WriteLine(deck.Deal().Description());
                Console.WriteLine(deck.Cards.Count);

                // Deal two cards to a player’s hand
                var playerHand = new List<Card>();
                playerHand.Add(deck.Deal());
                playerHand.Add(deck.Deal());
                Console.WriteLine(playerHand[0].Description());
                Console.WriteLine(playerHand[1].Description());

                // foreach (Card card in playerHand)
                // {
                //     Console.WriteLine($"{card.Face} of {card.Suit}");
                // }

                /* we'll get back to having both hands when the values are assigned*/

                // // Deal two cards to a dealer’s hand
                var dealerHand = new List<Card>();
                dealerHand.Add(deck.Deal());
                dealerHand.Add(deck.Deal());


                Console.WriteLine(deck.Cards.Count);

                // Sum the value of the hand
                var score = 0;
                foreach (Card card in playerHand)
                {
                    score += card.Value();
                }
                Console.WriteLine($"The score of your hand is {score}");

                // Ask user if they want to hit or stand.
                var Answer = "n";
                do
                {
                    Console.WriteLine("Do you want another card? Y/N");
                    Answer = Console.ReadLine();
                    if (Answer == "Y" || Answer == "y")
                    {
                        playerHand.Add(deck.Deal());
                        Console.WriteLine(playerHand[0].Description());
                        Console.WriteLine(playerHand[1].Description());
                        Console.WriteLine(playerHand[2].Description());
                    }
                    // else
                    // {
                    //     Console.WriteLine("You've chosen to STAND");

                    //     Console.WriteLine($"The score of your hand is {score}");
                    // }
                    score = 0;
                    foreach (Card card in playerHand)
                    {
                        score += card.Value();
                    }
                    // Console.WriteLine(score);
                    Console.WriteLine($"The score of your hand is {score}");
                    // return score;
                } while (score <= 21 && Answer == "Y");

                if (score > 21)
                {
                    Console.WriteLine("Dealer Wins");

                }

                //   Dealer: (state)
                // - if < 16 dealer must take another card
                // - If #DEALERHAND >= 17, it must stand.
                var dealerScore = 0;
                foreach (Card card in dealerHand)
                {
                    dealerScore += card.Value();
                }
                Console.WriteLine(dealerHand[0].Description());
                Console.WriteLine(dealerHand[1].Description());

                while (dealerScore < 17)
                {
                    dealerHand.Add(deck.Deal());
                    dealerScore = 0;
                    foreach (Card card in dealerHand)
                    {
                        dealerScore += card.Value();
                    }
                    Console.WriteLine(dealerHand[dealerHand.Count - 1].Description());
                }
                if (dealerScore > 21)
                {
                    Console.WriteLine("House Loses");
                }

                if (score <= 21 && score > dealerScore)
                {
                    Console.WriteLine("Suck it, I wim");
                }
                else
                {
                    Console.WriteLine("Go home you're drunk");
                }
                Console.WriteLine("Do you want to play again? ");
                // #PLAYERWIN
                // - if > DEALERHAND <= 21

                // If they want to hit, deal a card from the deck and add it to playerHand.
                // If they go over 21, end the game.
                // Repeat until they stand.
                // -	Once they stand, reveal computerHand.
                // computerHand will hit until greater than or equal to 17.
                // Compare computerHand and playerHand to see who wins.
                // If a tie, computer wins.
                // Ask if player wants to play again.
                //    Create new game that clears both hands and reshuffles the deck.

                continueGame = Console.ReadLine() == "Y";
            }
        }
    }
}
