using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Looper : MonoBehaviour
{
    public AudioSource sourceLoop;
    public AudioClip intro;
    private void Start()
    {
        if (intro) {
            sourceLoop.PlayOneShot(intro);
            sourceLoop.PlayScheduled(AudioSettings.dspTime + intro.length);
        }
        else
        {
            sourceLoop.Play();
        }
        sourceLoop.loop = true;
    }
}
