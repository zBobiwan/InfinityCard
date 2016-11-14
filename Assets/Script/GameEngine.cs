using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

public class GameEngine : MonoBehaviour
{
    public CardDefinition[] Definition;
    public Card[] PlayableCards;
    public Card[] TopCards;
    public Card[] MiddleCards;

    private List<GameplayCard> MyDeck = new List<GameplayCard>();
    private List<GameplayCard> OtherDeck = new List<GameplayCard>();

    private System.Random Random = new System.Random();
    private bool IsInit = false;
     
	// Use this for initialization
	void Start ()
    {
        InitDeck(MyDeck);
        InitDeck(OtherDeck);

        StartCoroutine(ShowCard());
    }

    // Update is called once per frame
    void Update ()
    {
	}

    public IEnumerator ShowCard()
    {
        for (int i = 0; i < 5; ++i)
        {
            yield return new WaitForSeconds(1);
            PlayableCards[i].Assign(MyDeck[i]);
            PlayableCards[i].Show = true;
        }

        IsInit = true;
    }

    public void InitDeck(List<GameplayCard> deck)
    {
        List<GameplayCard> baseDeck = new List<GameplayCard>();
        foreach (CardDefinition def in Definition)
        {
            baseDeck.Add(new GameplayCard(CardDefinition.Rarity.Common, 1, def));
        }

        while (baseDeck.Count != 0)
        {
            int randomIndex = Random.Next(baseDeck.Count);
            deck.Add(baseDeck[randomIndex]);
            baseDeck.RemoveAt(randomIndex);
        }
    }

    public void OnClick(Card card)
    {
        if (!IsInit)
        {
            return;
        }

        if (PlayableCards.Contains(card))
        {

        }
    }
}
