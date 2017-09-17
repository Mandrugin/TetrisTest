using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using UnityEngine.UI;

public class GameOverView : View {

    public enum Events
    {
        BUTTON_CLICKED
    }

    [Inject]
    public IEventDispatcher dispatcher { get; set; }

    public Text TitleText;
    public Button ActionButton;
    public Text ButtonText;

    [PostConstruct]
    public void Init()
    {
        TitleText.text = "Game Over";
        ButtonText.text = "Return to menu";
        ActionButton.onClick.AddListener(() => {
            dispatcher.Dispatch(Events.BUTTON_CLICKED);
        });
    }
}
