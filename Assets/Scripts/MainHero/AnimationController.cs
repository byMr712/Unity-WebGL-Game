using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private Animator _Animator;
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


