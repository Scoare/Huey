using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour, ITakesKnockback
{
    public int maxHealth = 5;
    public int health;
    public float healPercent = 0f;
    [SerializeField] private float knockbackScale = 5f;
    [SerializeField] private Slider healthBar;
    [SerializeField] private Slider healBar;
    [SerializeField] private InputActionReference healInput;
    [SerializeField] private ParticleSystem damageParticles;
    [SerializeField] private ParticleSystem healingParticles;
    [SerializeField] private PlayerSounds playerSounds;

    public void TakeKnockback(Vector3 position) {
        GetComponent<PlayerMovement>().playerVelocity += Vector3.up * knockbackScale;
    }

    private void OnEnable() {
        healInput.action.Enable();
    }

    private void OnDisable() {
        healInput.action.Disable();
    }

    void Awake() {
        healthBar.maxValue = maxHealth;
        health = maxHealth;
    }

    void Update() {
        healthBar.value = Mathf.Lerp(healthBar.value, health, Time.deltaTime * 2f);
        healBar.value = Mathf.Lerp(healBar.value, healPercent, Time.deltaTime * 2f);

        if (healInput.action.triggered && healPercent >= 1f) {
            healPercent = 0f;
            health = maxHealth;
            healingParticles.Play();
            playerSounds.Heal();
        }
    }

    public void Damage() {
        health -= 1;
        health = Mathf.Clamp(health, 0, maxHealth);

        damageParticles.Play();
        playerSounds.Damage();

        if (health <= 0) {
            Death();
        }
    }

    public void Dodge() {
        healPercent += 0.25f;

        GetComponent<PlayerDash>().dashCooldown = 0f;
        playerSounds.Dodge();
    }

    void Death() {
        Cursor.lockState = CursorLockMode.None;

        SceneManager.LoadScene(3);
    }
}
