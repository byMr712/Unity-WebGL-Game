using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script add to weapon

public class DamageScriptForEnemy : MonoBehaviour
{
    public float _DamageCount = 0.25f;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(FindFirstObjectByType<PlayerStats>().Damage(_DamageCount));
        }
    }
}