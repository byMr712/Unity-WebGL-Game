using System.Collections;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class WeaponColliderDetect : MonoBehaviour
{
    [SerializeField] private GameObject _Player;
    public PlayerStats _PlayerStatsScript;
    public HealthBarHUDTester _HealthBarHUDTesterScript;
    public Animator _Animator;

    public int colliderDamage = 2;
    //public string colliderTag = "Player";
    public Collider coll;

    private IEnumerator coroutine;

    float dmg = 0.25f;

    void Start()
    {
        StartCoroutine(WaitTwoSeconds());
    }

    //private void OnTriggerEnter(Collider coll)
    //{
    //    if (coll.gameObject.tag == "Player")
    //    {
    //        StartCoroutine(coroutine);
    //    }
    //}

    //private void OnTriggerExit(Collider coll)
    //{
    //        StopCoroutine(coroutine);
    //}

    private IEnumerator WaitTwoSeconds()
    {
        WaitForSeconds _TimerTwoSecunds = new WaitForSeconds(2f);

        while (true)
        {
            Debug.Log("На тебе!");
            yield return _TimerTwoSecunds; // Переиспользуем тот же объект
        }

        
       
        
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (_PlayerStatsScript.health != null)
            {
                _HealthBarHUDTesterScript.Hurt(0.25f);
                StartCoroutine(WaitTwoSeconds());
            }
        }
    }



}
