using strange.extensions.command.impl;
using strange.extensions.context.api;
using UnityEngine;

class InitGameFieldsCommand : EventCommand
{
    private static readonly string prefabGamePath = "gameAreaCanvas";
    private static readonly string prefabNextPath = "nextAreaCanvas";
    private static readonly string prefabSrocePath = "ScoreCanvas";

    [Inject(ContextKeys.CONTEXT_VIEW)]
    public GameObject contextView { get; set; }

    public override void Execute()
    {
        GameObject go = null;

        go = Object.Instantiate(Resources.Load<GameObject>(prefabGamePath));
        go.transform.SetParent(contextView.transform);
        go = Object.Instantiate(Resources.Load<GameObject>(prefabNextPath));
        go.transform.SetParent(contextView.transform);
        go = Object.Instantiate(Resources.Load<GameObject>(prefabSrocePath));
        go.transform.SetParent(contextView.transform);

        go = new GameObject("GameController");
        var gameController = go.AddComponent<GameController>();
        injectionBinder.injector.Inject(gameController, false);
    }
}
