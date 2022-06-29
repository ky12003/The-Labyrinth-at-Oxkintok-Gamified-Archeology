using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // This is so that it should find the Text component
using UnityEngine.Events; // This is so that you can extend the pointer handlers
using UnityEngine.EventSystems; // This is so that you can extend the pointer handlers
public class Mouseover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
	// Start is called before the first frame update
	void Start()
	{
		GetComponent<Renderer>().material.color = Color.black;

	}

	

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
		GetComponent<Renderer>().material.color = Color.black;
	}

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
		GetComponent<Renderer>().material.color = Color.red;
		Debug.Log("Enter " + gameObject.name);
	}
}
