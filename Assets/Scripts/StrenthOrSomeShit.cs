using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StrenthOrSomeShit : MonoBehaviour
{
    private PickManager pickManager;
    public GameObject canvasPrefab;
    [Range(1,100)]
    public int strength = 1;
    
    void Start(){
        gameObject.tag = "Pickable";
        pickManager = FindAnyObjectByType<PickManager>();
    }
    public void Selected(){
        transform.parent = null;
        transform.position = Vector3.zero;
        GameEventsManager.instance.pickedEvents.Picked(this.gameObject);
    }
}
