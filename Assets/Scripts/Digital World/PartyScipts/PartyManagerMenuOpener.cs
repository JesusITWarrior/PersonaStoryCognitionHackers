using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PartyManagerMenuOpener : MonoBehaviour
{
    //int i = 1;
    private PlayerControls controls;
    public GameObject TeamMenu;
    void Awake()
    {
        controls = new PlayerControls();
        controls.Movement.Pause.performed += x => openMenu();
        controls.MovementController.Pause.performed += x => openMenu();
    }

    void OnEnable()
    {
        controls.Enable();
    }

    void OnDisable()
    {
        controls.Disable();
    }
    void Update()
    {
        
    }

    void openMenu()
    {
        //OnDisable();
        //Debug.Log(i);
        Cursor.lockState = CursorLockMode.None;
        Instantiate(TeamMenu);
        Destroy(this.gameObject);
        //i++;
    }
}
