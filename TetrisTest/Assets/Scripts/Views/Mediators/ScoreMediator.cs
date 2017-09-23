using strange.extensions.mediation.impl;

public class ScoreMediator : Mediator
{
    [Inject]
    public ScoreView _viewView { get; set; }

    [Inject]
    public ScoreViewUpdateSignal scoreViewUpdateSignal { get; set; }

    [Inject]
    public DestroyScoreViewSignal destroyScoreViewSignal { get; set; }

    public override void OnRegister()
    {
        _viewView.UpdateScore(0);

        scoreViewUpdateSignal.AddListener(OnScoreUpdate);
        destroyScoreViewSignal.AddListener(OnSelfDestory);
    }

    public override void OnRemove()
    {
        scoreViewUpdateSignal.RemoveListener(OnScoreUpdate);
        destroyScoreViewSignal.RemoveListener(OnSelfDestory);
    }

    private void OnScoreUpdate(int score)
    {
        _viewView.UpdateScore(score);
    }

    private void OnSelfDestory()
    {
        Destroy(transform.parent.gameObject);
    }
}
