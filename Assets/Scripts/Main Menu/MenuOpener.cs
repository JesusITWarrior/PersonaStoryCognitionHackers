using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuOpener : MonoBehaviour
{
    public GameObject MainMenu;
    public AudioSource BGMusic;
    public void startMenu()
    {
        Invoke("beginMusic", 2f);
    }

    void beginMusic()
    {
        BGMusic.Play();
    }
}
