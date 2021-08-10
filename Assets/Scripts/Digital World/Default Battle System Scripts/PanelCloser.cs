using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PanelCloser : MonoBehaviour
{
    public AudioSource Back;
    public GameObject Circle;
    public GameObject NewCircle;
    private PlayerControls nav;
    // Start is called before the first frame update
    void Awake()
    {
        nav = new PlayerControls();
        nav.MenuNavigation.Back.performed += x => close();
    }

    void OnEnable()
    {
        nav.Enable();
    }

    void OnDisable()
    {
        nav.Disable();
    }

    // Update is called once per frame
    /*void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
                Panel.gameObject.SetActive(false);
                Back.Play();
                Circle.SetActive(false);
                NewCircle.SetActive(true);
                
        }
    }*/

    public void close()
    {
        Back.Play();
        Circle.SetActive(false);
        NewCircle.SetActive(true);
    }
}
