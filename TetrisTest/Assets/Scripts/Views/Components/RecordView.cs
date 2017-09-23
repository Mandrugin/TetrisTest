using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using UnityEngine.UI;

public class RecordView : View
{
    public enum Events
    {
        OK_BUTTON_CLICKED
    }

    [Inject]
    public IEventDispatcher dispatcher { get; set; }

    public Text RecordText;
    public Button OkButton;

    protected override void Awake()
    {
        base.Awake();
        OkButton.onClick.AddListener(() => dispatcher.Dispatch(Events.OK_BUTTON_CLICKED));
    }
}
