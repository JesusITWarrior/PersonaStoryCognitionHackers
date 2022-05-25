using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCombatController : MonoBehaviour
{

    //TODO: Set players to look at enemy that is attacking them


    public Animator animator;
    public float playerSpeed = 3;
    public bool isTurn = false, isAttacking = false, isShooting = false, toSpawn = true, isDis;
    private CharacterController controller;
    [SerializeField]
    private PlayerControls controls;
    [SerializeField]
    private InputActionReference menuControl;
    public InputActionReference back, click;
    private float idleTimer = 0, rotateSpeed = 5;
    public Vector3 move, targetPos;
    public short playerNum;

    // Start is called before the first frame update
    void Start()
    {
        controller = this.GetComponent<CharacterController>();
        animator = this.GetComponentInChildren<Animator>();
        animator.SetBool("isReal", false);
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
            if (isShooting)
            {

            }
        }

        move = targetPos - this.transform.position;         //This is the offset between the gameObject and the target coordinate that will be listed in goTo()
        //TODO: Add arrow and controller navigation here
        if(!isAttacking && toSpawn)
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(move), rotateSpeed * Time.deltaTime);      //Vector3(1.28999996,0,-1.88999999)   //Vector3(10.9899998,1.69815409,5.09000015)
        else if(!isAttacking && !toSpawn)
            SmoothLookBattleTurn(playerNum, isDis);


        if ((move.magnitude >= 1.2f && targetPos != Vector3.zero) || (move.magnitude >=0.2f && toSpawn))
        {
            animator.SetBool("isMoving", true);
            idleTimer = 0;
            move = move.normalized * playerSpeed;
            controller.Move(move * Time.deltaTime);
        }
        else
        {
            if (toSpawn)
                toSpawn = false;
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

    private void SmoothLookBattleTurn(int faceEnemies, bool isDisadvantage)
    {
        if (!isDisadvantage)
        {
            switch (faceEnemies)
            {
                case 1:
                    transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(new Vector3(0,0,0)), rotateSpeed * Time.deltaTime);
                    break;
                case 2:
                    transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(new Vector3(0, -90, 0)), rotateSpeed * Time.deltaTime);
                    break;
                case 3:
                    transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(new Vector3(0, 180, 0)), rotateSpeed * Time.deltaTime);
                    break;
                case 4:
                    transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(new Vector3(0, 90, 0)), rotateSpeed * Time.deltaTime);
                    break;
            }
        }
        else
        {
            switch (faceEnemies)
            {
                case 1:
                    transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(new Vector3(0, 180, 0)), rotateSpeed * Time.deltaTime);
                    break;
                case 2:
                    transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(new Vector3(0, 90, 0)), rotateSpeed * Time.deltaTime);
                    break;
                case 3:
                    transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(new Vector3(0, 0, 0)), rotateSpeed * Time.deltaTime);
                    break;
                case 4:
                    transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(new Vector3(0, -90, 0)), rotateSpeed * Time.deltaTime);
                    break;
            }
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

    public void goTo(Transform enemy)
    {
        this.transform.LookAt(enemy);
        float distance = Mathf.Sqrt((Mathf.Pow(this.transform.position.x - enemy.position.x, 2)) + (Mathf.Pow(this.transform.position.y - enemy.position.y, 2)) + (Mathf.Pow(this.transform.position.z - enemy.position.z, 2)));        //Uses distance formula of 2 3D points, in this case, the camera and current targetPos
        targetPos = enemy.position;
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
