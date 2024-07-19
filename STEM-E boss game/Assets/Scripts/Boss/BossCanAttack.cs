using System.Runtime.CompilerServices;
using UnityEngine;

public class BossCanAttack : MonoBehaviour
{
    [SerializeField] private BossMovement bossMovement;
    private float hitBoxLinger = 0.1f;

    private float timeTilDeath = 0.1f;

    void OnTriggerStay(Collider other) {
        if (!other.CompareTag("Player") || !enabled) {
            return;
        }

        if (other.GetComponent<PlayerHealth>() != null 
        && other.GetComponent<PlayerDash>() != null) {
            PlayerHealth _playerHealth = other.GetComponent<PlayerHealth>();
            PlayerDash _playerDash = other.GetComponent<PlayerDash>();

            if (_playerDash.isDashing)
                _playerHealth.Dodge();
            else
                _playerHealth.Damage();

            _playerHealth.healPercent = Mathf.Clamp(_playerHealth.healPercent, 0f, 1f);
            
            if (other.GetComponent<ITakesKnockback>() != null && !other.GetComponent<PlayerDash>().isDashing)
                other.GetComponent<ITakesKnockback>().TakeKnockback(bossMovement.gameObject.transform.position);
        }
        
        enabled = false;
    }

    void OnEnable() {
        timeTilDeath = hitBoxLinger;
    }

    void Update() {
        timeTilDeath -= Time.deltaTime;

        if (timeTilDeath <= 0f) enabled = false;
    }
}
