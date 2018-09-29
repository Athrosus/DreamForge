
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class CardDisplay : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public delegate void OnPlayEffect();

    public List<OnPlayEffect> ThisOnPlaySelfBuff = new List<OnPlayEffect>();
    public List<OnPlayEffect> ThisOnPlayEffects = new List<OnPlayEffect>();


    public bool HasAttackedThisTurn = false, WasItPlayed = false, IsTaunt = false, OnPlayTargetFound;
    int EachOnPlayBuff, EachOnPlayEffect;

    public CardStats card;
    public Text nameText;
    public Text descriptionText;
    public Image artworkImage;
    public Text manaText;
    public Text attackText;
    public Text healthText;
    public Text Tire;

    int health;


    // Use this for initialization
    void Start () {

        nameText.text = card.name;
        descriptionText.text = card.description;

        artworkImage.sprite = card.artwork;

        manaText.text = card.manaCost.ToString();
        attackText.text = card.attack.ToString();
        healthText.text = card.health.ToString();
        Tire.text = card.tire;


    }



    // Update is called once per frame
    void FixedUpdate () {

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
            OnPlayTargetFound = false;
            EachOnPlayBuff = 0;
            EachOnPlayEffect = 0;
            gameObject.GetComponent<CardEffects>().StartedTargeting = true;

            if (ThisOnPlaySelfBuff !=null) // This was added
            {
                OnPlaySelfBuffs();

            }

            WasItPlayed = true;
        }
        if (ThisOnPlayEffects != null && WasItPlayed == true && EachOnPlayEffect < ThisOnPlayEffects.Count)
        {

            OnPlayEffects();
        }


        int.TryParse(healthText.text, out health);


        if (health <= 0)
        {
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
   
            Debug.Log("running");
            ThisOnPlayEffects[EachOnPlayEffect]();

         if (OnPlayTargetFound == true && EachOnPlayEffect < ThisOnPlayEffects.Count)
         {


            gameObject.GetComponent<CardEffects>().StartedTargeting = true;
            EachOnPlayEffect++;
            OnPlayTargetFound = false;
         }
        
    }


}
