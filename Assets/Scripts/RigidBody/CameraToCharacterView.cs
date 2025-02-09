using UnityEngine;

public class CameraToCharacterView : MonoBehaviour
{
    [SerializeField] private Transform _OneCameraView;
    [SerializeField] private Transform _ThreeCameraView;
    [SerializeField] private bool _CameraOneViewMode = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
            _CameraOneViewMode = !_CameraOneViewMode;

        transform.position = _CameraOneViewMode ? _OneCameraView.position : _ThreeCameraView.position;
    }
}
