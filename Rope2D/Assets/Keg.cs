using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keg : MonoBehaviour
{
    Rope rope;

    private void Start()
    {
        rope = FindObjectOfType<Rope>();
    }

    
}
