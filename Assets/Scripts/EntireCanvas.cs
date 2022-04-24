using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntireCanvas : MonoBehaviour
{
    public RectTransform thingToSize;
    void Start()
    {
        thingToSize = GetComponent<RectTransform>();
        thingToSize.anchorMin = new Vector2(0,0);
        thingToSize.anchorMax = new Vector2(1,1);
    }

    public void resize()
    {
        thingToSize = GetComponent<RectTransform>();
        thingToSize.anchorMin = new Vector2(0, 0);
        thingToSize.anchorMax = new Vector2(1, 1);
    }
}
