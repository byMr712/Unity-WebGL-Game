using JetBrains.Annotations;
using UnityEngine;

public class GameoverScript : MonoBehaviour
{
    public GameObject _GameOverMenu;

    private void Update()
    {
        if (FindFirstObjectByType<PlayerStats>().health == 0f)
        {
            Time.timeScale = 0f;
            _GameOverMenu.SetActive(true);
        }
    } 
}
