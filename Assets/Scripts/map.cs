using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class map : MonoBehaviour
{
    // Start is called before the first frame update

  //  public UnityEvent onInteract;
 //   public float mouseSensitivity = 100f;
    public GameObject cam;

    // for rotating the player body in respect to where they want to face
//    public Transform playerBody;

    // amount to rotate about the x-axis (so rotation vertically when facing forward)
 //   float xRotation = 0f;
 //   public float speed = 4f;

    // for checking if player is using a popup item or not
    PopupToggle popupToggle;
  //  [SerializeField] GameObject uiInteractor;
    /** void Awake() {
        popupToggle = uiInteractor.GetComponent<PopupToggle>();
    }**/
    
    void Start()
    {
        // keep cursor inside the game (prevent user from getting mouse cursor outside the game window, default setting)
      /**  cam.transform.position = new Vector3(0,150,0);
        cam.transform.Rotate(90, 0, 0);**/

    }

    

    // Update is called once per frame
    void Update()
    {

     /**   if (Input.GetKey(KeyCode.Tab) || popupToggle.popupIsOpen)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            //useMouseForUI();
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            moveplayer();
        }**/
    }
/**
    void rotRight(float currAngle) 
    {
        if (currAngle >= 270) {
            playerBody.rotation = Quaternion.Euler(0f, 0f, 0f);
        } else if (currAngle >= 180) {
            playerBody.rotation = Quaternion.Euler(90f, 0f, 0f);
        } else if (currAngle >= 90) {
            playerBody.rotation = Quaternion.Euler(90f, 0f, 0f);
        } else {
            playerBody.rotation = Quaternion.Euler(90f, 0f, 0f);
        }
    }

    // function for doing leftward rotation with button
    void rotLeft(float currAngle) 
    {
        if (currAngle > 0 && currAngle <= 90) {
            playerBody.rotation = Quaternion.Euler(0f, 0f, 0f);
        } else if (currAngle <= 180) {
            playerBody.rotation = Quaternion.Euler(90f, 0f, 0f);
        } else if (currAngle <= 270) {
            playerBody.rotation = Quaternion.Euler(180f, 0f, 0f);
        } else {
            playerBody.rotation = Quaternion.Euler(270f, 0f, 0f);
        }
    }



    public void moveplayer() {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // move camera vertically on vertical movement of mouse
        xRotation -= mouseY;
        // restrict to 180 degrees so that player does not look backwards from forwards-facing position
        xRotation = Mathf.Clamp(xRotation, 0f, 0f);

        // rotate about x axis (vertically)
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // rotate about y axis (horizontally)
        playerBody.Rotate(Vector3.up * mouseX);

        /*-----
        Options for key press
        ------*/
        // get current rotational position (in degrees)
    /**    float currRotation = GetComponent<Camera>().transform.eulerAngles.x;
        // turn left with "J" key, turn right with "L" key
        if (Input.GetKeyDown(KeyCode.J))
        {
            rotLeft(currRotation);
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            rotRight(currRotation);
        }
    }**/
}
