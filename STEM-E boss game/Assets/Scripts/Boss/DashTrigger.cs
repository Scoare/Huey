using UnityEngine;

public class DashTrigger : MonoBehaviour
{
    [SerializeField] private BossMovement bossMovement;

    void OnTriggerEnter(Collider other) {
        if (!other.CompareTag("Player") || 
        other.GetComponent<ITakesKnockback>() == null || 
        !bossMovement.isDashing) 
        return;
        
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
        
        bossMovement.isDashing = false;
    }
}
