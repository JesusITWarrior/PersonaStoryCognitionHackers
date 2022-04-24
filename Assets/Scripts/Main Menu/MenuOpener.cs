using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MenuOpener : MonoBehaviour
{
    [SerializeField] private Animator mainMenuCamState;
    [SerializeField] private Text startText;
    private CinemachineStateCameraHandler cam;
    private Keyboard keyboard;
    private Gamepad gamepad;
    public AudioSource BGMusic;
    private bool isBooting = true, isAdvert = false;
    [SerializeField] private GameObject mainMenu;

    private void Awake()
    {
        //Start = pc.MenuNavigation.Start;
        /*if(PlayerPrefs.GetInt("firstTime",0) == 0)
        {
            canInterrupt = false;
            PlayerPrefs.SetInt("firstTime", 1);
        }
        else
        {
            canInterrupt = true;
        }*/
        keyboard = Keyboard.current;
        gamepad = Gamepad.current;
        mainMenu = GameObject.Find("UI Menu");
        mainMenu.SetActive(false);
        cam = GameObject.Find("State Camera Handler").GetComponent<CinemachineStateCameraHandler>();
    }

    /*private void OnEnable()
    {
        pc.Enable();
    }

    private void OnDisable()
    {
        pc.Disable();
    }*/

    private void Update()
    {
        gamepad = Gamepad.current;
        if (keyboard.anyKey.wasPressedThisFrame || (gamepad != null && gamepad.startButton.wasPressedThisFrame))
        {
            bootFaster();
        }
    }

    public void bootFaster()
    {
        if (!isBooting && !isAdvert)
        {
            //Add code here to make the game go into the actual main menu
            //TODO: Add sound effect that symbolizes the transition between logo to main menu
            
            //Play animation
            startText.gameObject.GetComponent<Animator>().SetTrigger("ConfirmFadeOut");
            StartCoroutine(toMainMenu());
        }

    }

    public void startMenu()
    {
        Invoke("beginMusic", 2f);
        isBooting = false;
        isAdvert = true;
        //Animate logo coming in, then the text appearing and flashing slowly
        StartCoroutine(showDevLogo());
        StartCoroutine(showGameLogo());
        StartCoroutine(showStartText());
        GameObject.Find("Main Camera").GetComponent<CRTPostProcess>().enabled = false;
    }

    IEnumerator showDevLogo()
    {
        yield return new WaitForSeconds(3f);
        //Show dev logo here
    }

    IEnumerator showGameLogo()
    {
        yield return new WaitForSeconds(5f);
        this.transform.Find("Logo").gameObject.SetActive(true);
    }

    IEnumerator showStartText()
    {
        yield return new WaitForSeconds(8f);
        this.transform.Find("Text").gameObject.SetActive(true);
        isAdvert = false;
    }

    IEnumerator toMainMenu()
    {
        yield return new WaitForSeconds(3f);
        this.gameObject.GetComponent<Canvas>().renderMode = RenderMode.WorldSpace;
        cam.toMainMenu();
        yield return new WaitForSeconds(5f);
        mainMenu.SetActive(true);       //Change this to make them fade in
    }

    void beginMusic()
    {
        BGMusic.Play();
    }
}
