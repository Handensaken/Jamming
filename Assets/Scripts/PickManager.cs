using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickManager : MonoBehaviour
{
    private Camera MainCamera;
    [NonSerialized] public List<GameObject> pickedCharacters = new List<GameObject>();
    void Start()
    {
        MainCamera = FindAnyObjectByType<Camera>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){
            TryPick();
        }
    }
    public void AddCharacters(GameObject character){
        pickedCharacters.Add(character);
    }
    private void TryPick(){
        RaycastHit hit;
        //if (Physics.Raycast(MainCamera.ScreenToWorldPoint(Input.mousePosition)))
    }
}
