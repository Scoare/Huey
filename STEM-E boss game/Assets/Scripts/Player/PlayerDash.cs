using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerDash : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private Animator animator;
    [SerializeField] private InputActionReference dashInput;
    [SerializeField] private PlayerSounds playerSounds;
    [SerializeField] private float dashInterval = 1f;

    public bool isDashing = false;

    [HideInInspector] public float dashCooldown;

    private void OnEnable() {
        dashInput.action.Enable();
    }

    private void OnDisable() {
        dashInput.action.Disable();
    }

    public void dashStart() {
        playerMovement.playerSpeed += playerMovement.dashSpeed;
    }

    public void dashEnd() {
        playerMovement.playerSpeed -= playerMovement.dashSpeed;
        isDashing = false;
        playerSounds.shouldPlayFootstepSounds = true;
    }

    void Update() {
        if (dashInput.action.triggered && !isDashing && dashCooldown <= 0f) {
            animator.SetTrigger("Dash");
            isDashing = true;
            dashCooldown = dashInterval;
            playerSounds.shouldPlayFootstepSounds = false;
        }

        dashCooldown -= Time.deltaTime;
    }
}
