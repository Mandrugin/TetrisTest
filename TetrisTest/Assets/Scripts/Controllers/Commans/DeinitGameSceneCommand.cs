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
        AppFacade.Instance.RemoveMediator(ScoreMediator.NAME);

        AppFacade.Instance.RemoveProxy(GameFieldProxy.NAME);
        AppFacade.Instance.RemoveProxy(NextFieldProxy.NAME);
        AppFacade.Instance.RemoveProxy(ScoreProxy.NAME);

        AppFacade.Instance.RemoveCommand(NotificationType.GET_SCORE_LINES_REMOVED_NOTE);
        AppFacade.Instance.RemoveCommand(NotificationType.GAME_OVER_NOTE);
    }
}
