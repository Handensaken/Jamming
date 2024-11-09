using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class BigCuntInMyAss : MonoBehaviour
{
    public List<Transform> CharacterWinPositions;

    private List<GameObject> yourSquad;

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PickManager pickManager = FindAnyObjectByType<PickManager>();
            yourSquad = pickManager.pickedCharacters;

            for (int i = 0; i < yourSquad.Count; i++)
            {
                Instantiate(yourSquad[i], CharacterWinPositions[i].position, quaternion.identity);
            }
        }
    }
}
