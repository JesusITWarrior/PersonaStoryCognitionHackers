using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToPartySelect : MonoBehaviour
{
    public GameObject T1, T2, T3, T4, P1, P2, P3, P4, Window;
    public AudioSource Back;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Back.Play();
            T1.SetActive(false);
            T2.SetActive(false);
            T3.SetActive(false);
            T4.SetActive(false);
            P1.SetActive(false);
            P2.SetActive(false);
            P3.SetActive(false);
            P4.SetActive(false);
            Window.SetActive(true);
        }
    }
}
