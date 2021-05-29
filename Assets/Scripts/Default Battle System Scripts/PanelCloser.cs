using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelCloser : MonoBehaviour
{
    public AudioSource Back;
    public GameObject Panel;
    public GameObject Circle;
    public GameObject NewCircle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
                Panel.gameObject.SetActive(false);
                Back.Play();
                Circle.SetActive(false);
                NewCircle.SetActive(true);
                
        }
    }

    public void close()
    {
        Panel.gameObject.SetActive(false);
        Circle.SetActive(false);
    }
}
