using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPanelAssignment : MonoBehaviour
{
    public GameObject C1, C2, C3, C4;
    public Party party;

    int pa = 1, pl = 0;

    void Start()
    {
        party = GameObject.Find("Party").GetComponent<Party>();
        //party.resetParty();
        getInfoPanel(C1);
        getInfoPanel(C2);
        getInfoPanel(C3);
        getInfoPanel(C4);
    }

    void getInfoPanel(GameObject Panel)
    {
        GameObject pfp, HP, SP, HPText, SPText, name;
        pfp = Panel.transform.GetChild(0).gameObject;
        HP = Panel.transform.GetChild(2).gameObject;
        SP = Panel.transform.GetChild(4).gameObject;
        HPText = Panel.transform.GetChild(5).gameObject;
        SPText = Panel.transform.GetChild(6).gameObject;
        name = Panel.transform.GetChild(7).gameObject;
        //pfp = 

        getNextPlayer();

        HPText.GetComponent<Text>().text = party.parties[pa][pl].GetComponent<Player>().getHealth().ToString();
        HP.GetComponent<Image>().fillAmount = party.parties[pa][pl].GetComponent<Player>().getHealth() / party.parties[pa][pl].GetComponent<Player>().getMaxHealth();
        SPText.GetComponent<Text>().text = party.parties[pa][pl].GetComponent<Player>().getSP().ToString();
        SP.GetComponent<Image>().fillAmount = party.parties[pa][pl].GetComponent<Player>().getSP() / party.parties[pa][pl].GetComponent<Player>().getMaxSP();
        name.GetComponent<Text>().text = party.parties[pa][pl].name;
        pl++;
    }

    void getNextPlayer()
    {
        if (pl == party.parties[pa].Count)
        {
            pa++;
            pl = 0;
        }
    }
}
