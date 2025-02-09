using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    //This class is designed to initialize objects in scripts,
    //because it is more convenient to manage everything in one place!

    //[SerializeField] private movement_script _MovementScript;
    [SerializeField] private RigidBodyMove _RigidBodyMoveScript;
    [SerializeField] private RigidBodyRotate _RigidBodyRotateScript;
    [SerializeField] private AnimationController _AnimationControllerScript;

    private void Awake()
    {
        //_Movement_script.Initialize();
        _RigidBodyMoveScript.Initialize();
        _RigidBodyRotateScript.Initialize();
        _AnimationControllerScript.Initialize();
    }
}
