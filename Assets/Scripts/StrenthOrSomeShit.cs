using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrenthOrSomeShit : MonoBehaviour
{
    [Range(1,100)]
    public int strength = 1;
    
    void Start(){
        gameObject.tag = "Pickable";
    }
}
