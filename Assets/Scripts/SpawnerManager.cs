using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints = new Transform[3];
    [SerializeField] private List<GameObject> spawnableCharacters = new List<GameObject>();
    void Start()
    {
        InstantiateCharacters();
    }
    void Update()
    {

    }
    private void InstantiateCharacters()
    {
        for (int i = 0; i < 3; i++)
        {
            int tempInt = Random.Range(0, spawnableCharacters.Count);
            Instantiate(spawnableCharacters[tempInt], spawnPoints[i]);
            spawnableCharacters.RemoveAt(tempInt);
        }
    }
}
