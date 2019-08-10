using UnityEngine.UI;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Deck : MonoBehaviour {
    GameObject Card;
    public List<GameObject> DeckCards = new List<GameObject>();
    public GameObject FakeCardHand, Hand, EndTurnButton;

    public List<int> RanNum = new List<int>();

    public void Start()
    {
        GameObject DrawnCard = (GameObject)Resources.Load("prefabs/Card", typeof(GameObject));
        for (int BlankCards = 0; BlankCards < 30; BlankCards++)
        {
            DeckCards.Add(Instantiate(DrawnCard));
            DeckCards[BlankCards].transform.SetParent(this.transform);
            DeckCards[BlankCards].tag = this.tag;
        }
        int startNumber = 0;
        int endNumber = 29;
        List<int> numberPot = new List<int>();
        for (int i = startNumber; i < endNumber + 1; i++)
        {
            numberPot.Add(i);
        }
        while (numberPot.Count > 0)
        {
            int index = Random.Range(0, numberPot.Count);
            int randomNumber = numberPot[index];
            numberPot.RemoveAt(index);
            RanNum.Add(randomNumber);
        }
        if (GameObject.Find("MadeDeck1") != null)
        {
            for (int j = 0; j < DeckCards.Count; j++)
            {
                if (this.tag == "Player1")
                {
                    DeckCards[RanNum[j]].GetComponent<CardDisplay>().card = GameObject.Find("MadeDeck1").GetComponent<DeckList>().CardsInDeck[j];
                }
                else
                {
                    DeckCards[RanNum[j]].GetComponent<CardDisplay>().card = GameObject.Find("MadeDeck2").GetComponent<DeckList>().CardsInDeck[j];
                }
            }
        }
        DrawACard(4);
    }
    public void OnMouseDown()
    {
        for (int i = 0; i < GameObject.Find("CardsInDeck").transform.childCount; i++)
        {
            Destroy(GameObject.Find("CardsInDeck").transform.GetChild(i).gameObject);
        }
        GameObject.Find("DeckCards").transform.SetParent(GameObject.Find("Canvas").transform);
        GameObject.Find("DeckCards").transform.SetAsLastSibling();

        foreach (Transform cardindeck in transform)
        {
            GameObject tempcard = Instantiate((GameObject)Resources.Load("prefabs/DeckCard"), GameObject.Find("CardsInDeck").transform);
            tempcard.GetComponent<CardDisplay>().card = cardindeck.GetComponent<CardDisplay>().card;
            tempcard.GetComponent<CardDisplay>().IsRevealed = cardindeck.GetComponent<CardDisplay>().IsRevealed;
            tempcard.GetComponent<drag>().StartParent = GameObject.Find("HandP1").transform; //Both Player 1 and 2 give DeckCards HandP1 as the Startparent becaus I suck at programming !
        }
    }
    public void DrawACard( int numOfCardsDrawn)
    {
        for (int i = 0; i < numOfCardsDrawn; i++)
        {
            if (DeckCards.Count >= 0)
            {
                if (Hand.transform.childCount <= 9)
                {
                    Card = transform.GetChild(DeckCards.Count - 1).gameObject;
                    DeckCards.RemoveAt(DeckCards.Count - 1);
                    Card.transform.SetParent(Hand.transform);
                    Card.GetComponent<CardDisplay>().EachWhenDrawnEffect = 0;
                    Card.GetComponent<CardDisplay>().WhenDrwanEffects();
                    //Debug.Log("You drew "+Card.GetComponent<CardDisplay>().nameText.text + " which is the "+ DeckCards.Count+" card in your deck.");   //Starts at 29
                }
                else
                {
                    Debug.Log("HandFull");
                    break;
                }
            }
            else
            {
                Debug.Log("U ded");
            }
        }
    }
}

