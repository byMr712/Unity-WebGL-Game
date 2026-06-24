using UnityEngine;

public class Player : MonoBehaviour
{
    public InputSystem _InputSystemScript;
    public float _Speed;
    public float _JumpForce;
    public int _JumpUse;
    int _MovePressedButton;
    private Rigidbody _RB;
    private Camera _Camera;


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

        if (Input.GetKeyDown(KeyCode.W) & !Input.GetKeyDown(KeyCode.S))
            _MovePressedButton = 1;
        if (Input.GetKeyDown(KeyCode.D) & !Input.GetKeyDown(KeyCode.A))
            _MovePressedButton = 2;
        if (Input.GetKeyDown(KeyCode.A) & !Input.GetKeyDown(KeyCode.D))
            _MovePressedButton = 3;
        if (Input.GetKeyDown(KeyCode.S) & !Input.GetKeyDown(KeyCode.W))
            _MovePressedButton = 4;
    }

    private void OnMove()
    {
        _RB.transform.Translate(new Vector3(_InputSystemScript._Move.x, 0, _InputSystemScript._Move.y) * _Speed * Time.deltaTime, Space.World);

        switch (_MovePressedButton)
        {
            case 1:
                transform.rotation = Quaternion.Euler(0, 0, 0);
                break;
            case 2:
                transform.rotation = Quaternion.Euler(0, 90, 0);
                break;
            case 3:
                transform.rotation = Quaternion.Euler(0, 270, 0);
                break;
            case 4:
                transform.rotation = Quaternion.Euler(0, 180, 0);
                break;
            default:

                break;
        }
    }

    private void OnJump()
    {
        if (_JumpUse < 1)
        {
            _RB.AddForce(Vector3.up * _JumpForce, ForceMode.Impulse);
            _JumpUse++;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        _JumpUse = 0;
    }

    private void OnAttack()
    {
        Debug.Log("Attack");
    }
}


