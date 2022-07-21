using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemachineCombatHandler : MonoBehaviour
{
    //TODO: Set every p1Cam available as a variable, specify which camera in BattleSystem
    //TODO: Ensure 
    public CinemachineStateDrivenCamera camState;
    [SerializeField]
    private CinemachineVirtualCamera startCam;
    [SerializeField]
    private CinemachineTrackedDolly currentPos;
    public Animator animator;
    public Animator staticAnimator;
    private float speed, end, difference;

    private void Awake()
    {
        currentPos = startCam.GetCinemachineComponent<CinemachineTrackedDolly>();
        speed = 0; end = 0;
    }

    public void lookTarget(BattleState state, Transform target)        //Used to focus on a game object in the scene from certain camera
    {
        //CAM CODE: 1= default, 2= targetting cam, 3= Casting cam, 4= Attack cam, 5= Shooting cam
        switch (state)
        {
            case BattleState.START:
                animator.Play("Player 1");
                break;
            case BattleState.PLAYER1TURN:
                camState.LookAt = target;
                break;
            case BattleState.ENEMY1TURN:
                animator.Play("Player 1");
                break;
        }
        camState.LookAt = target;
    }

    public void lookTarget(int cam, Transform target)
    {
        Debug.Log("This will be used for miscellaneous cameras");
    }

    void Update()
    {
        difference = end - currentPos.m_PathPosition;
        if (difference >= 0.05f)
        {
            currentPos.m_PathPosition += speed * Time.deltaTime;
        }
        else
        {
            speed = 0; end = 0; difference = 0;
        }
    }

    public void moveDolly(float sp, float st, float stop)      //Moves camera along the track at a certain speed
    {
        currentPos.m_PathPosition = st;
        difference = stop - st;
        end = stop;
        speed = sp;    
    }

    public void swapCams(int cam1, int cam2, float path)
    {
        currentPos.m_PathPosition = path;
        switch (cam2)
        {
            case 1:
                switch (cam1)
                {
                    case 2:

                        break;
                }
                break;
        }
    }

    public void startPerlin(BattleState state)
    {
        switch (state)
        {
            case BattleState.PLAYER1TURN:
                camState.ChildCameras[0].GetComponent<CinemachineVirtualCamera>(). GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 1;
                break;
            case BattleState.PLAYER2TURN:
                camState.ChildCameras[4].GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 1;
                break;
            case BattleState.PLAYER3TURN:
                camState.ChildCameras[8].GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 1;
                break;
            case BattleState.PLAYER4TURN:
                camState.ChildCameras[12].GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 1;
                break;
        }
        
    }

    public void stopPerlin(BattleState state)
    {
        switch (state)
        {
            case BattleState.PLAYER1TURN:
                camState.ChildCameras[0].GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 0;
                break;
            case BattleState.PLAYER2TURN:
                camState.ChildCameras[4].GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 0;
                break;
            case BattleState.PLAYER3TURN:
                camState.ChildCameras[8].GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 0;
                break;
            case BattleState.PLAYER4TURN:
                camState.ChildCameras[12].GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 0;
                break;
        }
    }
}
