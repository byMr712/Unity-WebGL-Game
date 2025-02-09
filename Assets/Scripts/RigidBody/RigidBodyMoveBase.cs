using UnityEngine;

public class RigidBodyMoveBase : MonoBehaviour
{
    [SerializeField] protected float _MoveSpeed = 5f;
    [SerializeField] protected Vector3 _MoveVector;
    protected void Update()
    {
        _MoveVector = Input.GetAxis("Horizontal") * transform.right + Input.GetAxis("Vertical") * transform.forward;
    }
}
