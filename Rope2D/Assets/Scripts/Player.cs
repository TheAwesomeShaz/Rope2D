using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool backtracking;

    public float backTrackSpeed = 40;
    public bool isMoving;

    Vector3 targetPos;
    public float speed;
    Rope rope;

    // Start is called before the first frame update
    void Start()
    {
        backtracking = false;

        rope = FindObjectOfType<Rope>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            isMoving = true;
            rope.deletePos = false;
            backtracking = false;

            Move();
        }

        else if (Input.GetMouseButtonUp(0))
        {
            rope.deletePos = true;
            backtracking = true;

        }

        else if (backtracking)
        {
            transform.position = Vector3.MoveTowards(transform.position, rope.ropePositions[rope.ropePositions.Count - 1],backTrackSpeed*Time.deltaTime);

            
        }
        //Debug.Log(backtracking);

      

    }

    

    private void Move()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {

            Vector3 targetPos = new Vector3(hit.point.x, transform.position.y, hit.point.z);
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
            if (transform.position == targetPos)
            {
                isMoving = false;
            }

        }
    }

    



}
