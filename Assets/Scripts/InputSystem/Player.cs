using System.Collections;
using System;
using UnityEngine;
using UnityEngine.EventSystems;


public class Player : MonoBehaviour
{
    public InputSystem _InputSystemScript;
    public float _Speed;
    public float _JumpForce;
    public int _JumpUse;
    public float _MouseSens;
    int _MovePressedButton;
    int _MoveRotationValue;
    bool _IsLestnica;
    [SerializeField] private float rayLength;

    private Rigidbody _RB;
    private Camera _Camera;

    //private float _XRotation = 0;
    //private float _YRotation = 0;

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
        IsLestnicaPlayer();

        if (Input.GetKeyDown(KeyCode.W) & !Input.GetKeyDown(KeyCode.S))
            _MovePressedButton = 1;
        if (Input.GetKeyDown(KeyCode.D) & !Input.GetKeyDown(KeyCode.A))
            _MovePressedButton = 2;
        if (Input.GetKeyDown(KeyCode.A) & !Input.GetKeyDown(KeyCode.D))
            _MovePressedButton = 3;
        if (Input.GetKeyDown(KeyCode.S) & !Input.GetKeyDown(KeyCode.W))
            _MovePressedButton = 4;



        if (_IsLestnica)
        {
            _RB.useGravity = false;
            //_RB.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        }
        else
        {
            _RB.useGravity = true;
            //_RB.AddForce(moveDirection.normalized * moveSpeed * 10f * 0.2f, ForceMode.Force);
        }


    }

    private void OnMove()
    {
        _RB.AddForce(new Vector3(_InputSystemScript._Move.x, 0, _InputSystemScript._Move.y) * _Speed * Time.deltaTime);

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

    private void OnLook()
    {
        //_XRotation -= _InputSystemScript._Look.y;
        //_XRotation = Mathf.Clamp(_XRotation, -60f, 30f);

        //_YRotation += _InputSystemScript._Look.x;


        //transform.rotation = Quaternion.Euler(0, _YRotation, 0);
    }

    private void OnJump()
    {
        if (_JumpUse < 1)
        {
            //Vector3 jump = new Vector3(0.0f, _JumpForce, 0.0f);
            _RB.AddForce(Vector3.up * _JumpForce, ForceMode.Impulse);
            _JumpUse++;
        }

        //_RB.AddForce(Vector3.up * _JumpForce, ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision other)
    {
        _JumpUse = 0;
    }

    private void OnAttack()
    {
        print("Attack");
    }

    IEnumerator WaitSeconds()
    {
        print("Корутина");
        yield return new WaitForSeconds(60);

    }

    public void IsLestnicaPlayer()
    {
        RaycastHit hit;
        
        if (Physics.Raycast(transform.position, Vector3.down, out hit, rayLength))
        {
            if (hit.collider.tag == "Lestnica")
            {
                _IsLestnica = true;
                Debug.Log("Lestnica");
                //Debug.DrawRay(transform.position, Vector3.down, Color.green);
            }
            else
            {
                _IsLestnica = false;
                Debug.Log("No Lestnica");
            }
        }
        
    }
}