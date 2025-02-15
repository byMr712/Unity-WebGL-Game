using System.Collections;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private Animator _Animator;
    public float _Speed = 0.0f;
    public float _Speed—oefficientRun = 2f;
    public float _Speed—oefficientIdle = 1f;
    private float  _RotateAnimationTime;
    //public InputSystem _InputSystemScript;
    bool _IsIdleAnimationCurrentState;

    public void Initialize()
    {
        _Animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            _Animator.SetBool("_IsIdleAnimationCurrentState", false);
        else
            _Animator.SetBool("_IsIdleAnimationCurrentState", true);


    }
}
