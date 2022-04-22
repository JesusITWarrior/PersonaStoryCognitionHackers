using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MenuOpener : MonoBehaviour
{
    [SerializeField] private InputActionReference Start;
    public GameObject MainMenu;
    public AudioSource BGMusic;
    private bool isBooting = true, canInterrupt = false;
    [SerializeField] private GameObject actualMenu;

    private void Awake()
    {
        if(PlayerPrefs.GetInt("firstTime",0) == 0)
        {
            canInterrupt = false;
            PlayerPrefs.SetInt("firstTime", 1);
        }
        else
        {
            canInterrupt = true;
        }
        actualMenu = GameObject.Find("UI Menu");
    }

    private void OnEnable()
    {
        Start.action.Enable();
    }

    private void OnDisable()
    {
        Start.action.Disable();
    }

    public void bootFaster()
    {
        if (isBooting && canInterrupt)
        {
            //Player is wanting to stop the bootup intro and 
            Destroy(GameObject.Find("Bootup Canvas"));
            Destroy(GameObject.Find("Bootup Canvas 2"));
            Destroy(GameObject.Find("Bootup Sound"));
            Destroy(GameObject.Find("Type"));
            startMenu();
            isBooting = false;
        }
        else if (!isBooting)
        {
            //Add code here to make the game go into the actual main menu
            //TODO: Add sound effect that symbolizes the transition between logo to main menu
            actualMenu.SetActive(true);
            //Play animation

        }

    }

    public void startMenu()
    {
        Invoke("beginMusic", 2f);
        isBooting = false;
        //Animate logo coming in, then the text appearing and flashing slowly
    }

    void beginMusic()
    {
        BGMusic.Play();
    }
}
