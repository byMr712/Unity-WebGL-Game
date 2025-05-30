using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InputSystem : MonoBehaviour
{
    public UnityEvent _AttackEvent = new();
    public UnityEvent _JumpEvent = new();
    
    //Mr712 - Create _AttackClick and _JumpEvent, since when attacking/jumping, the bool value always becomes true, so for now the temporary solution is
    public Vector2 _Move;
    public Vector2 _Look;
    public bool _Attack;
    public bool _Jump;

    public void OnMove(InputValue value)
    {
        _Move = value.Get<Vector2>();
    }
    public void OnLook(InputValue value)
    {
        _Look = value.Get<Vector2>();
    }
    public void OnAttack(InputValue value)
    {
        _Attack = value.isPressed;
    }
    public void OnJump(InputValue value)
    {
        _Jump = value.isPressed;
        _JumpEvent?.Invoke();
    }
}