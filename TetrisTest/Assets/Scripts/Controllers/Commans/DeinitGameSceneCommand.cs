using strange.extensions.command.impl;

class DeinitGameSceneCommand : EventCommand
{
    public override void Execute()
    {
        dispatcher.Dispatch(NotificationType.DESTROY_SCORE_VIEW);
        dispatcher.Dispatch(NotificationType.DESTROY_FIELDS_VIEWS);
    }
}
