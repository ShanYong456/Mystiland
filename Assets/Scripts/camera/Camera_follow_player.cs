using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_follow_player : MonoBehaviour
{
    private Transform playerTransform;

    public float x_offset;
    public float y_offset;
    
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    
    void Update()
    {
        //store current camera's postion in variable temp
        Vector3 temp = transform.position;

        //set the camera's postion x&y to be equal to the player's position x&y
        temp.x = playerTransform.position.x;

        temp.y = playerTransform.position.y;

        //add the offset value to the temporary camera's x&y position
        temp.x += x_offset;
        temp.y += y_offset;

        //set back the camera's temp position to the camera's current postion
        transform.position = temp;
    }
}
