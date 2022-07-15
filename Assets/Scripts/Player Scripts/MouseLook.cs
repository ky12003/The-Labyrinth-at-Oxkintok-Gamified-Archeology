using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    // from tutorial (for regular looking with mouse): https://www.youtube.com/watch?v=_QajrabyTJc
    
    // for how much/how fast camera moves in correlation with mouse movement
    public float mouseSensitivity = 100f;

    // for rotating the player body in respect to where they want to face
    public Transform playerBody;

    // amount to rotate about the x-axis (so rotation vertically when facing forward)
    float xRotation = 0f;

    // for checking if player is using a popup item or not
    PopupToggle popupToggle;
    [SerializeField] GameObject uiInteractor;

    // control speed
    public float speed = 4f;

    void Awake() {
        popupToggle = uiInteractor.GetComponent<PopupToggle>();
    }
    
    void Start()
    {
        // keep cursor inside the game (prevent user from getting mouse cursor outside the game window, default setting)
        Cursor.lockState = CursorLockMode.Locked;
    }


    void Update()
    {

        if (Input.GetKey(KeyCode.Tab) || popupToggle.popupIsOpen) {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            useMouseForUI();
        } else {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            useMouseForCamera();
        }
    }

    /*-------
    Helper functions
    -------*/
    // function for doing rightward rotation with button
    void rotRight(float currAngle) 
    {
        if (currAngle >= 270) {
            playerBody.rotation = Quaternion.Euler(0f, 0f, 0f);
        } else if (currAngle >= 180) {
            playerBody.rotation = Quaternion.Euler(0f, 270f, 0f);
        } else if (currAngle >= 90) {
            playerBody.rotation = Quaternion.Euler(0f, 180f, 0f);
        } else {
            playerBody.rotation = Quaternion.Euler(0f, 90f, 0f);
        }
    }

    // function for doing leftward rotation with button
    void rotLeft(float currAngle) 
    {
        if (currAngle > 0 && currAngle <= 90) {
            playerBody.rotation = Quaternion.Euler(0f, 0f, 0f);
        } else if (currAngle <= 180) {
            playerBody.rotation = Quaternion.Euler(0f, 90f, 0f);
        } else if (currAngle <= 270) {
            playerBody.rotation = Quaternion.Euler(0f, 180f, 0f);
        } else {
            playerBody.rotation = Quaternion.Euler(0f, 270f, 0f);
        }
    }

    // function for using mouse control/buttons for camera movement
    void useMouseForCamera() 
    {
        /*-----
        Options for mouse
        ------*/
        // get mouse input about horizontal/vertical axis
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // move camera vertically on vertical movement of mouse
        xRotation -= mouseY;
        // restrict to 180 degrees so that player does not look backwards from forwards-facing position
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // rotate about x axis (vertically)
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // rotate about y axis (horizontally)
        playerBody.Rotate(Vector3.up * mouseX);

        /*-----
        Options for key press
        ------*/
        // get current rotational position (in degrees)
        float currRotation = GetComponent<Camera>().transform.eulerAngles.y;
        // turn left with "J" key, turn right with "L" key
        if (Input.GetKeyDown(KeyCode.J)) {
            rotLeft(currRotation);
        } else if (Input.GetKeyDown(KeyCode.L)) {
            rotRight(currRotation);
        }
    }

    // function for using mouse control for interaction with UI
    void useMouseForUI() 
    {
        // nothing for now, may add stuff later
    }
}
