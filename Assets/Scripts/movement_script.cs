using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(CharacterController))]
public class movement_script : MonoBehaviour
{
    [Header("Movement stats")]
    [SerializeField, Range(0, 100)] private float _MoveSpeed;
    [SerializeField, Range(0, 100)] private float _RotateSpeed;
    [SerializeField, Range(0, 100)] private float _JumpPower;

    [Header("Gravity stats")]
    [SerializeField] private float _GravityValue = 20f;
    private float _CurrentGravityValue = 0; //Not SerializeField please, edit with script only!
    private Vector3 _MoveVector;

    [Header("Character components")]
    private CharacterController _CharacterController; //Static value, not SerializeField please!
    private Animator _Animator;



    public void Initialize()
    {
        _CharacterController = GetComponent<CharacterController>();
        _Animator = GetComponent<Animator>();
    }

    void Update()
    {
        MovementEngine();
        Gravity();
    }

    void MovementEngine()
    {
        //Normal movement
        _MoveVector = Vector3.zero;
        _MoveVector.x = Input.GetAxis("Horizontal") * _MoveSpeed;
        _MoveVector.z = Input.GetAxis("Vertical") * _MoveSpeed;

        //Animation during movement
        if (_MoveVector.x != 0 | _MoveVector.z != 0)
            _Animator.SetBool("Move", true);
        else
            _Animator.SetBool("Move", false);


        //Rotation when moving
        if (Vector3.Angle(Vector3.forward, _MoveVector) > 1f || Vector3.Angle(Vector3.forward, _MoveVector) == 0)
        {
            Vector3 _VectorAngle = Vector3.RotateTowards(transform.forward, _MoveVector, _RotateSpeed, 0.0f);
            transform.rotation = Quaternion.LookRotation(_VectorAngle);
        }

        _MoveVector.y = _CurrentGravityValue;
        _CharacterController.Move(_MoveVector * Time.deltaTime);
    }

    void Gravity()
    {
        if (!_CharacterController.isGrounded)
            _CurrentGravityValue -= _GravityValue * Time.deltaTime;
        else
            _CurrentGravityValue = 0f;
    }
}
