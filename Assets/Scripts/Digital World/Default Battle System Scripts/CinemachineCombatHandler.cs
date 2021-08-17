using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemachineCombatHandler : MonoBehaviour
{
    //TODO: Set every p1Cam available as a variable, specify which camera in BattleSystem
    //TODO: Ensure 
    [SerializeField]
    private CinemachineVirtualCamera p1Cam, p1Target, p1Cast, p1Attack, p1Shoot;
    [SerializeField]
    private CinemachineVirtualCamera p2Cam, p2Target, p2Cast, p2Attack, p2Shoot;
    [SerializeField]
    private CinemachineVirtualCamera p3Cam, p3Target, p3Cast, p3Attack, p3Shoot;
    [SerializeField]
    private CinemachineVirtualCamera p4Cam, p4Target, p4Cast, p4Attack, p4Shoot;
    [SerializeField]
    private CinemachineTrackedDolly currentPos;
    public Animator animator;
    private float speed, end, difference;

    private void Awake()
    {
        currentPos = p1Cam.GetCinemachineComponent<CinemachineTrackedDolly>();
        speed = 0; end = 0;
    }

    public void lookTarget(BattleState state, int cam, Transform target)        //Used to focus on a game object in the scene from certain camera
    {
        //CAM CODE: 1= default, 2= targetting cam, 3= Casting cam, 4= Attack cam, 5= Shooting cam
        CinemachineVirtualCamera cinema = null;
        switch (state) {
            case BattleState.START:
                cinema = p1Cam;
                animator.Play("Player 1");
                break;
            case BattleState.PLAYER1TURN:
                switch (cam)
                {
                    case 1:
                        cinema = p1Cam;
                        animator.Play("Player 1");
                        break;
                    case 2:
                        cinema = p1Target;
                        animator.Play("Player 1 Select");
                        break;
                    case 3:
                        cinema = p1Cast;
                        animator.Play("Player 1 Cast");
                        break;
                    case 4:
                        cinema = p1Attack;
                        animator.Play("Player 1 Attack");
                        break;
                    case 5:
                        cinema = p1Shoot;
                        animator.Play("Player 1 Shooting");
                        break;
                }
                break;
            case BattleState.PLAYER2TURN:
                switch (cam)
                {
                    case 1:
                        cinema = p2Cam;
                        break;
                    case 2:
                        cinema = p2Target;
                        break;
                    case 3:
                        cinema = p2Cast;
                        break;
                    case 4:
                        cinema = p2Attack;
                        break;
                    case 5:
                        cinema = p2Shoot;
                        break;
                }
                break;
            case BattleState.PLAYER3TURN:
                switch (cam)
                {
                    case 1:
                        cinema = p3Cam;
                        break;
                    case 2:
                        cinema = p3Target;
                        break;
                    case 3:
                        cinema = p3Cast;
                        break;
                    case 4:
                        cinema = p3Attack;
                        break;
                    case 5:
                        cinema = p3Shoot;
                        break;
                }
                break;
            case BattleState.PLAYER4TURN:
                switch (cam)
                {
                    case 1:
                        cinema = p4Cam;
                        break;
                    case 2:
                        cinema = p4Target;
                        break;
                    case 3:
                        cinema = p4Cast;
                        break;
                    case 4:
                        cinema = p4Attack;
                        break;
                    case 5:
                        cinema = p4Shoot;
                        break;
                }
                break;
        }
        cinema.LookAt = target;
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

    /*public void startPerlin()
    {
        p1Cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_NoiseProfile = "Handheld_normal_mild";
    }

    public void stopPerlin()
    {

    }*/
}
