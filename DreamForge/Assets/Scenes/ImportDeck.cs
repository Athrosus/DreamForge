using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ImportDeck : MonoBehaviour
{
    public Text ImportString;
    public GameObject ListOfAllCards;
    List<string> Cards = new List<string>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Import()
    {
        Cards = ImportString.text.Split('|').ToList();
        foreach (var item in Cards)
        {
            if (ListOfAllCards.transform.Find(item) != null && item != "|")
            {
                ListOfAllCards.transform.Find(item).GetComponent<AddCard>().PickThisCard();
            }
        }
    }
}
