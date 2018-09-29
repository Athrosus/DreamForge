using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


using UnityEngine.UI;

public class DeckCreated : MonoBehaviour
{
    public List<Image> PickedCards = new List<Image>();


    void Start()
    {


    }



    void FixedUpdate()
    {

        Scene CurrentScene = SceneManager.GetActiveScene();
        if (CurrentScene.name == "DeckBuilderP1") {
            if (GameObject.Find("MadeDeck1").GetComponent<DeckList>().CardsInDeck.Count == 30)
            {

                GameObject.Find("PlayButton").GetComponent<Button>().enabled = true;
                GameObject.Find("PlayBlock").GetComponent<Image>().enabled = false;
            }
            else
            {
                GameObject.Find("PlayButton").GetComponent<Button>().enabled = false;
                GameObject.Find("PlayBlock").GetComponent<Image>().enabled = true;

            }
            
        }
        else if (CurrentScene.name == "DeckBuilderP2")
        {
            if (GameObject.Find("MadeDeck2").GetComponent<DeckList>().CardsInDeck.Count == 30)
            {

                GameObject.Find("PlayButton").GetComponent<Button>().enabled = true;
                GameObject.Find("PlayBlock").GetComponent<Image>().enabled = false;
            }
            else
            {
                GameObject.Find("PlayButton").GetComponent<Button>().enabled = false;
                GameObject.Find("PlayBlock").GetComponent<Image>().enabled = true;

            }

        }
    }




    public void PlayButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
}


   