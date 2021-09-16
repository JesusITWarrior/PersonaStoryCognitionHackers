using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCombatController : MonoBehaviour
{

    //TODO: Set players to look at enemy that is attacking them


    public Animator animator;
    public float playerSpeed = 3;
    public bool isTurn = false, isAttacking = false;
    private CharacterController controller;
    [SerializeField]
    private PlayerControls controls;
    [SerializeField]
    private InputActionReference menuControl;
    public InputActionReference back, click;
    private float idleTimer = 0, rotateSpeed = 5;
    [SerializeField]
    public Vector3 move, targetPos;

    // Start is called before the first frame update
    void Start()
    {
        controller = this.GetComponent<CharacterController>();
        animator = this.GetComponentInChildren<Animator>();
        move = Vector3.zero;
    }

    private void OnEnable()
    {
        menuControl.action.Enable();
        back.action.Enable();
        click.action.Enable();
    }

    private void OnDisable()
    {
        menuControl.action.Disable();
        back.action.Disable();
        click.action.Disable();
    }

    public void LateUpdate()
    {
        Vector2 nav = menuControl.action.ReadValue<Vector2>();
        //TODO: Lock the action to whoever's turn it is
        if (isTurn)
        {

        }

        move = targetPos - this.transform.position;         //This is the offset between the gameObject and the target coordinate that will be listed in goTo()
        //TODO: Add arrow and controller navigation here
        if(!isAttacking)
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(move), rotateSpeed * Time.deltaTime);
        
        if (move.magnitude >= 0.2f && targetPos != Vector3.zero)
        {
            animator.SetBool("isMoving", true);
            idleTimer = 0;
            move = move.normalized * playerSpeed;
            controller.Move(move * Time.deltaTime);
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
                targetPos = Vector3.zero;
        }
    }
    public void LookBattleTurn(int faceEnemies, bool isDisadvantage)
    {
        if (!isDisadvantage)
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
        else {
            switch (faceEnemies)
            {
                case 1: //Leader
                    this.transform.rotation = Quaternion.identity;
                    this.transform.rotation = Quaternion.Euler(0, 180, 0);
                    break;
                case 2: //secondary
                    this.transform.rotation = Quaternion.identity;
                    this.transform.rotation = Quaternion.Euler(0, 90, 0);
                    //this.transform.Rotate(0, -90, 0);// = Quaternion.Euler(0,-90,0);
                    break;
                case 3: //tertiary
                    this.transform.rotation = Quaternion.identity;
                    this.transform.rotation = Quaternion.Euler(0, 0, 0);
                    break;
                case 4: //fourth player
                    this.transform.rotation = Quaternion.identity;
                    this.transform.rotation = Quaternion.Euler(0, -90, 0);
                    break;
            }
        }
    }

    public void goTo(int playerNum, int enemyNum)       //Used to move player to enemy position for attack. Does not accommodate for advantage....yet
    {   
        switch (playerNum)
            {
                case 1:
                    switch (enemyNum)
                    {
                        case 1:
                            targetPos = new Vector3(-0.430000007f, 0, -4.6500001f);
                            break;
                        case 2:
                            targetPos = new Vector3(-1.95700002f, 0, -1.63f);
                            break;
                        case 3:
                            targetPos = new Vector3(1.59000003f, 0, -3.3499999f);
                            break;
                        case 4:
                            targetPos = new Vector3(0.409999996f, 0, -0.298000008f);
                            break;
                        default:
                            targetPos = new Vector3(0.22f, 0, -11.10f);
                            break;
                    }
                    break;
                case 2:
                    switch (enemyNum)
                    {
                        case 1:
                            targetPos = new Vector3(0.654999971f, 0, -3.23900008f);
                            break;
                        case 2:
                            targetPos = new Vector3(-0.810000002f, 0, -0.405000001f);
                            break;
                        case 3:
                            targetPos = new Vector3(2.8900001f, 0, -1.96599996f);
                            break;
                        case 4:
                            targetPos = new Vector3(1.43099999f, 0, 0.801999986f);
                            break;
                        default:
                            targetPos = new Vector3(8.52f, 0, -1.32f);
                            break;
                    }
                    break;
                case 3:
                    switch (enemyNum)
                    {
                        case 1:
                            targetPos = new Vector3(-0.563000023f, 0, -2.33200002f);
                            break;
                        case 2:
                            targetPos = new Vector3(-1.94799995f, 0, 0.483999997f);
                            break;
                        case 3:
                            targetPos = new Vector3(1.80999994f, 0, -0.819999993f);
                            break;
                        case 4:
                            targetPos = new Vector3(0.209999993f, 0, 1.78999996f);
                            break;
                        default:
                            targetPos = new Vector3(-0.74f, 0, 7.29f);
                            break;
                    }
                    break;
                case 4:
                    switch (enemyNum)
                    {
                        case 1:
                            targetPos = new Vector3(-1.54999995f, 0, -3.40799999f);
                            break;
                        case 2:
                            targetPos = new Vector3(-2.88700008f, 0, -0.550000012f);
                            break;
                        case 3:
                            targetPos = new Vector3(0.620000005f, 0, -2.00900006f);
                            break;
                        case 4:
                            targetPos = new Vector3(-0.504999995f, 0, 0.765999973f);
                            break;
                        default:
                            targetPos = new Vector3(-8.28f, 0, -1.78f);
                            break;
                    }
                    break;
            }
    }

    public void returnToSpawn(int playerNum, bool isDisadvantage)            //Used to move player back to their spawn. Used for beginning of battle and after an attack
    {
        if (!isDisadvantage)
        {
            switch (playerNum)
            {
                case 1:
                    targetPos = new Vector3(0.22f, 0, -7.122f);
                    break;
                case 2:
                    targetPos = new Vector3(5.962f, 0, -1.318f);
                    break;
                case 3:
                    targetPos = new Vector3(-0.74f, 0, 4.58f);
                    break;
                case 4:
                    targetPos = new Vector3(-6.05f, 0, -1.78f);
                    break;
            }
        }
        else
        {
            switch (playerNum)
            {
                case 1:

                    break;
                case 2:

                    break;
                case 3:

                    break;
                case 4:

                    break;
            }
        }
    }
}
