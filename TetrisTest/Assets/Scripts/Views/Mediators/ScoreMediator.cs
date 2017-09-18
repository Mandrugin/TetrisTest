using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using UnityEngine;

public class ScoreMediator : EventMediator {

    [Inject]
    public ScoreView _viewView { get; set; }

    public override void OnRegister()
    {
        _viewView.UpdateScore(0);

        dispatcher.AddListener(NotificationType.SCORE_VIEW_UPDATE_NOTE, OnScoreUpdate);
        dispatcher.AddListener(NotificationType.DESTROY_SCORE_VIEW, OnSelfDestory);
    }

    public override void OnRemove()
    {
        dispatcher.RemoveListener(NotificationType.SCORE_VIEW_UPDATE_NOTE, OnScoreUpdate);
        dispatcher.RemoveListener(NotificationType.DESTROY_SCORE_VIEW, OnSelfDestory);
    }

    private void OnScoreUpdate(IEvent e)
    {
        _viewView.UpdateScore((int)e.data);
    }

    private void OnSelfDestory()
    {
        Destroy(transform.parent.gameObject);
    }
}
