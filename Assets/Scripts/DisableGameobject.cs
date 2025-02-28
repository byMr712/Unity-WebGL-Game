using UnityEngine;

public class DisableGameobject : MonoBehaviour
{
    public GameObject _DisableGameobject;
    bool _Enabled = true;
    private void Update()
    {
        if (Input.GetKey(KeyCode.Return) && _Enabled)
        {
            _DisableGameobject.SetActive(false);
            _Enabled = false;
        }
            
    }

}
