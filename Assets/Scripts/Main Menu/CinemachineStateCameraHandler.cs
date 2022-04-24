using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemachineStateCameraHandler : MonoBehaviour
{
    public CinemachineStateDrivenCamera camState;
    [SerializeField] private Animator camAnim;
    // Start is called before the first frame update
    void Start()
    {
        camAnim = camState.gameObject.GetComponent<Animator>();
        camAnim.Play("Boot/Start");
    }

    public void toMainMenu()
    {
        camAnim.Play("MainMenu");
    }
}
