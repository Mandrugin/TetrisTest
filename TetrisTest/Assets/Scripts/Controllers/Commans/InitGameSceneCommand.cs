using strange.extensions.command.impl;
using UnityEngine;

class InitGameSceneCommand : EventCommand
{
    public override void Execute()
    {
        Debug.Log("InitGameSceneCommand Executing");

        //AppContext.Instance.RegisterMediator(new GameFieldViewMediator());
        //AppContext.Instance.RegisterMediator(new NextFieldViewMediator());
        //AppContext.Instance.RegisterMediator(new ScoreMediator());

        //AppContext.Instance.RegisterProxy(new GameField());
        //AppContext.Instance.RegisterProxy(new NextField());
        //AppContext.Instance.RegisterProxy(new Score());

        //AppContext.Instance.RegisterCommand(NotificationType.GET_SCORE_LINES_REMOVED_NOTE, typeof(GetScoreLinesRemovedCommand));
        //AppContext.Instance.RegisterCommand(NotificationType.GAME_OVER_NOTE, typeof(GameOverCommand));
    }
}
