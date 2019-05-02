using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventTracker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    static void Damage(GameObject CardDoingDmg, string AmountOfDmg, GameObject CardBeingDmged)
    {
        CardBeingDmged.GetComponent<CardDisplay>().healthText.text = (int.Parse(CardBeingDmged.GetComponent<CardDisplay>().healthText.text) - int.Parse(AmountOfDmg)).ToString();
    }
    static void Damage(GameObject CardDoingDmg, int AmountOfDmg, GameObject CardBeingDmged)
    {
        CardBeingDmged.GetComponent<CardDisplay>().healthText.text = (int.Parse(CardBeingDmged.GetComponent<CardDisplay>().healthText.text) - AmountOfDmg).ToString();
    }
    static void DamageToFace(GameObject CardDoingDmg, string AmountOfDmg, GameObject FaceBeingDmged)
    {
        FaceBeingDmged.GetComponentInChildren<Text>().text = ((int.Parse(FaceBeingDmged.GetComponentInChildren<Text>().text) - int.Parse(AmountOfDmg)).ToString());
    }
}
