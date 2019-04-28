﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardEffects : MonoBehaviour
{
    public delegate void OnPlayEffect();
    public delegate void OnDeathEffect();
    public delegate void PassiveEffect();
    public bool IsTargetFound, StartedTargeting = false, player1turn;
    public GameObject PlayZone1, PlayZone2;
    public int NumberOfTargets=0;

    public void Start()
    {
        foreach (GameObject item in GameObject.FindGameObjectsWithTag("Player1"))
        {
            if (item.name == "PlayZone")
            {
                PlayZone1 = item;
            }
        }
        foreach (GameObject item in GameObject.FindGameObjectsWithTag("Player2"))
        {
            if (item.name == "PlayZone")
            {
                PlayZone2 = item;
            }
        }
        //    OnPlaySelfBuffs
        if (gameObject.GetComponent<CardDisplay>().nameText.text == "Flower" || gameObject.GetComponent<CardDisplay>().nameText.text == "Maunten" || gameObject.GetComponent<CardDisplay>().nameText.text == "Card2" || gameObject.GetComponent<CardDisplay>().nameText.text == "Card5" || gameObject.GetComponent<CardDisplay>().nameText.text == "Card8" || gameObject.GetComponent<CardDisplay>().nameText.text == "Card8_Spawn" || gameObject.GetComponent<CardDisplay>().nameText.text == "Card9")
        {
            gameObject.GetComponent<CardDisplay>().ThisOnPlaySelfBuff.Add(Taunt);
        }
        //    OnPlaySelfBuffs
        //    OnPlayEffects
        if (gameObject.GetComponent<CardDisplay>().nameText.text == "Flower")
        {
            gameObject.GetComponent<CardDisplay>().ThisOnPlayEffects.Add(Flower_OnPlayEffect);
        }
        if (gameObject.GetComponent<CardDisplay>().nameText.text == "Maunten")
        {
            gameObject.GetComponent<CardDisplay>().ThisOnPlayEffects.Add(Maunten_OnPlayEffect);
        }
        if (gameObject.GetComponent<CardDisplay>().nameText.text == "Card4")
        {
            gameObject.GetComponent<CardDisplay>().ThisOnPlayEffects.Add(Card4_OnPlayEffect); // !!! CAN OVERKILL !!!
        }
        if (gameObject.GetComponent<CardDisplay>().nameText.text == "Card8")
        {
            gameObject.GetComponent<CardDisplay>().ThisOnPlayEffects.Add(Card8_OnPlayEffect);
        }
        if (gameObject.GetComponent<CardDisplay>().nameText.text == "Card9")
        {
            gameObject.GetComponent<CardDisplay>().ThisOnPlayEffects.Add(Card8_OnPlayEffect);
        }
        if (gameObject.GetComponent<CardDisplay>().nameText.text == "Card10")
        {
            gameObject.GetComponent<CardDisplay>().ThisOnPlayEffects.Add(Card10_OnPlayEffect);
        }
        if (gameObject.GetComponent<CardDisplay>().nameText.text == "Card12")
        {
            gameObject.GetComponent<CardDisplay>().ThisOnPlayEffects.Add(Card12_OnPlayEffect);
        }
        if (gameObject.GetComponent<CardDisplay>().nameText.text == "Lum'ra")
        {
            gameObject.GetComponent<CardDisplay>().ThisOnPlayEffects.Add(Lum_ra_OnPlayEffect);
        }
        if (gameObject.GetComponent<CardDisplay>().nameText.text == "Spark Finger")
        {
            gameObject.GetComponent<CardDisplay>().ThisOnPlayEffects.Add(Spark_Finger_OnPlayEffect);
        }
        //    OnPlayEffects
        //    WhenDrawnEffects
        if (gameObject.GetComponent<CardDisplay>().nameText.text == "Repairatron")
        {
            gameObject.GetComponent<CardDisplay>().ThisWhenDrawnEffects.Add(Repairatron_WhenDrawnEffect);
        }
        if (gameObject.GetComponent<CardDisplay>().nameText.text == "Phum'Ra")
        {
            gameObject.GetComponent<CardDisplay>().ThisWhenDrawnEffects.Add(Phum_ra_WhenDrawnEffect);
        }
        //    WhenDrawnEffects
        //    OnStartOfTrunEffects
        if (gameObject.GetComponent<CardDisplay>().nameText.text == "Card1")
        {
            gameObject.GetComponent<CardDisplay>().ThisOnStartOfTrunEffects.Add(Card1_OnStartOfTurnEffect);

        }
        if (gameObject.GetComponent<CardDisplay>().nameText.text == "Card2")
        {
            gameObject.GetComponent<CardDisplay>().ThisOnStartOfTrunEffects.Add(Card2_OnStartOfTurnEffect);
        }
        //    OnStartOfTrunEffects
        //    OnEndOfTurnEffects
        if (gameObject.GetComponent<CardDisplay>().nameText.text == "Hungering Demon")
        {
            gameObject.GetComponent<CardDisplay>().ThisOnEndOfTrunEffects.Add(HungeringDemon_OnEndOfTurnEffect);
        } // !!! Kinda buggy with more of the same effect happoning at once, probably will get fixed when ordering is added !!! 
        if (gameObject.GetComponent<CardDisplay>().nameText.text == "Inmo'faseal the Everlasting")
        {
            gameObject.GetComponent<CardDisplay>().ThisOnEndOfTrunEffects.Add(Inmo_faseal_the_Everlasting_OnEndOfTurnEffect);
        }
        //    OnEndOfTurnEffects
        //    OnDeathEffects
        if (gameObject.GetComponent<CardDisplay>().nameText.text == "Card0")
        {
            gameObject.GetComponent<CardDisplay>().ThisOnDeathEffects.Add(Card0_OnDeathEffect);
        }
        if (gameObject.GetComponent<CardDisplay>().nameText.text == "Card3")
        {
            gameObject.GetComponent<CardDisplay>().ThisOnDeathEffects.Add(Card3_OnDeathEffect);
        }
        if (gameObject.GetComponent<CardDisplay>().nameText.text == "Card5")
        {
            gameObject.GetComponent<CardDisplay>().ThisOnDeathEffects.Add(Card5_OnDeathEffect);
        }
        if (gameObject.GetComponent<CardDisplay>().nameText.text == "Card6")
        {
            gameObject.GetComponent<CardDisplay>().ThisOnDeathEffects.Add(Card6_OnDeathEffect);
        }
        if (gameObject.GetComponent<CardDisplay>().nameText.text == "Card7")
        {
            gameObject.GetComponent<CardDisplay>().ThisOnDeathEffects.Add(Card7_OnDeathEffect);
        }
        if (gameObject.GetComponent<CardDisplay>().nameText.text == "Card11")
        {
            gameObject.GetComponent<CardDisplay>().ThisOnDeathEffects.Add(Card11_OnDeathEffect);
        }
        if (gameObject.GetComponent<CardDisplay>().nameText.text == "Inmo'faseal the Everlasting")
        {
            gameObject.GetComponent<CardDisplay>().ThisOnDeathEffects.Add(Inmo_faseal_the_Everlasting_OnDeathEffect);
        }
        if (gameObject.GetComponent<CardDisplay>().nameText.text == "Py'ra")
        {
            gameObject.GetComponent<CardDisplay>().ThisOnDeathEffects.Add(Py_ra_OnDeathEffect);
        }
        if (gameObject.GetComponent<CardDisplay>().nameText.text == "Lum'ra")
        {
            gameObject.GetComponent<CardDisplay>().ThisOnDeathEffects.Add(Lum_ra_OnDeathEffect);
        }
        if (gameObject.GetComponent<CardDisplay>().nameText.text == "Spark Finger")
        {
            gameObject.GetComponent<CardDisplay>().ThisOnDeathEffects.Add(Spark_Finger_OnDeathEffect);
        }

        //    OnDeathEffects

        //if (gameObject.GetComponent<CardDisplay>().nameText.text == "Snek")
        //{
        //    gameObject.GetComponent<CardDisplay>().ThisOnDeathEffects.Add(Snek_OnDeathSummon);    //!!!! Somehow allways happons after Snek_OnDeathAoeDmgEffect BUG !!!!

        //    gameObject.GetComponent<CardDisplay>().ThisOnDeathEffects.Add(Snek_OnDeathAoeDmgEffect);

        //    //gameObject.GetComponent<CardDisplay>().ThisOnPlayEffects.Add(Snek_OnPlayAoeDmgEffect);

        //    //gameObject.GetComponent<CardDisplay>().ThisOnPlayEffects.Add(Snek_OnPlayTargetedDmgEffect);

        //    //gameObject.GetComponent<CardDisplay>().ThisOnPlayEffects.Add(Snek_MoreSnek_Hand);

        //    //gameObject.GetComponent<CardDisplay>().ThisOnPlayEffects.Add(Snek_MoreSnek_Summon);
        //}
    }

    //OnPlaySelfBuffs

    public void Taunt()
    {
        if (gameObject.GetComponent<CardDisplay>() != null)
        {
            gameObject.GetComponent<CardDisplay>().IsTaunt = true;
        }
    }

    //OnPlayEffects

    public void Flower_OnPlayEffect()
    {
        int firstNumb = 2, secondNumb = 2;
        if (StartedTargeting == true)
        {
            GameObject EffectArrow = (GameObject)Resources.Load("prefabs/EffectArrow", typeof(GameObject));
            Instantiate(EffectArrow, gameObject.transform);
            GameObject.Find("EndTurn").GetComponent<Button>().interactable = false;
            StartedTargeting = false;
        }
        int TargetHP;
        if (Input.GetKeyDown(KeyCode.Mouse0) && GameObject.Find("EffectArrow(Clone)").GetComponent<EffectTargeting>().CardBeingTargeted != null && GameObject.Find("EffectArrow(Clone)").GetComponent<EffectTargeting>().CardBeingTargeted.transform.parent.name == "PlayZone")
        {
            Cursor.visible = true;
            IsTargetFound = true;
            int.TryParse(GameObject.Find("EffectArrow(Clone)").GetComponent<EffectTargeting>().CardBeingTargeted.GetComponent<CardDisplay>().healthText.text, out TargetHP);
            GameObject.Find("EffectArrow(Clone)").GetComponent<EffectTargeting>().CardBeingTargeted.GetComponent<CardDisplay>().healthText.text = (TargetHP + firstNumb * secondNumb).ToString();
            GameObject.Find("EndTurn").GetComponent<Button>().interactable = true;
            Destroy(GameObject.Find("EffectArrow(Clone)"));
            gameObject.GetComponent<CardDisplay>().OnPlayTargetFound = true;
            IsTargetFound = false;
        }
    }
    public void Maunten_OnPlayEffect()
    {
        int firstNumb = 3, secondNumb = 3;
        if (StartedTargeting == true)
        {
            GameObject EffectArrow = (GameObject)Resources.Load("prefabs/EffectArrow", typeof(GameObject));
            Instantiate(EffectArrow, gameObject.transform);
            GameObject.Find("EndTurn").GetComponent<Button>().interactable = false;
            StartedTargeting = false;
        }
        int TargetHP;
        if (Input.GetKeyDown(KeyCode.Mouse0) && GameObject.Find("EffectArrow(Clone)").GetComponent<EffectTargeting>().CardBeingTargeted != null && GameObject.Find("EffectArrow(Clone)").GetComponent<EffectTargeting>().CardBeingTargeted.transform.parent.name == "PlayZone")
        {
            Cursor.visible = true;
            IsTargetFound = true;
            int.TryParse(GameObject.Find("EffectArrow(Clone)").GetComponent<EffectTargeting>().CardBeingTargeted.GetComponent<CardDisplay>().healthText.text, out TargetHP);
            GameObject.Find("EffectArrow(Clone)").GetComponent<EffectTargeting>().CardBeingTargeted.GetComponent<CardDisplay>().healthText.text = (TargetHP + firstNumb * secondNumb).ToString();
            GameObject.Find("EndTurn").GetComponent<Button>().interactable = true;
            Destroy(GameObject.Find("EffectArrow(Clone)"));
            gameObject.GetComponent<CardDisplay>().OnPlayTargetFound = true;
            IsTargetFound = false;
        }
    }
    public void Card4_OnPlayEffect()
    {
        int firstNumb = 3;
        for (int i = 0; i < firstNumb; i++)
        {
            if (gameObject.tag == "Player1" && GameObject.Find("Bord").GetComponent<MinionCount>().MinionsOnPlayer2Side > 0)
            {
                int RandomEnemyMinions, MinionNumber = 0;
                RandomEnemyMinions = Random.Range(0, GameObject.Find("Bord").GetComponent<MinionCount>().MinionsOnPlayer2Side);
                Debug.Log("The minion Chosen is" + RandomEnemyMinions);
                foreach (var card in GameObject.FindGameObjectsWithTag("Player2"))
                {
                    if (card.name == "Card(Clone)" && card.transform.parent.name == "PlayZone" && int.Parse(card.GetComponent<CardDisplay>().healthText.text) > 0)
                    {
                        if (MinionNumber == RandomEnemyMinions)
                        {
                            card.GetComponent<CardDisplay>().healthText.text = (int.Parse(card.GetComponent<CardDisplay>().healthText.text) - 1).ToString();
                        }
                        MinionNumber++;
                    }
                }
            }
            else if (gameObject.tag == "Player2" && GameObject.Find("Bord").GetComponent<MinionCount>().MinionsOnPlayer1Side > 0)
            {
                int RandomEnemyMinions, MinionNumber = 0;
                RandomEnemyMinions = Random.Range(0, GameObject.Find("Bord").GetComponent<MinionCount>().MinionsOnPlayer1Side);
                Debug.Log("The minion Chosen is" + RandomEnemyMinions);

                foreach (var card in GameObject.FindGameObjectsWithTag("Player1"))
                {
                    if (card.name == "Card(Clone)" && card.transform.parent.name == "PlayZone" && int.Parse(card.GetComponent<CardDisplay>().healthText.text) > 0)
                    {
                        if (MinionNumber == RandomEnemyMinions)
                        {
                            card.GetComponent<CardDisplay>().healthText.text = (int.Parse(card.GetComponent<CardDisplay>().healthText.text) - 1).ToString();
                        }
                        MinionNumber++;
                    }
                }
            }
        }
        gameObject.GetComponent<CardDisplay>().OnPlayTargetFound = true;
    }
    public void Card8_OnPlayEffect()
    {
        SummonNEW("OnPlay", (CardStats)Resources.Load("CardPrefabs/Card8_Spawn", typeof(CardStats)), gameObject.transform.parent);
    }
    public void Card10_OnPlayEffect()
    {
        if (this.tag == "Player1")
        {
            GameObject.Find("Player1").GetComponentInChildren<Deck>().DrawACard(1);
        }
        else
        {
            GameObject.Find("Player2").GetComponentInChildren<Deck>().DrawACard(1);
        }
        gameObject.GetComponent<CardDisplay>().OnPlayTargetFound = true;
    }
    public void Card12_OnPlayEffect()
    {
        if (StartedTargeting == true)
        {
            GameObject EffectArrow = (GameObject)Resources.Load("prefabs/EffectArrow", typeof(GameObject));
            Instantiate(EffectArrow, gameObject.transform);
            GameObject.Find("EndTurn").GetComponent<Button>().interactable = false;
            StartedTargeting = false;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && GameObject.Find("EffectArrow(Clone)").GetComponent<EffectTargeting>().CardBeingTargeted != null && GameObject.Find("EffectArrow(Clone)").GetComponent<EffectTargeting>().CardBeingTargeted.transform.parent.name == "PlayZone")
        {
            Cursor.visible = true;
            IsTargetFound = true;
            GameObject.Find("EffectArrow(Clone)").GetComponent<EffectTargeting>().CardBeingTargeted.GetComponent<CardDisplay>().attackText.text = 1.ToString();
            GameObject.Find("EndTurn").GetComponent<Button>().interactable = true;
            Destroy(GameObject.Find("EffectArrow(Clone)"));
            gameObject.GetComponent<CardDisplay>().OnPlayTargetFound = true;
            IsTargetFound = false;
        }
    }
    public void Lum_ra_OnPlayEffect()
    {
        if (tag == "Player1")
        {
            SummonNEW("OnPlay", (CardStats)Resources.Load("CardPrefabs/Py'ra", typeof(CardStats)), PlayZone2.transform);
        }
        else if (tag == "Player2")
        {
            SummonNEW("OnPlay", (CardStats)Resources.Load("CardPrefabs/Py'ra", typeof(CardStats)), PlayZone1.transform);
        }
    }
    public void Spark_Finger_OnPlayEffect()
    {
        int FirstNum = 2;
        int TargetHP;
        if (StartedTargeting == true)
        {
            GameObject EffectArrow = (GameObject)Resources.Load("prefabs/EffectArrow", typeof(GameObject));
            Instantiate(EffectArrow, gameObject.transform);
            GameObject.Find("EndTurn").GetComponent<Button>().interactable = false;
            StartedTargeting = false;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && GameObject.Find("EffectArrow(Clone)").GetComponent<EffectTargeting>().CardBeingTargeted != null && GameObject.Find("EffectArrow(Clone)").GetComponent<EffectTargeting>().CardBeingTargeted.transform.parent.name == "PlayZone")
        {
            Cursor.visible = true;
            IsTargetFound = true;
            int.TryParse(GameObject.Find("EffectArrow(Clone)").GetComponent<EffectTargeting>().CardBeingTargeted.GetComponent<CardDisplay>().healthText.text, out TargetHP);
            GameObject.Find("EffectArrow(Clone)").GetComponent<EffectTargeting>().CardBeingTargeted.GetComponent<CardDisplay>().healthText.text = (TargetHP - 1).ToString();
            GameObject.Find("EndTurn").GetComponent<Button>().interactable = true;
            Destroy(GameObject.Find("EffectArrow(Clone)"));
            NumberOfTargets++;
            StartedTargeting = true;
            if (NumberOfTargets == FirstNum)
            {
                gameObject.GetComponent<CardDisplay>().OnPlayTargetFound = true;
                IsTargetFound = false;
                return;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Cursor.visible = true;
            IsTargetFound = true;
            GameObject.Find("EndTurn").GetComponent<Button>().interactable = true;
            Destroy(GameObject.Find("EffectArrow(Clone)"));
            gameObject.GetComponent<CardDisplay>().OnPlayTargetFound = true;
            IsTargetFound = false;
        }

    }
    //OnDeathEffects

    public void Card0_OnDeathEffect()
    {
        GameObject New_Snek = (GameObject)Resources.Load("prefabs/Card", typeof(GameObject));
        player1turn = GameObject.Find("EndTurn").GetComponent<MyTurn>().Player1Turn;
        if (this.tag == "Player1")
        {
            if (GameObject.Find("HandP1").transform.childCount <= 9)
            {
                GameObject New_snek = Instantiate(New_Snek, GameObject.Find("HandP1").transform);
                New_snek.GetComponent<CardDisplay>().card = (CardStats)Resources.Load("CardPrefabs/" + gameObject.GetComponent<CardDisplay>().card.name, typeof(CardStats));
                //New_snek.GetComponent<CardDisplay>().ThisOnDeathEffects.Add(New_snek.GetComponent<CardEffects>().Card0_OnDeathEffect);
                New_snek.GetComponent<drag>().StartParent = GameObject.Find("HandP1").transform;
                New_snek.GetComponent<CardEffects>().enabled = false;
                New_snek.tag = "Player1";
            }
        }
        if (this.tag == "Player2")
        {
            if (GameObject.Find("HandP2").transform.childCount <= 9)
            {
                GameObject New_snek = Instantiate(New_Snek, GameObject.Find("HandP2").transform);
                New_snek.GetComponent<CardDisplay>().card = (CardStats)Resources.Load("CardPrefabs/" + gameObject.GetComponent<CardDisplay>().card.name, typeof(CardStats));
                //New_snek.GetComponent<CardDisplay>().ThisOnDeathEffects.Add(New_snek.GetComponent<CardEffects>().Card0_OnDeathEffect);
                New_snek.GetComponent<drag>().StartParent = GameObject.Find("HandP2").transform;
                New_snek.transform.Rotate(0, 0, -180);
                New_snek.GetComponent<CardEffects>().enabled = false;
                New_snek.tag = "Player2";
            }
        }
    } //Not a true copy FULL card
    public void Card3_OnDeathEffect()
    {
        foreach (var card in GameObject.FindGameObjectsWithTag("Player1"))
        {
            if (card.name == "Card(Clone)" && card.transform.parent.name == "PlayZone" && int.Parse(card.GetComponent<CardDisplay>().healthText.text) > 0)
            {
                card.GetComponent<CardDisplay>().healthText.text = (int.Parse(card.GetComponent<CardDisplay>().healthText.text) - 2).ToString();
            }
        }
        foreach (var card in GameObject.FindGameObjectsWithTag("Player2"))
        {
            if (card.name == "Card(Clone)" && card.transform.parent.name == "PlayZone" && int.Parse(card.GetComponent<CardDisplay>().healthText.text) > 0)
            {
                card.GetComponent<CardDisplay>().healthText.text = (int.Parse(card.GetComponent<CardDisplay>().healthText.text) - 2).ToString();
            }
        }

        GameObject New_Snek = (GameObject)Resources.Load("prefabs/Card", typeof(GameObject));
        player1turn = GameObject.Find("EndTurn").GetComponent<MyTurn>().Player1Turn;
        if (this.tag == "Player1")
        {
            if (GameObject.Find("HandP1").transform.childCount <= 9)
            {
                GameObject New_snek = Instantiate(New_Snek, GameObject.Find("HandP1").transform);
                New_snek.GetComponent<CardDisplay>().card = (CardStats)Resources.Load("CardPrefabs/Card3_Spawn", typeof(CardStats));
                New_snek.GetComponent<CardDisplay>().ThisOnDeathEffects.Add(Card3_Spawn_OnDeathEffect);
                New_snek.GetComponent<drag>().StartParent = GameObject.Find("HandP1").transform;
                New_snek.GetComponent<CardEffects>().enabled = false;
                New_snek.tag = "Player1";
            }
        }
        if (this.tag == "Player2")
        {
            if (GameObject.Find("HandP2").transform.childCount <= 9)
            {
                GameObject New_snek = Instantiate(New_Snek, GameObject.Find("HandP2").transform);
                New_snek.GetComponent<CardDisplay>().card = (CardStats)Resources.Load("CardPrefabs/Card3_Spawn", typeof(CardStats));
                New_snek.GetComponent<CardDisplay>().ThisOnDeathEffects.Add(Card3_Spawn_OnDeathEffect);
                New_snek.GetComponent<drag>().StartParent = GameObject.Find("HandP2").transform;
                New_snek.transform.Rotate(0, 0, -180);
                New_snek.GetComponent<CardEffects>().enabled = false;
                New_snek.tag = "Player2";
            }
        }
    }
    public void Card3_Spawn_OnDeathEffect()
    {
        foreach (var card in GameObject.FindGameObjectsWithTag("Player1"))
        {
            if (card.name == "Card(Clone)" && card.transform.parent.name == "PlayZone" && int.Parse(card.GetComponent<CardDisplay>().healthText.text) > 0)
            {
                card.GetComponent<CardDisplay>().healthText.text = (int.Parse(card.GetComponent<CardDisplay>().healthText.text) - 2).ToString();
            }
        }
        foreach (var card in GameObject.FindGameObjectsWithTag("Player2"))
        {
            if (card.name == "Card(Clone)" && card.transform.parent.name == "PlayZone" && int.Parse(card.GetComponent<CardDisplay>().healthText.text) > 0)
            {
                card.GetComponent<CardDisplay>().healthText.text = (int.Parse(card.GetComponent<CardDisplay>().healthText.text) - 2).ToString();
            }
        }
    }
    public void Card5_OnDeathEffect()
    {
        foreach (var card in GameObject.FindGameObjectsWithTag("Player1"))
        {
            if (card.name == "Card(Clone)" && card.transform.parent.name == "PlayZone" && int.Parse(card.GetComponent<CardDisplay>().healthText.text) > 0)
            {
                card.GetComponent<CardDisplay>().healthText.text = (int.Parse(card.GetComponent<CardDisplay>().healthText.text) - 2).ToString();
            }
        }
        foreach (var card in GameObject.FindGameObjectsWithTag("Player2"))
        {
            if (card.name == "Card(Clone)" && card.transform.parent.name == "PlayZone" && int.Parse(card.GetComponent<CardDisplay>().healthText.text) > 0)
            {
                card.GetComponent<CardDisplay>().healthText.text = (int.Parse(card.GetComponent<CardDisplay>().healthText.text) - 2).ToString();
            }
        }
    }
    public void Card6_OnDeathEffect()
    {
        SummonNEW("OnDeath", (CardStats)Resources.Load("CardPrefabs/Card6_Spawn", typeof(CardStats)), gameObject.transform.parent);
    }
    public void Card7_OnDeathEffect()
    {
        int FirstNum = 2;
        if (gameObject.tag == "Player1")
        {
            GameObject.Find("FaceHPTextP1").GetComponentInChildren<Text>().text = (int.Parse(GameObject.Find("FaceHPTextP1").GetComponentInChildren<Text>().text) - FirstNum).ToString();
        }
        if (gameObject.tag == "Player2")
        {
            GameObject.Find("FaceHPTextP2").GetComponentInChildren<Text>().text = (int.Parse(GameObject.Find("FaceHPTextP2").GetComponentInChildren<Text>().text) - FirstNum).ToString();
        }
    }
    public void Card11_OnDeathEffect()
    {
        int FirstNum = 1;
        if (this.tag == "Player1")
        {
            GameObject.Find("Player1").GetComponentInChildren<Deck>().DrawACard(FirstNum);
        }
        else
        {
            GameObject.Find("Player2").GetComponentInChildren<Deck>().DrawACard(FirstNum);
        }
    }
    public void Inmo_faseal_the_Everlasting_OnDeathEffect()
    {
        player1turn = GameObject.Find("EndTurn").GetComponent<MyTurn>().Player1Turn;
        if (gameObject.tag == "Player1")
        {
            GameObject New_snek = Instantiate(gameObject, PlayZone1.transform);
            New_snek.name = "Card(Clone)";
            New_snek.GetComponent<LayoutElement>().ignoreLayout = true;
            New_snek.GetComponent<BoxCollider2D>().enabled = false;
            New_snek.GetComponent<CardDisplay>().card = (CardStats)Resources.Load("CardPrefabs/" + gameObject.GetComponent<CardDisplay>().card.name, typeof(CardStats));
            New_snek.GetComponent<Button>().onClick.AddListener(gameObject.transform.parent.GetComponent<PlayMinion>().AttackInitiation);
            New_snek.tag = "Player1";
        }
        if (gameObject.tag == "Player2")
        {
            GameObject New_snek = Instantiate(gameObject, PlayZone2.transform);
            New_snek.name = "Card(Clone)";
            New_snek.GetComponent<LayoutElement>().ignoreLayout = true;
            New_snek.GetComponent<BoxCollider2D>().enabled = false;
            New_snek.GetComponent<CardDisplay>().card = (CardStats)Resources.Load("CardPrefabs/" + gameObject.GetComponent<CardDisplay>().card.name, typeof(CardStats));
            New_snek.GetComponent<Button>().onClick.AddListener(gameObject.transform.parent.GetComponent<PlayMinion>().AttackInitiation);
            New_snek.tag = "Player2";
        }
        gameObject.GetComponent<CardDisplay>().OnPlayTargetFound = true;
    } //Not a true copy FULL card
    public void Py_ra_OnDeathEffect()
    {
        int FirstNum = 2;
        if (gameObject.transform.parent.tag == "Player1")
        {
            GameObject.Find("FaceHPTextP1").GetComponentInChildren<Text>().text = (int.Parse(GameObject.Find("FaceHPTextP1").GetComponentInChildren<Text>().text) - FirstNum).ToString();
        }
        if (gameObject.transform.parent.tag == "Player2")
        {
            GameObject.Find("FaceHPTextP2").GetComponentInChildren<Text>().text = (int.Parse(GameObject.Find("FaceHPTextP2").GetComponentInChildren<Text>().text) - FirstNum).ToString();
        }
    }
    public void Lum_ra_OnDeathEffect()
    {
        if (tag == "Player1")
        {
            SummonNEW("OnDeath", (CardStats)Resources.Load("CardPrefabs/Py'ra", typeof(CardStats)), PlayZone2.transform);
        }
        else if (tag == "Player2")
        {
            SummonNEW("OnDeath", (CardStats)Resources.Load("CardPrefabs/Py'ra", typeof(CardStats)), PlayZone1.transform);
        }
    }
    public void Spark_Finger_OnDeathEffect()
    {
        int FirstNum = 1;
        if (tag == "Player1")
        {
            GameObject.Find("FaceHPTextP2").GetComponentInChildren<Text>().text = (int.Parse(GameObject.Find("FaceHPTextP2").GetComponentInChildren<Text>().text) - FirstNum).ToString();
        }
        else
        {
            GameObject.Find("FaceHPTextP1").GetComponentInChildren<Text>().text = (int.Parse(GameObject.Find("FaceHPTextP1").GetComponentInChildren<Text>().text) - FirstNum).ToString();
        }
    }

    //PassiveEffects
    public void Card1_OnStartOfTurnEffect()
    {
        GetComponent<CardDisplay>().attackText.text = (int.Parse(GetComponent<CardDisplay>().attackText.text) + int.Parse(GetComponent<CardDisplay>().healthText.text)).ToString();
    }
    public void Card2_OnStartOfTurnEffect()
    {
        if (int.Parse(GetComponent<CardDisplay>().healthText.text) < 8)
        {
            GetComponent<CardDisplay>().attackText.text = (int.Parse(GetComponent<CardDisplay>().attackText.text) + 2).ToString();
            GetComponent<CardDisplay>().healthText.text = (int.Parse(GetComponent<CardDisplay>().healthText.text) + 1).ToString();
        }
    }
    public void HungeringDemon_OnEndOfTurnEffect()
    {
        if (int.Parse(this.GetComponent<CardDisplay>().healthText.text) > 0)
        {
            if (this.tag == "Player1" && GameObject.Find("Bord").GetComponent<MinionCount>().MinionsOnPlayer1Side > 1)
            {
                //if (this.transform.parent.GetChild(this.transform.GetSiblingIndex() + 1) != null)
                try {
                    this.GetComponent<CardDisplay>().healthText.text = (int.Parse(this.GetComponent<CardDisplay>().healthText.text) + int.Parse(this.transform.parent.GetChild(this.transform.GetSiblingIndex() + 1).GetComponent<CardDisplay>().healthText.text)).ToString();
                    this.GetComponent<CardDisplay>().attackText.text = (int.Parse(this.GetComponent<CardDisplay>().attackText.text) + int.Parse(this.transform.parent.GetChild(this.transform.GetSiblingIndex() + 1).GetComponent<CardDisplay>().attackText.text)).ToString();
                    this.transform.parent.GetChild(this.transform.GetSiblingIndex() + 1).GetComponent<CardDisplay>().healthText.text = "0";
                }
                //else
                catch {
                    this.GetComponent<CardDisplay>().healthText.text = (int.Parse(this.GetComponent<CardDisplay>().healthText.text) + int.Parse(this.transform.parent.GetChild(this.transform.GetSiblingIndex() - 1).GetComponent<CardDisplay>().healthText.text)).ToString();
                    this.GetComponent<CardDisplay>().attackText.text = (int.Parse(this.GetComponent<CardDisplay>().attackText.text) + int.Parse(this.transform.parent.GetChild(this.transform.GetSiblingIndex() - 1).GetComponent<CardDisplay>().attackText.text)).ToString();
                    this.transform.parent.GetChild(this.transform.GetSiblingIndex() - 1).GetComponent<CardDisplay>().healthText.text = "0";
                }
            }
            else if (this.tag == "Player2" && GameObject.Find("Bord").GetComponent<MinionCount>().MinionsOnPlayer2Side > 1)
            {
                //if (this.transform.parent.GetChild(this.transform.GetSiblingIndex() - 1) != null)
                try {
                    this.GetComponent<CardDisplay>().healthText.text = (int.Parse(this.GetComponent<CardDisplay>().healthText.text) + int.Parse(this.transform.parent.GetChild(this.transform.GetSiblingIndex() - 1).GetComponent<CardDisplay>().healthText.text)).ToString();
                    this.GetComponent<CardDisplay>().attackText.text = (int.Parse(this.GetComponent<CardDisplay>().attackText.text) + int.Parse(this.transform.parent.GetChild(this.transform.GetSiblingIndex() - 1).GetComponent<CardDisplay>().attackText.text)).ToString();
                    this.transform.parent.GetChild(this.transform.GetSiblingIndex() - 1).GetComponent<CardDisplay>().healthText.text = "0";
                }
                //else
                catch {
                    this.GetComponent<CardDisplay>().healthText.text = (int.Parse(this.GetComponent<CardDisplay>().healthText.text) + int.Parse(this.transform.parent.GetChild(this.transform.GetSiblingIndex() + 1).GetComponent<CardDisplay>().healthText.text)).ToString();
                    this.GetComponent<CardDisplay>().attackText.text = (int.Parse(this.GetComponent<CardDisplay>().attackText.text) + int.Parse(this.transform.parent.GetChild(this.transform.GetSiblingIndex() + 1).GetComponent<CardDisplay>().attackText.text)).ToString();
                    this.transform.parent.GetChild(this.transform.GetSiblingIndex() + 1).GetComponent<CardDisplay>().healthText.text = "0";
                }
            }
            else
            {
                if (gameObject.tag == "Player1")
                {
                    GameObject.Find("FaceHPTextP1").GetComponentInChildren<Text>().text = (int.Parse(GameObject.Find("FaceHPTextP1").GetComponentInChildren<Text>().text) - int.Parse(this.GetComponent<CardDisplay>().attackText.text)).ToString();
                }
                else
                {
                    GameObject.Find("FaceHPTextP2").GetComponentInChildren<Text>().text = (int.Parse(GameObject.Find("FaceHPTextP2").GetComponentInChildren<Text>().text) - int.Parse(this.GetComponent<CardDisplay>().attackText.text)).ToString();
                }
                this.GetComponent<CardDisplay>().healthText.text = "0";
            }
        }
    }
    public void Inmo_faseal_the_Everlasting_OnEndOfTurnEffect()
    {
        gameObject.GetComponent<LayoutElement>().ignoreLayout = false;
        //if (gameObject.tag == "Player1")
        //{
        //    gameObject.transform.SetParent(PlayZone1.transform);
        //}
        //else if (gameObject.tag == "Player2")
        //{
        //    gameObject.transform.SetParent(PlayZone2.transform);
        //}
    }
    public void Repairatron_WhenDrawnEffect()
    {
        if (tag == "Player1")
        {
            GameObject.Find("FaceHPTextP1").GetComponentInChildren<Text>().text = (int.Parse(GameObject.Find("FaceHPTextP1").GetComponentInChildren<Text>().text) + GameObject.Find("HandP1").transform.childCount).ToString();
        }
        else
        {
            GameObject.Find("FaceHPTextP2").GetComponentInChildren<Text>().text = (int.Parse(GameObject.Find("FaceHPTextP2").GetComponentInChildren<Text>().text) + GameObject.Find("HandP2").transform.childCount).ToString();
        }
    }
    public void Phum_ra_WhenDrawnEffect()
    {
        if (tag == "Player1")
        {
            SummonNEW("WhenDrawn", (CardStats)Resources.Load("CardPrefabs/Py'ra", typeof(CardStats)), PlayZone2.transform);
            SummonNEW("WhenDrawn", (CardStats)Resources.Load("CardPrefabs/Py'ra", typeof(CardStats)), PlayZone2.transform);
        }
        else if (tag == "Player2")
        {
            SummonNEW("WhenDrawn", (CardStats)Resources.Load("CardPrefabs/Py'ra", typeof(CardStats)), PlayZone1.transform);
            SummonNEW("WhenDrawn", (CardStats)Resources.Load("CardPrefabs/Py'ra", typeof(CardStats)), PlayZone1.transform);
        }
    }

    //public void Snek_OnPlayTargetedDmgEffect()
    //{
    //    if (StartedTargeting == true)
    //    {
    //        GameObject EffectArrow = (GameObject)Resources.Load("prefabs/EffectArrow", typeof(GameObject));
    //        Instantiate(EffectArrow, gameObject.transform);
    //        GameObject.Find("EndTurn").GetComponent<Button>().interactable = false;
    //        StartedTargeting = false;
    //    }
    //    int TargetHP;
    //    if (IsTargetFound == true)
    //    {
    //        int.TryParse(GameObject.Find("EffectArrow(Clone)").GetComponent<EffectTargeting>().CardBeingTargeted.GetComponent<CardDisplay>().healthText.text, out TargetHP);
    //        GameObject.Find("EffectArrow(Clone)").GetComponent<EffectTargeting>().CardBeingTargeted.GetComponent<CardDisplay>().healthText.text = (TargetHP - 1).ToString();
    //        GameObject.Find("EndTurn").GetComponent<Button>().interactable = true;
    //        Destroy(GameObject.Find("EffectArrow(Clone)"));
    //        gameObject.GetComponent<CardDisplay>().OnPlayTargetFound = true;
    //        IsTargetFound = false;
    //    }
    //}

    //public void Snek_MoreSnek_Hand()
    //{
    //    if (StartedTargeting == true)
    //    {
    //        GameObject New_Snek = (GameObject)Resources.Load("prefabs/Card", typeof(GameObject));

    //        player1turn = GameObject.Find("EndTurn").GetComponent<MyTurn>().Player1Turn;
    //        if (player1turn == true)
    //        {
    //            GameObject New_snek = Instantiate(New_Snek, GameObject.Find("HandP1").transform);
    //            New_snek.GetComponent<drag>().StartParent = GameObject.Find("HandP1").transform;
    //            New_snek.GetComponent<CardEffects>().enabled = false;
    //            New_snek.tag = "Player1";

    //        }
    //        if (player1turn == false)
    //        {
    //            GameObject New_snek = Instantiate(New_Snek, GameObject.Find("HandP2").transform);
    //            New_snek.GetComponent<drag>().StartParent = GameObject.Find("HandP2").transform;
    //            New_snek.transform.Rotate(0, 0, -180);
    //            New_snek.GetComponent<CardEffects>().enabled = false;
    //            New_snek.tag = "Player2";

    //        }

    //        gameObject.GetComponent<CardDisplay>().card = New_Snek.GetComponent<CardDisplay>().card;

    //        gameObject.GetComponent<CardDisplay>().OnPlayTargetFound = true;

    //    }
    //}

    //public void Snek_MoreSnek_Summon()
    //{
    //    if (StartedTargeting == true)
    //    {
    //        GameObject New_Snek = (GameObject)Resources.Load("prefabs/Card", typeof(GameObject));

    //        player1turn = GameObject.Find("EndTurn").GetComponent<MyTurn>().Player1Turn;
    //        if (player1turn == true)
    //        {
    //            GameObject New_snek = Instantiate(gameObject, gameObject.transform.parent);
    //            New_snek.name = "Card(Clone)";
    //            New_snek.GetComponent<LayoutElement>().ignoreLayout = false;
    //            New_snek.GetComponent<CardEffects>().enabled = false;
    //            New_snek.GetComponent<BoxCollider2D>().enabled = false;

    //            //Becaus the first OnPlayEffect is so fast the card doesnt know it'll get a card yet, the second one does so there's an error when I try to add another button
    //            if (gameObject.GetComponent<CardDisplay>().EachOnPlayEffect == 0)
    //            {
    //                Button But = New_snek.gameObject.AddComponent<Button>();
    //                But.onClick.AddListener(gameObject.transform.parent.GetComponent<PlayMinion>().AttackInitiation);
    //            }
    //            else
    //            {
    //                New_snek.GetComponent<Button>().onClick.AddListener(gameObject.transform.parent.GetComponent<PlayMinion>().AttackInitiation);
    //            }

    //            New_snek.tag = "Player1";

    //        }
    //        if (player1turn == false)
    //        {
    //            GameObject New_snek = Instantiate(gameObject, gameObject.transform.parent);
    //            New_snek.name = "Card(Clone)";
    //            New_snek.GetComponent<LayoutElement>().ignoreLayout = false;
    //            New_snek.GetComponent<CardEffects>().enabled = false;
    //            New_snek.GetComponent<BoxCollider2D>().enabled = false;

    //            //Becaus the first OnPlayEffect is so fast the card doesnt know it'll get a card yet, the second one does so there's an error when I try to add another button
    //            if (gameObject.GetComponent<CardDisplay>().EachOnPlayEffect == 0)
    //            {
    //                Button But = New_snek.gameObject.AddComponent<Button>();
    //                But.onClick.AddListener(gameObject.transform.parent.GetComponent<PlayMinion>().AttackInitiation);
    //            }
    //            else
    //            {
    //                New_snek.GetComponent<Button>().onClick.AddListener(gameObject.transform.parent.GetComponent<PlayMinion>().AttackInitiation);
    //            }
    //            New_snek.tag = "Player2";
    //        }
    //        gameObject.GetComponent<CardDisplay>().card = New_Snek.GetComponent<CardDisplay>().card;
    //        gameObject.GetComponent<CardDisplay>().OnPlayTargetFound = true;

    //    }
    //}
    //public void Snek_OnPlayAoeDmgEffect()
    //{
    //    foreach (var card in GameObject.FindGameObjectsWithTag("Player1") )
    //    {
    //        if (card.name == "Card(Clone)" && card.transform.parent.name == "PlayZone" && card.tag != gameObject.tag)
    //        {
    //            int TargetHP;
    //            int.TryParse(card.GetComponent<CardDisplay>().healthText.text, out TargetHP);
    //            TargetHP = TargetHP - 1;
    //            card.GetComponent<CardDisplay>().healthText.text = (TargetHP).ToString();
    //        }
    //    }

    //    foreach (var card in GameObject.FindGameObjectsWithTag("Player2"))
    //    {
    //        if (card.name == "Card(Clone)" && card.transform.parent.name == "PlayZone" && card.tag != gameObject.tag)
    //        {
    //            int TargetHP;
    //            int.TryParse(card.GetComponent<CardDisplay>().healthText.text, out TargetHP);
    //            TargetHP = TargetHP - 1;
    //            card.GetComponent<CardDisplay>().healthText.text = (TargetHP).ToString();
    //        }
    //    }

    //    StartedTargeting = false;
    //    gameObject.GetComponent<CardDisplay>().OnPlayTargetFound = true;
    //}

    //// OnDeathEffects

    //public void Snek_OnDeathSummon()
    //{
    //    GameObject New_Snek = (GameObject)Resources.Load("prefabs/Card", typeof(GameObject));

    //    if (gameObject.tag == "Player1")
    //    {
    //        Debug.Log("Summon");
    //        GameObject New_snek = Instantiate(gameObject, gameObject.transform.parent);
    //        New_snek.name = "Card(Clone)";
    //        New_snek.tag = "Player1";
    //        New_snek.GetComponent<LayoutElement>().ignoreLayout = false;
    //        New_snek.GetComponent<CardEffects>().enabled = false;
    //        New_snek.GetComponent<BoxCollider2D>().enabled = false;
    //        //Button But = New_snek.gameObject.AddComponent<Button>();  //intoresting
    //        New_snek.GetComponent<Button>().onClick.AddListener(gameObject.transform.parent.GetComponent<PlayMinion>().AttackInitiation);
    //    }
    //    if (gameObject.tag == "Player2")
    //    {
    //        Debug.Log("Summon");
    //        GameObject New_snek = Instantiate(gameObject, gameObject.transform.parent);
    //        New_snek.name = "Card(Clone)";
    //        New_snek.tag = "Player2";
    //        New_snek.GetComponent<LayoutElement>().ignoreLayout = false;
    //        New_snek.GetComponent<CardEffects>().enabled = false;
    //        New_snek.GetComponent<BoxCollider2D>().enabled = false;
    //        //Button But = New_snek.gameObject.AddComponent<Button>();  //intoresting
    //        New_snek.GetComponent<Button>().onClick.AddListener(gameObject.transform.parent.GetComponent<PlayMinion>().AttackInitiation);
    //    }

    //    gameObject.GetComponent<CardDisplay>().card = New_Snek.GetComponent<CardDisplay>().card;
    //}
    //public void Snek_OnDeathAoeDmgEffect()
    //{
    //    foreach (var card in GameObject.FindGameObjectsWithTag("Player1"))
    //    {
    //        if (card.name == "Card(Clone)" && card.transform.parent.name == "PlayZone" && card.GetComponent<CardDisplay>().healthText.text != "0" && card.tag != gameObject.tag)
    //        {
    //            Debug.Log("Aoe Damage");
    //            int TargetHP;
    //            int.TryParse(card.GetComponent<CardDisplay>().healthText.text, out TargetHP);
    //            TargetHP = TargetHP - 1;
    //            card.GetComponent<CardDisplay>().healthText.text = (TargetHP).ToString();
    //        }
    //    }

    //    foreach (var card in GameObject.FindGameObjectsWithTag("Player2"))
    //    {
    //        if (card.name == "Card(Clone)" && card.transform.parent.name == "PlayZone" && card.GetComponent<CardDisplay>().healthText.text != "0" && card.tag != gameObject.tag)
    //        {
    //            Debug.Log("Aoe Damage");

    //            int TargetHP;
    //            int.TryParse(card.GetComponent<CardDisplay>().healthText.text, out TargetHP);
    //            TargetHP = TargetHP - 1;
    //            card.GetComponent<CardDisplay>().healthText.text = (TargetHP).ToString();
    //        }
    //    }
    //}

    public GameObject Summon(string ByWhatEffect, GameObject WhatCard, Transform ToWhere)
    {
        player1turn = GameObject.Find("EndTurn").GetComponent<MyTurn>().Player1Turn;
        GameObject New_card = Instantiate(WhatCard, ToWhere);
        if (StartedTargeting == true)
        {
            if (ByWhatEffect == "OnPlay")
            {
                if (player1turn == true)
                {
                    New_card.name = "Card(Clone)";
                    New_card.GetComponent<LayoutElement>().ignoreLayout = false;
                    New_card.GetComponent<CardEffects>().enabled = false;
                    New_card.GetComponent<BoxCollider2D>().enabled = false;
                    New_card.tag = "Player1";
                    //Becaus the first OnPlayEffect is so fast the card doesnt know it'll get a card yet, the second one does so there's an error when I try to add another button
                    if (gameObject.GetComponent<CardDisplay>().EachOnPlayEffect == 0)
                    {
                        Button But = New_card.gameObject.AddComponent<Button>();
                        But.onClick.AddListener(gameObject.transform.parent.GetComponent<PlayMinion>().AttackInitiation);
                    }
                    else
                    {
                        New_card.GetComponent<Button>().onClick.AddListener(gameObject.transform.parent.GetComponent<PlayMinion>().AttackInitiation);
                    }
                }
                if (player1turn == false)
                {
                    New_card.name = "Card(Clone)";
                    New_card.GetComponent<LayoutElement>().ignoreLayout = false;
                    New_card.GetComponent<CardEffects>().enabled = false;
                    New_card.GetComponent<BoxCollider2D>().enabled = false;
                    New_card.tag = "Player2";
                    if (gameObject.GetComponent<CardDisplay>().EachOnPlayEffect == 0)
                    {
                        Button But = New_card.gameObject.AddComponent<Button>();
                        But.onClick.AddListener(gameObject.transform.parent.GetComponent<PlayMinion>().AttackInitiation);
                    }
                    else
                    {
                        New_card.GetComponent<Button>().onClick.AddListener(gameObject.transform.parent.GetComponent<PlayMinion>().AttackInitiation);
                    }
                }
            }
            if (ByWhatEffect == "OnDeath")
            {
                if (gameObject.tag == "Player1")
                {
                    New_card.name = "Card(Clone)";
                    New_card.tag = "Player1";
                    New_card.GetComponent<LayoutElement>().ignoreLayout = false;
                    New_card.GetComponent<CardEffects>().enabled = false;
                    New_card.GetComponent<BoxCollider2D>().enabled = false;
                    New_card.GetComponent<Button>().onClick.AddListener(gameObject.transform.parent.GetComponent<PlayMinion>().AttackInitiation);
                    GameObject.Find("Bord").GetComponent<MinionCount>().MinionsOnPlayer1Side++;
                }
                if (gameObject.tag == "Player2")
                {
                    New_card.name = "Card(Clone)";
                    New_card.tag = "Player2";
                    New_card.GetComponent<LayoutElement>().ignoreLayout = false;
                    New_card.GetComponent<CardEffects>().enabled = false;
                    New_card.GetComponent<BoxCollider2D>().enabled = false;
                    New_card.GetComponent<Button>().onClick.AddListener(gameObject.transform.parent.GetComponent<PlayMinion>().AttackInitiation);
                    GameObject.Find("Bord").GetComponent<MinionCount>().MinionsOnPlayer2Side++;
                }
            }
        }
        gameObject.GetComponent<CardDisplay>().OnPlayTargetFound = true;
        return New_card;
    }
    public GameObject SummonNEW(string ByWhatEffect, CardStats WhatCard, Transform ToWhere)
    {
        player1turn = GameObject.Find("EndTurn").GetComponent<MyTurn>().Player1Turn;
        GameObject New_card = Instantiate((GameObject)Resources.Load("prefabs/Card", typeof(GameObject)), ToWhere);
        New_card.GetComponent<CardDisplay>().card = WhatCard;
        if (StartedTargeting == true)
        {
            if (ByWhatEffect == "OnPlay")
            {
                if (ToWhere.tag == "Player1")
                {
                    New_card.name = "Card(Clone)";
                    New_card.tag = "Player1";
                    New_card.GetComponent<LayoutElement>().ignoreLayout = false;
                    //New_card.GetComponent<CardEffects>().enabled = false;
                    New_card.GetComponent<BoxCollider2D>().enabled = false;
                    New_card.GetComponent<CardDisplay>().HasAttackedThisTurn = true;
                    Button But = New_card.gameObject.AddComponent<Button>();
                    But.onClick.AddListener(PlayZone1.GetComponent<PlayMinion>().AttackInitiation);

                    //Becaus the first OnPlayEffect is so fast the card doesnt know it'll get a card yet, the second one does so there's an error when I try to add another button
                    //if (gameObject.GetComponent<CardDisplay>().EachOnPlayEffect == 0)
                    //{
                    //Button But = New_card.gameObject.AddComponent<Button>();
                    //But.onClick.AddListener(gameObject.transform.parent.GetComponent<PlayMinion>().AttackInitiation);
                    //}
                    //else
                    //{
                    //    New_card.GetComponent<Button>().onClick.AddListener(gameObject.transform.parent.GetComponent<PlayMinion>().AttackInitiation);
                    //}

                }
                if (ToWhere.tag == "Player2")
                {
                    New_card.name = "Card(Clone)";
                    New_card.tag = "Player2";
                    New_card.GetComponent<LayoutElement>().ignoreLayout = false;
                    //New_card.GetComponent<CardEffects>().enabled = false;
                    New_card.GetComponent<BoxCollider2D>().enabled = false;
                    New_card.GetComponent<CardDisplay>().HasAttackedThisTurn = true;
                    New_card.transform.Rotate(0, 0, 180);
                    Button But = New_card.gameObject.AddComponent<Button>();
                    But.onClick.AddListener(PlayZone2.GetComponent<PlayMinion>().AttackInitiation);
                }
                //gameObject.GetComponent<CardDisplay>().OnPlayTargetFound = true;
            }
            if (ByWhatEffect == "OnDeath")
            {
                if (ToWhere.tag == "Player1")
                {
                    New_card.name = "Card(Clone)";
                    New_card.tag = "Player1";
                    New_card.GetComponent<LayoutElement>().ignoreLayout = false;
                    //New_card.GetComponent<CardEffects>().enabled = false;
                    New_card.GetComponent<BoxCollider2D>().enabled = false;
                    New_card.GetComponent<CardDisplay>().HasAttackedThisTurn = true;
                    Button But = New_card.gameObject.AddComponent<Button>();
                    But.onClick.AddListener(PlayZone1.GetComponent<PlayMinion>().AttackInitiation);
                    GameObject.Find("Bord").GetComponent<MinionCount>().MinionsOnPlayer1Side++;
                }
                if (ToWhere.tag == "Player2")
                {
                    New_card.name = "Card(Clone)";
                    New_card.tag = "Player2";
                    New_card.GetComponent<LayoutElement>().ignoreLayout = false;
                    //New_card.GetComponent<CardEffects>().enabled = false;
                    New_card.GetComponent<BoxCollider2D>().enabled = false;
                    New_card.GetComponent<CardDisplay>().HasAttackedThisTurn = true;
                    New_card.transform.Rotate(0, 0, 180);
                    Button But = New_card.gameObject.AddComponent<Button>();
                    But.onClick.AddListener(PlayZone2.GetComponent<PlayMinion>().AttackInitiation);
                    GameObject.Find("Bord").GetComponent<MinionCount>().MinionsOnPlayer2Side++;
                }
            }
        }
        if (ByWhatEffect == "WhenDrawn")
        {
            if (ToWhere.tag == "Player1")
            {
                New_card.name = "Card(Clone)";
                New_card.tag = "Player1";
                New_card.GetComponent<LayoutElement>().ignoreLayout = false;
                //New_card.GetComponent<CardEffects>().enabled = false;
                New_card.GetComponent<BoxCollider2D>().enabled = false;
                New_card.GetComponent<CardDisplay>().HasAttackedThisTurn = true;
                Button But = New_card.gameObject.AddComponent<Button>();
                But.onClick.AddListener(PlayZone1.GetComponent<PlayMinion>().AttackInitiation);
                GameObject.Find("Bord").GetComponent<MinionCount>().MinionsOnPlayer1Side++;
            }
            if (ToWhere.tag == "Player2")
            {
                New_card.name = "Card(Clone)";
                New_card.tag = "Player2";
                New_card.GetComponent<LayoutElement>().ignoreLayout = false;
                //New_card.GetComponent<CardEffects>().enabled = false;
                New_card.GetComponent<BoxCollider2D>().enabled = false;
                New_card.GetComponent<CardDisplay>().HasAttackedThisTurn = true;
                New_card.transform.Rotate(0, 0, 180);
                Button But = New_card.gameObject.AddComponent<Button>();
                But.onClick.AddListener(PlayZone2.GetComponent<PlayMinion>().AttackInitiation);
                GameObject.Find("Bord").GetComponent<MinionCount>().MinionsOnPlayer2Side++;
            }
        }
        gameObject.GetComponent<CardDisplay>().OnPlayTargetFound = true;
        return New_card;
    }
}

