using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartyNumButton : MonoBehaviour
{
    //TODO: Remove this as a scene and implement this as seperate UI
    //TODO: Add button guide on bottom left
    //TODO: Add confirmation button to set parties.
    //TODO: Read parties to determine what panel each character is assigned to
    public GameObject window;
    public InputField Num;
    public Party partyRef;
    PlayerControls keyboard;
    public Button button;
    public GameObject Main, TL1, TL2, TS1, TS2, TS3, T1, T2, T3, T4, CP1, CP2, CP3, CP4, confirmWindow;
    public AudioSource Select;
    public AudioSource Error;

    void Awake()
    {
        keyboard = new PlayerControls();
    }

    void OnEnable()
    {
        keyboard.Enable();
    }

    void OnDisable()
    {
        keyboard.Disable();
    }
    void Update()
    {
        keyboard.MenuNavigation.Submit.performed += x => onClick();
    }

    public void onClick()
    {
        int partiesNum = int.Parse(Num.GetComponent<InputField>().text);
        if (partiesNum > 0 && partiesNum < 4)
        {
            Select.Play();
            partyRef.resetParties();     //TODO optimize this to instead read parties and reset it after confirmation
            displayPanels(partiesNum);
            window.SetActive(false);
        }
        else if (partiesNum == 4)
        {
            Select.Play();
            //partyRef.createParties(partiesNum);
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
                CP1.transform.localPosition = new Vector3(0f, 357, 0f);
                CP2.SetActive(true);
                CP2.transform.localPosition = new Vector3(0f, 243, 0f);
                CP3.SetActive(true);
                CP3.transform.localPosition = new Vector3(0f, 130, 0f);
                CP4.SetActive(true);
                CP4.transform.localPosition = new Vector3(0f, 17, 0f);
                confirmWindow.SetActive(true);
                break;
            case 2:
                TL1.SetActive(true);
                //TL1.transform.localPosition = new Vector3(-250, 240, 0);
                CP1.SetActive(true);
                CP1.transform.localPosition = new Vector3(-300, 357.5f, 0f);
                CP2.SetActive(true);
                CP2.transform.localPosition = new Vector3(-300, 242.7f, 0f);
                CP3.SetActive(true);
                CP3.transform.localPosition = new Vector3(-300, 128.8f, 0f);
                CP4.SetActive(true);
                CP4.transform.localPosition = new Vector3(300, 357.5f, 0f);  //Moved to team 2 to compensate for lack of space
                TL2.SetActive(true);
                //TL2.transform.localPosition = new Vector3(250,240,0);
                confirmWindow.SetActive(true);
                break;
            case 3:
                TS1.SetActive(true);
                //T1.transform.localPosition = new Vector3(-500, 240, 0);
                CP1.SetActive(true);
                CP1.transform.localPosition = new Vector3(-500, 357, 0f);
                CP2.SetActive(true);
                CP2.transform.localPosition = new Vector3(-500, 244, 0f);
                CP3.SetActive(true);
                CP3.transform.localPosition = new Vector3(0, 357, 0f);
                CP4.SetActive(true);
                CP4.transform.localPosition = new Vector3(500, 357, 0f);    //Moved to team 2 to compensate for lack of space
                TS2.SetActive(true);
                //T2.transform.localPosition = new Vector3(0, 240, 0);
                TS3.SetActive(true);
                //T3.transform.localPosition = new Vector3(500, 240, 0);
                confirmWindow.SetActive(true);

                break;
            case 4:
                //Sets each character panel into a slot in each team
                T1.SetActive(true);
                //T1.transform.localPosition = new Vector3(-720, 240, 0);
                CP1.SetActive(true);
                CP1.transform.localPosition = new Vector3(-724, 359, 0f);
                T2.SetActive(true);
                //T2.transform.localPosition = new Vector3(-240, 240, 0);
                CP2.SetActive(true);
                CP2.transform.localPosition = new Vector3(-242, 359, 0f);
                T3.SetActive(true);
                //T3.transform.localPosition = new Vector3(240, 240, 0);
                CP3.SetActive(true);
                CP3.transform.localPosition = new Vector3(242, 359, 0f);
                T4.SetActive(true);
                //T4.transform.localPosition = new Vector3(720, 240, 0);
                CP4.SetActive(true);
                CP4.transform.localPosition = new Vector3(724, 359, 0f);
                confirmWindow.SetActive(true);
                break;
        }
    }
}