using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeckCardsScript : MonoBehaviour
{
    public GameObject P1PlayZone;
    public GameObject P2PlayZone;
    public bool HasLoaded = false;
    public GameObject DeckP1, DeckP2;
    public List<GameObject> P1CardsInDeck = new List<GameObject>();
    public List<GameObject> P2CardsInDeck = new List<GameObject>();
    void Start()
    {
    }

    void Update()
    {
        P1PlayZone = GameObject.Find("Player1").GetComponent<WhoTurn>().Player1sThings[1];
        P2PlayZone = GameObject.Find("Player1").GetComponent<WhoTurn>().Player2sThings[1];
        if (gameObject.transform.parent == GameObject.Find("Canvas").transform)
        {
            P1PlayZone.GetComponent<Rigidbody2D>().simulated = false;
            P2PlayZone.GetComponent<Rigidbody2D>().simulated = false;
            if (HasLoaded == false)
            {
                foreach (Transform card in GameObject.Find("CardsInDeck").transform)
                {
                    if (card.GetComponent<CardDisplay>().IsRevealed == true)
                    {
                        card.GetChild(14).GetComponent<Image>().enabled = false;
                    }
                }
                HasLoaded = true;
            }
        }
    }
    public void CloseButton()
    {
        P1CardsInDeck = DeckP1.GetComponent<Deck>().DeckCards;
        P2CardsInDeck = DeckP2.GetComponent<Deck>().DeckCards;

        gameObject.transform.SetParent(GameObject.Find("EventSystem").transform);
        P1PlayZone.GetComponent<Rigidbody2D>().simulated = true;
        P2PlayZone.GetComponent<Rigidbody2D>().simulated = true;
        HasLoaded = false;

        GameObject.Find("DeckCardsClose").GetComponent<Button>().onClick.RemoveListener(GameObject.Find("P1HeroPower").GetComponent<HeroPowerScript>().P1ArchivistHPButton);
        GameObject.Find("DeckCardsClose").GetComponent<Button>().onClick.RemoveListener(GameObject.Find("P2HeroPower").GetComponent<HeroPowerScript>().P2ArchivistHPButton);
    }
}
