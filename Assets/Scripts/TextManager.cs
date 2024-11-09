using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextManager : MonoBehaviour
{
    public TextMeshProUGUI text;
    public GameObject textHolder;
    void Start()
    {
        GameEventsManager.instance.cameraEvents.OnHoverEnter += EnableText;
        GameEventsManager.instance.cameraEvents.OnHoverExit += DisableText;
    }
    void OnEnable()
    {

    }
    void OnDisable()
    {
        GameEventsManager.instance.cameraEvents.OnHoverEnter -= EnableText;
        GameEventsManager.instance.cameraEvents.OnHoverExit -= DisableText;
    }
    void EnableText(Transform transform)
    {
        
        string temp = transform.gameObject.GetComponent<StrenthOrSomeShit>().line;
        if (temp != null)
        {
            text.text = temp;
        }
    }
    void DisableText()
    {

    }
}
