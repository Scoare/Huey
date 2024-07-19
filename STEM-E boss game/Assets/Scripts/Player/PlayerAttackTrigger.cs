using UnityEngine;

public class PlayerAttackTrigger : MonoBehaviour
{
    private float hitBoxLinger = 0.1f;

    private float timeTilDeath = 0.1f;

    void OnTriggerStay(Collider other) {
        if (!other.CompareTag("Enemy") || !enabled) return;

        if (other.GetComponent<BossHealth>() != null) {
            BossHealth _bossHealth = other.GetComponent<BossHealth>();

            _bossHealth.Damage();
        
            enabled = false;
        }
    }

    void OnEnable() {
        timeTilDeath = hitBoxLinger;
    }

    void Update() {
        timeTilDeath -= Time.deltaTime;

        if (timeTilDeath <= 0f) enabled = false;
    }
}
