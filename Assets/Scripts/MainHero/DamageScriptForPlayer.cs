using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script add to weapon

public class DamageScriptForPlayer : MonoBehaviour
{
    public float _DamageCount = 0.25f;


    private void OnCollisionEnter(Collision collision)
    {
        StartCoroutine(FindFirstObjectByType<PlayerStats>().Damage(_DamageCount));
    }
}