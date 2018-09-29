using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeckList : MonoBehaviour {

    public List<CardStats> CardsInDeck = new List<CardStats>();
    public void FixedUpdate()
    {
    
    }
    public void Awake()
    {
        if(this.name == "MadeDeck1" || this.name == "MadeDeck2")
        DontDestroyOnLoad(this);
        
    }
}
