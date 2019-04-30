
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using System.ComponentModel;
using System;

public class CardDisplay : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
  
    public delegate void OnPlayEffect();
    public delegate void OnDeathEffect();
    public delegate void PassiveEffect();

    public List<OnPlayEffect> ThisOnPlaySelfBuff = new List<OnPlayEffect>();
    public List<OnPlayEffect> ThisOnPlayEffects = new List<OnPlayEffect>();
    public List<OnDeathEffect> ThisOnDeathEffects = new List<OnDeathEffect>();
    public List<PassiveEffect> ThisOnStartOfTrunEffects = new List<PassiveEffect>();
    public List<PassiveEffect> ThisOnEndOfTrunEffects = new List<PassiveEffect>();
    public List<PassiveEffect> ThisWhenDrawnEffects = new List<PassiveEffect>();

    public bool HasAttackedThisTurn = true, WasItPlayed = false, IsTaunt = false, HasDied = false, OnStartOfTurnOnce = true, OnPlayTargetFound, OnEndOfTurnOnce = true;
    public int EachOnPlayBuff, EachOnPlayEffect, EachOnDeathEffect, EachWhenDrawnEffect;

    public CardStats card;
    public Text nameText;
    public Text descriptionText;
    public Image artworkImage;
    public Text manaText;
    public Text attackText;
    public Text healthText;
    public Text Tire;
    int health;

    public Text HealthText{
        get { return healthText; }
        set
        {
            if (healthText != value)
            {
                healthText = value;
            }
        }
    }

    // Use this for initialization
    void Start () {
        if (card != null)
        {
            nameText.text = card.name;
            descriptionText.text = card.description;
            artworkImage.sprite = card.artwork;
            manaText.text = card.manaCost.ToString();
            attackText.text = card.attack.ToString();
            healthText.text = card.health.ToString();
            Tire.text = card.tire;

        }
    }

    
    // Update is called once per frame
    void FixedUpdate () {
        GameObject TurnButton = GameObject.Find("EndTurn");
        if (GameObject.Find("EffectArrow(Clone)") != null)
        {
            gameObject.GetComponent<Rigidbody2D>().simulated = false;
        }
        else
        {
            gameObject.GetComponent<Rigidbody2D>().simulated = true;
        }
        if (Input.GetKeyUp(KeyCode.Mouse0) && gameObject.transform.parent.name == "PlayZone" && WasItPlayed == false)
        {
            EachOnPlayBuff = 0;
            EachOnPlayEffect = 0;
            EachOnDeathEffect = 0;
            OnPlayTargetFound = false;
            gameObject.GetComponent<CardEffects>().StartedTargeting = true;
            gameObject.GetComponent<CardEffects>().NumberOfTargets = 0;
            if (ThisOnPlaySelfBuff != null) // This was added || and idk why it's here now
            {
                OnPlaySelfBuffs();
            }
            WasItPlayed = true;
            OnStartOfTurnOnce = true;
            OnEndOfTurnOnce = true;
        }

        if (ThisOnPlayEffects != null && WasItPlayed == true && EachOnPlayEffect < ThisOnPlayEffects.Count)
        {
            OnPlayEffects();
        }
        if (this.transform.parent.name == "PlayZone" && ThisOnStartOfTrunEffects.Count != 0 && WasItPlayed == true)
        {
            if (this.tag == "Player1" && TurnButton.GetComponent<MyTurn>().MyTurnJustStartedP1 == true && OnStartOfTurnOnce == false)
            {
                OnStartOfTurnEffects();
                OnStartOfTurnOnce = true;
            }
            else if (this.tag == "Player2" && TurnButton.GetComponent<MyTurn>().MyTurnJustStartedP2 == true && OnStartOfTurnOnce == false)
            {
                OnStartOfTurnEffects();
                OnStartOfTurnOnce = true;
            }
        }
        if (this.transform.parent.name == "PlayZone" && ThisOnEndOfTrunEffects.Count != 0 && WasItPlayed == true)
        {
            if (this.tag == "Player1" && TurnButton.GetComponent<MyTurn>().MyTurnJustStartedP2 == true && OnEndOfTurnOnce == false)
            {
                OnEndOfTurnEffects();
                OnEndOfTurnOnce = true;
            }
            else if (this.tag == "Player2" && TurnButton.GetComponent<MyTurn>().MyTurnJustStartedP1 == true && OnEndOfTurnOnce == false)
            {
                OnEndOfTurnEffects();
                OnEndOfTurnOnce = true;
            }
        }
        int.TryParse(healthText.text, out health);
        if (health <= 0)
        {
            if (gameObject.tag == "Player1")
            {
                GameObject.Find("Bord").GetComponent<MinionCount>().MinionsOnPlayer1Side--;
            }
            if (gameObject.tag == "Player2")
            {
                GameObject.Find("Bord").GetComponent<MinionCount>().MinionsOnPlayer2Side--;
            }
            OnDeathEffects();
            HasDied = true;
            Destroy(gameObject);
        }

    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        if (gameObject.tag == "Player1" )
        {
            foreach (GameObject item in GameObject.FindGameObjectsWithTag("Player1"))
            {
                if (item.name == "PlayZone")
                {
                    item.GetComponent<PlayMinion>().CardAttacking = gameObject;
                }
            }
        }
        else if (gameObject.tag == "Player2")
        {
            foreach (GameObject item in GameObject.FindGameObjectsWithTag("Player2"))
            {
                if (item.name == "PlayZone")
                {
                    item.GetComponent<PlayMinion>().CardAttacking = gameObject;
                }
            }
        }
        if (GameObject.Find("AttackArrow(Clone)") != null)
        {
            GameObject.Find("AttackArrow(Clone)").GetComponent<Attack>().CardBeingAttacked = gameObject;
        }
        if (GameObject.Find("EffectArrow(Clone)") != null)
        {
            GameObject.Find("EffectArrow(Clone)").GetComponent<EffectTargeting>().CardBeingTargeted = gameObject;
        }
    }
    public void OnPointerExit(PointerEventData pointerEventData)
    {
        if (GameObject.Find("AttackArrow(Clone)") != null)
        {
            GameObject.Find("AttackArrow(Clone)").GetComponent<Attack>().CardBeingAttacked = null;
        }
        if (GameObject.Find("EffectArrow(Clone)") != null)
        {
            GameObject.Find("EffectArrow(Clone)").GetComponent<EffectTargeting>().CardBeingTargeted = null;
        }
    }

    public void OnPlaySelfBuffs()
    {
        foreach (OnPlayEffect Onplaybuff in ThisOnPlaySelfBuff)
        {
            ThisOnPlaySelfBuff[EachOnPlayBuff]();
            EachOnPlayBuff++;
        }
    }
    public void OnPlayEffects()
    {
        ThisOnPlayEffects[EachOnPlayEffect]();
        if (OnPlayTargetFound == true && EachOnPlayEffect < ThisOnPlayEffects.Count)
        {
            gameObject.GetComponent<CardEffects>().StartedTargeting = true;
            EachOnPlayEffect++;
            OnPlayTargetFound = false;
        }
    }
    public void OnStartOfTurnEffects()
    {
        int EachOnStartOfTurnEffect = 0;
        foreach (PassiveEffect onstartofturneffect in ThisOnStartOfTrunEffects)
        {
            ThisOnStartOfTrunEffects[EachOnStartOfTurnEffect]();
            EachOnStartOfTurnEffect++;
        }
    }
    public void OnEndOfTurnEffects()
    {
        int EachOnEndOfTurnEffect = 0;
        foreach (PassiveEffect onendofturneffect in ThisOnEndOfTrunEffects)
        {
            ThisOnEndOfTrunEffects[EachOnEndOfTurnEffect]();
            EachOnEndOfTurnEffect++;
        }
    }
    public void OnDeathEffects()
    {
        foreach (OnDeathEffect ondeatheffect in ThisOnDeathEffects)
        {
            ThisOnDeathEffects[EachOnDeathEffect]();
            EachOnDeathEffect++;
        }
    }
    public void WhenDrwanEffects()
    {
        foreach (PassiveEffect whendrawneffects in ThisWhenDrawnEffects)
        {
            ThisWhenDrawnEffects[EachWhenDrawnEffect]();
            EachWhenDrawnEffect++;
        }
    }
}
