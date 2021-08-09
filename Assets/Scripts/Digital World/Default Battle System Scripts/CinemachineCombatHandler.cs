using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemachineCombatHandler : MonoBehaviour
{
    //TODO: Set every p1Cam available as a variable, specify which camera in BattleSystem
    [SerializeField]
    private CinemachineVirtualCamera p1Cam;
    [SerializeField]
    private CinemachineSmoothPath track;
    [SerializeField]
    private CinemachineTrackedDolly currentPos;
    private float speed, start, end, difference;

    private Vector3 p1Angle, p2Angle, p3Angle, p4Angle;

    private void Awake()
    {
        currentPos = p1Cam.GetCinemachineComponent<CinemachineTrackedDolly>();
        speed = 0; start = 0; end = 0;
    }

    public void lookTarget(int cam, Transform target)        //Used to focus on a game object in the scene
    {
        switch (cam) {
            case 1:
                p1Cam.LookAt = target;
                break;
        }
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
}
