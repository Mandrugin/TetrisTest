using strange.extensions.command.impl;
using strange.extensions.context.api;
using UnityEngine;

public class CreateRecordViewCommand : Command
{
    private static readonly string PREFAB_RECORD_PATH = "RecordCanvas";

    [Inject(ContextKeys.CONTEXT_VIEW)]
    public GameObject contextView { get; set; }

    public override void Execute()
    {
        Object.Instantiate(Resources.Load<GameObject>(PREFAB_RECORD_PATH), contextView.transform);
    }
}