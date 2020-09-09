using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
    public bool deletePos;
    public Transform playerTransform;
    Player player;
    public Transform ropeStartPoint; // the point from which the rope will start rendering
    public LineRenderer rope;
    public LayerMask collMask;


    public List<Vector3> ropePositions { get; set; } = new List<Vector3>();

    //private void Awake() => AddPosToRope(Vector3.zero);
    private void Awake() => AddPosToRope(ropeStartPoint.position);

    private void Start()
    {
        player = FindObjectOfType<Player>();
    }

    private void Update()
    {
        DetectCollisionEnter();

        UpdateRopePositions();
        LastSegmentGoToPlayerPos();

        //if (ropePositions.Count > 2) DetectCollisionExits();

        //Unwind();

        if (deletePos)
        {
            DeleteAllPositions();
            return;
        }
    }

    private void Unwind()
    {
        if (ropePositions.Count > 2)
        {
            // distX is the distance between origin and second last point plus second last point  and last point
            Vector3 distX =  (ropePositions[ropePositions.Count - 2] - ropeStartPoint.position) 
                + (ropePositions[ropePositions.Count - 1] - ropePositions[ropePositions.Count - 2]);

            // distY is the distance between second last and third last point
            Vector3 distY = (ropePositions[ropePositions.Count - 2] - ropeStartPoint.position)
                + (ropePositions[ropePositions.Count - 2] - ropePositions[ropePositions.Count - 3]);

            // distance x is greater than distance y
            if (distX.magnitude > distY.magnitude)
            {
                //delete second last position 
                ropePositions.RemoveAt(ropePositions.Count - 2);
            }
            else return;
        }
        
    }

    private void DetectCollisionEnter()
    {
        if (!player.backtracking)
        {
            RaycastHit hit;
            if (Physics.Linecast(playerTransform.position, rope.GetPosition(ropePositions.Count - 2), out hit, collMask))
            {
                ropePositions.RemoveAt(ropePositions.Count - 1);

                AddPosToRope(hit.point);
            }
        }
       
    }

    private void DetectCollisionExits()
    {
        RaycastHit hit;
        if (!Physics.Linecast(playerTransform.position, rope.GetPosition(ropePositions.Count - 3), out hit, collMask))
        {
            ropePositions.RemoveAt(ropePositions.Count - 2);
        }
    }

    private void AddPosToRope(Vector3 _pos)
    {
        ropePositions.Add(_pos);
        ropePositions.Add(playerTransform.position); //Always the last pos must be the player
    }

    private void UpdateRopePositions()
    {
        rope.positionCount = ropePositions.Count;
        rope.SetPositions(ropePositions.ToArray());
    }

    private void LastSegmentGoToPlayerPos() => rope.SetPosition(rope.positionCount - 1, playerTransform.position);

    public void DeleteAllPositions()
    {
        StartCoroutine(RemovePositions());
        
    }

    private IEnumerator RemovePositions()
    {
        for (int i = ropePositions.Count - 1; i > 1; i--)
        {
            yield return new WaitForSeconds(0f);
            // player.transform.position = ropePositions[ropePositions.Count - 1];
            if (ropePositions.Count > 1)
            {
                ropePositions.RemoveAt(i);
            }
            else {
                break;}
            
        }
    }
}