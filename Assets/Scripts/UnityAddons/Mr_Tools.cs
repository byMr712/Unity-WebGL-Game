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
        Debug.LogWarning("Быстрый режим Play Mode = ВЫКЛЮЧЕН");
    }

    [MenuItem("Mr712 Tools/3) ON GZIP Build")]
    public static void OnFastPlayMode()
    {
        PlayerSettings.WebGL.compressionFormat = (WebGLCompressionFormat)1;
        Debug.LogWarning("Режим сжатия билда GZIP = ВКЛЮЧЁН");
    }

    [MenuItem("Mr712 Tools/4) OFF GZIP Build")]
    public static void OffFastPlayMode()
    {
        PlayerSettings.WebGL.compressionFormat = (WebGLCompressionFormat)2;
        Debug.LogWarning("Режим сжатия билда GZIP = ВЫКЛЮЧЕН");
    }

    //Проверка изменения состояния Play Mode
    [InitializeOnLoadMethod]
    private static void CheckPlayModeStatus()
    {
        //Подписка на событие проверки состояния Play Mode
        EditorApplication.playModeStateChanged += state =>
        {
            //Если Play Mode не был включён - ничего не происходит
            if (state != PlayModeStateChange.EnteredPlayMode) return;

            //Если "On FastPlayMode" выключен - ничего не происходит
            if (!EditorSettings.enterPlayModeOptionsEnabled) return;
            var options = EditorSettings.enterPlayModeOptions;
            if (options == EnterPlayModeOptions.None) return;

            //Если "On FastPlayMode" включен - пишем это в консоль
            string messange = "Быстрый режим Play Mode = ВКЛЮЧЁН! \n Данная опция только для отладки. Отключить можно во вкладке 'Mr712 Tools' вверху экрана";
            Debug.LogError(messange.Trim());
        };
    }
}
#endif