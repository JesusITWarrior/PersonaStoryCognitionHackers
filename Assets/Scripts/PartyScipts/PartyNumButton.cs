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
    //public Party partyRef;
    PlayerControls keyboard;
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
            //partyRef.resetParties();     //TODO optimize this to instead read parties and reset it after confirmation
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
                CP1.transform.localPosition = new Vector3(-544, 160.7f, 0f);
                CP1.transform.localScale = new Vector3(0.335239768f, 0.128322378f, 1.01959085f);
                CP2.SetActive(true);
                CP2.transform.localPosition = new Vector3(-544, -6.4f, 0f);
                CP2.transform.localScale = new Vector3(0.335239768f, 0.128322378f, 1.01959085f);
                CP3.SetActive(true);
                CP3.transform.localPosition = new Vector3(-544, -173, 0f);
                CP3.transform.localScale = new Vector3(0.335239768f, 0.128322378f, 1.01959085f);
                CP4.SetActive(true);
                CP4.transform.localPosition = new Vector3(-544, -340, 0f);
                CP4.transform.localScale = new Vector3(0.335239768f, 0.128322378f, 1.01959085f);
                confirmWindow.SetActive(true);
                confirmWindow.transform.localPosition = new Vector3(19, -2.5f, 0);
                break;
            case 2:
                TL1.SetActive(true);
                //TL1.transform.localPosition = new Vector3(-250, 240, 0);
                CP1.SetActive(true);
                CP1.transform.localPosition = new Vector3(-549f, 276, 0f);
                CP1.transform.localScale = new Vector3(0.298265189f, 0.0803216696f, 1.01959085f);
                CP2.SetActive(true);
                CP2.transform.localPosition = new Vector3(-549f, 172, 0f);
                CP2.transform.localScale = new Vector3(0.298265189f, 0.0803216696f, 1.01959085f);
                CP3.SetActive(true);
                CP3.transform.localPosition = new Vector3(-549f, 68, 0f);
                CP3.transform.localScale = new Vector3(0.298265189f, 0.0803216696f, 1.01959085f);
                CP4.SetActive(true);
                CP4.transform.localPosition = new Vector3(-549f, -175, 0f);  //Moved to team 2 to compensate for lack of space
                CP4.transform.localScale = new Vector3(0.298265189f, 0.0803216696f, 1.01959085f);
                TL2.SetActive(true);
                //TL2.transform.localPosition = new Vector3(250,240,0);
                confirmWindow.SetActive(true);
                confirmWindow.transform.localPosition = new Vector3(19, -2.5f, 0);
                break;
            case 3:
                TS1.SetActive(true);
                //T1.transform.localPosition = new Vector3(-500, 240, 0);
                CP1.SetActive(true);
                CP1.transform.localPosition = new Vector3(-629, 262, 0f);
                CP1.transform.localScale = new Vector3(0.213123366f, 0.0813337192f, 1.01959085f);
                CP2.SetActive(true);
                CP2.transform.localPosition = new Vector3(-629, 156, 0f);
                CP2.transform.localScale = new Vector3(0.213123366f, 0.0813337192f, 1.01959085f);
                CP3.SetActive(true);
                CP3.transform.localPosition = new Vector3(-171, -4, 0f);             //Moved to team 2 to compensate for lack of space
                CP3.transform.localScale = new Vector3(0.213123366f, 0.0813337192f, 1.01959085f);
                CP4.SetActive(true);
                CP4.transform.localPosition = new Vector3(-629, -269, 0f);    //Moved to team 3 to compensate for lack of space
                CP4.transform.localScale = new Vector3(0.213123366f, 0.0813337192f, 1.01959085f);
                TS2.SetActive(true);
                TS3.SetActive(true);
                confirmWindow.SetActive(true);
                confirmWindow.transform.localPosition = new Vector3(24.3f, -2.5f, 0);


                break;
            case 4:
                T1.SetActive(true);
                CP1.SetActive(true);
                CP1.transform.localPosition = new Vector3(-676, 284, 0f);
                CP1.transform.localScale = new Vector3(0.189582199f, 0.0729505941f, 1.01959085f);
                T2.SetActive(true);
                CP2.SetActive(true);
                CP2.transform.localPosition = new Vector3(-676, 63, 0f);
                CP2.transform.localScale = new Vector3(0.189582199f, 0.0729505941f, 1.01959085f);
                T3.SetActive(true);
                CP3.SetActive(true);
                CP3.transform.localPosition = new Vector3(-676, -157, 0f);
                CP3.transform.localScale = new Vector3(0.189582199f, 0.0729505941f, 1.01959085f);
                T4.SetActive(true);
                CP4.SetActive(true);
                CP4.transform.localPosition = new Vector3(-676, -377, 0f);
                CP4.transform.localScale = new Vector3(0.189582199f, 0.0729505941f, 1.01959085f);
                confirmWindow.SetActive(true);
                confirmWindow.transform.localPosition = new Vector3(12.2f, -2.5f, 0);
                break;
        }
    }
}