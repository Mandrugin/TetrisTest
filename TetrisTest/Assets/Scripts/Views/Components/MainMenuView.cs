using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using UnityEngine.UI;

public class MainMenuView : View
{
    public Signal startButtonClickedSignal = new Signal();
    public Signal exitButtonClickedSignal = new Signal();

    public Button StartButton;
	public Button ExitButton;

    protected override void Awake() {
        base.Awake();

		StartButton.onClick.AddListener( () => { startButtonClickedSignal.Dispatch(); } );
		ExitButton.onClick.AddListener( () => { exitButtonClickedSignal.Dispatch(); } );
	}
}
