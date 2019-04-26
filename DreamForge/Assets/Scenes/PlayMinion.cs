using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayMinion : MonoBehaviour
{
    public GameObject CardAttacking;
    public GameObject Hand = null;
    public GameObject TurnSwitcher;
    public Sprite ArrowIcon;
    public int MinionTryingToBePlayed, IsTheMinionPlayed, IsTheMinionAttacking = 0, SelectedCardMana;
    public bool IsThereAnEnemyTaunt;

    public void Start()
    {
        if (TurnSwitcher.GetComponent<MyTurn>().Player1Turn == true && this.tag == "Player2") // player 1 turn
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
        else if (TurnSwitcher.GetComponent<MyTurn>().Player1Turn == false && this.tag == "Player1") // player 2 turn
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        int.TryParse(collision.gameObject.GetComponent<CardDisplay>().manaText.text, out SelectedCardMana);
        if (SelectedCardMana <= TurnSwitcher.GetComponent<MyTurn>().Player1Mana && TurnSwitcher.GetComponent<MyTurn>().Player1Turn == true && this.tag == "Player1")
        {
            collision.transform.SetParent(this.transform);
            MinionTryingToBePlayed = 1;
            collision.gameObject.GetComponent<CardDisplay>().HasAttackedThisTurn = true;
        }
        else if (SelectedCardMana <= TurnSwitcher.GetComponent<MyTurn>().Player2Mana && TurnSwitcher.GetComponent<MyTurn>().Player1Turn == false && this.tag == "Player2")
        {
            collision.transform.SetParent(this.transform);
            MinionTryingToBePlayed = 1;
            collision.gameObject.GetComponent<CardDisplay>().HasAttackedThisTurn = true;
        }
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (IsTheMinionPlayed == 1)
        {
            if (TurnSwitcher.GetComponent<MyTurn>().Player1Turn == true && this.tag == "Player1")
            {
                TurnSwitcher.GetComponent<MyTurn>().Player1Mana = TurnSwitcher.GetComponent<MyTurn>().Player1Mana - SelectedCardMana;
                collision.GetComponent<BoxCollider2D>().enabled = false;
                Button But = collision.gameObject.AddComponent<Button>();
                But.onClick.AddListener(AttackInitiation);
                GameObject.Find("Bord").GetComponent<MinionCount>().MinionsOnPlayer1Side++;
                MinionTryingToBePlayed = 0;
            }
            else if (TurnSwitcher.GetComponent<MyTurn>().Player1Turn == false && this.tag == "Player2")
            {
                TurnSwitcher.GetComponent<MyTurn>().Player2Mana = TurnSwitcher.GetComponent<MyTurn>().Player2Mana - SelectedCardMana;
                collision.GetComponent<BoxCollider2D>().enabled = false;
                Button But = collision.gameObject.AddComponent<Button>();
                But.onClick.AddListener(AttackInitiation);
                GameObject.Find("Bord").GetComponent<MinionCount>().MinionsOnPlayer2Side++;
                MinionTryingToBePlayed = 0;
            }
        }
    }
    public void AttackInitiation()
    {
        GameObject AttackArrow = (GameObject)Resources.Load("prefabs/AttackArrow", typeof(GameObject));
        IsThereAnEnemyTaunt = false;
        if (TurnSwitcher.GetComponent<MyTurn>().Player1Turn == true && this.tag == "Player1" && CardAttacking.GetComponent<CardDisplay>().HasAttackedThisTurn == false)
        {
            Cursor.visible = false;
            Instantiate(AttackArrow, gameObject.GetComponent<PlayMinion>().CardAttacking.transform);
            GameObject.Find("AttackArrow(Clone)").GetComponent<Attack>().CardThatStartedAttack = CardAttacking;
            IsTheMinionAttacking = 1;
        }
        else if (TurnSwitcher.GetComponent<MyTurn>().Player1Turn == false && this.tag == "Player2" && CardAttacking.GetComponent<CardDisplay>().HasAttackedThisTurn == false)
        {
            Cursor.visible = false;
            Instantiate(AttackArrow, gameObject.GetComponent<PlayMinion>().CardAttacking.transform);
            GameObject.Find("AttackArrow(Clone)").GetComponent<Attack>().CardThatStartedAttack = CardAttacking;
            IsTheMinionAttacking = 1;
        }
    }
    public void FixedUpdate()
    {
        if (MinionTryingToBePlayed == 1 && Input.GetKeyUp(KeyCode.Mouse0) == true)
        {
            IsTheMinionPlayed = 1;
        }
        else
        {
            IsTheMinionPlayed = 0;
        }
        if (TurnSwitcher.GetComponent<MyTurn>().Player1Turn == true && this.tag == "Player2") // player 1 turn
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
        else if (TurnSwitcher.GetComponent<MyTurn>().Player1Turn == true && this.tag == "Player1") // player 1 turn
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
        else if (TurnSwitcher.GetComponent<MyTurn>().Player1Turn == false && this.tag == "Player1") // player 2 turn
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
        else if (TurnSwitcher.GetComponent<MyTurn>().Player1Turn == false && this.tag == "Player2") // player 2 turn
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
        if (IsTheMinionAttacking == 1)
        {
            if (GameObject.Find("AttackArrow(Clone)") != null)
            {
                Vector2 mousePoition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
                Vector2 actualMouse = Camera.main.ScreenToWorldPoint(mousePoition);
                Vector2 objePosition = this.transform.position;
                Vector2 Arrow = objePosition - actualMouse;
                Vector2 line = new Vector2(1f, 0f);
                float angle = Vector2.SignedAngle(line, Arrow);
                GameObject.Find("AttackArrow(Clone)").transform.position = actualMouse;
                GameObject.Find("AttackArrow(Clone)").transform.eulerAngles = new Vector3(0, 0, angle);
            }
        }
        if (IsTheMinionAttacking == 1)
        {
            if (this.tag == "Player1" && TurnSwitcher.GetComponent<MyTurn>().Player1Turn == true)
            {
                foreach (GameObject item in GameObject.FindGameObjectsWithTag("Player2"))
                {
                    if (item.name == "PlayZone")
                    {
                        GameObject EnemyPlayZone = item;
                        for (int z = 0; z < EnemyPlayZone.transform.childCount; z++)
                        {
                            if (EnemyPlayZone.transform.GetChild(z).GetComponent<CardDisplay>().IsTaunt == true)
                            {
                                IsThereAnEnemyTaunt = true;
                            }
                            EnemyPlayZone.transform.GetChild(z).GetComponent<BoxCollider2D>().enabled = true;
                            EnemyPlayZone.transform.GetChild(z).GetComponent<BoxCollider2D>().isTrigger = true;
                        }
                    }
                }

            }
            else if (this.tag == "Player2" && TurnSwitcher.GetComponent<MyTurn>().Player1Turn == false)
            {
                foreach (GameObject item in GameObject.FindGameObjectsWithTag("Player1"))
                {
                    if (item.name == "PlayZone")
                    {
                        GameObject EnemyPlayZone = item;
                        for (int z = 0; z < EnemyPlayZone.transform.childCount; z++)
                        {
                            if (EnemyPlayZone.transform.GetChild(z).GetComponent<CardDisplay>().IsTaunt == true)
                            {
                                IsThereAnEnemyTaunt = true;
                            }
                            EnemyPlayZone.transform.GetChild(z).GetComponent<BoxCollider2D>().enabled = true;
                            EnemyPlayZone.transform.GetChild(z).GetComponent<BoxCollider2D>().isTrigger = true;
                        }
                    }
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse1) == true /*|| Input.GetKeyDown(KeyCode.Mouse0) == true */)
        {
            if (IsTheMinionAttacking == 1)
            {
                Cursor.visible = true;
                IsTheMinionAttacking = 0;
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
        else if (Input.GetKeyDown(KeyCode.Mouse0) == true)
        {
            IsTheMinionAttacking = 0;
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        MinionTryingToBePlayed = 0;
        collision.transform.SetParent(collision.GetComponent<drag>().StartParent);
    }
    public void OnMouseDown()
    {
    }
}
