using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class PickManager : MonoBehaviour
{
    public List<GameObject> pickedCharacters = new List<GameObject>();
    public Transform fightingPos;
    [SerializeField] private Transform[] pickedCharacterPosition = new Transform[5];
    void Start()
    {
        GameEventsManager.instance.pickedEvents.OnPicked += AddCharacters;
        GameEventsManager.instance.pickedEvents.OnSelectionDone += MoveCharacter;
    }
    void OnDisable()
    {
        GameEventsManager.instance.pickedEvents.OnPicked -= AddCharacters;
        GameEventsManager.instance.pickedEvents.OnSelectionDone -= MoveCharacter;
    }
    public void AddCharacters(GameObject character)
    {
        pickedCharacters.Add(character);
        /*if (pickedCharacterPosition != null)
        {
            character.transform.position = pickedCharacterPosition[pickedCharacters.Count - 1].position;
        }*/
        
    }
    private void MoveCharacter(GameObject character)
    {
//        Debug.Log("running");
        if (pickedCharacterPosition != null)
        {
            character.transform.parent.transform.position = pickedCharacterPosition[pickedCharacters.Count - 1].position;
        }
        if (pickedCharacters.Count == 5)
        {
            GameEventsManager.instance.cameraEvents.FightStart();
            Debug.Log("whore");
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
