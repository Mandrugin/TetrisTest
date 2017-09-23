using strange.extensions.command.impl;
using UnityEngine;

public class CheckPlayerRecordsCommand : EventCommand
{
    [Inject]
    public Score _score { get; set; }

    [Inject]
    public PlayerStats _playerStats { get; set; }

    public override void Execute()
    {
        if (_playerStats.MaxScore >= _score.score)
            return;

        Retain();

        _playerStats.MaxScore = _score.score;
        dispatcher.Dispatch(NotificationType.SAVE_PLAYER_DATA);
        dispatcher.Dispatch(NotificationType.CREATE_RECORD_VIEW_NOTE);
        dispatcher.AddListener(NotificationType.RECORD_WINDOW_CLOSED_NOTE, OnRecordWindowClosed);
    }

    void OnRecordWindowClosed()
    {
        dispatcher.RemoveListener(NotificationType.RECORD_WINDOW_CLOSED_NOTE, OnRecordWindowClosed);
        Release();
    }
}