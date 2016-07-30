using PureMVC.Patterns;
using PureMVC.Interfaces;
using UnityEngine;

class InitGameSceneCommand : SimpleCommand
{
    public override void Execute(INotification notification)
    {
        Debug.Log("InitGameSceneCommand Executing");

        AppFacade.Instance.RegisterMediator(new GameFieldViewMediator());
        AppFacade.Instance.RegisterMediator(new NextFieldViewMediator());

        AppFacade.Instance.RegisterProxy(new GameFieldProxy());
        AppFacade.Instance.RegisterProxy(new NextFieldProxy());
    }
}
