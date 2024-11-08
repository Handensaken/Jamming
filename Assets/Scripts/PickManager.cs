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
            character.transform.position = pickedCharacterPosition[pickedCharacters.Count - 1].position;
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 1, 0, 0.75F);
        foreach (var item in pickedCharacterPosition)
        {
            Gizmos.DrawSphere(item.transform.position, 0.5f);
        }
    }
}
