using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class IntroTyper : MonoBehaviour
{
    [Header("Sounds")]
    public AudioSource typeBroadcast;
    [SerializeField]
    private AudioClip[] keyTypeSounds;
    [SerializeField]
    private MenuOpener menuStart;
    public AudioSource Ambience;
    [Header("Text Variables")]
    [SerializeField]
    private Text[] stages;
    private string phrase = "";
    private int ph;
    private float timing = 0;

    public void loginStart()
    {
        clearScreen();
        Invoke("startTyping", 1.3f);
    }

    private void startTyping()
    {
        phrase = "Login required:";
        foreach(char a in phrase)
        {
            StartCoroutine(printToScreen(a));
            timing += 0.01f;
        }
        timing += 0.1f;
        Invoke("shiftUp", timing);

        phrase = "Username: ";
        foreach(char a in phrase)
        {
            StartCoroutine(printToScreen(a));
            timing += 0.01f;
        }
        timing += 1f;

        phrase = "PlaceHolderUsername";
        foreach (char a in phrase)
        {
            StartCoroutine(typeSound(a));
            timing += 0.1f;
        }
        timing += 0.5f;
        StartCoroutine(typeSound(' '));
        timing += 0.3f;
        Invoke("shiftUp", timing);

        phrase = "Password: ";
        foreach(char a in phrase)
        {
            StartCoroutine(printToScreen(a));
            timing += 0.01f;
        }
        timing += 1f;

        phrase = "        ";
        foreach(char a in phrase)
        {
            StartCoroutine(typeSound(a));
            timing += 0.1f;
        }
        timing += 2f;
        Invoke("shiftUp", timing);

        phrase = "Success. Welcome, [REDACTED]";
        foreach(char a in phrase)
        {
            StartCoroutine(printToScreen(a));
            timing += 0.01f;
        }
        timing += 2f;
        Invoke("clearScreen", timing);

        phrase = "C:/ ";
        foreach(char a in phrase)
        {
            StartCoroutine(printToScreen(a));
        }

        timing += 2f;

        phrase = "cd";
        foreach(char a in phrase)
        {
            StartCoroutine(typeSound(a));
            timing += 0.1f;
        }
        timing += 0.3f;
        StartCoroutine(typeSound(' '));
        phrase = Application.dataPath;
        foreach (char a in phrase)
            StartCoroutine(printToScreen(a));
        timing += 0.3f;
        StartCoroutine(typeSound(' '));
        
        timing += 0.1f;
        StartCoroutine(typeSound(' '));
        Invoke("shiftUp", timing);

        phrase = Application.dataPath+" ";
        foreach(char a in phrase)
        {
            StartCoroutine(printToScreen(a));
        }
        timing += 1f;

        phrase = "start PSCH.exe";
        foreach(char a in phrase)
        {
            StartCoroutine(typeSound(a));
            timing += 0.1f;
        }
        timing += 1.5f;
        StartCoroutine(typeSound(' '));
        timing += 0.1f;
        Invoke("clearScreen", timing);
        Invoke("quiet", timing);
    }

    private void shiftUp()
    {
        for (int i = stages.Length-1; i > 0; i--)
        {
            stages[i].text = stages[i-1].text;
        }
        stages[0].text = "";
    }

    IEnumerator printToScreen(char placeholder)
    {
        yield return new WaitForSeconds(timing);
        stages[0].text = stages[0].text + placeholder;
    }

    IEnumerator typeSound(char placeholder)
    {
        yield return new WaitForSeconds(timing);
        int rnd = UnityEngine.Random.Range(0, 3);
        typeBroadcast.PlayOneShot(keyTypeSounds[rnd]);
        stages[0].text = stages[0].text + placeholder;
    }

    private void clearScreen()
    {
        for (int i = 0; i < stages.Length; i++)
        {
            stages[i].text = "";
        }
    }

    void quiet()
    {
        Destroy(Ambience.gameObject);
        Destroy(GameObject.Find("Bootup Canvas"));
        GameObject.Find("Backdrop").transform.SetParent(GameObject.Find("Start Menu").transform);
        GameObject.Find("Backdrop").transform.SetSiblingIndex(0);
        menuStart.startMenu();
        Destroy(this.gameObject);
    }
}
