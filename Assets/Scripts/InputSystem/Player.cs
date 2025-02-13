using UnityEngine;


public class Player : MonoBehaviour
{
    public InputSystem _InputSystemScript;
    public float _Speed;
    public float _JumpForce;
    public float _MouseSens;

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
        //_XRotation -= _InputSystemScript._Look.y;
        //_XRotation = Mathf.Clamp(_XRotation, -60f, 30f);

        //_YRotation += _InputSystemScript._Look.x;

        
        //transform.rotation = Quaternion.Euler(0, _YRotation, 0);
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