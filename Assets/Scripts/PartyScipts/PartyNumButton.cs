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
    public Canvas canvas;
    public InputField Num;
    public Party partyRef;
    public Button button;
    public GameObject Panel, Text, Slot, CP1, CP2, CP3, CP4, confirmWindow;
    public AudioSource Select;
    public AudioSource Error;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            onClick();
        }
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
        } else if (partiesNum == 4)
        {
            Select.Play();
            //partyRef.createParties(partiesNum);
            displayPanels(partiesNum);
            window.SetActive(false);
        }
        else{
            Debug.Log("Invalid number");
            Error.Play();
        }
    }

    public void displayPanels(int num)
    {
        
        switch (num)
        {
            case 1:
                {
                    GameObject TeamPanel = Instantiate(Panel);
                    TeamPanel.transform.parent = canvas.transform;
                    TeamPanel.transform.GetComponent<RectTransform>().anchorMin = new Vector2(.5f, 1);
                    TeamPanel.transform.GetComponent<RectTransform>().anchorMax = new Vector2(.5f, 1);
                    TeamPanel.transform.localPosition = new Vector3(0,0,0);
                    GameObject TeamName = Instantiate(Text);
                    TeamName.GetComponent<Text>().text = "Team 1";
                    TeamName.transform.parent = TeamPanel.transform;
                    GameObject Leader = Instantiate(Slot), P2 = Instantiate(Slot), P3 = Instantiate(Slot), P4 = Instantiate(Slot);
                    Leader.transform.parent = TeamPanel.transform;
                    P2.transform.parent = TeamPanel.transform;
                    P3.transform.parent = TeamPanel.transform;
                    P4.transform.parent = TeamPanel.transform;


                    //Main.SetActive(true);
                    CP1.SetActive(true);
                    CP2.SetActive(true);
                    CP3.SetActive(true);
                    CP4.SetActive(true);
                    confirmWindow.SetActive(true);
                    break;
                }
            case 2:
                //TL1.SetActive(true);
                //TL1.transform.localPosition = new Vector3(-105, 122.5f, 0);
                //CP1.SetActive(true);
                //CP1.transform.localPosition = new Vector3(-105, 148, 0f);
                //CP2.SetActive(true);
                //CP2.transform.localPosition = new Vector3(-105, 98.6f, 0f);
                //CP3.SetActive(true);
                //CP3.transform.localPosition = new Vector3(-105, 50, 0f);
                //CP4.SetActive(true);
                //CP4.transform.localPosition = new Vector3(105, 148, 0f);  //Moved to team 2 to compensate for lack of space
                //TL2.SetActive(true);
                //TL2.transform.localPosition = new Vector3(105,122.5f,0);
                //confirmWindow.SetActive(true);
                break;
            case 3:
                //TS1.SetActive(true);
                //TS1.transform.localPosition = new Vector3(-275, 150, 0);
                //CP1.SetActive(true);
                //CP1.transform.localPosition = new Vector3(-275, 148, 0f);
                //CP2.SetActive(true);
                //CP2.transform.localPosition = new Vector3(-275, 99, 0f);
                //CP3.SetActive(true);
                //CP3.transform.localPosition = new Vector3(0, 148, 0f);      //Moved to team 2 to compensate for lack of space
                //CP4.SetActive(true);
                //CP4.transform.localPosition = new Vector3(275, 148, 0f);    //Moved to team 3 to compensate for lack of space
                //TS2.SetActive(true);
                //TS2.transform.localPosition = new Vector3(0, 150, 0);
                //TS3.SetActive(true);
                //TS3.transform.localPosition = new Vector3(275,150,0);
                //confirmWindow.SetActive(true);

                break;
            case 4:
                //Sets each character panel into a slot in each team
                //T1.SetActive(true);
                //T1.transform.localPosition = new Vector3(-300, 171, 0);
                //CP1.SetActive(true);
                //CP1.transform.localPosition = new Vector3(-720, 354.6443f, 0f);
                //T2.SetActive(true);
                //T2.transform.localPosition = new Vector3(-100, 171, 0);
                //CP2.SetActive(true);
                //CP2.transform.localPosition = new Vector3(-240, 354.6443f, 0f);
                //T3.SetActive(true);
                //T3.transform.localPosition = new Vector3(100, 171, 0);
                //CP3.SetActive(true);
                //CP3.transform.localPosition = new Vector3(245, 354.6443f, 0f);
                //T4.SetActive(true);
                //T4.transform.localPosition = new Vector3(300, 171,0);
                //CP4.SetActive(true);
                //CP4.transform.localPosition = new Vector3(720, 354.6443f, 0f);
                //confirmWindow.SetActive(true);
                break;
        }
    }
}
