using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroller : MonoBehaviour
{

    public float scrollX = 1f;
    public float scrollY = 0f;
    public Player player;
    

    // Update is called once per frame
    void Update()
    {

        if (player.isMoving)
        {
            float OffsetX = Time.time * scrollX;
            float OffsetY = Time.time * scrollY;
            GetComponent<Renderer>().material.mainTextureOffset = new Vector2(OffsetX, OffsetY);

        }
        
    }


}
