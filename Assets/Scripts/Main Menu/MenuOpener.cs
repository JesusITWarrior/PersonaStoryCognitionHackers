using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MenuOpener : MonoBehaviour
{
    [SerializeField] private InputActionReference Start;
    public AudioSource BGMusic;
    private bool isBooting = true, canInterrupt = false;
    [SerializeField] private GameObject mainMenu;

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
        mainMenu = GameObject.Find("UI Menu");
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
            mainMenu.SetActive(true);
            //Play animation

        }

    }

    public void startMenu()
    {
        Invoke("beginMusic", 2f);
        isBooting = false;
        //Animate logo coming in, then the text appearing and flashing slowly
        StartCoroutine(showLogo());
        StartCoroutine(showStartText());
        GameObject.Find("Main Camera").GetComponent<CRTPostProcess>().enabled = false;
    }

    IEnumerator showLogo()
    {
        yield return new WaitForSeconds(5f);
        this.transform.Find("Logo").gameObject.SetActive(true);
    }

    IEnumerator showStartText()
    {
        yield return new WaitForSeconds(8f);
        this.transform.Find("Text").gameObject.SetActive(true);
    }

    void beginMusic()
    {
        BGMusic.Play();
    }
}
