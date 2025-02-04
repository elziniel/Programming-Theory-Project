#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{
    private int currentScene;

    private void Start()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
    }

    public void PreviousScene()
    {
        if (currentScene > 0)
        {
            SceneManager.LoadScene(currentScene - 1);
        }
        else
        {
#if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
#else
            Application.Quit();
#endif
        }
    }

    public void NextScene()
    {
        if (currentScene <= SceneManager.sceneCount)
        {
            SceneManager.LoadScene(currentScene + 1);
        }
    }

    public void UpdateText(string text, FloatReference value)
    {

    }
}
