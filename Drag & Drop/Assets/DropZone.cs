﻿using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler{

	public void OnPointerEnter(PointerEventData eventData)
	{
		if(eventData.pointerDrag == null)
			return; 
		//Debug.Log("OnPointerEnter");
		Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
		if(d != null)
		{
			d.placeholderParent = this.transform;
		}
	}
	public void OnPointerExit(PointerEventData eventData)
	{
		if(eventData.pointerDrag == null)
			return; 
		//Debug.Log("OnPointerExit");
		Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
		if(d != null && d.placeholderParent == this.transform)
		{
			d.placeholderParent = d.parentToReturnTo;
		}
	}
	public void OnDrop(PointerEventData eventData)
	{
		Debug.Log(eventData.pointerDrag.name + " was dropped on " + gameObject.name);

		Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
		if(d != null)
		{
			d.parentToReturnTo = this.transform;
		}
	}
}
