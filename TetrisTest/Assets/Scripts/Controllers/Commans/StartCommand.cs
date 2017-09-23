using strange.extensions.command.impl;

public class StartCommand : Command
{
    [Inject]
    public LoadPlayerDataSignal loadPlayerDataSignal { get; set; }

    [Inject]
    public CreateMainMenuSignal createMainMenuSignal { get; set; }

    public override void Execute()
    {
        loadPlayerDataSignal.Dispatch();
        createMainMenuSignal.Dispatch();
    }
}