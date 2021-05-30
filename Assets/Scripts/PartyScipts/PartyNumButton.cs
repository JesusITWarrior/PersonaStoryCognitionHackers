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
    public Button button;
    public GameObject T1,T2,T3,T4, CP1, CP2, CP3, CP4, confirmWindow;
    public AudioSource Select;
    public AudioSource Error;
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
        GameObject toHide;
        switch (num)
        {
            case 1:
                T1.SetActive(true);
                T1.transform.localPosition = new Vector3(0f,240f,0f);
                CP1.SetActive(true);
                CP1.transform.localPosition = new Vector3(0f, 354.6443f,0f);
                CP2.SetActive(true);
                CP2.transform.localPosition = new Vector3(0f, 237.7631f, 0f);
                CP3.SetActive(true);
                CP3.transform.localPosition = new Vector3(0f, 122.0004f, 0f);
                CP4.SetActive(true);
                CP4.transform.localPosition = new Vector3(0f,6.237671f,0f);
                confirmWindow.SetActive(true);
                break;
            case 2:
                T1.SetActive(true);
                T1.transform.localPosition = new Vector3(-250, 240, 0);
                CP1.SetActive(true);
                CP1.transform.localPosition = new Vector3(-250, 354.6443f, 0f);
                CP2.SetActive(true);
                CP2.transform.localPosition = new Vector3(-250, 237.7631f, 0f);
                CP3.SetActive(true);
                CP3.transform.localPosition = new Vector3(-250, 122.0004f, 0f);
                CP4.SetActive(true);
                CP4.transform.localPosition = new Vector3(250, 354.6443f, 0f);  //Moved to team 2 to compensate for lack of space
                T2.SetActive(true);
                T2.transform.localPosition = new Vector3(250,240,0);
                confirmWindow.SetActive(true);

                //Gets rid of 4th panel on all teams
                toHide = T1.transform.GetChild(3).gameObject;
                toHide.SetActive(false);
                toHide = T2.transform.GetChild(3).gameObject;
                toHide.SetActive(false);
                break;
            case 3:
                T1.SetActive(true);
                T1.transform.localPosition = new Vector3(-500, 240, 0);
                CP1.SetActive(true);
                CP1.transform.localPosition = new Vector3(-500, 354.6443f, 0f);
                CP2.SetActive(true);
                CP2.transform.localPosition = new Vector3(-500, 237.7631f, 0f);
                CP3.SetActive(true);
                CP3.transform.localPosition = new Vector3(-500, 122.0004f, 0f);
                CP4.SetActive(true);
                CP4.transform.localPosition = new Vector3(0, 354.6443f, 0f);    //Moved to team 2 to compensate for lack of space
                T2.SetActive(true);
                T2.transform.localPosition = new Vector3(0, 240, 0);
                T3.SetActive(true);
                T3.transform.localPosition = new Vector3(500,240,0);
                confirmWindow.SetActive(true);

                //Gets rid of 4th panel on all teams
                toHide = T1.transform.GetChild(3).gameObject;
                toHide.SetActive(false);
                toHide = T2.transform.GetChild(3).gameObject;
                toHide.SetActive(false);
                toHide = T3.transform.GetChild(3).gameObject;
                toHide.SetActive(false);
                break;
            case 4:
                //Sets each character panel into a slot in each team
                T1.SetActive(true);
                T1.transform.localPosition = new Vector3(-720, 240, 0);
                CP1.SetActive(true);
                CP1.transform.localPosition = new Vector3(-720, 354.6443f, 0f);
                T2.SetActive(true);
                T2.transform.localPosition = new Vector3(-240, 240, 0);
                CP2.SetActive(true);
                CP2.transform.localPosition = new Vector3(-240, 354.6443f, 0f);
                T3.SetActive(true);
                T3.transform.localPosition = new Vector3(240, 240, 0);
                CP3.SetActive(true);
                CP3.transform.localPosition = new Vector3(245, 354.6443f, 0f);
                T4.SetActive(true);
                T4.transform.localPosition = new Vector3(720,240,0);
                CP4.SetActive(true);
                CP4.transform.localPosition = new Vector3(720, 354.6443f, 0f);
                confirmWindow.SetActive(true);

                //Removes all the rest of the panels within and makes the team panel shorter
                for (int i = 1; i < 4; i++)
                {
                    toHide = T1.transform.GetChild(i).gameObject;
                    toHide.SetActive(false);
                    toHide = T2.transform.GetChild(i).gameObject;
                    toHide.SetActive(false);
                    toHide = T3.transform.GetChild(i).gameObject;
                    toHide.SetActive(false);
                    toHide = T4.transform.GetChild(i).gameObject;
                    toHide.SetActive(false);
                }
                break;
        }
    }
}
