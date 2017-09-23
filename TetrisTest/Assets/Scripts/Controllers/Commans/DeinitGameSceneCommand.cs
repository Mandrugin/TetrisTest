using strange.extensions.command.impl;

class DeinitGameSceneCommand : Command
{
    [Inject]
    public DestroyScoreViewSignal destroyScoreViewSignal { get; set; }

    [Inject]
    public DestroyFieldsViewSignal destroyFieldsViewSignal { get; set; }

    [Inject]
    public DestroyButtonsViewSignal destroyButtonsViewSignal { get; set; }

    public override void Execute()
    {
        destroyScoreViewSignal.Dispatch();
        destroyFieldsViewSignal.Dispatch();
        destroyButtonsViewSignal.Dispatch();
    }
}
