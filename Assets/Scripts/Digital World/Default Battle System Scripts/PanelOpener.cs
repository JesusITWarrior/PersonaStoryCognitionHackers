using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelOpener : MonoBehaviour
{
    public GameObject Circle;
    public GameObject NewCircle;
    
    
    public void OpenPanel() {  
        Circle.SetActive(false);
        NewCircle.SetActive(true);
    }
}
