using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dontdestroylight : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
