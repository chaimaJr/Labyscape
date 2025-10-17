using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    private AudioController audioController;

    private void Awake()
    {
        audioController = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioController>();
    }

    public void OnRetryClick()
    {
        audioController.PlaySFX(audioController.keyCollected);

        SceneManager.LoadScene("SampleScene");
    }

    public void OnMenuClick()
    {
        audioController.PlaySFX(audioController.keyCollected);

        SceneManager.LoadScene("StartScene");

    }

    public void OnExitClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

}
