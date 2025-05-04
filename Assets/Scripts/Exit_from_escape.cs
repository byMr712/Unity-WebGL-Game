using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Exit_from_escape : MonoBehaviour
{
    public GameObject _menu;
    public GameObject[] Escape_to_menu;
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            foreach(GameObject obj in Escape_to_menu)
            {
                if (obj.activeSelf == true)
                {
                    obj.SetActive(false);
                    _menu.SetActive(true);
                }
            }
        }
    }
}

