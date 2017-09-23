using UnityEditor;
using UnityEngine;

public class CommandGenerator : EditorWindow
{
    private static AppContext context;

    private Vector2 scrollPosition;

    [MenuItem("Tools/Command generator")]
    static void Init()
    {
        if (Application.isPlaying)
        {
            context = FindObjectOfType<AppContextView>().context as AppContext;
        }

        CommandGenerator window = (CommandGenerator)EditorWindow.GetWindow(typeof(CommandGenerator));
        window.Show();
    }

    void OnGUI()
    {
        if (!Application.isPlaying)
        {
            GUILayout.Label("Run editor to use this tool kits");
            return;
        }
        else if (context == null)
        {
            context = FindObjectOfType<AppContextView>().context as AppContext;
        }

        scrollPosition = GUILayout.BeginScrollView(scrollPosition);

        if (GUILayout.Button("GAME OVER COMMAND"))
        {
            context.injectionBinder.GetInstance<GameOverSignal>().Dispatch();
        }

        if (GUILayout.Button("SAVE PLAYER DATA"))
        {
            context.injectionBinder.GetInstance<SavePlayerDataSignal>().Dispatch();
        }

        if (GUILayout.Button("LOAD PLAYER DATA"))
        {
            context.injectionBinder.GetInstance<LoadPlayerDataSignal>().Dispatch();
        }

        if (GUILayout.Button("CLEAR PLAYER DATA"))
        {
            context.injectionBinder.GetInstance<ClearPlayerDataSignal>().Dispatch();
        }

        GUILayout.EndScrollView();
    }
}
