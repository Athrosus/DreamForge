using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attack : MonoBehaviour {
    public string StartTag ;
    public GameObject CardThatStartedAttack, CardBeingAttacked, Face;
    public int StartAtt, StartHP ,TargetAttack ,TargetHP;
    

    // Use this for initialization
    void Start () {
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //Which card started the attack
        if (CardThatStartedAttack != null)
        {
            int.TryParse(CardThatStartedAttack.GetComponent<CardDisplay>().attackText.text, out StartAtt);
            int.TryParse(CardThatStartedAttack.GetComponent<CardDisplay>().healthText.text, out StartHP);
            StartTag = CardThatStartedAttack.tag;
        }
        if (Face != null && StartTag != Face.tag)
        {
            int.TryParse(Face.GetComponentInChildren<Text>().text, out TargetHP);
            TargetAttack = 0;
            if (Input.GetKeyDown(KeyCode.Mouse0) && gameObject.transform.parent.gameObject.transform.parent.GetComponent<PlayMinion>().IsThereAnEnemyTaunt == true)
            {
                Debug.Log("Taunt in the way");
            }
            else if (Input.GetKeyDown(KeyCode.Mouse0) && gameObject.transform.parent.gameObject.transform.parent.GetComponent<PlayMinion>().IsThereAnEnemyTaunt == false)
            {
                EventTracker.DamageToFace(CardThatStartedAttack, StartAtt.ToString(), Face);
                Cursor.visible = true;
                CardThatStartedAttack.GetComponent<CardDisplay>().HasAttackedThisTurn = true;
            }
        }
        //What can you attack and the calculation/return
        if (CardBeingAttacked != null && StartTag != CardBeingAttacked.tag && CardBeingAttacked.transform.parent.name != "HandP1" && CardBeingAttacked.transform.parent.name != "HandP2")
        {
            int.TryParse(CardBeingAttacked.GetComponent<CardDisplay>().attackText.text, out TargetAttack);
            int.TryParse(CardBeingAttacked.GetComponent<CardDisplay>().healthText.text, out TargetHP);
            if (Input.GetKeyDown(KeyCode.Mouse0) && CardBeingAttacked.GetComponent<CardDisplay>().IsTaunt == false && gameObject.transform.parent.gameObject.transform.parent.GetComponent<PlayMinion>().IsThereAnEnemyTaunt == true)
            {
                Debug.Log("Taunt in the way");
            }
            else if (Input.GetKeyDown(KeyCode.Mouse0) && CardBeingAttacked.GetComponent<CardDisplay>().IsTaunt == true && gameObject.transform.parent.gameObject.transform.parent.GetComponent<PlayMinion>().IsThereAnEnemyTaunt == true)
            {
                EventTracker.Damage(CardThatStartedAttack ,StartAtt, CardBeingAttacked);
                EventTracker.Damage(CardBeingAttacked,TargetAttack, CardThatStartedAttack);
                Cursor.visible = true;
                CardThatStartedAttack.GetComponent<CardDisplay>().HasAttackedThisTurn = true;
            }
            else if (Input.GetKeyDown(KeyCode.Mouse0) && CardBeingAttacked.GetComponent<CardDisplay>().IsTaunt == false && gameObject.transform.parent.gameObject.transform.parent.GetComponent<PlayMinion>().IsThereAnEnemyTaunt == false)
            {
                EventTracker.Damage(CardThatStartedAttack,StartAtt, CardBeingAttacked);
                EventTracker.Damage(CardBeingAttacked,TargetAttack, CardThatStartedAttack);
                Cursor.visible = true;
                CardThatStartedAttack.GetComponent<CardDisplay>().HasAttackedThisTurn = true;
            }
        }
        //Clear all after LMB
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Cursor.visible = true;
            Destroy(GameObject.Find("AttackArrow(Clone)"));
            foreach (GameObject item in GameObject.FindGameObjectsWithTag("Player2"))
            {
                if (item.name == "PlayZone")
                {
                    GameObject EnemyPlayZone = item;
                    for (int z = 0; z < EnemyPlayZone.transform.childCount; z++)
                    {
                        EnemyPlayZone.transform.GetChild(z).GetComponent<BoxCollider2D>().enabled = false;
                        EnemyPlayZone.transform.GetChild(z).GetComponent<BoxCollider2D>().isTrigger = false;
                    }
                }
            }
            foreach (GameObject item in GameObject.FindGameObjectsWithTag("Player1"))
            {
                if (item.name == "PlayZone")
                {
                    GameObject EnemyPlayZone = item;
                    for (int z = 0; z < EnemyPlayZone.transform.childCount; z++)
                    {
                        EnemyPlayZone.transform.GetChild(z).GetComponent<BoxCollider2D>().enabled = false;
                        EnemyPlayZone.transform.GetChild(z).GetComponent<BoxCollider2D>().isTrigger = false;
                    }
                }
            }
        }
    }
}
