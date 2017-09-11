using UnityEngine;
using strange.extensions.command.impl;
using strange.extensions.context.api;

public class StartupCommand : EventCommand
{
    private static readonly string prefabPath = "MainMenuCanvas";

    [Inject(ContextKeys.CONTEXT_VIEW)]
    public GameObject contextView { get; set; }

    public override void Execute()
    {
        //AppContext.Instance.RegisterCommand(NotificationType.INIT_GAME_SCENE_NOTE, typeof(InitGameSceneCommand));
        //AppContext.Instance.RegisterCommand(NotificationType.DEINIT_GAME_SCENE_NOTE, typeof(DeinitGameSceneCommand));
        //SceneManager.LoadScene("start");

        var go = Object.Instantiate(Resources.Load(prefabPath)) as GameObject;
        if (go != null)
        {
            go.transform.SetParent(contextView.transform);
        }
        else
        {
            Debug.LogError("Main menu not found!");
        }

        Debug.Log("Startup command executed");
    }
}