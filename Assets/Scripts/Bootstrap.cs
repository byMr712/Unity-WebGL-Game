using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    //������ ����� ������ ��� ������������� �������� � ��������, ���� ��������� ���� � ����� ����� �������
    [SerializeField] private movement_script movement_script;


    private void Awake()
    {
        movement_script.Initialize();
    }
}
