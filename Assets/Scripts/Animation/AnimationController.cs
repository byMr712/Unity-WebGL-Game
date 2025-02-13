using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private Animator _Animator;
    public float _Speed = 0.0f;
    public float _Speed—oefficientRun = 2f;
    public float _Speed—oefficientIdle = 1f;
    private int  _SpeedHash;
    //public InputSystem _InputSystemScript;
    bool _IsIdleAnimationCurrentState;

    public void Initialize()
    {
        _Animator = GetComponent<Animator>();
        _SpeedHash = Animator.StringToHash("Speed");
    }

    void FixedUpdate()
    {
        bool _IsIdleAnimationState = _Animator.GetBool("_IsIdleAnimationCurrentState");


    }
}
