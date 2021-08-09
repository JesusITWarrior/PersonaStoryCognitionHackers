using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemachineCombatHandler : MonoBehaviour
{
    //TODO: Set every vcam available as a variable, specify which camera in BattleSystem
    [SerializeField]
    private CinemachineVirtualCamera vcam;
    [SerializeField]
    private CinemachineSmoothPath track;
    [SerializeField]
    private CinemachineTrackedDolly currentPos;
    private float speed, start, end, difference;

    private Vector3 p1Angle, p2Angle, p3Angle, p4Angle;

    private void Awake()
    {
        currentPos = vcam.GetCinemachineComponent<CinemachineTrackedDolly>();
        speed = 0; start = 0; end = 0;
    }

    public void lookTarget(Transform target)        //Used to focus on a game object in the scene
    {
        vcam.LookAt = target;
    }

    public void cancelLook()        //
    {
        vcam.LookAt = null;
    }

    void Update()
    {
        difference = end - currentPos.m_PathPosition;
        if (difference >= 0.005f)
        {
            currentPos.m_PathPosition += speed * Time.deltaTime;
        }
        else
        {
            speed = 0; start = 0; end = 0; difference = 0;
        }
    }

    public void cancelLook(int playerNum, Vector3 angle)       //Saves the current rotation and look for a player's turn
    {
        switch (playerNum)
        {
            case 1:
                p1Angle = angle;
                break;
            case 2:
                p2Angle = angle;
                break;
            case 3:
                p3Angle = angle;
                break;
            case 4:
                p4Angle = angle;
                break;
        }
    }

    public void moveDolly(float sp, float st, float stop)      //Moves camera along the track at a certain speed
    {
        currentPos.m_PathPosition = st;
        difference = stop - st;
        end = stop;
        speed = sp;    
    }
}
