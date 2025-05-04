using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Switch_display : MonoBehaviour
{
    public GameObject _display1, _display2;
    int check = 0;
    public void Switched_display()
    {
        check = check + 1;
        if (check == 1)
        {
            _display1.SetActive(false);
            _display2.SetActive(true);
            check = 0;
        }
    }
}
