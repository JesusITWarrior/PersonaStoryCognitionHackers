using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCombatController : MonoBehaviour
{

    //TODO: Set players to look at enemy that is attacking them


    Animator animator;
    private float playerSpeed = 5;
    private CharacterController controller;
    [SerializeField]
    private PlayerControls controls;
    [SerializeField]
    private InputActionReference menuControl;
    private float idleTimer = 0;
    private Vector3 move;

    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponentInChildren<Animator>();
    }

    private void OnEnable()
    {
        menuControl.action.Enable();
    }

    private void OnDisable()
    {
        menuControl.action.Disable();
    }

    private void Update()
    {
        Vector2 nav = menuControl.action.ReadValue<Vector2>();

        //TODO: Add arrow and controller navigation here

        if (move != Vector3.zero)
        {
            animator.SetBool("isMoving", true);
            idleTimer = 0;
        }
        else
        {
            animator.SetBool("isMoving", false);
            idleTimer += Time.deltaTime;
            if (idleTimer >= 30)
            {
                System.Random rnd = new System.Random();
                int IdlePicker = rnd.Next(1, 3);
                switch (IdlePicker)
                {
                    case 1:
                        animator.SetTrigger("Stretch");
                        break;
                    case 2:
                        Debug.Log("Secondary Idle Animation");
                        break;
                }
                idleTimer = 0;
            }
        }
    }
    public void LookBattleTurn(int faceEnemies)
    {
        switch (faceEnemies)
        {
            case 1: //Leader
                this.transform.rotation = Quaternion.identity;
                this.transform.rotation = Quaternion.Euler(0, 0, 0);
                break;
            case 2: //secondary
                this.transform.rotation = Quaternion.identity;
                this.transform.rotation = Quaternion.Euler(0, -90, 0);
                //this.transform.Rotate(0, -90, 0);// = Quaternion.Euler(0,-90,0);
                break;
            case 3: //tertiary
                this.transform.rotation = Quaternion.identity;
                this.transform.rotation = Quaternion.Euler(0, 180, 0);
                break;
            case 4: //fourth player
                this.transform.rotation = Quaternion.identity;
                this.transform.rotation = Quaternion.Euler(0, 90, 0);
                break;
        }
    }

    public void LookAmbushTurn(int faceEnemies) { 
        switch (faceEnemies)
        {
            case 1: //Leader
                this.transform.rotation = Quaternion.identity;
                this.transform.rotation = Quaternion.Euler(0, 0, 0);
                break;
            case 2: //secondary
                this.transform.rotation = Quaternion.identity;
                this.transform.rotation = Quaternion.Euler(0, -90, 0);
                //this.transform.Rotate(0, -90, 0);// = Quaternion.Euler(0,-90,0);
                break;
            case 3: //tertiary
                this.transform.rotation = Quaternion.identity;
                this.transform.rotation = Quaternion.Euler(0, 180, 0);
                break;
            case 4: //fourth player
                this.transform.rotation = Quaternion.identity;
                this.transform.rotation = Quaternion.Euler(0, 90, 0);
                break;
        }
    }

    public void LookAttacked(int faceEnemies)
    {
        switch (faceEnemies)
        {
            case 1: //1st enemy
                this.transform.rotation = Quaternion.identity;
                this.transform.rotation = Quaternion.Euler(0, 0, 0);
                break;
            case 2: //2nd enemy
                this.transform.rotation = Quaternion.identity;
                this.transform.rotation = Quaternion.Euler(0, -90, 0);
                //this.transform.Rotate(0, -90, 0);// = Quaternion.Euler(0,-90,0);
                break;
            case 3: //3rd enemy
                this.transform.rotation = Quaternion.identity;
                this.transform.rotation = Quaternion.Euler(0, 180, 0);
                break;
            case 4: //4th enemy
                this.transform.rotation = Quaternion.identity;
                this.transform.rotation = Quaternion.Euler(0, 90, 0);
                break;
        }
    }
}
