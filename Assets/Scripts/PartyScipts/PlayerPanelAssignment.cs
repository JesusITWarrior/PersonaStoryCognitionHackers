using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPanelAssignment : MonoBehaviour
{
    public GameObject C1, C2, C3, C4;
    public Party party;

    void Start()
    {
        party = GameObject.Find("Party").GetComponent<Party>();
        First();
        
    }

    void First()
    {
        GameObject pfp, HP, SP, HPText, SPText, name;
        pfp = C1.transform.GetChild(0).gameObject;
        HP = C1.transform.GetChild(2).gameObject;
        SP = C1.transform.GetChild(4).gameObject;
        HPText = C1.transform.GetChild(5).gameObject;
        SPText = C1.transform.GetChild(6).gameObject;
        name = C1.transform.GetChild(7).gameObject;
        //pfp = 
        //HPText.GetComponent<Text>().text = party.parties[1][0].healthText.text;
        //HP.GetComponent<Image>().fillAmount = party.parties[1][0].getHealth() / party.parties[1][0].getMaxHealth();
        //SPText.GetComponent<Text>().text = party.parties[1][0].spiritText.text;
        //SP.GetComponent<Image>().fillAmount = party.parties[1][0].getSP() / party.parties[1][0].getMaxSP();
        name.GetComponent<Text>().text = party.parties[1][0].name;
        
    }

    void Second()
    {
        GameObject pfp, HP, SP, HPText, SPText, name;
        pfp = C2.transform.GetChild(0).gameObject;
        HP = C2.transform.GetChild(2).gameObject;
        SP = C2.transform.GetChild(4).gameObject;
        HPText = C2.transform.GetChild(5).gameObject;
        SPText = C2.transform.GetChild(6).gameObject;
        name = C2.transform.GetChild(7).gameObject;
    }

    void Third()
    {
        GameObject pfp, HP, SP, HPText, SPText, name;
        pfp = C3.transform.GetChild(0).gameObject;
        HP = C3.transform.GetChild(2).gameObject;
        SP = C3.transform.GetChild(4).gameObject;
        HPText = C3.transform.GetChild(5).gameObject;
        SPText = C3.transform.GetChild(6).gameObject;
        name = C3.transform.GetChild(7).gameObject;
    }

    void Fourth()
    {
        GameObject pfp, HP, SP, HPText, SPText, name;
        pfp = C4.transform.GetChild(0).gameObject;
        HP = C4.transform.GetChild(2).gameObject;
        SP = C4.transform.GetChild(4).gameObject;
        HPText = C4.transform.GetChild(5).gameObject;
        SPText = C4.transform.GetChild(6).gameObject;
        name = C4.transform.GetChild(7).gameObject;
    }
}
