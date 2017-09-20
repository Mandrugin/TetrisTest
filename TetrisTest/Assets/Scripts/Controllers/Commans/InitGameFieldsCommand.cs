using strange.extensions.command.impl;
using strange.extensions.context.api;
using UnityEngine;

class InitGameFieldsCommand : EventCommand
{
    private static readonly string prefabGamePath = "gameAreaCanvas";
    private static readonly string prefabNextPath = "nextAreaCanvas";
    private static readonly string prefabSrocePath = "ScoreCanvas";
    private static readonly string prefabControllInputCanvas = "ControllInputCanvas";

    [Inject(ContextKeys.CONTEXT_VIEW)]
    public GameObject contextView { get; set; }

    public override void Execute()
    {
        Object.Instantiate(Resources.Load<GameObject>(prefabGamePath), contextView.transform);
        Object.Instantiate(Resources.Load<GameObject>(prefabNextPath), contextView.transform);
        Object.Instantiate(Resources.Load<GameObject>(prefabSrocePath), contextView.transform);
        Object.Instantiate(Resources.Load<GameObject>(prefabControllInputCanvas), contextView.transform);

        var go = new GameObject("GameController", typeof(GameController));
        injectionBinder.injector.Inject(go.GetComponent<GameController>(), false);
    }
}
