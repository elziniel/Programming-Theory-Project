#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{
    public WeaponSelect weaponSelect;
    private int currentScene;

    private void Start()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
    }

    private void OnEnable()
    {
        if (weaponSelect != null)
        {
            weaponSelect.onWeaponChanged += NewWeaponSelected;
        }
    }

    private void OnDisable()
    {
        if (weaponSelect != null)
        {
            weaponSelect.onWeaponChanged -= NewWeaponSelected;
        }
    }

    private void NewWeaponSelected(WeaponType weapon)
    {
        MainManager.Instance.SpaceshipWeapon = weapon;
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
}
