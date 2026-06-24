using UnityEngine;

public class OpenMenuAndPause : MonoBehaviour
{
    [SerializeField] private GameObject _Menu, _Game;

    private void Awake()
    {
        Time.timeScale = 0f;
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Tab))
            OpenMenuAndPauseGame();
    }

    public void OpenMenuAndPauseGame()
    {
        _Menu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void CloseMenuAndResumeGame()
    {
        _Menu.SetActive(false);
        _Game.SetActive(true);
        Time.timeScale = 1f;
    }

}
