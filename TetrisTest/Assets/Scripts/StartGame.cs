using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour {

	public Button StartButton;
	public Button ExitButton;

	void Awake() {
		StartButton.onClick.AddListener( () => { Application.LoadLevel( "main" ); } );
		ExitButton.onClick.AddListener( () => { Application.Quit(); } );
	}
}
