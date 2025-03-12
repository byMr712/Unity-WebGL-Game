using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.ProBuilder;
using UnityEngine.ProBuilder.Shapes;
using UnityEngine.ProBuilder.MeshOperations;

public class Door_up : MonoBehaviour
{
    [SerializeField] private ProBuilderMesh _Wall_transform_to_no_door;
    [SerializeField] private GameObject _This_trigger_to_room;
    [SerializeField] private GameObject _Next_trigger_to_room;
    //[SerializeField] private Camera _MainCamera;

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("Trigger door");
        _This_trigger_to_room.SetActive(false);
        Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z + 23f);

    }
}
