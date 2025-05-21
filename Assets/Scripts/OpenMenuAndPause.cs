using UnityEngine;

public class OpenMenuAndPause : MonoBehaviour
{
    [SerializeField] private GameObject _Menu, _Game;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
            OpenMenuAndPauseGame();
    }

    public void OpenMenuAndPauseGame()
    {
        _Menu.SetActive(true);
        //_Game.SetActive(false);
        Time.timeScale = 0f;
    }

    public void CloseMenuAndResumeGame()
    {
        _Menu.SetActive(false);
        _Game.SetActive(true);
        Time.timeScale = 1f;
    }

}
