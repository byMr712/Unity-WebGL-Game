using System.Runtime.CompilerServices;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private Animator _Animator;
    [SerializeField] private float _Speed = 0.0f;
    float _Speed—oefficientWalk = 2f;
    float _Speed—oefficientIdle = 1f;
    private int _SpeedHash;

    public void Initialize()
    {
        _Animator = GetComponent<Animator>();
        _SpeedHash = Animator.StringToHash("Speed");
    }

    void FixedUpdate()
    {
        //Animation walk for player
        bool _WalkPressed = Input.GetKey("w");
        if (_WalkPressed && _Speed < 1.0f)
            _Speed += Time.fixedDeltaTime * _Speed—oefficientWalk;
        if (!_WalkPressed && _Speed > 0.0f)
            _Speed -= Time.fixedDeltaTime * _Speed—oefficientIdle;
        _Animator.SetFloat(_SpeedHash, _Speed);
        //Protection against out-of-scope values
        if (_Speed < 0.0f && !_WalkPressed)
            _Speed = 0.0f;
            Debug.Log("Animation speed zero protected!");
    }
}
