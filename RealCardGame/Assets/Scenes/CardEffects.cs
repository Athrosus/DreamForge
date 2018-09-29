using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardEffects : MonoBehaviour {

    public bool IsTargetFound, StartedTargeting, player1turn;
    

    public void Start()
    {

        if (gameObject.GetComponent<CardDisplay>().nameText.text == "Flower" || gameObject.GetComponent<CardDisplay>().nameText.text == "Maunten")
        {
            gameObject.GetComponent<CardDisplay>().ThisOnPlaySelfBuff.Add(Taunt);

        }
        if (gameObject.GetComponent<CardDisplay>().nameText.text == "Snek")
        {
            //gameObject.GetComponent<CardDisplay>().ThisOnPlayEffects.Add(Snek_OnPlayEffect);
            gameObject.GetComponent<CardDisplay>().ThisOnPlayEffects.Add(Snek_OnPlayEffect);

            gameObject.GetComponent<CardDisplay>().ThisOnPlayEffects.Add(Snek_MoreSnek);



        }
    }
    
    
    public void Taunt()
    {
        Debug.Log("Am Taunting");
        if (gameObject.GetComponent<CardDisplay>() != null)
        {
            gameObject.GetComponent<CardDisplay>().IsTaunt = true;
        }
    }

    public void Snek_OnPlayEffect()
    {
        if (StartedTargeting == true)
        {
            GameObject EffectArrow = (GameObject)Resources.Load("prefabs/EffectArrow", typeof(GameObject));
            Instantiate(EffectArrow, gameObject.transform);

            GameObject.Find("EndTurn").GetComponent<Button>().interactable = false;
       

            StartedTargeting = false;

        }

        int TargetHP;
       
        if (IsTargetFound == true)
        {


            int.TryParse(GameObject.Find("EffectArrow(Clone)").GetComponent<EffectTargeting>().CardBeingTargeted.GetComponent<CardDisplay>().healthText.text, out TargetHP);
            GameObject.Find("EffectArrow(Clone)").GetComponent<EffectTargeting>().CardBeingTargeted.GetComponent<CardDisplay>().healthText.text = (TargetHP - 1).ToString();

            GameObject.Find("EndTurn").GetComponent<Button>().interactable = true;
            

            Destroy(GameObject.Find("EffectArrow(Clone)"));
            gameObject.GetComponent<CardDisplay>().OnPlayTargetFound = true;
            IsTargetFound = false;



        }


    }

    public void Snek_MoreSnek()
    {


        if (StartedTargeting == true)
        {
            GameObject New_Snek = (GameObject)Resources.Load("prefabs/Card", typeof(GameObject));

            player1turn = GameObject.Find("EndTurn").GetComponent<MyTurn>().Player1Turn;
            Debug.Log(player1turn);
            if (player1turn == true)
            {
                GameObject New_snek = Instantiate(New_Snek, GameObject.Find("HandP1").transform);
                New_snek.GetComponent<drag>().StartParent = GameObject.Find("HandP1").transform;
                New_snek.GetComponent<CardEffects>().enabled = false;
                New_snek.tag = "Player1";

            }
            if (player1turn == false)
            {
                GameObject New_snek = Instantiate(New_Snek, GameObject.Find("HandP2").transform);
                New_snek.GetComponent<drag>().StartParent = GameObject.Find("HandP2").transform;
                New_snek.transform.Rotate(0, 0, -180);
                New_snek.GetComponent<CardEffects>().enabled = false;
                New_snek.tag = "Player2";

            }

            //Instantiate(New_Snek, gameObject.transform.parent);

            gameObject.GetComponent<CardDisplay>().card = New_Snek.GetComponent<CardDisplay>().card;
            
            StartedTargeting = false;
            gameObject.GetComponent<CardDisplay>().OnPlayTargetFound = true;

        }
    }

}


