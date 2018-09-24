# Scramblies

## Author
https://www.codewars.com/users/FrankK

## Source
https://www.codewars.com/kata/sortable-poker-hands/csharp

## Description

A famous casino is suddenly faced with a sharp decline of their revenues. They decide to offer Texas hold'em also online. Can you help them by writing an algorithm that can rank poker hands?

Task:

 - Create a poker hand that has a constructor that accepts a string containing 5 cards:
    ```
    PokerHand hand = new PokerHand("KS 2H 5C JD TD");
    ```
 - The characteristics of the string of cards are:
    - A space is used as card seperator
    - Each card consists of two characters
    - The first character is the value of the card, valid characters are: 
    ```
    2, 3, 4, 5, 6, 7, 8, 9, T(en), J(ack), Q(ueen), K(ing), A(ce)
    ```
    - The second character represents the suit, valid characters are: 
    ```
    S(pades), H(earts), D(iamonds), C(lubs)
    ```
 - The poker hands must be sortable by rank, the highest rank first:
    ```
    var hands = new List<PokerHand> 
    { 
        new PokerHand("KS 2H 5C JD TD"),
        new PokerHand("2C 3C AC 4C 5C")
    };
    hands.Sort();
    ```
 - Apply the Texas Hold'em rules for ranking the cards.
 - There is no ranking for the suits.
 - An ace can either rank high or rank low in a straight or straight flush. Example of a straight with a low ace:
    ```
    "5C 4D 3C 2S AS"
    ```