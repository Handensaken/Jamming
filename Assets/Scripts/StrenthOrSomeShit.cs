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
    public GameObject spotlight;

    void Start()
    {
        if (spotlight != null)
        {
            spotlight.SetActive(false);
        }
        gameObject.tag = "Pickable";
        GameEventsManager.instance.pickedEvents.OnSelectionDone += SelectionDone;
    }
    void OnDisable()
    {
        GameEventsManager.instance.pickedEvents.OnSelectionDone -= SelectionDone;
    }
    void Update()
    {
        if (Hover)
        {

        }
    }
    private void SelectionDone(GameObject g)
    {
        spotlight.SetActive(false);

    }
    public void Selected()
    {
        if (spotlight != null)
        {
            spotlight.SetActive(true);
        }
        transform.parent = null;
        Hover = false;
        GameEventsManager.instance.cameraEvents.HoverExit();
        Destroy(transform.GetChild(0).gameObject);
        //transform.position = Vector3.zero;
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
