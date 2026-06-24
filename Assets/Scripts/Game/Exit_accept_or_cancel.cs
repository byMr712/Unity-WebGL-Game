using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit_accept_or_cancel : MonoBehaviour
{
    public GameObject _exit;
    public void Exit_accept()
    {
        Application.Quit();
    }
    public void Exit_cancel()
    {
        _exit.SetActive(false);
    }
}
