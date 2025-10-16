using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{

    public void OnRetryClick()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void OnMenuClick()
    {
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
