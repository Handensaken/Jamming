using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndyFallRandomShot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Animator>().SetInteger("AndyFall", Random.Range(0, 11));
    }

    // Update is called once per frame
    void Update() { }
}
