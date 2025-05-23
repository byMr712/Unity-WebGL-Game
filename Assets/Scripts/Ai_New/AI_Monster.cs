using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_Monster : MonoBehaviour
{
    private NavMeshAgent AI_Agent;
    private GameObject _Player;
    public GameObject _Panel_GaveOver, _VragWeapons;

    public Transform[] WayPoints;
    public int Current_Patch;

    public enum AI_State { Patrol, Stay, Chase};
    public AI_State AI_Enemy;

    private Animator _Animator;
    public bool _AttackDetect = false;

    void Start()
    {
        AI_Agent = gameObject.GetComponent<NavMeshAgent>();
        _Player = GameObject.FindGameObjectWithTag("Player");
        _Animator = gameObject.GetComponent<Animator>();
        _VragWeapons = GameObject.FindGameObjectWithTag("VragWeapons");
    }

    void FixedUpdate()
    {
        if (AI_Enemy == AI_State.Patrol)
        {
            AI_Agent.isStopped = false;
            AI_Agent.SetDestination(WayPoints[Current_Patch].transform.position);
            float Patch_Dist = Vector3.Distance(WayPoints[Current_Patch].transform.position, gameObject.transform.position);
            if (Patch_Dist < 1)
            {
                Current_Patch++;
                Current_Patch = Current_Patch % WayPoints.Length;
            }
        }

        if (AI_Enemy == AI_State.Stay)
        {
            AI_Agent.isStopped = true;
        }

        if (AI_Enemy == AI_State.Chase)
        {
            AI_Agent.SetDestination(_Player.transform.position);
        }

        float Dist_Player = Vector3.Distance(_Player.transform.position, gameObject.transform.position);
        float Dist_Weapon_To_Player = Vector3.Distance(_Player.transform.position, _VragWeapons.gameObject.transform.position);
        if (Dist_Player < 1.5 & _AttackDetect)
        {
            if (!_Animator.GetCurrentAnimatorStateInfo(1).IsName("_Attack"))
            {
                _Animator.SetTrigger("_Attack");
                _Animator.SetTrigger("_Run_Warrior");
                //Debug.Log("Есть пробитие без проверки");
                //if (Dist_Weapon_To_Player < 1)
                //{
                //    Debug.Log("Есть пробитие");
                //}
                _AttackDetect = false;
            }
        }

    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    Debug.Log("Объект вошел в зону.");
    //}

    //private void OnCollisionEnter(Collision collision)
    //{
    //    print("Collision detected");
    //    print(collision.gameObject);
    //}
}