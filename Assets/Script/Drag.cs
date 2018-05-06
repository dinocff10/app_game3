using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour ,IBeginDragHandler ,IDragHandler ,IEndDragHandler {

    public void OnBeginDrag(PointerEventData eventData)
    {
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        

        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
       
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}



}
