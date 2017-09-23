using strange.extensions.mediation.impl;

public class RecordMediator : Mediator
{
    [Inject]
    public RecordView recordView { get; set; }

    [Inject]
    public PlayerStats playerStats { get; set; }

    [Inject]
    public RecordWindowClosedSignal recordWindowClosedSignal { get; set; }

    public override void OnRegister()
    {
        recordView.okButtonClickedSignal.AddListener(Close);
        recordView.RecordText.text = playerStats.MaxScore.ToString();
    }

    public override void OnRemove()
    {
        recordView.okButtonClickedSignal.RemoveListener(Close);
        recordWindowClosedSignal.Dispatch();
    }

    private void Close()
    {
        Destroy(transform.parent.gameObject);
    }
}
