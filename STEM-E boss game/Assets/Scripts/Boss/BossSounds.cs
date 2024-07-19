using UnityEngine;

public class BossSounds : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip damageClip;
    [SerializeField] private AudioClip boomClip;
    [SerializeField] private AudioClip screamClip;
    [SerializeField] private AudioClip slamClip;
    [SerializeField] private AudioClip dashClip;
    [SerializeField] private AudioClip swingClip;

    public bool shouldPlayFootstepSounds = true;

    public void Damage() {
        audioSource.PlayOneShot(damageClip);
    }

    public void Boom() {
        audioSource.PlayOneShot(boomClip);
    }

    public void Scream() {
        audioSource.PlayOneShot(screamClip);
    }

    public void Slam() {
        audioSource.PlayOneShot(slamClip);
    }

    public void Dash() {
        audioSource.PlayOneShot(dashClip);
    }

    public void Swing() {
        audioSource.PlayOneShot(swingClip);
    }
}
