using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Cutscene : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private RawImage blackScreen;
    private Animator playerAnimator;

    private float velocity = 2f;
    private bool played = false;

    void Start() {
        playerAnimator = player.GetComponent<Animator>();
    }

    void Update() {
        player.transform.position += new Vector3(0, 0, Time.deltaTime * velocity * -1f);

        if (player.transform.position.z <= -2f) {
            if (played == false) {
                audioSource.Play();
                StartCoroutine(BlackScreen());
            }

            played = true;
            velocity = 0f;
        }

        if (velocity <= 0f) {
            playerAnimator.SetTrigger("StopWalking");
        }
    }

    IEnumerator BlackScreen() {
        yield return new WaitForSeconds(4.4f);
        blackScreen.color = new Color(0, 0, 0, 255);
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene(2);
    }
}
