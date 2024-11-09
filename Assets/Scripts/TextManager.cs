using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextManager : MonoBehaviour
{
    public TextMeshProUGUI introText;
    public TextMeshProUGUI nameText;
    public GameObject textHolder;
    void Start()
    {
        GameEventsManager.instance.cameraEvents.OnHoverEnter += EnableText;
        GameEventsManager.instance.cameraEvents.OnHoverExit += DisableText;
        textHolder.SetActive(false);
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
        textHolder.SetActive(true);
        StrenthOrSomeShit temp = transform.gameObject.GetComponent<StrenthOrSomeShit>();
        if (temp != null)
        {
            introText.text = temp.line;
            nameText.text = temp.characterName;
        }
    }
    void DisableText()
    {
        textHolder.SetActive(false);
    }
}
