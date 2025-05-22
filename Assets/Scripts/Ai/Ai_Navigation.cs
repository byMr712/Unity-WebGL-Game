using UnityEngine;
using UnityEngine.AI;

public class Ai_Navigation : MonoBehaviour
{
    [SerializeField] private Transform[] _NavMeshPoints;
    private Transform _CurrentPoint;
    [SerializeField] private enum _EnumState { _Potrul, _WalkToPlayer};
    _EnumState _CurrentState = _EnumState._Potrul;
    private GameObject _Player;
    private NavMeshAgent _Agent;

    void Start()
    {
        _Player = GameObject.FindGameObjectWithTag("Player");
        _Agent = GetComponent<NavMeshAgent>();
        _Agent.SetDestination(_Player.transform.position);
        WalkToNewPoint();

    }

    void Update()
    {
        if ((transform.position - _CurrentPoint.position).magnitude < 5f)
        {
            WalkToNewPoint();
        }
        Debug.Log(_CurrentState);
    }

    void WalkToNewPoint()
    {
        _CurrentPoint = _NavMeshPoints[Random.Range(0, _NavMeshPoints.Length)];
        _Agent.SetDestination(_CurrentPoint.transform.position);
    }

    private void FixedUpdate()
    {
        float _Cache_dot = Vector3.Dot((_Player.transform.position - transform.position).normalized, transform.forward);
        RaycastHit _Hit;
        if (_Cache_dot > 0.2f)
        {
            if (Physics.Raycast(transform.position, (_Player.transform.position - transform.position), out _Hit, 100f))
            {
                if (_Hit.transform == _Player)
                {
                    _CurrentState = _EnumState._WalkToPlayer;
                    if (_CurrentState == _EnumState._Potrul)
                    {
                        Invoke("DisableWalkToPlayer", 5f);
                    }
                }
            }
        }
        if (_CurrentState == _EnumState._WalkToPlayer)
        {
            _Agent.SetDestination(_Player.transform.position);
        }

    }

    void DisableWalkToPlayer()
    {
        RaycastHit _Hit;
        if (Physics.Raycast(transform.position, (_Player.transform.position - transform.position), out _Hit, 100f))
        {
            if (_Hit.transform != _Player)
            {
                _CurrentState = _EnumState._Potrul;
            }
            else
            {
                Invoke("DisableWalkToPlayer", 5f);
            }
        }
    }
}
