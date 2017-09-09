using PureMVC.Interfaces;
using PureMVC.Patterns;
using UnityEngine;

public class GameOverCommand : SimpleCommand
{
    public override void Execute(INotification notification)
    {
        AppFacade.Instance.RegisterMediator(new GameOverMediator());
        Debug.Log("GameOver command executed");
    }
}