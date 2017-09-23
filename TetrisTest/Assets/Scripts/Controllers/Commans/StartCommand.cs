using strange.extensions.command.impl;

public class StartCommand : EventCommand
{
    public override void Execute()
    {
        dispatcher.Dispatch(NotificationType.LOAD_PLAYER_DATA);
        dispatcher.Dispatch(NotificationType.MAIN_MENU_CRATE_NOTE);
    }
}