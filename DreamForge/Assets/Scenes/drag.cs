using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class drag : MonoBehaviour
{
    public Transform StartParent = null;
    public Transform placeholderP = null;
    GameObject placeholder = null;

    public void Start()
    {
        if (this.tag == "Player1")
        {
            StartParent = GameObject.Find("HandP1").transform;
        }
        else if (this.tag == "Player2")
        {
            StartParent = GameObject.Find("HandP2").transform;
        }
    }
    public void FixedUpdate()
    {
        if (this.transform.parent == StartParent && GameObject.Find("EffectArrow(Clone)") == null)
        {
            gameObject.GetComponent<Rigidbody2D>().simulated = true;
        }
    }
    public void OnMouseDown()
    {
        placeholder = new GameObject();
        LayoutElement le = placeholder.AddComponent<LayoutElement>();
        le.preferredWidth = 150;
        le.preferredHeight = 230;
        le.flexibleHeight = 0;
        le.flexibleWidth = 0;
    }

    public void OnMouseDrag()
    {
        placeholder.transform.SetParent(this.transform.parent);
        GetComponent<LayoutElement>().ignoreLayout = true;
        this.transform.SetAsLastSibling();
        placeholderP = this.transform.parent;
        float ZDistance = 100;
        Vector3 mousePoition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, ZDistance);
        Vector3 objePosition = Camera.main.ScreenToWorldPoint(mousePoition);
        transform.position = objePosition;
        placeholder.transform.SetSiblingIndex(this.transform.GetSiblingIndex());
        if (StartParent == GameObject.Find("HandP1").transform)
        {
            for (int i = 0; i < placeholderP.childCount; i++)
            {
                if (this.transform.position.x < placeholderP.GetChild(i).position.x)
                {
                    placeholder.transform.SetSiblingIndex(i);
                    break;
                }
            }
        }
        else
        {
            for (int i = 0; i < placeholderP.childCount; i++)
            {
                if (this.transform.position.x > placeholderP.GetChild(i).position.x)
                {
                    placeholder.transform.SetSiblingIndex(i);
                    break;
                }
            }
        }
    }
    public void OnMouseUp()
    {
        this.transform.SetSiblingIndex(placeholder.transform.GetSiblingIndex());
        GetComponent<LayoutElement>().ignoreLayout = false;
        Destroy(placeholder);
    }
}



