using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PartyNumButton : MonoBehaviour
{
    //TODO: Remove this as a scene and implement this as seperate UI
    //TODO: Add button guide on bottom left
    //TODO: Add confirmation button to set parties.
    //TODO: Read parties to determine what panel each character is assigned to
    public GameObject window;
    public InputField Num;
    //public Party partyRef;
    private PlayerControls keyboard;
    public GameObject Main, TL1, TL2, TS1, TS2, TS3, T1, T2, T3, T4, CP1, CP2, CP3, CP4, confirmWindow;
    public AudioSource Select;
    public AudioSource Error;

    int i = 1;

    private void Awake()
    {
        keyboard = new PlayerControls();
        keyboard.MenuNavigation.Submit.performed += x => onClick();
    }

    void OnEnable()
    {
        keyboard.Enable();
    }

    void OnDisable()
    {
        keyboard.Disable();
    }
    private void Update()
    {
        
    }

    public void onClick()
    {
        int partiesNum = int.Parse(Num.GetComponent<InputField>().text);
        if (partiesNum > 0 && partiesNum < 4)
        {
            Select.Play();
            displayPanels(partiesNum);
            window.SetActive(false);
        }
        else if (partiesNum == 4)
        {
            Select.Play();
            displayPanels(partiesNum);
            window.SetActive(false);
        }
        else
        {
            Debug.Log("Invalid number");
            Error.Play();
        }
    }

    public void displayPanels(int num)
    {
        
        switch (num)
        {
            case 1:
                Main.SetActive(true);
                
                CP1.SetActive(true);
                CP1.transform.localPosition = new Vector3(-430.4281f, 208.4341f, 0f);
                CP1.transform.localScale = new Vector3(0.297441512f, 0.105847992f, 1.01959085f);
                CP2.SetActive(true);
                CP2.transform.localPosition = new Vector3(-430.4281f, 57.67982f, 0f);
                CP2.transform.localScale = new Vector3(0.297441512f, 0.105847992f, 1.01959085f);
                CP3.SetActive(true);
                CP3.transform.localPosition = new Vector3(-430.4281f, -91.63171f, 0f);
                CP3.transform.localScale = new Vector3(0.297441512f, 0.105847992f, 1.01959085f);
                CP4.SetActive(true);
                CP4.transform.localPosition = new Vector3(-430.4281f, -240.9435f, 0f);
                CP4.transform.localScale = new Vector3(0.297441512f, 0.105847992f, 1.01959085f);
                confirmWindow.SetActive(true);
                //confirmWindow.transform.localPosition = new Vector3(19, -2.5f, 0);
                break;
            case 2:
                TL1.SetActive(true);
                //TL1.transform.localPosition = new Vector3(-250, 240, 0);
                CP1.SetActive(true);
                CP1.transform.localPosition = new Vector3(-522.5577f, 256.3206f, 0f);
                CP1.transform.localScale = new Vector3(0.1764507f, 0.0684814528f, 1.01959085f);
                CP2.SetActive(true);
                CP2.transform.localPosition = new Vector3(-522.5577f, 149.1474f, 0f);
                CP2.transform.localScale = new Vector3(0.1764507f, 0.0684814528f, 1.01959085f);
                CP3.SetActive(true);
                CP3.transform.localPosition = new Vector3(-522.5577f, 43.00002f, 0f);
                CP3.transform.localScale = new Vector3(0.1764507f, 0.0684814528f, 1.01959085f);
                CP4.SetActive(true);
                CP4.transform.localPosition = new Vector3(-95.55774f, -45.67943f, 0f);  //Moved to team 2 to compensate for lack of space
                CP4.transform.localScale = new Vector3(0.1764507f, 0.0684814528f, 1.01959085f);
                TL2.SetActive(true);
                //TL2.transform.localPosition = new Vector3(250,240,0);
                confirmWindow.SetActive(true);
                //confirmWindow.transform.localPosition = new Vector3(19, -2.5f, 0);
                break;
            case 3:
                TS1.SetActive(true);
                //T1.transform.localPosition = new Vector3(-500, 240, 0);
                CP1.SetActive(true);
                CP1.transform.localPosition = new Vector3(-524.5577f, 258.3206f, 0f);
                CP1.transform.localScale = new Vector3(0.177346334f, 0.0679421127f, 1.01959085f);
                CP2.SetActive(true);
                CP2.transform.localPosition = new Vector3(-524.5577f, 151.1473f, 0f);
                CP2.transform.localScale = new Vector3(0.177346334f, 0.0679421127f, 1.01959085f);
                CP3.SetActive(true);
                CP3.transform.localPosition = new Vector3(-108.5577f, 51.3206f, 0f);             //Moved to team 2 to compensate for lack of space
                CP3.transform.localScale = new Vector3(0.177346334f, 0.0679421127f, 1.01959085f);
                CP4.SetActive(true);
                CP4.transform.localPosition = new Vector3(-524.5577f, -151.6794f, 0f);    //Moved to team 3 to compensate for lack of space
                CP4.transform.localScale = new Vector3(0.177346334f, 0.0679421127f, 1.01959085f);
                TS2.SetActive(true);
                TS3.SetActive(true);
                confirmWindow.SetActive(true);
                //confirmWindow.transform.localPosition = new Vector3(24.3f, -2.5f, 0);


                break;
            case 4:
                T1.SetActive(true);
                CP1.SetActive(true);
                CP1.transform.localPosition = new Vector3(-524.5577f, 198.6f, 0f);
                CP1.transform.localScale = new Vector3(0.177555084f, 0.0686136857f, 1.01959085f);
                T2.SetActive(true);
                CP2.SetActive(true);
                CP2.transform.localPosition = new Vector3(-524.5577f, -75.40001f, 0f);
                CP2.transform.localScale = new Vector3(0.177555084f, 0.0686136857f, 1.01959085f);
                T3.SetActive(true);
                CP3.SetActive(true);
                CP3.transform.localPosition = new Vector3(-95.55774f, 198.6f, 0f); 
                CP3.transform.localScale = new Vector3(0.177555084f, 0.0686136857f, 1.01959085f);
                T4.SetActive(true);
                CP4.SetActive(true);
                CP4.transform.localPosition = new Vector3(-95.55774f, -75.40001f, 0f);
                CP4.transform.localScale = new Vector3(0.177555084f, 0.0686136857f, 1.01959085f);
                confirmWindow.SetActive(true);
                //confirmWindow.transform.localPosition = new Vector3(12.2f, -2.5f, 0);
                break;
        }
        i++;
    }
}