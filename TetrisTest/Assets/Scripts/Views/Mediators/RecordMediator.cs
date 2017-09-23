using strange.extensions.mediation.impl;

public class RecordMediator : EventMediator
{
    [Inject]
    public RecordView recordView { get; set; }

    [Inject]
    public PlayerStats playerStats { get; set; }

    public override void OnRegister()
    {
        recordView.dispatcher.AddListener(RecordView.Events.OK_BUTTON_CLICKED, Close);
        recordView.RecordText.text = playerStats.MaxScore.ToString();
    }

    public override void OnRemove()
    {
        recordView.dispatcher.RemoveListener(RecordView.Events.OK_BUTTON_CLICKED, Close);
        dispatcher.Dispatch(NotificationType.RECORD_WINDOW_CLOSED_NOTE);
    }

    private void Close()
    {
        Destroy(transform.parent.gameObject);
    }
}
