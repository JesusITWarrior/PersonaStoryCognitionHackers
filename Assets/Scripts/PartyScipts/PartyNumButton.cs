using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartyNumButton : MonoBehaviour
{
    public GameObject window;
    public InputField Num;
    public Party partyRef;
    public Button button;
    public GameObject T1,T2,T3,T4;
    public void onClick()
    {
        int partiesNum = int.Parse(Num.GetComponent<InputField>().text);
        if (partiesNum > 0 && partiesNum < 5)
        {
            partyRef.createParties(partiesNum);     //TODO move this into after the parties have been completely created
            displayPanels(partiesNum);
            window.SetActive(false);
        }
        else{
            Debug.Log("Invalid number");
        }
    }

    public void displayPanels(int num)
    {
        switch (num)
        {
            case 1:
                T1.SetActive(true);
                T1.transform.localPosition = new Vector3(0,240,0);
                break;
            case 2:
                T1.SetActive(true);
                T1.transform.localPosition = new Vector3(-250, 240, 0);
                T2.SetActive(true);
                T2.transform.localPosition = new Vector3(250,240,0);
                break;
            case 3:
                T1.SetActive(true);
                T1.transform.localPosition = new Vector3(-500, 240, 0);
                T2.SetActive(true);
                T2.transform.localPosition = new Vector3(0, 240, 0);
                T3.SetActive(true);
                T3.transform.localPosition = new Vector3(500,240,0);
                break;
            case 4:
                T1.SetActive(true);
                T1.transform.localPosition = new Vector3(-720, 240, 0);
                T2.SetActive(true);
                T2.transform.localPosition = new Vector3(-240, 240, 0);
                T3.SetActive(true);
                T3.transform.localPosition = new Vector3(240, 240, 0);
                T4.SetActive(true);
                T4.transform.localPosition = new Vector3(720,240,0);
                break;
        }
    }
}
