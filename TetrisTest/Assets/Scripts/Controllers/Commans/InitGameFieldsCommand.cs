using strange.extensions.command.impl;
using UnityEngine;

class InitGameFieldsCommand : EventCommand
{
    private static readonly string prefabGamePath = "gameAreaCanvas";
    private static readonly string prefabNextPath = "nextAreaCanvas";
    private static readonly string prefabSrocePath = "ScoreCanvas";

    public override void Execute()
    {
        Debug.Log("InitGameFieldsCommand Executing");

        Object.Instantiate(Resources.Load(prefabGamePath));
        Object.Instantiate(Resources.Load(prefabNextPath));
        Object.Instantiate(Resources.Load(prefabSrocePath));

        var go = new GameObject();
        var gameController = go.AddComponent<GameController>();
        injectionBinder.injector.Inject(gameController, false);
    }
}
