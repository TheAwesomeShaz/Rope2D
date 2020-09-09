
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBody : MonoBehaviour
{

    [SerializeField] bool isRewinding = false;
    public Transform origin;

    public float recordTime = 5f;

    List<Vector3> positions;

    Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        positions = new List<Vector3>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0) && transform.position != origin.position)
        {
            StartRewind();
        }
        else if(positions.Count<1)
        {
            StopRewind();
        }
    }
    private void FixedUpdate()
    {
        if (isRewinding)
        {
            Rewind();
        }
        else
        {
            Record();
        }
    }

    private void Rewind()
    {
        if (positions.Count > 0)
        {
        transform.position = positions[0];
        positions.RemoveAt(0);
        }
        else
        {
            StopRewind();
        }
    }

    private void StopRewind()
    {
        isRewinding = false;
    }

    private void StartRewind()
    {
        isRewinding = true;
    }


    private void Record()
    {
        positions.Insert(0,transform.position);

    }
}