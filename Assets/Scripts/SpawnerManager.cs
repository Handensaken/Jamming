using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    [SerializeField]
    private Transform[] spawnPoints = new Transform[3];
    public List<GameObject> spawnableCharacters = new List<GameObject>();
    private List<GameObject> spawnedCharacters = new List<GameObject>();

    void Start()
    {
        InstantiateCharacters();
    }

    void OnEnable()
    {
        GameEventsManager.instance.pickedEvents.OnSelectionDone += NewSpawn;
        GameEventsManager.instance.pickedEvents.OnPicked += RemoveUnSelected;
    }

    void OnDisable()
    {
        GameEventsManager.instance.pickedEvents.OnSelectionDone -= NewSpawn;
        GameEventsManager.instance.pickedEvents.OnPicked -= RemoveUnSelected;
    }

    private void InstantiateCharacters()
    {
        for (int i = 0; i < 3; i++)
        {
            if (spawnableCharacters.Count != 0)
            {
                int tempInt = UnityEngine.Random.Range(0, spawnableCharacters.Count);
                spawnedCharacters.Add(Instantiate(spawnableCharacters[tempInt], spawnPoints[i]));
                spawnableCharacters.RemoveAt(tempInt);
            }
        }
    }

    private void NewSpawn(GameObject gameObject)
    {
        InstantiateCharacters();
    }

    [SerializeField]
    private ParticleSystem Ash;

    private void RemoveUnSelected(GameObject gameObject)
    {
        spawnedCharacters.Remove(gameObject);
        foreach (var item in spawnedCharacters)
        {
//            Debug.Log(item);
            if (item != null)
            {
                SpawnParticles(item.transform.position);
            }
            Destroy(item);
        }
    }

    private void SpawnParticles(Vector3 pos)
    {
        Instantiate(Ash, new Vector3(pos.x, pos.y-1, pos.z), quaternion.identity);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 1, 0, 0.75F);
        foreach (var item in spawnPoints)
        {
            Gizmos.DrawSphere(item.transform.position, 0.5f);
        }
    }
}
