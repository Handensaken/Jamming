using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PickManager : MonoBehaviour
{
    private List<GameObject> pickedCharacters = new List<GameObject>();
    [SerializeField] private Transform[] pickedCharacterPosition = new Transform[5];
    void OnEnable()
    {
        GameEventsManager.instance.pickedEvents.OnPicked += AddCharacters;
    }
    void OnDisable()
    {
        GameEventsManager.instance.pickedEvents.OnPicked -= AddCharacters;
    }
    public void AddCharacters(GameObject character)
    {
        pickedCharacters.Add(character);
        if (pickedCharacterPosition != null)
        {
            character.transform.position = pickedCharacterPosition[pickedCharacters.Count].position;
        }
    }
}
