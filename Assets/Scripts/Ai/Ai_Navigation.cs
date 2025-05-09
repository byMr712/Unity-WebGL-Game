using UnityEngine;
using UnityEngine.AI;

public class Ai_Navigation : MonoBehaviour
{
    private GameObject _Player;
    private NavMeshAgent _Agent;
    void Start()
    {
        _Player = GameObject.FindGameObjectWithTag("Player");
        _Agent = GetComponent<NavMeshAgent>();
        _Agent.SetDestination(_Player.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
