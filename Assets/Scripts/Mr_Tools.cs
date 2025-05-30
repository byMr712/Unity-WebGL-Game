#if UNITY_EDITOR
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;

public class Mr_Tool : EditorWindow
{
    bool _GzipActivate;
    private static void SetPlayMode(EnterPlayModeOptions options)
    {
        EditorSettings.enterPlayModeOptionsEnabled = true;
        EditorSettings.enterPlayModeOptions = options;
    }

    [MenuItem("Mr712 Tools/1) ON FastPlayMode")]
    public static void OnGZIPBuild()
    {
        SetPlayMode(EnterPlayModeOptions.DisableDomainReload | EnterPlayModeOptions.DisableSceneReload);
    }

    [MenuItem("Mr712 Tools/2) OFF FastPlayMode")]
    public static void OffGZIPBuild()
    {
        EditorSettings.enterPlayModeOptionsEnabled = false;
        Debug.LogWarning("������� ����� Play Mode = ��������");
    }

    [MenuItem("Mr712 Tools/3) ON GZIP Build")]
    public static void OnFastPlayMode()
    {
        PlayerSettings.WebGL.compressionFormat = (WebGLCompressionFormat)1;
        Debug.LogWarning("����� ������ ����� GZIP = ����ר�");
    }

    [MenuItem("Mr712 Tools/4) OFF GZIP Build")]
    public static void OffFastPlayMode()
    {
        PlayerSettings.WebGL.compressionFormat = (WebGLCompressionFormat)2;
        Debug.LogWarning("����� ������ ����� GZIP = ��������");
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