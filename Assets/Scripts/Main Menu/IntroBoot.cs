using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class IntroBoot : MonoBehaviour
{
    [SerializeField] private IntroTyper nextStage;
    [Header("Text Variables")]
    [SerializeField] private Text[] stages;
    private string phrase = "";
    private int ph;
    private float timing = 0.08f;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < stages.Length; i++)
        {
            stages[i].text = "";
        }
        Invoke("startTyping", 3f);
    }

    void startTyping()
    {
        phrase = "Initializing";
        foreach(char a in phrase){
            ph = 0;
            StartCoroutine(printToScreen(a, ph));
            timing += 0.01f;
        }
        phrase = "...";
        foreach (char a in phrase)
        {
            ph = 0;
            StartCoroutine(printToScreen(a, ph));
            timing += 0.5f;
        }

        phrase = "Device: " + SystemInfo.deviceName+" - "+SystemInfo.operatingSystem;
        foreach (char a in phrase)
        {
            ph = 1;
            StartCoroutine(printToScreen(a, ph));
            timing += 0.01f;
        }

        phrase = "BIOS Date " + System.DateTime.Now + " Ver: 0.0.1";
        foreach (char a in phrase)
        {
            ph = 2;
            StartCoroutine(printToScreen(a, ph));
            timing += 0.01f;
        }
        
        phrase = "CPU: " + SystemInfo.processorType;
        foreach (char a in phrase)
        {
            ph = 3;
            StartCoroutine(printToScreen(a, ph));
            timing += 0.01f;
        }
        
        phrase = "Speed: " + SystemInfo.processorFrequency + " MHz";
        foreach (char a in phrase)
        {
            ph = 4;
            StartCoroutine(printToScreen(a, ph));
            timing += 0.01f;
        }

        phrase = "CPU functionality nominal...";
        foreach (char a in phrase)
        {
            ph = 5;
            StartCoroutine(printToScreen(a, ph));
            timing += 0.01f;
        }
        
        timing += 2f;

        phrase = "GPU: " + SystemInfo.graphicsDeviceName;
        foreach (char a in phrase)
        {
            ph = 6;
            StartCoroutine(printToScreen(a, ph));
            timing += 0.01f;
        }

        phrase = "GPU Memory: " + SystemInfo.graphicsMemorySize+" MB";
        foreach (char a in phrase)
        {
            ph = 7;
            StartCoroutine(printToScreen(a, ph));
            timing += 0.01f;
        }

        phrase = "GPU functionality nominal...";
        foreach(char a in phrase)
        {
            ph = 8;
            StartCoroutine(printToScreen(a, ph));
            timing += 0.01f;
        }
        timing += 0.5f;

        phrase = "Booting";
        foreach (char a in phrase)
        {
            ph = 9;
            StartCoroutine(printToScreen(a, ph));
            timing += 0.01f;
        }
        phrase = "...";
        foreach (char a in phrase)
        {
            ph = 9;
            StartCoroutine(printToScreen(a, ph));
            timing += 0.5f;
        }


        timing += 2f;
        Invoke("login", timing);
    }

    IEnumerator printToScreen(char placeholder, int index)
    {
        yield return new WaitForSeconds(timing);
        stages[index].text = stages[index].text + placeholder;
    }

    void login()
    {
        nextStage.gameObject.SetActive(true);
        nextStage.loginStart();
        GameObject.Find("Icon").transform.SetParent(GameObject.Find("Bootup Canvas 2").transform);
        GameObject.Find("Backdrop").transform.SetParent(GameObject.Find("Bootup Canvas 2").transform);
        GameObject.Find("Backdrop").transform.SetSiblingIndex(0);
        this.gameObject.SetActive(false);
    }

    
}
