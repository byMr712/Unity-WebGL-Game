#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

public static class Mr_Tool
{
    private static void SetPlayMode(EnterPlayModeOptions options)
    {
        EditorSettings.enterPlayModeOptionsEnabled = true;
        EditorSettings.enterPlayModeOptions = options;
    }

    [MenuItem("Mr712 Tools/1) ON FastPlayMode")]
    public static void OnFastPlayMode()
    {
        SetPlayMode(EnterPlayModeOptions.DisableDomainReload | EnterPlayModeOptions.DisableSceneReload);

        //Debug.Log("������� ����� Play Mode = ����ר�");
    }

    [MenuItem("Mr712 Tools/2) OFF FastPlayMode")]
    public static void OffFastPlayMode()
    {
        EditorSettings.enterPlayModeOptionsEnabled = false;
        Debug.LogWarning("������� ����� Play Mode = ��������");
    }

    //�������� ��������� ��������� Play Mode
    [InitializeOnLoadMethod]
    private static void CheckPlayModeStatus()
    {
        //�������� �� ������� �������� ��������� Play Mode
        EditorApplication.playModeStateChanged += state =>
        {
            //���� Play Mode �� ��� ������� - ������ �� ����������
            if (state != PlayModeStateChange.EnteredPlayMode) return;

            //���� "On FastPlayMode" �������� - ������ �� ����������
            if (!EditorSettings.enterPlayModeOptionsEnabled) return;
            var options = EditorSettings.enterPlayModeOptions;
            if (options == EnterPlayModeOptions.None) return;

            //���� "On FastPlayMode" ������� - ����� ��� � �������
            string messange = "������� ����� Play Mode = ����ר�! \n ������ ����� ������ ��� �������. ��������� ����� �� ������� 'Mr712 Tools' ������ ������";
            Debug.LogError(messange.Trim());
        };
    }
}
#endif