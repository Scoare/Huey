using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] footstepClips;
    [SerializeField] private AudioClip jumpClip;
    [SerializeField] private AudioClip swingClip;
    [SerializeField] private AudioClip damageClip;
    [SerializeField] private AudioClip healClip;
    [SerializeField] private AudioClip dodgeClip;

    public bool shouldPlayFootstepSounds = true;

    public void Step() {
        if (shouldPlayFootstepSounds)
            audioSource.PlayOneShot(footstepClips[Random.Range(0, footstepClips.Length)]);
    }

    public void Jump() {
        audioSource.PlayOneShot(jumpClip);
    }

    public void Swing() {
        audioSource.PlayOneShot(swingClip);
    }

    public void Damage() {
        audioSource.PlayOneShot(damageClip);
    }

    public void Heal() {
        audioSource.PlayOneShot(healClip);
    }

    public void Dodge() {
        audioSource.PlayOneShot(dodgeClip);
    }
}
