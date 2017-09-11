using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using UnityEngine.UI;

public class MainMenuView : View {

    public enum Events
    {
        START_BUTTON_CLICKED,
        EXIT_BUTTON_CLICKED
    }

    [Inject]
    public IEventDispatcher dispatcher { get; set; }

    public Button StartButton;
	public Button ExitButton;

    protected override void Awake() {
        base.Awake();

		StartButton.onClick.AddListener( () => { dispatcher.Dispatch(Events.START_BUTTON_CLICKED); } );
		ExitButton.onClick.AddListener( () => { dispatcher.Dispatch(Events.EXIT_BUTTON_CLICKED); } );
	}
}
