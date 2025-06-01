using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void MenuSceneActivate()
    {
        SceneManager.LoadSceneAsync("MenuScene");
        Debug.Log("MenuScene");
    }

    public void GameSceneActivate()
    {
        SceneManager.LoadSceneAsync("GameScene");
        Debug.Log("GameScene");
    }
}