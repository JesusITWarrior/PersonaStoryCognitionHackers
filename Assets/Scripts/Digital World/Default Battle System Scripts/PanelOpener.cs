using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelOpener : MonoBehaviour
{
    public GameObject Circle;
    public GameObject Panel;
    public GameObject NewCircle;
    
    
    public void OpenPanel() {  
        Panel.SetActive(true);
        Circle.SetActive(false);
        NewCircle.SetActive(true);
    }
}
