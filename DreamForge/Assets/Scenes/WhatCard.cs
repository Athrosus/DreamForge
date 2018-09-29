using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WhatCard : MonoBehaviour {

    public CardStats ThisCardForRemoval;
    public int NumOfCard =0;

    public void FixedUpdate()
    {
        //gameObject.GetComponentInChildren<Text>().text = ThisCardForRemoval.name;
        //Debug.Log(NumOfCard-1);
        NumOfCard = GameObject.Find(ThisCardForRemoval.name).GetComponent<AddCard>().RemovePlateClone.Count;
    }

    public void OnButtonPressRemove()
    {
        /* for (int i = 0; i < GameObject.Find("DBList").transform.childCount; i++)
         {
           if(  GameObject.Find("DBList").GetComponentInChildren<WhatCard>().ThisCardForRemoval.name == ThisCardForRemoval.name)
             {
                 NumOfCard++;
             }
         }
         */

        Scene CurrentScene = SceneManager.GetActiveScene();

        GameObject.Find(ThisCardForRemoval.name).GetComponent<AddCard>().RemovePlateClone.RemoveAt(NumOfCard - 1);

        if (CurrentScene.name == "DeckBuilderP1")
        {
            GameObject.Find("MadeDeck1").GetComponent<DeckList>().CardsInDeck.Remove(ThisCardForRemoval);
            Destroy(gameObject);
        }
        if (CurrentScene.name == "DeckBuilderP2")
        {
            GameObject.Find("MadeDeck2").GetComponent<DeckList>().CardsInDeck.Remove(ThisCardForRemoval);
            Destroy(gameObject);
        }
    }
}
