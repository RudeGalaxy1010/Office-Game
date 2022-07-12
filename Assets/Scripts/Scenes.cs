using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
    private const string MenuScene = "MenuScene";
    private const string LevelScene = "MainScene";

    public void LoadMenuScene()
    {
        SceneManager.LoadScene(MenuScene);
    }

    public void LoadLevelScene()
    {
        SceneManager.LoadScene(LevelScene);
    }
}
