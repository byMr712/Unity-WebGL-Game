using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public delegate void OnHealthChangedDelegate();
    public OnHealthChangedDelegate onHealthChangedCallback;
    public NavMeshAgent _NavMeshAgent;
    public Animator _AnimatorAgent;

    //Object in this region active in all scene
    #region Sigleton 
    private static PlayerStats instance;
    public static PlayerStats Instance
    {
        get
        {
            if (instance == null)
                instance = FindAnyObjectByType<PlayerStats>();
            return instance;
        }
    }
    #endregion

    public float health = 3;
    [SerializeField]
    private float maxHealth;
    [SerializeField]
    private float maxTotalHealth;

    public float Health { get { return health; } }
    public float MaxHealth { get { return maxHealth; } }
    public float MaxTotalHealth { get { return maxTotalHealth; } }

    private void Start()
    {

    }

    public void Heal(float health)
    {
        this.health += health;
        ClampHealth();
    }

    public void TakeDamage(float dmg)
    {
        health -= dmg;
        ClampHealth();
        if (health < 0)
        Destroy(gameObject);
    }

    public void AddHealth()
    {
        maxHealth += 1;
        if (onHealthChangedCallback != null)
            onHealthChangedCallback.Invoke();

        this.health += 1f;
        ClampHealth();
    }

    //Reaload health UI
    void ClampHealth()
    {
        health = Mathf.Clamp(health, 0, maxHealth);

        if (onHealthChangedCallback != null)
            onHealthChangedCallback.Invoke();
    }

    public IEnumerator Damage(float _DamageCount)
    {

        TakeDamage(_DamageCount);
        Debug.Log("Урон получен");
        _NavMeshAgent.isStopped = true;
        _AnimatorAgent.SetTrigger("_Attack");

        yield return new WaitForSeconds(0.5f);
        _NavMeshAgent.isStopped = false;

    }

    //public IEnumerator HAddHealth()
    //{

    //    AddHealth();
    //    Debug.Log("Сердце получено");
    //    _NavMeshAgent.isStopped = true;
    //    _AnimatorAgent.SetTrigger("_Attack");

    //    yield return new WaitForSeconds(0.5f);
    //    _NavMeshAgent.isStopped = false;

    //}

}
