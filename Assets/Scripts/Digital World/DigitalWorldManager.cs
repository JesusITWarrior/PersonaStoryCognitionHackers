using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(WorldManager))]
public class DigitalWorldManager : MonoBehaviour
{
    public int area;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    //Make a function that returns the combat area and ShadowSOs to pass in.
}
