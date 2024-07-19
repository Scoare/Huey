using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private GameObject attackCollider;
    [SerializeField] private InputActionReference attackInput;
    [SerializeField] private Animator animator;

    private void OnEnable() {
        attackInput.action.Enable();
    }

    private void OnDisable() {
        attackInput.action.Disable();
    }

    void Update() {
        if (attackInput.action.triggered && !animator.GetCurrentAnimatorStateInfo(1).IsName("Attack")) {
            animator.SetTrigger("Attack");
        }
    }

    public void attack() {
        attackCollider.GetComponent<PlayerAttackTrigger>().enabled = true;
    }
}
