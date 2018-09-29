using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectTargeting : MonoBehaviour {

    public GameObject CardThatStartedTargeting, CardBeingTargeted;
    // Use this for initialization
    void Start () {

        CardThatStartedTargeting = gameObject.transform.parent.gameObject;
        Cursor.visible = false;


    }

    // Update is called once per frame
    void FixedUpdate () {

        Vector2 mousePoition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 actualMouse = Camera.main.ScreenToWorldPoint(mousePoition);
        Vector2 objePosition = this.transform.position;
        GameObject.Find("EffectArrow(Clone)").transform.position = actualMouse;

        

        if (Input.GetKeyDown(KeyCode.Mouse0) && CardBeingTargeted != null)
        {
            Cursor.visible = true;
            CardThatStartedTargeting.GetComponent<CardEffects>().IsTargetFound = true;

        }

    }
}
