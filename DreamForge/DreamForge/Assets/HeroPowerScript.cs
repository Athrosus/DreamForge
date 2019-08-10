using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroPowerScript : MonoBehaviour
{
    public bool Player1Turn;
    public GameObject tempcard1, tempcard2, tempcard3;
    public GameObject ttempcard1, ttempcard2, ttempcard3;
    public int Counter = 0;
    public GameObject DeckP1, DeckP2;
    void Start()
    {
        if (tag == "Player1")
        {
            GetComponent<Button>().onClick.RemoveListener(DeckP2.GetComponent<Deck>().OnMouseDown);
            GetComponent<Button>().onClick.AddListener(DeckP1.GetComponent<Deck>().OnMouseDown);
        }
        if (tag == "Player2")
        {
            GetComponent<Button>().onClick.RemoveListener(DeckP1.GetComponent<Deck>().OnMouseDown);
            GetComponent<Button>().onClick.AddListener(DeckP2.GetComponent<Deck>().OnMouseDown);
        }
        GetComponent<Button>().onClick.AddListener(ArchivistHP);
        GetComponent<Button>().enabled = false;
    }
    private void FixedUpdate()
    {
        Player1Turn = GameObject.Find("EndTurn").GetComponent<MyTurn>().Player1Turn;
    }
    public void ArchivistHP()
    {
        if (tag == "Player1" && 1 <= GameObject.Find("EndTurn").GetComponent<MyTurn>().Player1Mana)
        {
            GameObject.Find("EndTurn").GetComponent<MyTurn>().Player1Mana = GameObject.Find("EndTurn").GetComponent<MyTurn>().Player1Mana - 1;
            GetComponent<Button>().enabled = false;
            Counter = 0;
            for (int i = 1; i < 4; i++)
            {
                if (Counter == 0)
                {
                    DeckP1.transform.GetChild(DeckP1.transform.childCount - i).GetComponent<CardDisplay>().IsRevealed = true;
                }
                if (Counter == 1)
                {
                    DeckP1.transform.GetChild(DeckP1.transform.childCount - i).GetComponent<CardDisplay>().IsRevealed = true;
                }
                if (Counter == 2)
                {
                    DeckP1.transform.GetChild(DeckP1.transform.childCount - i).GetComponent<CardDisplay>().IsRevealed = true;
                }
                Counter++;
            }
            GameObject.Find("DeckCardsClose").GetComponent<Button>().onClick.AddListener(P1ArchivistHPButton);
            DeckP1.GetComponent<Deck>().OnMouseDown();
            Counter = 0;
            for (int i = 1; i < 4; i++)
            {
                if (Counter == 0)
                {
                    ttempcard1 = GameObject.Find("CardsInDeck").transform.GetChild(GameObject.Find("CardsInDeck").transform.childCount - i).gameObject;
                }
                if (Counter == 1)
                {
                    ttempcard2 = GameObject.Find("CardsInDeck").transform.GetChild(GameObject.Find("CardsInDeck").transform.childCount - i).gameObject;
                }
                if (Counter == 2)
                {
                    ttempcard3 = GameObject.Find("CardsInDeck").transform.GetChild(GameObject.Find("CardsInDeck").transform.childCount - i).gameObject;
                }
                Counter++;
                GameObject.Find("CardsInDeck").transform.GetChild(GameObject.Find("CardsInDeck").transform.childCount - i).GetComponent<BoxCollider2D>().enabled = true;
            }
            Counter = 0;
            foreach (Transform card in DeckP1.transform)
            {
                if (Counter == DeckP1.transform.childCount - 1)
                {
                    tempcard1 = card.gameObject;
                }
                if (Counter == DeckP1.transform.childCount - 2)
                {
                    tempcard2 = card.gameObject;
                }
                if (Counter == DeckP1.transform.childCount - 3)
                {
                    tempcard3 = card.gameObject;
                }
                Counter++;
            }
        }
        if (tag == "Player2" && 1 <= GameObject.Find("EndTurn").GetComponent<MyTurn>().Player2Mana)
        {
            GameObject.Find("EndTurn").GetComponent<MyTurn>().Player2Mana = GameObject.Find("EndTurn").GetComponent<MyTurn>().Player2Mana - 1;
            GetComponent<Button>().enabled = false;
            Counter = 0;
            for (int i = 1; i < 4; i++)
            {
                if (Counter == 0)
                {
                    DeckP2.transform.GetChild(DeckP2.transform.childCount - i).GetComponent<CardDisplay>().IsRevealed = true;
                }
                if (Counter == 1)
                {
                    DeckP2.transform.GetChild(DeckP2.transform.childCount - i).GetComponent<CardDisplay>().IsRevealed = true;
                }
                if (Counter == 2)
                {
                    DeckP2.transform.GetChild(DeckP2.transform.childCount - i).GetComponent<CardDisplay>().IsRevealed = true;
                }
                Counter++;
            }
            GameObject.Find("DeckCardsClose").GetComponent<Button>().onClick.AddListener(P2ArchivistHPButton);
            DeckP2.GetComponent<Deck>().OnMouseDown();
            Counter = 0;
            for (int i = 1; i < 4; i++)
            {
                if (Counter == 0)
                {
                    ttempcard1 = GameObject.Find("CardsInDeck").transform.GetChild(GameObject.Find("CardsInDeck").transform.childCount - i).gameObject;
                }
                if (Counter == 1)
                {
                    ttempcard2 = GameObject.Find("CardsInDeck").transform.GetChild(GameObject.Find("CardsInDeck").transform.childCount - i).gameObject;
                }
                if (Counter == 2)
                {
                    ttempcard3 = GameObject.Find("CardsInDeck").transform.GetChild(GameObject.Find("CardsInDeck").transform.childCount - i).gameObject;
                }
                Counter++;
                GameObject.Find("CardsInDeck").transform.GetChild(GameObject.Find("CardsInDeck").transform.childCount - i).GetComponent<BoxCollider2D>().enabled = true;
            }
            Counter = 0;
            foreach (Transform card in DeckP2.transform)
            {
                if (Counter == DeckP2.transform.childCount - 1)
                {
                    tempcard1 = card.gameObject;
                }
                if (Counter == DeckP2.transform.childCount - 2)
                {
                    tempcard2 = card.gameObject;
                }
                if (Counter == DeckP2.transform.childCount - 3)
                {
                    tempcard3 = card.gameObject;
                }
                Counter++;
            }
        }
    }
    public void P1ArchivistHPButton()
    {
        int Position1, Position2, Position3;
        Position1 = GameObject.Find("P1HeroPower").GetComponent<HeroPowerScript>().ttempcard1.transform.GetSiblingIndex();
        Position2 = GameObject.Find("P1HeroPower").GetComponent<HeroPowerScript>().ttempcard2.transform.GetSiblingIndex();
        Position3 = GameObject.Find("P1HeroPower").GetComponent<HeroPowerScript>().ttempcard3.transform.GetSiblingIndex();
        for (int i = 0; i < 3; i++)
        {
            if (Position1 < Position2 && Position1 < Position3)
            {
                GameObject.Find("P1HeroPower").GetComponent<HeroPowerScript>().tempcard1.transform.SetSiblingIndex(GameObject.Find("P1HeroPower").GetComponent<HeroPowerScript>().ttempcard1.transform.GetSiblingIndex());
                Position1 = int.MaxValue;
                ttempcard1.GetComponent<Collider2D>().enabled = false;
            }
            else if (Position2 < Position3 && Position2 < Position1)
            {
                GameObject.Find("P1HeroPower").GetComponent<HeroPowerScript>().tempcard2.transform.SetSiblingIndex(GameObject.Find("P1HeroPower").GetComponent<HeroPowerScript>().ttempcard2.transform.GetSiblingIndex());
                Position2 = int.MaxValue;
                ttempcard2.GetComponent<Collider2D>().enabled = false;
            }
            else if (Position3 < Position2 && Position3 < Position1)
            {
                GameObject.Find("P1HeroPower").GetComponent<HeroPowerScript>().tempcard3.transform.SetSiblingIndex(GameObject.Find("P1HeroPower").GetComponent<HeroPowerScript>().ttempcard3.transform.GetSiblingIndex());
                Position3 = int.MaxValue;
                ttempcard3.GetComponent<Collider2D>().enabled = false;
            }
        }
    }
    public void P2ArchivistHPButton()
    {
        int Position1, Position2, Position3;
        Position1 = GameObject.Find("P2HeroPower").GetComponent<HeroPowerScript>().ttempcard1.transform.GetSiblingIndex();
        Position2 = GameObject.Find("P2HeroPower").GetComponent<HeroPowerScript>().ttempcard2.transform.GetSiblingIndex();
        Position3 = GameObject.Find("P2HeroPower").GetComponent<HeroPowerScript>().ttempcard3.transform.GetSiblingIndex();
        for (int i = 0; i < 3; i++)
        {
            if (Position1 < Position2 && Position1 < Position3)
            {
                GameObject.Find("P2HeroPower").GetComponent<HeroPowerScript>().tempcard1.transform.SetSiblingIndex(GameObject.Find("P2HeroPower").GetComponent<HeroPowerScript>().ttempcard1.transform.GetSiblingIndex());
                Position1 = int.MaxValue;
                ttempcard1.GetComponent<Collider2D>().enabled = false;
            }
            else if (Position2 < Position3 && Position2 < Position1)
            {
                GameObject.Find("P2HeroPower").GetComponent<HeroPowerScript>().tempcard2.transform.SetSiblingIndex(GameObject.Find("P2HeroPower").GetComponent<HeroPowerScript>().ttempcard2.transform.GetSiblingIndex());
                Position2 = int.MaxValue;
                ttempcard2.GetComponent<Collider2D>().enabled = false;
            }
            else if (Position3 < Position2 && Position3 < Position1)
            {
                GameObject.Find("P2HeroPower").GetComponent<HeroPowerScript>().tempcard3.transform.SetSiblingIndex(GameObject.Find("P2HeroPower").GetComponent<HeroPowerScript>().ttempcard3.transform.GetSiblingIndex());
                Position3 = int.MaxValue;
                ttempcard3.GetComponent<Collider2D>().enabled = false;
            }
        }
    }
}
