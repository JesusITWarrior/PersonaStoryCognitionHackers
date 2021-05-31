using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToPartySelect : MonoBehaviour
{
    public GameObject Main, TL1, TL2, TS1, TS2, TS3, T1, T2, T3, T4, P1, P2, P3, P4, TeamNumWindow, ConfirmationWindow;
    public AudioSource Back;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            close();
        }
    }

    public void close()
    {
        Back.Play();
        Main.SetActive(false);
        TL1.SetActive(false);
        TL2.SetActive(false);
        TS1.SetActive(false);
        TS2.SetActive(false);
        TS3.SetActive(false);
        T1.SetActive(false);
        T2.SetActive(false);
        T3.SetActive(false);
        T4.SetActive(false);
        P1.SetActive(false);
        P2.SetActive(false);
        P3.SetActive(false);
        P4.SetActive(false);
        ConfirmationWindow.SetActive(false);
        TeamNumWindow.SetActive(true);
    }
}
