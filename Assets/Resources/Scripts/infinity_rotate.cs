using UnityEngine;

public class infinity_rotate : MonoBehaviour
{
    [SerializeField] private GameObject _Rotate_object;
    void Update()
    {
        _Rotate_object.transform.Rotate(Vector3.up * Time.deltaTime * 40f);
    }
}
