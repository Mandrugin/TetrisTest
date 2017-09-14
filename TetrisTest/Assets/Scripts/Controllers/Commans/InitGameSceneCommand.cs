using strange.extensions.command.impl;
using strange.extensions.context.api;
using strange.extensions.context.impl;
using strange.extensions.injector.impl;
using UnityEngine;
using UnityEngine.Windows.Speech;

class InitGameSceneCommand : EventCommand
{
    private static readonly string prefabGamePath = "gameAreaCanvas";
    private static readonly string prefabNextPath = "nextAreaCanvas";

    public override void Execute()
    {
        Debug.Log("InitGameSceneCommand Executing");

        Object.Instantiate(Resources.Load(prefabGamePath));
        Object.Instantiate(Resources.Load(prefabNextPath));

        var go = new GameObject();
        var gameController = go.AddComponent<GameController>();
        injectionBinder.injector.Inject(gameController, false);

        //AppContext.Instance.RegisterMediator(new GameFieldViewMediator());
        //AppContext.Instance.RegisterMediator(new NextFieldViewMediator());
        //AppContext.Instance.RegisterMediator(new ScoreMediator());

        //AppContext.Instance.RegisterProxy(new Score());

        //AppContext.Instance.RegisterCommand(NotificationType.GET_SCORE_LINES_REMOVED_NOTE, typeof(GetScoreLinesRemovedCommand));
        //AppContext.Instance.RegisterCommand(NotificationType.GAME_OVER_NOTE, typeof(GameOverCommand));
    }
}
