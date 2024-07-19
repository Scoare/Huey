using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int health;
    [SerializeField] private Slider bossBar;
    [SerializeField] private ParticleSystem damageParticles;
    [SerializeField] private BossSounds bossSounds;

    void Awake() {
        bossBar.maxValue = maxHealth;
        health = maxHealth;
    }

    void Update() {
        bossBar.value = Mathf.Lerp(bossBar.value, health, Time.deltaTime * 2f);

        if (health <= 0) {
            Win();
        }
    }

    public void Damage() {
        health -= 1;
        health = Mathf.Clamp(health, 0, maxHealth);

        damageParticles.Play();
        bossSounds.Damage();
    }

    private void Win() {
        Cursor.lockState = CursorLockMode.None;

        SceneManager.LoadScene(4);
    }
}
