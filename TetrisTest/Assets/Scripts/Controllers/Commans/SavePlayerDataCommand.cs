using strange.extensions.command.impl;

public class SavePlayerDataCommand : Command
{
    [Inject]
    public IDataSaver _datatSaver { get; set; }

    [Inject]
    public PlayerStats _playerStats { get; set; }

    [Inject]
    public Score _score { get; set; }

    public override void Execute()
    {
        _playerStats.MaxScore = _score.score;

        _datatSaver.SaveString(typeof(PlayerStats).Name, _playerStats.SaveToString());
    }
}