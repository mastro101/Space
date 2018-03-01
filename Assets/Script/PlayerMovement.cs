using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [Header("Input Settings")]
    public KeyCode ForwardInput;
    public KeyCode BackwardInput;
    public KeyCode LeftInput;
    public KeyCode RightInput;

    public float MovementSpeed;

	void FixedUpdate () {
        // Up
        if (Input.GetKey(ForwardInput))
        {
            transform.position += Vector3.forward * MovementSpeed;
        }
        else if (Input.GetKey(BackwardInput))
        {
            transform.position += Vector3.back * MovementSpeed;
        }
        // Left
        if (Input.GetKey(LeftInput))
        {
            transform.position += Vector3.left * MovementSpeed;
        }
        else if (Input.GetKey(RightInput))
        {
            transform.position += Vector3.right * MovementSpeed;
        }


    }
}
