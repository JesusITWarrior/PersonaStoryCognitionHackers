using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private PlayerControls controls;
    [SerializeField]
    private InputActionReference movementControl;
    [SerializeField]
    private InputActionReference jumpControl;
    private CharacterController controller;
    private Transform cameraMain;
    Animator animation;

    [SerializeField]
    private Vector3 playerVelocity;
    [SerializeField]
    private bool groundedPlayer;
    private float playerSpeed = 5;
    private float jumpHeight = 1;
    private float gravityValue = -9.81f;
    private float rotationSpeed = 4;
    private float idleTimer = 0;

    private void OnEnable()
    {
        movementControl.action.Enable();
        jumpControl.action.Enable();
    }

    private void OnDisable()
    {
        movementControl.action.Disable();
        jumpControl.action.Disable();
    }

    private void Start()
    {
        controller = this.GetComponent<CharacterController>();
        cameraMain = Camera.main.transform;
        animation = this.GetComponentInChildren<Animator>();
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if(groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0;
            animation.SetBool("jumped", false);
        }
        Vector2 movement = movementControl.action.ReadValue<Vector2>();
        Vector3 move = new Vector3(movement.x, 0, movement.y);

        if (movement != Vector2.zero)
        {
            animation.SetBool("isMoving", true);
            idleTimer = 0;
        }
        else
        {
            animation.SetBool("isMoving", false);
            idleTimer += Time.deltaTime;
            if(idleTimer >= 30)
            {
                System.Random rnd = new System.Random();
                int IdlePicker = rnd.Next(1,3);
                switch (IdlePicker) {
                    case 1:
                        animation.SetTrigger("Stretch");
                        break;
                    case 2:
                        Debug.Log("Secondary Idle Animation");
                        break;
                }
                idleTimer = 0;
            }
        }

        move = cameraMain.forward * move.z + cameraMain.right * move.x;

        controller.Move(move * Time.deltaTime * playerSpeed);

        if (jumpControl.action.triggered && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3 * gravityValue);
            animation.SetBool("jumped", true);
        }
        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
        if (movement != Vector2.zero)
        {
            float targetAngle = Mathf.Atan2(movement.x, movement.y) * Mathf.Rad2Deg + cameraMain.eulerAngles.y;
            Quaternion rotation = Quaternion.Euler(0, targetAngle, 0);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);
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
}
