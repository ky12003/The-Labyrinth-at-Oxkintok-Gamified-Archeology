using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    // store specific event for when interactable is interacted with (edited within unity)
    public UnityEvent onInteract;
    public UnityEvent onLook;
    public UnityEvent onNoInteraction;
    public AudioSource pickpage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
