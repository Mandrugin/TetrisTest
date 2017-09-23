using strange.extensions.command.impl;

public class CheckPlayerRecordsCommand : Command
{
    [Inject]
    public Score _score { get; set; }

    [Inject]
    public PlayerStats _playerStats { get; set; }

    [Inject]
    public SavePlayerDataSignal savePlayerDataSignal { get; set; }

    [Inject]
    public CreateRecordViewSignal createRecordViewSignal { get; set; }

    [Inject]
    public RecordWindowClosedSignal recordWindowClosedSignal { get; set; }

    public override void Execute()
    {
        if (_playerStats.MaxScore >= _score.score)
            return;

        Retain();

        _playerStats.MaxScore = _score.score;
        savePlayerDataSignal.Dispatch();
        createRecordViewSignal.Dispatch();
        recordWindowClosedSignal.AddListener(OnRecordWindowClosed);
    }

    void OnRecordWindowClosed()
    {
        recordWindowClosedSignal.RemoveListener(OnRecordWindowClosed);
        Release();
    }
}