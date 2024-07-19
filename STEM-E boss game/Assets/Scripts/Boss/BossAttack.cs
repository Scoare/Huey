using UnityEngine;

public class BossAttack : MonoBehaviour
{
    [SerializeField] private BossMovement bossMovement;
    [SerializeField] private GameObject player;
    [SerializeField] private Animator animator;
    [SerializeField] private float attackInterval = 5f;
    [SerializeField] private float dashDistance = 5f;

    private float attackCooldown = 0f;

    void Update() {
        attackCooldown -= Time.deltaTime;

        checkForDash();
    }

    void OnTriggerStay(Collider other) {
        if (!other.CompareTag("Player")) return;

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle") 
        || animator.GetCurrentAnimatorStateInfo(0).IsName("Walk")) {
            bossMovement.shouldMove = false;
        }

        if (attackCooldown > 0f) return;

        attack(-1);
    }

    void OnTriggerExit(Collider other) {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle") 
        || animator.GetCurrentAnimatorStateInfo(0).IsName("Walk")) {
            bossMovement.shouldMove = true;
        }
    }

    private void attack(int attackId) {
        bossMovement.shouldMove = false;
        attackCooldown = attackInterval;
        animator.SetInteger("AttackId", attackId == -1 ? Random.Range(0, 4) : attackId);
        animator.SetTrigger("Attack");
    }

    private void checkForDash() {
        if (Vector3.Distance(transform.position, player.transform.position) > dashDistance && attackCooldown <= 0) {
            attack(4);
        }
    }
}
