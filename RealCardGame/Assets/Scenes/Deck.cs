﻿using UnityEngine.UI;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Deck : MonoBehaviour {
    int i, j;
    GameObject Card;
    public List<GameObject> DeckCards = new List<GameObject>();
    public GameObject FakeCardHand, Hand, EndTurnButton;

    public List<int> RanNum = new List<int>();

    public void Start()
    {

        GameObject DrawnCard = (GameObject)Resources.Load("prefabs/Card", typeof(GameObject));

        for (i = 0; i < 30; i++)
        {

            DeckCards.Add(Instantiate(DrawnCard));
            DeckCards[i].transform.SetParent(this.transform);
            DeckCards[i].tag = this.tag;
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




        for (j = 0; j < DeckCards.Count; j++)
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

    


    
    public void OnMouseDown()
    {

        if (DeckCards.Count >= 0)
        {
            
            if (Hand.transform.childCount <= 9)
            {
                Card = DeckCards[DeckCards.Count - 1];
                DeckCards.RemoveAt(DeckCards.Count-1);
                Card.transform.SetParent(Hand.transform);

               // Debug.Log(DeckCards.Count);

                
            }
            else
            {
                Debug.Log("HandFull");
            }
        }
        else
        {
            Debug.Log("U ded");
        }
    }
    
}

