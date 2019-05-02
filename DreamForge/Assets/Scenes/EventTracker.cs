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
        CardBeingDmged.GetComponent<CardDisplay>().healthText.text = (int.Parse(CardBeingDmged.GetComponent<CardDisplay>().healthText.text) - int.Parse(AmountOfDmg)).ToString();
        string message = CardDoingDmg.tag +" "+ CardDoingDmg.GetComponent<CardDisplay>().card.name + " did " + AmountOfDmg + " dmg to " + CardBeingDmged.tag +" "+ CardBeingDmged.GetComponent<CardDisplay>().card.name;
        History.Add(message);
    }
    public static void Damage(GameObject CardDoingDmg, int AmountOfDmg, GameObject CardBeingDmged)
    {
        CardBeingDmged.GetComponent<CardDisplay>().healthText.text = (int.Parse(CardBeingDmged.GetComponent<CardDisplay>().healthText.text) - AmountOfDmg).ToString();
        string message = CardDoingDmg.tag +" "+ CardDoingDmg.GetComponent<CardDisplay>().card.name + " did " + AmountOfDmg + " dmg to " + CardBeingDmged.tag +" "+ CardBeingDmged.GetComponent<CardDisplay>().card.name;
        History.Add(message);
    }
    public static void DestroyCard(GameObject CardDoingDestroying, GameObject CardBeingDestroyed)
    {
        CardBeingDestroyed.GetComponent<CardDisplay>().healthText.text = "0";
        string message = CardDoingDestroying.tag + " " + CardDoingDestroying.GetComponent<CardDisplay>().card.name + " destroyed " + CardBeingDestroyed.tag + " " + CardBeingDestroyed.GetComponent<CardDisplay>().card.name;
        History.Add(message);
    }
    public static void DamageToFace(GameObject CardDoingDmg, string AmountOfDmg, GameObject FaceBeingDmged)
    {
        FaceBeingDmged.GetComponentInChildren<Text>().text = ((int.Parse(FaceBeingDmged.GetComponentInChildren<Text>().text) - int.Parse(AmountOfDmg)).ToString());
        string message = CardDoingDmg.tag +" "+ CardDoingDmg.GetComponent<CardDisplay>().card.name + " did " + AmountOfDmg + " dmg to " + FaceBeingDmged.tag;
        History.Add(message);
    }
    public static void DamageToFace(GameObject CardDoingDmg, int AmountOfDmg, GameObject FaceBeingDmged)
    {
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
}
