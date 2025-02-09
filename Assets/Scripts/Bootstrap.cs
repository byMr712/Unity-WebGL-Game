using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    //Данный класс создан для инициализации объектов в скриптах, ведь управлять всем в одном месте удобнее
    [SerializeField] private movement_script movement_script;


    private void Awake()
    {
        movement_script.Initialize();
    }
}
