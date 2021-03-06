﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyTurn : MonoBehaviour {

    public bool Player1Turn, MyTurnJustEndedP1, MyTurnJustEndedP2, MyTurnJustStartedP1, MyTurnJustStartedP2;
    public GameObject Player1, Player2;
    public int FirstPlayerNum, Player1ManaMax =1, Player1Mana, Player2ManaMax=1, Player2Mana;

	void Start () {
        FirstPlayerNum = Random.Range(1, 3);
        if(FirstPlayerNum == 1)
        {
            Player1Turn = true;
        }
        else
        {
            Player1Turn = false;
        }
    }
	public void OnEndTurn()
    {
        Player1Turn= !Player1Turn;
        if (Player1Turn == true)
        {
            //Player 2 turn ended
            MyTurnJustEndedP2 = true;
            GameObject.Find("P2HeroPower").GetComponent<Button>().enabled = false;
            //Player 1 turn started
            GameObject.Find("P1HeroPower").GetComponent<Button>().enabled = true;
            GameObject.Find("Player1").transform.SetAsLastSibling();
            MyTurnJustStartedP1 = true;
            GameObject.Find("Player1").GetComponentInChildren<Deck>().DrawACard(1);
            MyTurnJustStartedP2 = false;
            MyTurnJustEndedP1 = false;
            foreach (var item in GameObject.FindGameObjectsWithTag("Player2"))
            {
                if (item.transform.parent.name == "PlayZone")
                {
                    item.GetComponent<CardDisplay>().HasAttackedThisTurn = false;
                }
            }
        }
        else
        {
            //Player 1 turn ended
            MyTurnJustEndedP1 = true;
            GameObject.Find("P1HeroPower").GetComponent<Button>().enabled = false;
            //Player 2 turn started
            GameObject.Find("P2HeroPower").GetComponent<Button>().enabled = true;
            GameObject.Find("Player2").transform.SetAsLastSibling();
            MyTurnJustStartedP2 = true;
            GameObject.Find("Player2").GetComponentInChildren<Deck>().DrawACard(1);
            MyTurnJustStartedP1 = false;
            MyTurnJustEndedP2 = false;
            foreach (var item in GameObject.FindGameObjectsWithTag("Player1"))
            {
                if (item.transform.parent.name == "PlayZone")
                {
                    item.GetComponent<CardDisplay>().HasAttackedThisTurn = false;
                }
            }
        }
        if (Player1Turn == true && Player2ManaMax <= 9)
        {
            Player2ManaMax++;
        }
        else if (Player1Turn == false && Player1ManaMax <=9)
        {
            Player1ManaMax++;
        }
        Player2Mana = Player2ManaMax;
        Player1Mana = Player1ManaMax;

        foreach (var item in GameObject.FindGameObjectsWithTag("Player1"))
        {
            if (item.transform.parent.name == "PlayZone")
            {
                item.GetComponent<CardDisplay>().OnStartOfTurnOnce = false;
                item.GetComponent<CardDisplay>().OnEndOfTurnOnce = false;

            }
        }
        foreach (var item in GameObject.FindGameObjectsWithTag("Player2"))
        {
            if (item.transform.parent.name == "PlayZone")
            {
                item.GetComponent<CardDisplay>().OnStartOfTurnOnce = false;
                item.GetComponent<CardDisplay>().OnEndOfTurnOnce = false;
            }
        }
    }
    // Update is called once per frame
    void FixedUpdate () {
        
    }
}
