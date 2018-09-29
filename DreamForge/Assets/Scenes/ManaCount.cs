using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaCount : MonoBehaviour {
    public GameObject EndTurnButton;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(this.tag == "Player1")
        {
            gameObject.GetComponent<Text>().text = (EndTurnButton.GetComponent<MyTurn>().Player1Mana).ToString();
        }
        else if (this.tag == "Player2")
        {
            gameObject.GetComponent<Text>().text = (EndTurnButton.GetComponent<MyTurn>().Player2Mana).ToString();
        }

    }
}
