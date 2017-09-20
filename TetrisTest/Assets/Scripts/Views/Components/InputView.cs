using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using UnityEngine.UI;

public class InputView : View
{
    public enum Events
    {
        UP_BUTTON_CLICKED,
        DOWN_BUTTON_CLICKED,
        LEFT_BUTTON_CLICKED,
        RIGHT_BUTTON_CLICKED
    }

    [Inject]
    public IEventDispatcher dispatcher { get; set; }

    public Button UpButton;
    public Button DownButton;
    public Button LeftButton;
    public Button RightButton;

    [PostConstruct]
    public void PostConstruct()
    {
        UpButton.onClick.AddListener(() => dispatcher.Dispatch(Events.UP_BUTTON_CLICKED));
        DownButton.onClick.AddListener(() => dispatcher.Dispatch(Events.DOWN_BUTTON_CLICKED));
        LeftButton.onClick.AddListener(() => dispatcher.Dispatch(Events.LEFT_BUTTON_CLICKED));
        RightButton.onClick.AddListener(() => dispatcher.Dispatch(Events.RIGHT_BUTTON_CLICKED));
    }
}
