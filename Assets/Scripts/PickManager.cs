using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PickManager : MonoBehaviour
{
    private List<GameObject> pickedCharacters = new List<GameObject>();
    public List<Transform> CharacterWinPositions;
    public List<Transform> CharacterLosePositions;
    public Transform fightingPos;
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
        if(pickedCharacters.Count == 5) {GameEventsManager.instance.cameraEvents.FightStart();
            pickedCharacters[0].transform.position = fightingPos.position;
            pickedCharacters[0].transform.rotation = fightingPos.rotation;
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
