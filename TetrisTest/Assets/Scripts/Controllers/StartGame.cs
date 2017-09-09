//TODO: ВЫВЕСТИ В МЕДИАТОР

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {

	public Button StartButton;
	public Button ExitButton;

	void Awake() {
		StartButton.onClick.AddListener( () => { SceneManager.LoadScene( "main" ); } );
		ExitButton.onClick.AddListener( () => { Application.Quit(); } );
	}
}
