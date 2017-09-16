using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;

public class ScoreMediator : EventMediator {

    [Inject]
    public ScoreView _viewView { get; set; }

    public override void OnRegister()
    {
        _viewView.UpdateScore(0);

        dispatcher.AddListener(NotificationType.SCORE_VIEW_UPDATE_NOTE, OnScoreUpdate);
    }

    public override void OnRemove()
    {
        dispatcher.RemoveListener(NotificationType.SCORE_VIEW_UPDATE_NOTE, OnScoreUpdate);
    }

    private void OnScoreUpdate(IEvent e)
    {
        _viewView.UpdateScore((int)e.data);
    }
}
