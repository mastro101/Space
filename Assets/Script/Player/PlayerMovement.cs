﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [Header("Input Settings")]
    public KeyCode ForwardInput;
    public KeyCode BackwardInput;
    public KeyCode LeftInput;
    public KeyCode RightInput;

    public float UpLimit, BackLimit, LeftLimimit, RightLimit;

    public float MovementSpeed;

    public float XAxisMovement;
    public float ZAxisMovement;

    void FixedUpdate () {
        // Up
        if (Input.GetKey(ForwardInput) && transform.position.z < UpLimit)
        {
            transform.position += Vector3.forward * MovementSpeed;
            ZAxisMovement = 1;
        }
        else if (Input.GetKey(BackwardInput) && transform.position.z > BackLimit)
        {
            transform.position += Vector3.back * MovementSpeed;
            ZAxisMovement = -1;
        }
        // Left
        if (Input.GetKey(LeftInput) && transform.position.x > LeftLimimit)
        {
            transform.position += Vector3.left * MovementSpeed;
            XAxisMovement = -1;
        }
        else if (Input.GetKey(RightInput) && transform.position.x < RightLimit)
        {
            transform.position += Vector3.right * MovementSpeed;
            XAxisMovement = 1;
        }


    }
}
