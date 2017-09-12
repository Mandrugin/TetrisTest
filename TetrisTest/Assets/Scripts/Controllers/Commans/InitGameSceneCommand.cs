using strange.extensions.command.impl;
using strange.extensions.injector.impl;
using UnityEngine;

class InitGameSceneCommand : EventCommand
{
    string prefabPath = "gameAreaCanvas";

    public override void Execute()
    {
        Debug.Log("InitGameSceneCommand Executing");

        var prefab = GameObject.Instantiate(Resources.Load(prefabPath)) as GameObject;
        var field = prefab.GetComponentInChildren<FieldViewComponent>();

        var go = new GameObject();
        var gameController = go.AddComponent<GameController>();
        //go.transform.SetParent(context.transform);
        injectionBinder.injector.Inject(gameController);

        //AppContext.Instance.RegisterMediator(new GameFieldViewMediator());
        //AppContext.Instance.RegisterMediator(new NextFieldViewMediator());
        //AppContext.Instance.RegisterMediator(new ScoreMediator());

        //AppContext.Instance.RegisterProxy(new Score());

        //AppContext.Instance.RegisterCommand(NotificationType.GET_SCORE_LINES_REMOVED_NOTE, typeof(GetScoreLinesRemovedCommand));
        //AppContext.Instance.RegisterCommand(NotificationType.GAME_OVER_NOTE, typeof(GameOverCommand));
    }
}
