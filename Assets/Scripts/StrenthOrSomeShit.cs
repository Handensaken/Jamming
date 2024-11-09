using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StrenthOrSomeShit : MonoBehaviour
{
    public GameObject canvasPrefab;
    [Range(1, 100)]
    public int strength = 1;
    private bool Hover = false;
    public string line;
    public string characterName;

    void Start()
    {
        gameObject.tag = "Pickable";
    }
    void Update()
    {
        if (Hover)
        {

        }
    }
    public void Selected()
    {
        transform.parent = null;
        Hover = false;
        GameEventsManager.instance.cameraEvents.HoverExit();
        Destroy(transform.GetChild(0).gameObject);
        transform.position = Vector3.zero;
        GameEventsManager.instance.pickedEvents.Picked(this.gameObject);
    }
    public void OnHoverEnter()
    {
        Hover = true;
        GameEventsManager.instance.cameraEvents.HoverEnter(this.gameObject.transform);
    }
    public void OnHoverExit()
    {
        Hover = false;
        GameEventsManager.instance.cameraEvents.HoverExit();
    }
}
