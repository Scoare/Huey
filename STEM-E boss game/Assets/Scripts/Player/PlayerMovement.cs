using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private InputActionReference movementInput;
    [SerializeField] private InputActionReference jumpInput;
    public float playerSpeed = 2.0f;
    public float dashSpeed = 20.0f;
    [SerializeField] private float rotationSpeed = 20.0f;
    [SerializeField] private float jumpHeight = 2.0f;
    [SerializeField] private float gravityValue = -9.81f;

    private CharacterController controller;
    public Transform cameraMainTransform;
    private Animator animator;
    public Vector3 playerVelocity;
    private bool groundedPlayer;

    private void OnEnable() {
        movementInput.action.Enable();
        jumpInput.action.Enable();
    }

    private void OnDisable() {
        movementInput.action.Disable();
        jumpInput.action.Enable();
    }

    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        animator = gameObject.GetComponent<Animator>();
        cameraMainTransform = Camera.main.transform;

        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector2 movement = movementInput.action.ReadValue<Vector2>();
        Vector3 move = new Vector3(movement.x, 0, movement.y);
        move = cameraMainTransform.forward.normalized * move.z + cameraMainTransform.right.normalized * move.x;
        move.y = 0;
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (jumpInput.action.IsPressed() && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            animator.SetTrigger("Jump");
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        if (movement != Vector2.zero) {
            float targetAngle = /*Mathf.Atan2(movement.x, movement.y) * Mathf.Rad2Deg +*/ cameraMainTransform.eulerAngles.y;
            Quaternion rotation = Quaternion.Euler(0f, targetAngle, 0f);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);
        }

        if (animator.GetCurrentAnimatorStateInfo(1).IsName("Attack"))
            transform.rotation = Quaternion.Euler(0, cameraMainTransform.eulerAngles.y, 0);

        animator.SetBool("isWalking", movement != Vector2.zero);
        animator.SetBool("isGrounded", controller.isGrounded);
    }
}
