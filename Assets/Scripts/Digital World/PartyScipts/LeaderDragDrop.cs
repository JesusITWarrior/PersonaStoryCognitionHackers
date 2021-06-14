using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LeaderDragDrop : MonoBehaviour, IDropHandler
{
    public AudioSource Error;
    public void OnDrop(PointerEventData eventData)
    {
        Error.Play();
    }
}