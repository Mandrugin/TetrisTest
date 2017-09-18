using UnityEngine;
using strange.extensions.command.impl;
using strange.extensions.context.api;

public class MainMenuCommand : EventCommand
{
    private static readonly string prefabPath = "MainMenuCanvas";

    [Inject(ContextKeys.CONTEXT_VIEW)]
    public GameObject contextView { get; set; }

    public override void Execute()
    {
        var go = Object.Instantiate(Resources.Load(prefabPath)) as GameObject;
        if (go != null)
        {
            go.transform.SetParent(contextView.transform);
        }
        else
        {
            Debug.LogError("Main menu not found!");
        }
    }
}