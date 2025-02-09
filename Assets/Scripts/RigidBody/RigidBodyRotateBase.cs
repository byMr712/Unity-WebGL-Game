using Unity.VisualScripting;
using UnityEngine;

public class RigidBodyRotateBase : MonoBehaviour
{
    [SerializeField, Range(0, 10)] protected float _Sensivity;
    [SerializeField, Range(0, 100)] protected float _Smoothness;
    [SerializeField] protected Transform _TransformCharacter;

    protected float _XRotation;
    protected float _YRotation;

    public void Initialize()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    protected void Update()
    {
        _YRotation += Input.GetAxis("Mouse X") * _Sensivity;
        _XRotation -= Input.GetAxis("Mouse Y") * _Sensivity;
        _XRotation = Mathf.Clamp(_XRotation, -90f, 90f);
    }

    protected void RotateCharacter()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(_XRotation, _YRotation, 0), Time.deltaTime * _Smoothness);
        _TransformCharacter.rotation = Quaternion.Lerp(_TransformCharacter.rotation, Quaternion.Euler(0, _YRotation, 0), Time.deltaTime * _Smoothness);
    }
}
