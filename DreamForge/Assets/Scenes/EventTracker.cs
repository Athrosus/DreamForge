using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EventTracker : MonoBehaviour
{
    public static List<string> History = new List<string>();
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void Damage(GameObject CardDoingDmg, string AmountOfDmg, GameObject CardBeingDmged)
    {
        string message;
        LifeSteal(CardDoingDmg, AmountOfDmg, CardBeingDmged);
        CardBeingDmged.GetComponent<CardDisplay>().healthText.text = (int.Parse(CardBeingDmged.GetComponent<CardDisplay>().healthText.text) - int.Parse(AmountOfDmg)).ToString();
        if (int.Parse(CardBeingDmged.GetComponent<CardDisplay>().healthText.text) <=0)
        {
            message = CardDoingDmg.tag + " " + CardDoingDmg.GetComponent<CardDisplay>().card.name + " Has Killed " + CardBeingDmged.tag + " " + CardBeingDmged.GetComponent<CardDisplay>().card.name;
            CardDoingDmg.GetComponent<CardDisplay>().OnKillEffects();
        }
        else
        {
            message = CardDoingDmg.tag + " " + CardDoingDmg.GetComponent<CardDisplay>().card.name + " did " + AmountOfDmg + " dmg to " + CardBeingDmged.tag + " " + CardBeingDmged.GetComponent<CardDisplay>().card.name;
        }
        History.Add(message);
    }
    public static void Damage(GameObject CardDoingDmg, int AmountOfDmg, GameObject CardBeingDmged)
    {
        string message;
        LifeSteal(CardDoingDmg, AmountOfDmg, CardBeingDmged);
        CardBeingDmged.GetComponent<CardDisplay>().healthText.text = (int.Parse(CardBeingDmged.GetComponent<CardDisplay>().healthText.text) - AmountOfDmg).ToString();
        if (int.Parse(CardBeingDmged.GetComponent<CardDisplay>().healthText.text) <= 0)
        {
            message = CardDoingDmg.tag + " " + CardDoingDmg.GetComponent<CardDisplay>().card.name + " Has Killed " + CardBeingDmged.tag + " " + CardBeingDmged.GetComponent<CardDisplay>().card.name;
            CardDoingDmg.GetComponent<CardDisplay>().OnKillEffects();
        }
        else
        {
            message = CardDoingDmg.tag + " " + CardDoingDmg.GetComponent<CardDisplay>().card.name + " did " + AmountOfDmg + " dmg to " + CardBeingDmged.tag + " " + CardBeingDmged.GetComponent<CardDisplay>().card.name;
        }
        History.Add(message);
    }
    public static void DestroyCard(GameObject CardDoingDestroying, GameObject CardBeingDestroyed)
    {
        CardBeingDestroyed.GetComponent<CardDisplay>().healthText.text = "0";
        string message = CardDoingDestroying.tag + " " + CardDoingDestroying.GetComponent<CardDisplay>().card.name + " destroyed " + CardBeingDestroyed.tag + " " + CardBeingDestroyed.GetComponent<CardDisplay>().card.name;
        CardDoingDestroying.GetComponent<CardDisplay>().OnKillEffects();
        History.Add(message);
    }
    public static void DamageToFace(GameObject CardDoingDmg, string AmountOfDmg, GameObject FaceBeingDmged)
    {
        LifeSteal(CardDoingDmg, AmountOfDmg, FaceBeingDmged);
        FaceBeingDmged.GetComponentInChildren<Text>().text = ((int.Parse(FaceBeingDmged.GetComponentInChildren<Text>().text) - int.Parse(AmountOfDmg)).ToString());
        string message = CardDoingDmg.tag +" "+ CardDoingDmg.GetComponent<CardDisplay>().card.name + " did " + AmountOfDmg + " dmg to " + FaceBeingDmged.tag;
        History.Add(message);
    }
    public static void DamageToFace(GameObject CardDoingDmg, int AmountOfDmg, GameObject FaceBeingDmged)
    {
        LifeSteal(CardDoingDmg, AmountOfDmg, FaceBeingDmged);
        FaceBeingDmged.GetComponentInChildren<Text>().text = ((int.Parse(FaceBeingDmged.GetComponentInChildren<Text>().text) - AmountOfDmg).ToString());
        string message = CardDoingDmg.tag + " " + CardDoingDmg.GetComponent<CardDisplay>().card.name + " did " + AmountOfDmg + " dmg to " + FaceBeingDmged.tag;
        History.Add(message);
    }
    public void HistoryLog()
    {
        foreach (var item in History)
        {
            Debug.Log(item);
        }
    }
    public static void LifeSteal(GameObject CardDoingDmg, int Damage, GameObject CardBeingDmged)
    {
        if (CardDoingDmg.GetComponent<CardDisplay>().IsLifeSteal)
        {
            if (CardBeingDmged.name == "FaceIconP1" || CardBeingDmged.name == "FaceIconP2")
            {
                if (int.Parse(CardBeingDmged.GetComponentInChildren<Text>().text) < Damage)
                {
                    int RealDmg = int.Parse(CardBeingDmged.GetComponentInChildren<Text>().text);
                    if (CardDoingDmg.tag == "Player1")
                    {
                        GameObject.Find("FaceIconP1").GetComponentInChildren<Text>().text = ((int.Parse(GameObject.Find("FaceIconP1").GetComponentInChildren<Text>().text) + RealDmg).ToString());
                    }
                    else
                    {
                        GameObject.Find("FaceIconP2").GetComponentInChildren<Text>().text = ((int.Parse(GameObject.Find("FaceIconP2").GetComponentInChildren<Text>().text) + RealDmg).ToString());
                    }
                }
                else
                {
                    if (CardDoingDmg.tag == "Player1")
                    {
                        GameObject.Find("FaceIconP1").GetComponentInChildren<Text>().text = ((int.Parse(GameObject.Find("FaceIconP1").GetComponentInChildren<Text>().text) + Damage).ToString());
                    }
                    else
                    {
                        GameObject.Find("FaceIconP2").GetComponentInChildren<Text>().text = ((int.Parse(GameObject.Find("FaceIconP2").GetComponentInChildren<Text>().text) + Damage).ToString());
                    }
                }
            }
            else
            {
                if (int.Parse(CardBeingDmged.GetComponent<CardDisplay>().healthText.text) < Damage)
                {
                    int RealDmg = int.Parse(CardBeingDmged.GetComponent<CardDisplay>().healthText.text);
                    if (CardDoingDmg.tag == "Player1")
                    {
                        GameObject.Find("FaceIconP1").GetComponentInChildren<Text>().text = ((int.Parse(GameObject.Find("FaceIconP1").GetComponentInChildren<Text>().text) + RealDmg).ToString());
                    }
                    else
                    {
                        GameObject.Find("FaceIconP2").GetComponentInChildren<Text>().text = ((int.Parse(GameObject.Find("FaceIconP2").GetComponentInChildren<Text>().text) + RealDmg).ToString());
                    }
                }
                else
                {
                    if (CardDoingDmg.tag == "Player1")
                    {
                        GameObject.Find("FaceIconP1").GetComponentInChildren<Text>().text = ((int.Parse(GameObject.Find("FaceIconP1").GetComponentInChildren<Text>().text) + Damage).ToString());
                    }
                    else
                    {
                        GameObject.Find("FaceIconP2").GetComponentInChildren<Text>().text = ((int.Parse(GameObject.Find("FaceIconP2").GetComponentInChildren<Text>().text) + Damage).ToString());
                    }
                }
            }
        }
    }
    public static void LifeSteal(GameObject CardDoingDmg, string Damage, GameObject CardBeingDmged)
    {
        if (CardDoingDmg.GetComponent<CardDisplay>().IsLifeSteal)
        {
            if (CardBeingDmged.name == "FaceIconP1" || CardBeingDmged.name == "FaceIconP2")
            {
                if (int.Parse(CardBeingDmged.GetComponentInChildren<Text>().text) < int.Parse(Damage))
                {
                    int RealDmg = int.Parse(CardBeingDmged.GetComponentInChildren<Text>().text);
                    if (CardDoingDmg.tag == "Player1")
                    {
                        GameObject.Find("FaceIconP1").GetComponentInChildren<Text>().text = ((int.Parse(GameObject.Find("FaceIconP1").GetComponentInChildren<Text>().text) + RealDmg).ToString());
                    }
                    else
                    {
                        GameObject.Find("FaceIconP2").GetComponentInChildren<Text>().text = ((int.Parse(GameObject.Find("FaceIconP2").GetComponentInChildren<Text>().text) + RealDmg).ToString());
                    }
                }
                else
                {
                    if (CardDoingDmg.tag == "Player1")
                    {
                        GameObject.Find("FaceIconP1").GetComponentInChildren<Text>().text = ((int.Parse(GameObject.Find("FaceIconP1").GetComponentInChildren<Text>().text) + int.Parse(Damage)).ToString());
                    }
                    else
                    {
                        GameObject.Find("FaceIconP2").GetComponentInChildren<Text>().text = ((int.Parse(GameObject.Find("FaceIconP2").GetComponentInChildren<Text>().text) + int.Parse(Damage)).ToString());
                    }
                }
            }
            else
            {
                if (int.Parse(CardBeingDmged.GetComponent<CardDisplay>().healthText.text) < int.Parse(Damage))
                {
                    int RealDmg = int.Parse(CardBeingDmged.GetComponent<CardDisplay>().healthText.text);
                    if (CardDoingDmg.tag == "Player1")
                    {
                        GameObject.Find("FaceIconP1").GetComponentInChildren<Text>().text = ((int.Parse(GameObject.Find("FaceIconP1").GetComponentInChildren<Text>().text) + RealDmg).ToString());
                    }
                    else
                    {
                        GameObject.Find("FaceIconP2").GetComponentInChildren<Text>().text = ((int.Parse(GameObject.Find("FaceIconP2").GetComponentInChildren<Text>().text) + RealDmg).ToString());
                    }
                }
                else
                {
                    if (CardDoingDmg.tag == "Player1")
                    {
                        GameObject.Find("FaceIconP1").GetComponentInChildren<Text>().text = ((int.Parse(GameObject.Find("FaceIconP1").GetComponentInChildren<Text>().text) + int.Parse(Damage)).ToString());
                    }
                    else
                    {
                        GameObject.Find("FaceIconP2").GetComponentInChildren<Text>().text = ((int.Parse(GameObject.Find("FaceIconP2").GetComponentInChildren<Text>().text) + int.Parse(Damage)).ToString());
                    }
                }
            }
        }
    }
}
