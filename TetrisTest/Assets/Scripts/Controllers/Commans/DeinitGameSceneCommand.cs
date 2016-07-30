using PureMVC.Patterns;
using PureMVC.Interfaces;
using UnityEngine;

class DeinitGameSceneCommand : SimpleCommand
{
    public override void Execute(INotification notification)
    {
        Debug.Log("DeinitGameSceneCommand Executing");

        AppFacade.Instance.RemoveMediator(GameFieldViewMediator.NAME);
        AppFacade.Instance.RemoveMediator(NextFieldViewMediator.NAME);

        AppFacade.Instance.RemoveProxy(GameFieldProxy.NAME);
        AppFacade.Instance.RemoveProxy(NextFieldProxy.NAME);
    }
}
