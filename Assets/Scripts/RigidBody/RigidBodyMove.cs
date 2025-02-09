using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RigidBodyMove : RigidBodyMoveBase
{
    private Rigidbody _Rigidbody;

    public void Initialize()
    {
        _Rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _Rigidbody.MovePosition(transform.position + _MoveVector * _MoveSpeed * Time.fixedDeltaTime);
    }
}
