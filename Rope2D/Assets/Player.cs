using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    bool isMoving;
    Vector3 targetPos;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            SetTarget();
        }

        if (isMoving)
        {
            Move();
        }
    }

    private void SetTarget()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetPos = new Vector3(mousePos.x, transform.position.y, mousePos.z);
        isMoving = true;
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        if(transform.position == targetPos)
        {
            isMoving = false;
        }
    }
}
