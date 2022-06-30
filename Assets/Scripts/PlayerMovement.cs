using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // using tutorial: https://www.youtube.com/watch?v=_QajrabyTJc
    public CharacterController controller;

    // control speed
    public float speed = 4f;

    
    void Update()
    {
        // get user input for horizontal/vertical movement
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // move along x/z axis (no y axis movement since the player cannot fly)
        Vector3 move = transform.right * x + transform.forward * z;

        // move player
        controller.Move(move * speed * Time.deltaTime);
    }
}