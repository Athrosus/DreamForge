using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotYourTurn : MonoBehaviour {

    public GameObject TurnSwitcher, HandP1, HandP2;

    

    void Start () {

    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if(TurnSwitcher.GetComponent<MyTurn>().Player1Turn == true) // player 1 turn
        {
            this.transform.position = new Vector3(0.0f, 423f, 0.0f);
            
        }
        else if (TurnSwitcher.GetComponent<MyTurn>().Player1Turn == false) // player 2 turn
        {
            this.transform.position = new Vector3(0.0f, -423f, 0.0f);

        }


    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
    }


    public void OnTriggerStay2D(Collider2D collision)
    {

        if (TurnSwitcher.GetComponent<MyTurn>().Player1Turn == true) // player 1 turn
        {
         
            collision.GetComponent<Rigidbody2D>().simulated = false;

        }
        else if (TurnSwitcher.GetComponent<MyTurn>().Player1Turn == false) // player 2 turn
        {
          
            collision.GetComponent<Rigidbody2D>().simulated = false;


        }

    }
    
}
