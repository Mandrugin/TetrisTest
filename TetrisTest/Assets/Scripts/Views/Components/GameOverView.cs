using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using UnityEngine.UI;

public class GameOverView : View
{
    public Signal buttonClicked = new Signal();

    public Text TitleText;
    public Button ActionButton;
    public Text ButtonText;

    [PostConstruct]
    public void Init()
    {
        TitleText.text = "Game Over";
        ButtonText.text = "Return to menu";
        ActionButton.onClick.AddListener(() => { buttonClicked.Dispatch(); });
    }
}
