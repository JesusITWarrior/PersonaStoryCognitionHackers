using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntireCanvas : MonoBehaviour
{
    public GameObject thingToSize;
    void Start()
    {
        float x = Screen.width;
        float y = Screen.height;
        thingToSize.transform.localScale = new Vector3(x, y, 1);
    }
}
