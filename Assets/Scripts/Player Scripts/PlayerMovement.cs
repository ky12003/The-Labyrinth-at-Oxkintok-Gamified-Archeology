using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // using tutorial: https://www.youtube.com/watch?v=_QajrabyTJc
    public CharacterController controller;
    public float gravity = -9.81f;

    // for checking if player is using a popup item or not
    PopupToggle popupToggle;
    [SerializeField] GameObject uiInteractor;

    // control speed
    public float speed = 4f;

    // velocity
    Vector3 velocity;

    // ground check
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;

    void Awake() {
        popupToggle = uiInteractor.GetComponent<PopupToggle>();
    }
    
    void Update()
    {
        if (!popupToggle.popupIsOpen) {
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

            if (isGrounded && velocity.y < 0) {
                velocity.y = -2f;
            }

            // get user input for horizontal/vertical movement
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            // move along x/z axis (no y axis movement since the player cannot fly)
            Vector3 move = transform.right * x + transform.transform.forward * z;

            // move player
            controller.Move(move * speed * Time.deltaTime);

            // handle gravity
            velocity.y += gravity * Time.deltaTime;

            controller.Move(velocity * Time.deltaTime);
        }

    }
}
