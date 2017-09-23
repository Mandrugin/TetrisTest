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
            context.dispatcher.Dispatch(NotificationType.GAME_OVER_NOTE);
        }

        if (GUILayout.Button("SAVE PLAYER DATA"))
        {
            context.dispatcher.Dispatch(NotificationType.SAVE_PLAYER_DATA);
        }

        if (GUILayout.Button("LOAD PLAYER DATA"))
        {
            context.dispatcher.Dispatch(NotificationType.LOAD_PLAYER_DATA);
        }

        if (GUILayout.Button("CLEAR PLAYER DATA"))
        {
            context.dispatcher.Dispatch(NotificationType.CLEAR_PLAYER_DATA);
        }

        GUILayout.EndScrollView();
    }
}
