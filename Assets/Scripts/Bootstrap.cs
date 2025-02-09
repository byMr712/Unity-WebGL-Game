using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    //This class is designed to initialize objects in scripts,
    //because it is more convenient to manage everything in one place!
    [SerializeField] private movement_script movement_script;


    private void Awake()
    {
        movement_script.Initialize();
    }
}
