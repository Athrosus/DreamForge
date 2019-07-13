using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardEffects : MonoBehaviour
{
    public delegate void OnPlayEffect();
    public delegate void OnDeathEffect();
    public delegate void PassiveEffect();
    public bool IsTargetFound, StartedTargeting = false, player1turn;
    public GameObject PlayZone1, PlayZone2, DeckP1, DeckP2, FaceP1, FaceP2;
    public int NumberOfTargets=0;

    public void Start()
    {
        foreach (GameObject item in GameObject.FindGameObjectsWithTag("Player1"))
        {
            if (item.name == "Deck")
            {
                DeckP1 = item;
            }
        }
        foreach (GameObject item in GameObject.FindGameObjectsWithTag("Player2"))
        {
            if (item.name == "Deck")
            {
                DeckP2 = item;
            }
        }
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
        FaceP1 = GameObject.Find("FaceIconP1");
        FaceP2 = GameObject.Find("FaceIconP2");

        //    OnPlaySelfBuffs
        if (gameObject.GetComponent<CardDisplay>().nameText.text == "Flower" || gameObject.GetComponent<CardDisplay>().nameText.text == "Dun_Rast_Spawn" || gameObject.GetComponent<CardDisplay>().nameText.text == "Dun'Rast" || gameObject.GetComponent<CardDisplay>().nameText.text == "Card18" || gameObject.GetComponent<CardDisplay>().nameText.text == "StoneGate Priestess" || gameObject.GetComponent<CardDisplay>().nameText.text == "Maunten" || gameObject.GetComponent<CardDisplay>().nameText.text == "Card2" || gameObject.GetComponent<CardDisplay>().nameText.text == "Card5" || gameObject.GetComponent<CardDisplay>().nameText.text == "Card8" || gameObject.GetComponent<CardDisplay>().nameText.text == "Card8_Spawn")
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
        if (gameObject.GetComponent<CardDisplay>().nameText.text == "Card16")
        {
            gameObject.GetComponent<CardDisplay>().ThisOnPlayEffects.Add(Card16_OnPlayEffect);
        }
        if (gameObject.GetComponent<CardDisplay>().nameText.text == "Card17")
        {
            gameObject.GetComponent<CardDisplay>().ThisOnPlayEffects.Add(Card17_OnPlayEffect);
        }
        if (gameObject.GetComponent<CardDisplay>().nameText.text == "Card18")
        {
            gameObject.GetComponent<CardDisplay>().ThisOnPlayEffects.Add(Card18_OnPlayEffect);
        }
        if (gameObject.GetComponent<CardDisplay>().nameText.text == "Fractured Obelisc")
        {
            gameObject.GetComponent<CardDisplay>().ThisOnPlayEffects.Add(Fractured_Obelisc_OnPlayEffect);
        }
        if (gameObject.GetComponent<CardDisplay>().nameText.text == "Keth'faseal the Generous")
        {
            gameObject.GetComponent<CardDisplay>().ThisOnPlayEffects.Add(Keth_faseal_OnPlayEffect);
        }
        if (gameObject.GetComponent<CardDisplay>().nameText.text == "Card19")
        {
            gameObject.GetComponent<CardDisplay>().ThisOnPlayEffects.Add(Card19_OnPlayEffect);
        }
        if (gameObject.GetComponent<CardDisplay>().nameText.text == "Card20")
        {
            gameObject.GetComponent<CardDisplay>().ThisOnPlayEffects.Add(Card20_OnPlayEffect);
        }
        if (gameObject.GetComponent<CardDisplay>().nameText.text == "Card21")
        {
            gameObject.GetComponent<CardDisplay>().ThisOnPlayEffects.Add(Card21_OnPlayEffect);
        }
        if (gameObject.GetComponent<CardDisplay>().nameText.text == "Dun'Rast")
        {
            gameObject.GetComponent<CardDisplay>().ThisOnPlayEffects.Add(Dun_Rast_OnPlayEffect);
        }
        if (gameObject.GetComponent<CardDisplay>().nameText.text == "Card22")
        {
            gameObject.GetComponent<CardDisplay>().ThisOnPlayEffects.Add(Card22_OnPlayEffect);
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
        if (gameObject.GetComponent<CardDisplay>().nameText.text == "Card15")
        {
            gameObject.GetComponent<CardDisplay>().ThisWhenDrawnEffects.Add(Card15_WhenDrawnEffect);
        }
        if (gameObject.GetComponent<CardDisplay>().nameText.text == "Fractured Obelisc")
        {
            gameObject.GetComponent<CardDisplay>().ThisWhenDrawnEffects.Add(Fractured_Obelisc_WhenDrawnEffect);
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
        } // !!! Kinda buggy with more of the same effect happoning at once, also kills itself randomly 
        if (gameObject.GetComponent<CardDisplay>().nameText.text == "Inmo'faseal the Everlasting")
        {
            gameObject.GetComponent<CardDisplay>().ThisOnEndOfTrunEffects.Add(Inmo_faseal_the_Everlasting_OnEndOfTurnEffect);
        }
        if (gameObject.GetComponent<CardDisplay>().nameText.text == "StoneGate Priestess")
        {
            gameObject.GetComponent<CardDisplay>().ThisOnEndOfTrunEffects.Add(StoneGate_Priestess_OnEndOfTurnEffect);
        }

        //    OnEndOfTurnEffects
        //    OnKillEffects
        if (gameObject.GetComponent<CardDisplay>().nameText.text == "Card22")
        {
            gameObject.GetComponent<CardDisplay>().ThisOnKillEffects.Add(Card22_OnKillEffect);
        }
        //    OnKillEffects
        //    OnDeathEffects
        if (gameObject.GetComponent<CardDisplay>().nameText.text == "Card0")
        {
            gameObject.GetComponent<CardDisplay>().ThisOnDeathEffects.Add(Card0_OnDeathEffect);
        }
        if (gameObject.GetComponent<CardDisplay>().nameText.text == "Card3")
        {
            gameObject.GetComponent<CardDisplay>().ThisOnDeathEffects.Add(Card3_OnDeathEffect);
        }
        if (gameObject.GetComponent<CardDisplay>().nameText.text == "Card3_Spawn")
        {
            gameObject.GetComponent<CardDisplay>().ThisOnDeathEffects.Add(Card3_Spawn_OnDeathEffect);
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
        if (gameObject.GetComponent<CardDisplay>().nameText.text == "Card16")
        {
            gameObject.GetComponent<CardDisplay>().ThisOnDeathEffects.Add(Card16_OnDeathEffect);
        }
        if (gameObject.GetComponent<CardDisplay>().nameText.text == "Card17")
        {
            gameObject.GetComponent<CardDisplay>().ThisOnDeathEffects.Add(Card17_OnDeathEffect);
        }
        if (gameObject.GetComponent<CardDisplay>().nameText.text == "Card22")
        {
            gameObject.GetComponent<CardDisplay>().ThisOnDeathEffects.Add(Card22_OnDeathEffect);
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
                foreach (var card in GameObject.FindGameObjectsWithTag("Player2"))
                {
                    if (card.name == "Card(Clone)" && card.transform.parent.name == "PlayZone" && int.Parse(card.GetComponent<CardDisplay>().healthText.text) > 0)
                    {
                        if (MinionNumber == RandomEnemyMinions)
                        {
                            EventTracker.Damage(gameObject, 1, card);
                        }
                        MinionNumber++;
                    }
                }
            }
            else if (gameObject.tag == "Player2" && GameObject.Find("Bord").GetComponent<MinionCount>().MinionsOnPlayer1Side > 0)
            {
                int RandomEnemyMinions, MinionNumber = 0;
                RandomEnemyMinions = Random.Range(0, GameObject.Find("Bord").GetComponent<MinionCount>().MinionsOnPlayer1Side);

                foreach (var card in GameObject.FindGameObjectsWithTag("Player1"))
                {
                    if (card.name == "Card(Clone)" && card.transform.parent.name == "PlayZone" && int.Parse(card.GetComponent<CardDisplay>().healthText.text) > 0)
                    {
                        if (MinionNumber == RandomEnemyMinions)
                        {
                            EventTracker.Damage(gameObject, 1, card);
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
        int FirstNum = 1;
        for (int i = 0; i < FirstNum; i++)
        {
            SummonNEW("OnPlay", (CardStats)Resources.Load("CardPrefabs/Card8_Spawn", typeof(CardStats)), gameObject.transform.parent);
        }
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
            EventTracker.Damage(gameObject, 1, GameObject.Find("EffectArrow(Clone)").GetComponent<EffectTargeting>().CardBeingTargeted);
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
    public void Card16_OnPlayEffect()
    {
        int FirstNum = 20, SecondNum = 60;
        if (tag == "Player1")
        {
            if (int.Parse(GameObject.Find("FaceHPTextP1").GetComponentInChildren<Text>().text) > FirstNum && int.Parse(GameObject.Find("FaceHPTextP1").GetComponentInChildren<Text>().text) < SecondNum)
            {
                GameObject.Find("Player1").GetComponentInChildren<Deck>().DrawACard(1);
            }
        }
        else
        {
            if (int.Parse(GameObject.Find("FaceHPTextP2").GetComponentInChildren<Text>().text) > FirstNum && int.Parse(GameObject.Find("FaceHPTextP2").GetComponentInChildren<Text>().text) < SecondNum)
            {
                GameObject.Find("Player2").GetComponentInChildren<Deck>().DrawACard(1);
            }
        }
        gameObject.GetComponent<CardDisplay>().OnPlayTargetFound = true;
    }
    public void Card17_OnPlayEffect()
    {
        int FirstNum = 5;
        if (this.tag == "Player1")
        {
            GameObject.Find("Player1").GetComponentInChildren<Deck>().DrawACard(FirstNum);
        }
        else
        {
            GameObject.Find("Player2").GetComponentInChildren<Deck>().DrawACard(FirstNum);
        }
        gameObject.GetComponent<CardDisplay>().OnPlayTargetFound = true;

    }
    public void Card18_OnPlayEffect()
    {
        if (this.tag == "Player1")
        {
            GameObject.Find("Player2").GetComponentInChildren<Deck>().DrawACard(GameObject.Find("HandP1").transform.childCount - GameObject.Find("HandP2").transform.childCount);
        }
        else
        {
            GameObject.Find("Player1").GetComponentInChildren<Deck>().DrawACard(GameObject.Find("HandP2").transform.childCount - GameObject.Find("HandP1").transform.childCount);
        }
        gameObject.GetComponent<CardDisplay>().OnPlayTargetFound = true;

    }
    public void Fractured_Obelisc_OnPlayEffect()
    {
        int FirstNum = 1, SecondNum = 1;
        if (this.tag == "Player1")
        {
            foreach (var card in GameObject.FindGameObjectsWithTag("Player1"))
            {
                if (card.name == "Card(Clone)" && card.transform.parent.name == "PlayZone")
                {
                    card.GetComponent<CardDisplay>().healthText.text = (int.Parse(card.GetComponent<CardDisplay>().healthText.text) + FirstNum).ToString();
                    card.GetComponent<CardDisplay>().attackText.text = (int.Parse(card.GetComponent<CardDisplay>().attackText.text) + SecondNum).ToString();
                }
            }
        }
        else
        {
            foreach (var card in GameObject.FindGameObjectsWithTag("Player2"))
            {
                if (card.name == "Card(Clone)" && card.transform.parent.name == "PlayZone")
                {
                    card.GetComponent<CardDisplay>().healthText.text = (int.Parse(card.GetComponent<CardDisplay>().healthText.text) + FirstNum).ToString();
                    card.GetComponent<CardDisplay>().attackText.text = (int.Parse(card.GetComponent<CardDisplay>().attackText.text) + SecondNum).ToString();
                }
            }
        }
        gameObject.GetComponent<CardDisplay>().OnPlayTargetFound = true;

    }
    public void Keth_faseal_OnPlayEffect()
    {
        if (StartedTargeting == true)
        {
            GameObject EffectArrow = (GameObject)Resources.Load("prefabs/EffectArrow", typeof(GameObject));
            Instantiate(EffectArrow, gameObject.transform);
            GameObject.Find("EndTurn").GetComponent<Button>().interactable = false;
            StartedTargeting = false;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && GameObject.Find("EffectArrow(Clone)").GetComponent<EffectTargeting>().CardBeingTargeted != null && GameObject.Find("EffectArrow(Clone)").GetComponent<EffectTargeting>().CardBeingTargeted.transform.parent.name == "PlayZone" && GameObject.Find("EffectArrow(Clone)").GetComponent<EffectTargeting>().CardBeingTargeted.tag == this.tag)
        {
            Cursor.visible = true;
            IsTargetFound = true;
            if (this.tag == "Player1")
            {
                foreach (var card in GameObject.FindGameObjectsWithTag("Player1"))
                {
                    if (card.name == "Card(Clone)" && card.transform.parent.name == "PlayZone" && card != GameObject.Find("EffectArrow(Clone)").GetComponent<EffectTargeting>().CardBeingTargeted)
                    {
                        GameObject.Find("EffectArrow(Clone)").GetComponent<EffectTargeting>().CardBeingTargeted.GetComponent<CardDisplay>().healthText.text = (int.Parse(card.GetComponent<CardDisplay>().healthText.text) + (int.Parse(GameObject.Find("EffectArrow(Clone)").GetComponent<EffectTargeting>().CardBeingTargeted.GetComponent<CardDisplay>().healthText.text))).ToString();
                        GameObject.Find("EffectArrow(Clone)").GetComponent<EffectTargeting>().CardBeingTargeted.GetComponent<CardDisplay>().attackText.text = (int.Parse(card.GetComponent<CardDisplay>().attackText.text) + (int.Parse(GameObject.Find("EffectArrow(Clone)").GetComponent<EffectTargeting>().CardBeingTargeted.GetComponent<CardDisplay>().attackText.text))).ToString();
                    }
                }
                for (int i = 0; i < PlayZone1.transform.childCount; i++)
                {
                    GameObject card = PlayZone1.transform.GetChild(i).gameObject;
                    if (card != GameObject.Find("EffectArrow(Clone)").GetComponent<EffectTargeting>().CardBeingTargeted)
                    {
                        EventTracker.DestroyCard(gameObject, card);
                    }
                }
            }
            else
            {
                foreach (var card in GameObject.FindGameObjectsWithTag("Player2"))
                {
                    if (card.name == "Card(Clone)" && card.transform.parent.name == "PlayZone" && card != GameObject.Find("EffectArrow(Clone)").GetComponent<EffectTargeting>().CardBeingTargeted)
                    {
                        GameObject.Find("EffectArrow(Clone)").GetComponent<EffectTargeting>().CardBeingTargeted.GetComponent<CardDisplay>().healthText.text = (int.Parse(card.GetComponent<CardDisplay>().healthText.text) + (int.Parse(GameObject.Find("EffectArrow(Clone)").GetComponent<EffectTargeting>().CardBeingTargeted.GetComponent<CardDisplay>().healthText.text))).ToString();
                        GameObject.Find("EffectArrow(Clone)").GetComponent<EffectTargeting>().CardBeingTargeted.GetComponent<CardDisplay>().attackText.text = (int.Parse(card.GetComponent<CardDisplay>().attackText.text) + (int.Parse(GameObject.Find("EffectArrow(Clone)").GetComponent<EffectTargeting>().CardBeingTargeted.GetComponent<CardDisplay>().attackText.text))).ToString();
                    }
                }
                for (int i = 0; i < PlayZone2.transform.childCount; i++)
                {
                    GameObject card = PlayZone2.transform.GetChild(i).gameObject;
                    if (card != GameObject.Find("EffectArrow(Clone)").GetComponent<EffectTargeting>().CardBeingTargeted)
                    {
                        EventTracker.DestroyCard(gameObject, card);
                    }
                }
            }
            GameObject.Find("EndTurn").GetComponent<Button>().interactable = true;
            Destroy(GameObject.Find("EffectArrow(Clone)"));
            gameObject.GetComponent<CardDisplay>().OnPlayTargetFound = true;
            IsTargetFound = false;
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
    public void Card19_OnPlayEffect()
    {
        if (tag == "Player1" && GameObject.Find("Bord").GetComponent<MinionCount>().MinionsOnPlayer1Side < 1)
        {
        gameObject.GetComponent<CardDisplay>().HasAttackedThisTurn = false;
        }
        else if(tag == "Player2" && GameObject.Find("Bord").GetComponent<MinionCount>().MinionsOnPlayer2Side < 1)
        {
        gameObject.GetComponent<CardDisplay>().HasAttackedThisTurn = false;
        }
        gameObject.GetComponent<CardDisplay>().OnPlayTargetFound = true;
    }
    public void Card20_OnPlayEffect()
    {
        int FirstNum = 2;
        for (int i = 0; i < FirstNum; i++)
        {
        SummonNEW("OnPlay", (CardStats)Resources.Load("CardPrefabs/Fractured_Obelisc_Spawn", typeof(CardStats)), gameObject.transform.parent);
        }
    }
    public void Card21_OnPlayEffect()
    {
        int FirstNum = 2;
        if (tag == "Player1" && DeckP1.transform.childCount > DeckP2.transform.childCount)
        {
            for (int i = 0; i < FirstNum; i++)
            {
                SummonNEW("OnPlay", (CardStats)Resources.Load("CardPrefabs/Card21_Spawn", typeof(CardStats)), gameObject.transform.parent);
            }
        }
        else if (tag == "Player2" && DeckP2.transform.childCount > DeckP1.transform.childCount)
        {
            for (int i = 0; i < FirstNum; i++)
            {
                SummonNEW("OnPlay", (CardStats)Resources.Load("CardPrefabs/Card21_Spawn", typeof(CardStats)), gameObject.transform.parent);
            }
        }
        gameObject.GetComponent<CardDisplay>().OnPlayTargetFound = true;
    }
    public void Dun_Rast_OnPlayEffect()
    {
        int FirstNum = 1;
        for (int i = 0; i < FirstNum; i++)
        {
            SummonNEW("OnPlay", (CardStats)Resources.Load("CardPrefabs/Dun_Rast_Spawn", typeof(CardStats)), gameObject.transform.parent);
        }
    }
    public void Card22_OnPlayEffect()
    {
        int FirstdNum = 1;
        foreach (var card in GameObject.FindGameObjectsWithTag(gameObject.tag))
        {
            if (card.name == "Card(Clone)" && card.transform.parent.name == "PlayZone" && int.Parse(card.GetComponent<CardDisplay>().healthText.text) > 0)
            {
                card.GetComponent<CardDisplay>().healthText.text = (int.Parse(card.GetComponent<CardDisplay>().healthText.text) + FirstdNum).ToString();
            }
        }
        gameObject.GetComponent<CardDisplay>().OnPlayTargetFound = true;
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
                EventTracker.Damage(gameObject, 2, card);
            }
        }
        foreach (var card in GameObject.FindGameObjectsWithTag("Player2"))
        {
            if (card.name == "Card(Clone)" && card.transform.parent.name == "PlayZone" && int.Parse(card.GetComponent<CardDisplay>().healthText.text) > 0)
            {
                EventTracker.Damage(gameObject, 2, card);
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
                New_snek.GetComponent<drag>().StartParent = GameObject.Find("HandP1").transform;
                New_snek.tag = "Player1";
            }
        }
        if (this.tag == "Player2")
        {
            if (GameObject.Find("HandP2").transform.childCount <= 9)
            {
                GameObject New_snek = Instantiate(New_Snek, GameObject.Find("HandP2").transform);
                New_snek.GetComponent<CardDisplay>().card = (CardStats)Resources.Load("CardPrefabs/Card3_Spawn", typeof(CardStats));
                New_snek.GetComponent<drag>().StartParent = GameObject.Find("HandP2").transform;
                New_snek.transform.Rotate(0, 0, -180);
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
                EventTracker.Damage(gameObject, 2, card);
            }
        }
        foreach (var card in GameObject.FindGameObjectsWithTag("Player2"))
        {
            if (card.name == "Card(Clone)" && card.transform.parent.name == "PlayZone" && int.Parse(card.GetComponent<CardDisplay>().healthText.text) > 0)
            {
                EventTracker.Damage(gameObject, 2, card);
            }
        }
    }
    public void Card5_OnDeathEffect()
    {
        foreach (var card in GameObject.FindGameObjectsWithTag("Player1"))
        {
            if (card.name == "Card(Clone)" && card.transform.parent.name == "PlayZone" && int.Parse(card.GetComponent<CardDisplay>().healthText.text) > 0)
            {
                EventTracker.Damage(gameObject, 2, card);
            }
        }
        foreach (var card in GameObject.FindGameObjectsWithTag("Player2"))
        {
            if (card.name == "Card(Clone)" && card.transform.parent.name == "PlayZone" && int.Parse(card.GetComponent<CardDisplay>().healthText.text) > 0)
            {
                EventTracker.Damage(gameObject, 2, card);
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
            EventTracker.DamageToFace(gameObject, FirstNum, FaceP1);
        }
        if (gameObject.tag == "Player2")
        {
            EventTracker.DamageToFace(gameObject, FirstNum, FaceP2);
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
        //player1turn = GameObject.Find("EndTurn").GetComponent<MyTurn>().Player1Turn;
        //if (gameObject.tag == "Player1")
        //{
        //    GameObject New_snek = Instantiate(gameObject, PlayZone1.transform);
        //    New_snek.name = "Card(Clone)";
        //    New_snek.GetComponent<LayoutElement>().ignoreLayout = true;
        //    New_snek.GetComponent<BoxCollider2D>().enabled = false;
        //    New_snek.GetComponent<CardDisplay>().card = (CardStats)Resources.Load("CardPrefabs/" + gameObject.GetComponent<CardDisplay>().card.name, typeof(CardStats));
        //    New_snek.GetComponent<Button>().onClick.AddListener(gameObject.transform.parent.GetComponent<PlayMinion>().AttackInitiation);
        //    New_snek.tag = "Player1";
        //}
        //if (gameObject.tag == "Player2")
        //{
        //    GameObject New_snek = Instantiate(gameObject, PlayZone2.transform);
        //    New_snek.name = "Card(Clone)";
        //    New_snek.GetComponent<LayoutElement>().ignoreLayout = true;
        //    New_snek.GetComponent<BoxCollider2D>().enabled = false;
        //    New_snek.GetComponent<CardDisplay>().card = (CardStats)Resources.Load("CardPrefabs/" + gameObject.GetComponent<CardDisplay>().card.name, typeof(CardStats));
        //    New_snek.GetComponent<Button>().onClick.AddListener(gameObject.transform.parent.GetComponent<PlayMinion>().AttackInitiation);
        //    New_snek.tag = "Player2";
        //}
        //gameObject.GetComponent<CardDisplay>().OnPlayTargetFound = true;
        GameObject newcard = SummonNEW("OnDeath", (CardStats)Resources.Load("CardPrefabs/Inmo'faseal the Everlasting", typeof(CardStats)), gameObject.transform.parent);
        newcard.GetComponent<LayoutElement>().ignoreLayout = true;
    } //Not a true copy FULL card
    public void Py_ra_OnDeathEffect()
    {
        int FirstNum = 2;
        if (gameObject.transform.parent.tag == "Player1")
        {
            EventTracker.DamageToFace(gameObject, FirstNum, FaceP1);
        }
        if (gameObject.transform.parent.tag == "Player2")
        {
            EventTracker.DamageToFace(gameObject, FirstNum, FaceP2);
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
            EventTracker.DamageToFace(gameObject, FirstNum, FaceP2);
        }
        else
        {
            EventTracker.DamageToFace(gameObject, FirstNum, FaceP1);
        }
    }
    public void Card16_OnDeathEffect()
    {
        int FirstNum = 20, SecondNum = 60;
        if (tag == "Player1")
        {
            if (int.Parse(GameObject.Find("FaceHPTextP1").GetComponentInChildren<Text>().text) < FirstNum || int.Parse(GameObject.Find("FaceHPTextP1").GetComponentInChildren<Text>().text) > SecondNum)
            {
                GameObject.Find("Player1").GetComponentInChildren<Deck>().DrawACard(2);
            }
        }
        else
        {
            if (int.Parse(GameObject.Find("FaceHPTextP2").GetComponentInChildren<Text>().text) < FirstNum || int.Parse(GameObject.Find("FaceHPTextP2").GetComponentInChildren<Text>().text) > SecondNum)
            {
                GameObject.Find("Player2").GetComponentInChildren<Deck>().DrawACard(2);
            }
        }
    }
    public void Card17_OnDeathEffect()
    {
        int FirstNum = 5;
        if (this.tag == "Player1")
        {
            GameObject.Find("Player1").GetComponentInChildren<Deck>().DrawACard(FirstNum);
        }
        else
        {
            GameObject.Find("Player2").GetComponentInChildren<Deck>().DrawACard(FirstNum);
        }
    }
    public void Card22_OnDeathEffect()
    {
        int SecondNum = 1;
        foreach (var card in GameObject.FindGameObjectsWithTag(gameObject.tag))
        {
            if (card.name == "Card(Clone)" && card.transform.parent.name == "PlayZone" && int.Parse(card.GetComponent<CardDisplay>().healthText.text) > 0)
            {
                card.GetComponent<CardDisplay>().attackText.text = (int.Parse(card.GetComponent<CardDisplay>().attackText.text) + SecondNum).ToString();
            }
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
                    //this.transform.parent.GetChild(this.transform.GetSiblingIndex() + 1).GetComponent<CardDisplay>().healthText.text = "0";
                    EventTracker.DestroyCard(gameObject, transform.parent.GetChild(transform.GetSiblingIndex() + 1).gameObject);
                }
                //else
                catch {
                    this.GetComponent<CardDisplay>().healthText.text = (int.Parse(this.GetComponent<CardDisplay>().healthText.text) + int.Parse(this.transform.parent.GetChild(this.transform.GetSiblingIndex() - 1).GetComponent<CardDisplay>().healthText.text)).ToString();
                    this.GetComponent<CardDisplay>().attackText.text = (int.Parse(this.GetComponent<CardDisplay>().attackText.text) + int.Parse(this.transform.parent.GetChild(this.transform.GetSiblingIndex() - 1).GetComponent<CardDisplay>().attackText.text)).ToString();
                    //this.transform.parent.GetChild(this.transform.GetSiblingIndex() - 1).GetComponent<CardDisplay>().healthText.text = "0";
                    EventTracker.DestroyCard(gameObject, transform.parent.GetChild(transform.GetSiblingIndex() - 1).gameObject);
                }
            }
            else if (this.tag == "Player2" && GameObject.Find("Bord").GetComponent<MinionCount>().MinionsOnPlayer2Side > 1)
            {
                //if (this.transform.parent.GetChild(this.transform.GetSiblingIndex() - 1) != null)
                try {
                    this.GetComponent<CardDisplay>().healthText.text = (int.Parse(this.GetComponent<CardDisplay>().healthText.text) + int.Parse(this.transform.parent.GetChild(this.transform.GetSiblingIndex() - 1).GetComponent<CardDisplay>().healthText.text)).ToString();
                    this.GetComponent<CardDisplay>().attackText.text = (int.Parse(this.GetComponent<CardDisplay>().attackText.text) + int.Parse(this.transform.parent.GetChild(this.transform.GetSiblingIndex() - 1).GetComponent<CardDisplay>().attackText.text)).ToString();
                    //this.transform.parent.GetChild(this.transform.GetSiblingIndex() - 1).GetComponent<CardDisplay>().healthText.text = "0";
                    EventTracker.DestroyCard(gameObject, transform.parent.GetChild(transform.GetSiblingIndex() - 1).gameObject);
                }
                //else
                catch {
                    this.GetComponent<CardDisplay>().healthText.text = (int.Parse(this.GetComponent<CardDisplay>().healthText.text) + int.Parse(this.transform.parent.GetChild(this.transform.GetSiblingIndex() + 1).GetComponent<CardDisplay>().healthText.text)).ToString();
                    this.GetComponent<CardDisplay>().attackText.text = (int.Parse(this.GetComponent<CardDisplay>().attackText.text) + int.Parse(this.transform.parent.GetChild(this.transform.GetSiblingIndex() + 1).GetComponent<CardDisplay>().attackText.text)).ToString();
                    //this.transform.parent.GetChild(this.transform.GetSiblingIndex() + 1).GetComponent<CardDisplay>().healthText.text = "0";
                    EventTracker.DestroyCard(gameObject, transform.parent.GetChild(transform.GetSiblingIndex() + 1).gameObject);
                }
            }
            else
            {
                if (gameObject.tag == "Player1")
                {
                    EventTracker.DamageToFace(gameObject, GetComponent<CardDisplay>().attackText.text, FaceP1);
                    //GameObject.Find("FaceHPTextP1").GetComponentInChildren<Text>().text = (int.Parse(GameObject.Find("FaceHPTextP1").GetComponentInChildren<Text>().text) - int.Parse(this.GetComponent<CardDisplay>().attackText.text)).ToString();
                }
                else
                {
                    //GameObject.Find("FaceHPTextP2").GetComponentInChildren<Text>().text = (int.Parse(GameObject.Find("FaceHPTextP2").GetComponentInChildren<Text>().text) - int.Parse(this.GetComponent<CardDisplay>().attackText.text)).ToString();
                    EventTracker.DamageToFace(gameObject, GetComponent<CardDisplay>().attackText.text, FaceP1);
                }
                EventTracker.DestroyCard(gameObject, gameObject);
                //this.GetComponent<CardDisplay>().healthText.text = "0";
            }
        }
    } //Changed a lot so might work even worse
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
    public void StoneGate_Priestess_OnEndOfTurnEffect()
    {
        int FirstNum = 3;
        if (gameObject.transform.parent.tag == "Player1")
        {
            GameObject.Find("FaceHPTextP1").GetComponentInChildren<Text>().text = (int.Parse(GameObject.Find("FaceHPTextP1").GetComponentInChildren<Text>().text) + FirstNum).ToString();
        }
        if (gameObject.transform.parent.tag == "Player2")
        {
            GameObject.Find("FaceHPTextP2").GetComponentInChildren<Text>().text = (int.Parse(GameObject.Find("FaceHPTextP2").GetComponentInChildren<Text>().text) + FirstNum).ToString();
        }
    }
    
    public void Repairatron_WhenDrawnEffect()
    {
        if (tag == "Player1")
        {
            GameObject.Find("FaceHPTextP1").GetComponentInChildren<Text>().text = (int.Parse(GameObject.Find("FaceHPTextP1").GetComponentInChildren<Text>().text) + GameObject.Find("HandP1").transform.childCount-1).ToString();
        }
        else
        {
            GameObject.Find("FaceHPTextP2").GetComponentInChildren<Text>().text = (int.Parse(GameObject.Find("FaceHPTextP2").GetComponentInChildren<Text>().text) + GameObject.Find("HandP2").transform.childCount-1).ToString();
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
    public void Card15_WhenDrawnEffect()
    {
        int FirstNum = 5, SecondNum = 5;
        if (tag == "Player1")
        {
            if (GameObject.Find("HandP1").transform.childCount - 1 >= SecondNum)
            {
                GameObject.Find("FaceHPTextP1").GetComponentInChildren<Text>().text = (int.Parse(GameObject.Find("FaceHPTextP1").GetComponentInChildren<Text>().text) + FirstNum).ToString();
            }
            if (GameObject.Find("HandP1").transform.childCount - 1 <= SecondNum)
            {
                GameObject.Find("Player1").GetComponentInChildren<Deck>().DrawACard(1);
            }
        }
        else
        {
            if (GameObject.Find("HandP2").transform.childCount - 1 >= SecondNum)
            {
                GameObject.Find("FaceHPTextP2").GetComponentInChildren<Text>().text = (int.Parse(GameObject.Find("FaceHPTextP2").GetComponentInChildren<Text>().text) + FirstNum).ToString();
            }
            if (GameObject.Find("HandP2").transform.childCount - 1 <= SecondNum)
            {
                GameObject.Find("Player2").GetComponentInChildren<Deck>().DrawACard(1);
            }
        }
    }
    public void Fractured_Obelisc_WhenDrawnEffect()
    {
        if (tag == "Player1")
        {
            for (int i = 0; i < GameObject.Find("EndTurn").GetComponent<MyTurn>().Player1ManaMax ; i++)
            {
                SummonNEW("WhenDrawn", (CardStats)Resources.Load("CardPrefabs/Fractured_Obelisc_Spawn", typeof(CardStats)), PlayZone1.transform);
            }
        }
        else
        {
            for (int i = 0; i < GameObject.Find("EndTurn").GetComponent<MyTurn>().Player2ManaMax; i++)
            {
                SummonNEW("WhenDrawn", (CardStats)Resources.Load("CardPrefabs/Fractured_Obelisc_Spawn", typeof(CardStats)), PlayZone2.transform);
            }
        }
    }

    public void Card22_OnKillEffect()
    {
        int SecondNum = 1;
        foreach (var card in GameObject.FindGameObjectsWithTag(gameObject.tag))
        {
            if (card.name == "Card(Clone)" && card.transform.parent.name == "PlayZone" && int.Parse(card.GetComponent<CardDisplay>().healthText.text) > 0)
            {
                card.GetComponent<CardDisplay>().attackText.text = (int.Parse(card.GetComponent<CardDisplay>().attackText.text) + SecondNum).ToString();
            }
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

