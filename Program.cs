using System;
using System.Collections.Generic;

class Card
{
    public string Suit { get; }
    public string Face { get; }

    public Card(string newSuit, string newFace)
    {
        Suit = newSuit;
        Face = newFace;
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

    public void Shuffle() /* - method to shuffle
    
     the deck  */
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

            // Deal two cards to a dealer’s hand
            var dealerHand = new List<Card>();
            dealerHand.Add(deck.Deal());
            dealerHand.Add(deck.Deal());
            Console.WriteLine(dealerHand[0].Description());
            Console.WriteLine(dealerHand[1].Description());

            Console.WriteLine(deck.Cards.Count);

            // Sum the value of the hand
            // Ask user if they want to hit or stand.

            // If they want to hit, deal a card from the deck and add it to playerHand.
            // If they go over 21, end the game.
            // Repeat until they stand.
            // -	Once they stand, reveal computerHand.
            // computerHand will hit until greater than or equal to 17.
            // Compare computerHand and playerHand to see who wins.
            // If a tie, computer wins.
            // Ask if player wants to play again.
            //    Create new game that clears both hands and reshuffles the deck.
        }
    }
}
