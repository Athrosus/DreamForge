using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhoTurn : MonoBehaviour {
    public GameObject TurnSwitcher;
    public GameObject[] Player1sThings, Player2sThings;
    void Start()
    {
        Player2sThings = GameObject.FindGameObjectsWithTag("Player2");
        Player1sThings = GameObject.FindGameObjectsWithTag("Player1");
    }
    // Player1sThings[0] = Player1
    // Player1sThings[1] = Deck
    // Player1sThings[2] = PlayZone
    // Player1sThings[3] = Hand

    // Player1sThings[0] = Deck
    // Player1sThings[1] = Hand
    // Player1sThings[2] = PlayZone
    // Player1sThings[3] = Player2

    void FixedUpdate()
    {
        if (TurnSwitcher.GetComponent<MyTurn>().Player1Turn == true)
        {
            //Debug.Log("It's Player1's turn");
            //ItsPTurn = 1;
        }
        else if (TurnSwitcher.GetComponent<MyTurn>().Player1Turn == false)
        {
            //Debug.Log("It's Player2's turn");
            //ItsPTurn = 2;
        }
    }
}
