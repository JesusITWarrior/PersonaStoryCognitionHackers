using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
    [SerializeField] private Canvas canvas;
    private RectTransform rectTransform;
    public Vector3 initialSpot;
    private CanvasGroup canvasGroup;
    static bool replaceCharPanel;

    public int index = 0;
    public void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        index = transform.GetSiblingIndex();
        canvasGroup = GetComponent<CanvasGroup>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        replaceCharPanel = false;
        Debug.Log("OnBeginDrag");
        transform.SetAsLastSibling();
        initialSpot = transform.localPosition;
        canvasGroup.blocksRaycasts = false;

    }

    public void OnDrag(PointerEventData eventData)
    {
        
        Debug.Log("OnDrag");
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        transform.SetSiblingIndex(index);
        if (!eventData.pointerEnter) {
            if (!replaceCharPanel) {
                transform.localPosition = initialSpot;
            }
        }
        canvasGroup.blocksRaycasts = true;
        replaceCharPanel = false;
    }

    public void OnDrop(PointerEventData eventData)
    {

        if (eventData.pointerDrag != null)
        {
            Debug.Log("OnDrop");
            replaceCharPanel = true;
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition; //Sets the drug panel to spot where the previous panel was
            transform.localPosition = eventData.pointerDrag.GetComponent<DragDrop>().initialSpot; //Assigns the panel that is being replaced to the original spot of the drug panel
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
        //initialSpot = transform.localPosition;
    }
}
