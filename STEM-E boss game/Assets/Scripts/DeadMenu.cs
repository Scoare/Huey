using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadMenu : MonoBehaviour
{
    public void PlayGame() {
        SceneManager.LoadScene(2);
    }

    public void QuitGame() {
        Application.Quit();
    }
}
