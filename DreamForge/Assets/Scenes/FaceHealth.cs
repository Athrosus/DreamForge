using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class FaceHealth : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    int FaceHPp1, FaceHPP2;
	// Use this for initialization
	void Start () {
	}
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        if (GameObject.Find("AttackArrow(Clone)") != null)
        {
            GameObject.Find("AttackArrow(Clone)").GetComponent<Attack>().Face = gameObject;
        }
    }
    public void OnPointerExit(PointerEventData pointerEventData)
    {
        if (GameObject.Find("AttackArrow(Clone)") != null)
        {
            GameObject.Find("AttackArrow(Clone)").GetComponent<Attack>().Face = null;
        }
    }
    // Update is called once per frame
    void FixedUpdate () {
        int.TryParse(GameObject.Find("FaceHPTextP1").GetComponent<Text>().text, out FaceHPp1);
        int.TryParse(GameObject.Find("FaceHPTextP2").GetComponent<Text>().text, out FaceHPP2);
        if (FaceHPp1 <= 0)
        {
            Debug.Log("Player 1 has lost");
        }
        else if (FaceHPP2 <= 0)
        {
            Debug.Log("Player 2 has lost");
        }
	}
}
