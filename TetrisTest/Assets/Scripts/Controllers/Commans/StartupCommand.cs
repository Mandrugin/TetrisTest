using UnityEngine;
using UnityEngine.SceneManagement;
using PureMVC.Patterns;
using PureMVC.Interfaces;

/// <summary>
/// Startup application simple command;
/// </summary>
public class StartupCommand : SimpleCommand
{
    public override void Execute(INotification notification)
    {
        AppFacade.Instance.RegisterCommand(NotificationType.INIT_GAME_SCENE_NOTE, typeof(InitGameSceneCommand));
        AppFacade.Instance.RegisterCommand(NotificationType.DEINIT_GAME_SCENE_NOTE, typeof(DeinitGameSceneCommand));
        SceneManager.LoadScene("start");
        Debug.Log("Startup command executed");
    }
}