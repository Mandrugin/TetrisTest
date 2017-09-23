using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using UnityEngine.UI;

public class InputView : View
{
    public Signal upButtonClicked = new Signal();
    public Signal downButtonClicked = new Signal();
    public Signal leftButtonClicked = new Signal();
    public Signal rightButtonClicked = new Signal();

    public Button UpButton;
    public Button DownButton;
    public Button LeftButton;
    public Button RightButton;

    [PostConstruct]
    public void PostConstruct()
    {
        UpButton.onClick.AddListener(() => upButtonClicked.Dispatch());
        DownButton.onClick.AddListener(() => downButtonClicked.Dispatch());
        LeftButton.onClick.AddListener(() => leftButtonClicked.Dispatch());
        RightButton.onClick.AddListener(() => rightButtonClicked.Dispatch());
    }
}
