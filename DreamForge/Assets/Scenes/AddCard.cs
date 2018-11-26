using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AddCard : MonoBehaviour {

    public CardStats ThisCard;
    public Text NumOfCopys;
    public List<GameObject> RemovePlateClone = new List<GameObject>();
    public GameObject FakeRemovePlate;
    public int CountOfSameCard = 0;

    public void Start()
    {
    }
    public void PickThisCard()
    {
        /* j = 0;
         for (int w = 0; w < GameObject.Find("MadeDeck").GetComponent<DeckList>().CardsInDeck.Count; w++)
         {
             if (GameObject.Find("MadeDeck").GetComponent<DeckList>().CardsInDeck[w].name == ThisCard.name)
             {
                 j++;
             }
         }*/
        CountOfSameCard = RemovePlateClone.Count;
        Scene CurrentScene = SceneManager.GetActiveScene();
        if (this.GetComponent<AddCard>().ThisCard.tire == "Epic" && CountOfSameCard < 1)
        {
            GameObject.Find("DBList").GetComponent<DeckList>().CardsInDeck.Add(ThisCard);
            if (CurrentScene.name == "DeckBuilderP1")
            {
                GameObject.Find("MadeDeck1").GetComponent<DeckList>().CardsInDeck.Add(ThisCard);
            }
            else if (CurrentScene.name == "DeckBuilderP2")
            {
                GameObject.Find("MadeDeck2").GetComponent<DeckList>().CardsInDeck.Add(ThisCard);
            }
            GameObject RemovePlate = (GameObject)Resources.Load("prefabs/RemoveCardButton", typeof(GameObject));
            RemovePlateClone.Add(Instantiate(RemovePlate));
            if (RemovePlateClone[CountOfSameCard] != null)
            {
                RemovePlateClone[CountOfSameCard].GetComponentInChildren<Text>().text = ThisCard.name;
                RemovePlateClone[CountOfSameCard].GetComponent<WhatCard>().NumOfCard = CountOfSameCard;
                RemovePlateClone[CountOfSameCard].GetComponent<WhatCard>().ThisCardForRemoval = ThisCard;
                RemovePlateClone[CountOfSameCard].transform.SetParent(FakeRemovePlate.transform.parent);
            }
        }
        else if (this.GetComponent<AddCard>().ThisCard.tire == "Rare" && CountOfSameCard < 2)
        {
            GameObject.Find("DBList").GetComponent<DeckList>().CardsInDeck.Add(ThisCard);
            if (CurrentScene.name == "DeckBuilderP1")
            {
                GameObject.Find("MadeDeck1").GetComponent<DeckList>().CardsInDeck.Add(ThisCard);
            }
            else if (CurrentScene.name == "DeckBuilderP2")
            {
                GameObject.Find("MadeDeck2").GetComponent<DeckList>().CardsInDeck.Add(ThisCard);
            }
            GameObject RemovePlate = (GameObject)Resources.Load("prefabs/RemoveCardButton", typeof(GameObject));
            RemovePlateClone.Add(Instantiate(RemovePlate));
            if (RemovePlateClone[CountOfSameCard] != null)
            {
                RemovePlateClone[CountOfSameCard].GetComponentInChildren<Text>().text = ThisCard.name;
                RemovePlateClone[CountOfSameCard].GetComponent<WhatCard>().NumOfCard = CountOfSameCard;
                RemovePlateClone[CountOfSameCard].GetComponent<WhatCard>().ThisCardForRemoval = ThisCard;
                RemovePlateClone[CountOfSameCard].transform.SetParent(FakeRemovePlate.transform.parent);
            }
        }
        else if (this.GetComponent<AddCard>().ThisCard.tire == "Common" && CountOfSameCard < 4)
        {
            GameObject.Find("DBList").GetComponent<DeckList>().CardsInDeck.Add(ThisCard);
            if (CurrentScene.name == "DeckBuilderP1")
            {
                GameObject.Find("MadeDeck1").GetComponent<DeckList>().CardsInDeck.Add(ThisCard);
            }
            else if (CurrentScene.name == "DeckBuilderP2")
            {
                GameObject.Find("MadeDeck2").GetComponent<DeckList>().CardsInDeck.Add(ThisCard);
            }
            GameObject RemovePlate = (GameObject)Resources.Load("prefabs/RemoveCardButton", typeof(GameObject));
            RemovePlateClone.Add(Instantiate(RemovePlate));
            if (RemovePlateClone[CountOfSameCard] != null)
            {
                RemovePlateClone[CountOfSameCard].GetComponentInChildren<Text>().text = ThisCard.name;
                RemovePlateClone[CountOfSameCard].GetComponent<WhatCard>().NumOfCard = CountOfSameCard;
                RemovePlateClone[CountOfSameCard].GetComponent<WhatCard>().ThisCardForRemoval = ThisCard;
                RemovePlateClone[CountOfSameCard].transform.SetParent(FakeRemovePlate.transform.parent);
            }
        }
    }
    public void FixedUpdate()
    {
    }
    public void RemoveCard()
    {
    }
}
