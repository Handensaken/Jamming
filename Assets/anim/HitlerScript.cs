using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HitlerScript : MonoBehaviour
{
    [SerializeField]
    private GameObject gun;

    [SerializeField]
    private GameObject FireFX;

    // Start is called before the first frame update
    void Start()
    {
        GameEventsManager.instance.cameraEvents.OnFightStart += StartShit;
    }

    void OnDisable() {
        GameEventsManager.instance.cameraEvents.OnFightStart -= StartShit;
     }

    // Update is called once per frame
    void Update() { }

    public void ActivateGun()
    {
        gun.SetActive(true);
    }

    public void Shoot()
    {
        FireFX.SetActive(true);
    }

    private void StartShit()
    {
        GetComponent<Animator>().SetBool("Fighting", true);
    }
}
