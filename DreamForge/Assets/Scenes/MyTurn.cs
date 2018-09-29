using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyTurn : MonoBehaviour {

    public bool Player1Turn;
    public GameObject Player1, Player2;
    public int FirstPlayerNum, Player1ManaMax =1, Player1Mana, Player2ManaMax=1, Player2Mana;

	void Start () {
        FirstPlayerNum= Random.Range(1, 3);
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
            if (item.name == "Card(Clone)")
            {
                item.GetComponent<CardDisplay>().HasAttackedThisTurn = false;
            }

        }
        foreach (var item in GameObject.FindGameObjectsWithTag("Player2"))
        {
            if (item.name == "Card(Clone)")
            {
                item.GetComponent<CardDisplay>().HasAttackedThisTurn = false;
            }

        }
        
    }



    // Update is called once per frame
    void Update () {
        if (Player1Turn == true)
        {
            GameObject.Find("Player1").transform.SetAsLastSibling();

        }
        if (Player1Turn == false)
        {
            GameObject.Find("Player2").transform.SetAsLastSibling();

        }
    }
}
