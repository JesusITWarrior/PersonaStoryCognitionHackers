using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreeSecondDelay : MonoBehaviour
{

	// Use this for initialization
	void Start()
	{
		AudioSource BGMusic = GetComponent<AudioSource>();
		BGMusic.PlayDelayed(1);
	}
}
