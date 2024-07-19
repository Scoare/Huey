using UnityEngine;
using UnityEngine.AI;

public class BossMovement : MonoBehaviour
{
    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject player;
    [SerializeField] private float moveSpeed = 3.5f;
    [SerializeField] private float rotationSpeed = 2f;
    [SerializeField] private float dashSpeed = 10f;
    public bool shouldMove = true;
    public bool shouldRotate = true;
    public bool isDashing = false;

    void Awake() {
        navMeshAgent.speed = moveSpeed;
    }

    void Update() {
        navMeshAgent.SetDestination(shouldMove 
        ? player.transform.position 
        : transform.position);

        animator.SetBool("isWalking", shouldMove);

        if (shouldRotate) {
            Quaternion targetRotation = Quaternion.LookRotation(player.transform.position - transform.position);
            
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }

    public void dash(int _startOrStop) {
        navMeshAgent.speed = _startOrStop == 0 ? dashSpeed : moveSpeed;
        navMeshAgent.acceleration = _startOrStop == 0 ? 1000000f : 8f;

        isDashing = _startOrStop == 0;

        shouldMove = true;
        shouldRotate = true;
    }
    
    public void setShouldMove(int _shouldMove) {
        shouldMove = _shouldMove != 0;
    }
}
