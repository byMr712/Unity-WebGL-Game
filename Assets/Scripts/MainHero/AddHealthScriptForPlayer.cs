using UnityEngine;

public class AddHealthScriptForPlayer : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Heart"))
        {
            Debug.Log("Detect heart");
            FindFirstObjectByType<PlayerStats>().AddHealth();
            Destroy(other.gameObject);
        }
    }
}


