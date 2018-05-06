using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Dragable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Transform initparent;
    Vector3 initposition;
    public void OnBeginDrag(PointerEventData eventData)
    {
        initparent = transform.parent;
        initposition = transform.position;

        GetComponent<CanvasGroup>().blocksRaycasts = false;

    }

    public void OnDrag(PointerEventData eventData)
    {


        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        this.transform.SetParent(initparent);
        this.transform.position = initposition;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }



}
