using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleMenu : MonoBehaviour
{
    [SerializeField]
    private string gameSceneName;
    [SerializeField]
    private string creditsScene;

    public void LoadGameScene()
    {
        SceneManager.LoadScene(gameSceneName);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void LoadCredtis()
    {
        SceneManager.LoadScene(creditsScene);
    }
}
