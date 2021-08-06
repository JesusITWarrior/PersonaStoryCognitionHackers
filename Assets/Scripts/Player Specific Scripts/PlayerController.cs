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
    Animator animator;

    [SerializeField]
    private Vector3 fallVector;     //Meant for "falling"
    [SerializeField]
    private bool groundedPlayer;
    [SerializeField]
    private Vector3 move;
    private float playerSpeed = 5;
    private float playerSprintSpeed = 10;
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
        animator = this.GetComponentInChildren<Animator>();
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if(groundedPlayer && fallVector.y < 0)
        {
            fallVector.y = 0;
            animator.SetBool("jumped", false);
        }
        Vector2 movement = movementControl.action.ReadValue<Vector2>();
        move = new Vector3(movement.x, 0, movement.y).normalized;

        if (movement != Vector2.zero)
        {
            animator.SetBool("isMoving", true);
            idleTimer = 0;
        }
        else
        {
            animator.SetBool("isMoving", false);
            idleTimer += Time.deltaTime;
            if(idleTimer >= 30)
            {
                System.Random rnd = new System.Random();
                int IdlePicker = rnd.Next(1,3);
                switch (IdlePicker) {
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

        move = cameraMain.forward * move.z + cameraMain.right * move.x;
        move.y = 0;         //Sets y velocity to 0 to prevent "hopping" while looking up or down. Doesn't prevent slowing down when looking in those directions

        controller.Move(move * Time.deltaTime * playerSpeed);

        if (jumpControl.action.triggered && groundedPlayer)
        {
            fallVector.y += Mathf.Sqrt(jumpHeight * -3 * gravityValue);
            animator.SetBool("jumped", true);
        }
        fallVector.y += gravityValue * Time.deltaTime;
        controller.Move(fallVector * Time.deltaTime);
        if (movement != Vector2.zero)
        {
            float targetAngle = Mathf.Atan2(movement.x, movement.y) * Mathf.Rad2Deg + cameraMain.eulerAngles.y;
            Quaternion rotation = Quaternion.Euler(0, targetAngle, 0);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);
        }
    }
}
