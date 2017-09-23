using strange.extensions.command.impl;

public class LoadPlayerDataCommand : EventCommand
{
    [Inject]
    public IDataSaver _datatSaver { get; set; }

    [Inject]
    public PlayerStats _playerStats { get; set; }

    public override void Execute()
    {
        _playerStats.LoadFromJson(_datatSaver.LoadString(typeof(PlayerStats).Name, "{}"));
    }
}