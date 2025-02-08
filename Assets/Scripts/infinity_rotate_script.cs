using UnityEngine;

public class infinity_rotate_script : MonoBehaviour
{
    [SerializeField] private GameObject _Rotate_object;
    void Update()
    {
        _Rotate_object.transform.Rotate(Vector3.up * Time.deltaTime * 40f);
    }
}
