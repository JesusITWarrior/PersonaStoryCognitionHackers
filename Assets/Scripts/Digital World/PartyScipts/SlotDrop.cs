using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlotDrop : MonoBehaviour, IDropHandler
{
    public GameObject Panel;
    public Canvas menu;
    public bool inSlot = true;
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            Debug.Log("OnDropSlot");
            eventData.pointerDrag.GetComponent<Transform>().parent = Panel.transform;
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition; //Sets the drug panel to spot where the previous panel was
            eventData.pointerDrag.GetComponent<Transform>().parent = menu.transform;
            eventData.pointerDrag.GetComponent<Transform>().SetSiblingIndex(eventData.pointerDrag.GetComponent<DragDrop>().index);
        }
    }
}