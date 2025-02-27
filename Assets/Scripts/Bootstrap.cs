using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    //This class is designed to initialize objects in scripts,
    //because it is more convenient to manage everything in one place!

    //[SerializeField] private movement_script _MovementScript;
    [SerializeField] private AnimationController _AnimationControllerScript;
    [SerializeField] private Player _PlayerScript;

    private void Awake()
    {
        //_Movement_script.Initialize();
        //_AnimationControllerScript.Initialize();
        //_PlayerScript.Initialize();
    }
}
