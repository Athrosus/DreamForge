
using UnityEngine;
using System.Collections.Generic;

public class AllCards : MonoBehaviour {

    
    public List<CardStats> AllCardsObj = new List<CardStats>();

    public void OnButtonPress()
    {

        
    AllCardsObj.Add( new CardStats());
    }
    

    
}
