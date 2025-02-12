using UnityEngine;


public class Player : MonoBehaviour
{
    [SerializeField] private InputSystem _InputSystemScript;
    [SerializeField, Range(0,1000)] private float _Speed;
    [SerializeField, Range(0,10)] private float _JumpForce;
    [SerializeField, Range(0,10)] private float _MouseSens;

    private Rigidbody _RB;
    private Camera _Camera;

    private float _XRotation = 0;
    private float _YRotation = 0;

    public void Awake()
    {
        _RB = GetComponent<Rigidbody>();
        _Camera = Camera.main;

        _InputSystemScript._AttackEvent.AddListener(OnAttack);
        _InputSystemScript._JumpEvent.AddListener(OnJump);
    }

    void Update()
    {
        OnMove();
        OnLook();

    }

    private void OnMove()
    {
        _RB.AddRelativeForce(new Vector3(_InputSystemScript._Move.x, 0, _InputSystemScript._Move.y) * _Speed * Time.deltaTime);
    }

    private void OnLook()
    {
        _XRotation -= _InputSystemScript._Look.y;
        _XRotation = Mathf.Clamp(_XRotation, -60f, 30f);

        _YRotation += _InputSystemScript._Look.x;

        _Camera.transform.localRotation = Quaternion.Euler(_XRotation, 0, 0);
        transform.rotation = Quaternion.Euler(0, _YRotation, 0);
    }

    private void OnJump()
    {
        _RB.AddForce(Vector3.up * _JumpForce, ForceMode.Impulse);
    }

    private void OnAttack()
    {
        print("Attack");
    }
}