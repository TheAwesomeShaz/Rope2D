using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Origin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            other.GetComponent<Player>().backtracking = false;
        }
    }
}
