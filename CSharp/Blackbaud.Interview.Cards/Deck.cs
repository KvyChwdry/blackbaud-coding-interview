namespace Blackbaud.Interview.Cards;

/// <summary>
/// A deck of cards
/// </summary>
public class Deck
{
    private readonly Stack<Card> _stackOfCards;

    /// <summary>
    /// Private constructor for a new deck of <paramref name="cards"/>.
    /// Use Deck.NewDeck() static factory method.
    /// </summary>
    /// <param name="cards"></param>
    private Deck(IEnumerable<Card> cards)
    {
        _stackOfCards = new Stack<Card>(cards);
    }

    /// <summary>
    /// Creates and returns a new deck of cards.
    /// </summary>
    /// <returns></returns>
    public static Deck NewDeck()
    {
        return new Deck(
            Enum.GetValues<Suit>().SelectMany(suit =>
                Enum.GetValues<Rank>().Select(rank =>
                    new Card(rank, suit))
        ));
    }

    /// <summary>
    /// The number of remaining cards in the deck
    /// </summary>
    public int RemainingCards => _stackOfCards.Count;

    /// <summary>
    /// Returns true if there are no remaining cards in the deck
    /// </summary>
    public bool Empty => RemainingCards == 0;

    /// <summary>
    /// Removes the next card from the deck.
    /// </summary>
    /// <returns>The next card from the deck.
    /// Returns null if no cards remain.</returns>
    public Card NextCard()
    {
        if (!Empty)
        {
            var nextCard = _stackOfCards.Pop();
            return nextCard;
        }
        else
        {
            return null;
        }
    }

    /// <summary>
    /// Shuffles the deck using the Fisher-Yates (Knuth) shuffle algorithm.
    /// This provides a uniform random distribution where every permutation is equally likely.
    /// </summary>
    /// <param name="times">The number of times to shuffle the deck. Default is 1.</param>
    public void Shuffle(int times = 1)
    {
        for (int shuffleCount = 0; shuffleCount < times; shuffleCount++)
        {
            // Convert stack to array for in-place shuffling
            var cards = _stackOfCards.ToArray();
            var random = new Random();

            // Fisher-Yates shuffle algorithm
            // Iterate backward through the array, swapping each element with a random element at or before it
            for (int i = cards.Length - 1; i > 0; i--)
            {
                // Generate random index from 0 to i (inclusive)
                int j = random.Next(0, i + 1);
                
                // Swap cards[i] with cards[j]
                (cards[i], cards[j]) = (cards[j], cards[i]);
            }

            // Reconstruct the stack with shuffled cards
            _stackOfCards.Clear();
            foreach (var card in cards)
            {
                _stackOfCards.Push(card);
            }
        }
    }

}
