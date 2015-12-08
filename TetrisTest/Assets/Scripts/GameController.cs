using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

    public const int HORIZONTAL_SIZE = 10;
    public const int VERTICAL_SIZE = 20;
    public const int ADDITIONAL_FIELD = 4;

    public const int EMPTY_ELEMENT = 0;
    public const int FREE_ELEMENT = 1;
    public const int FIXED_ELEMENT = 2;

	private bool pressedUP = false;
	private bool pressedDOWN = false;
	private bool pressedLEFT = false;
	private bool pressedRIGHT = false;

    public RectTransform gameBackGround;

    private int[,] gameAreaModel = new int[VERTICAL_SIZE + ADDITIONAL_FIELD, HORIZONTAL_SIZE];
    private Image[,] gameAreaView = new Image[VERTICAL_SIZE + ADDITIONAL_FIELD, HORIZONTAL_SIZE];

	Vector2 tetraminoPosition = new Vector2();

    void Start () {
        Utilz.FillArea( gameBackGround, gameAreaView, HORIZONTAL_SIZE, VERTICAL_SIZE, ADDITIONAL_FIELD );
        Utilz.UpdateView( gameAreaModel, gameAreaView, HORIZONTAL_SIZE, VERTICAL_SIZE, ADDITIONAL_FIELD );
		int[,] currentTeramino = Utilz.Teramino7;
		currentTeramino = Utilz.RotateTeramino( currentTeramino );

		for( int i = 0; i < currentTeramino.GetLength(0); ++i ) {
			for( int j = 0; j < currentTeramino.GetLength(0); ++j ) {
				gameAreaModel[VERTICAL_SIZE + ADDITIONAL_FIELD - 1 - i, HORIZONTAL_SIZE / 2 + j] = currentTeramino[i, j];
			}
		}
		StartCoroutine( Step() );
	}

	IEnumerator Step() {
		while( true ) {
			yield return new WaitForSeconds( 0.5f );
			if( Utilz.IsBottom( gameAreaModel, HORIZONTAL_SIZE, VERTICAL_SIZE, ADDITIONAL_FIELD ) ) {
				Debug.Log( "bottom" );
				break;
			}
			Utilz.PullDown( gameAreaModel, HORIZONTAL_SIZE, VERTICAL_SIZE, ADDITIONAL_FIELD );
			Utilz.UpdateView( gameAreaModel, gameAreaView, HORIZONTAL_SIZE, VERTICAL_SIZE, ADDITIONAL_FIELD );
		}
	}

	void Update() {
		pressedUP = Input.GetKeyDown( KeyCode.UpArrow );
		pressedDOWN = Input.GetKeyDown( KeyCode.DownArrow );
		pressedLEFT = Input.GetKeyDown( KeyCode.LeftArrow );
		pressedRIGHT = Input.GetKeyDown( KeyCode.RightArrow );

		if( pressedLEFT ) {
			if( !Utilz.IsLeft( gameAreaModel, HORIZONTAL_SIZE, VERTICAL_SIZE, ADDITIONAL_FIELD ) ) {
				Utilz.PullLeft( gameAreaModel, HORIZONTAL_SIZE, VERTICAL_SIZE, ADDITIONAL_FIELD );
				Utilz.UpdateView( gameAreaModel, gameAreaView, HORIZONTAL_SIZE, VERTICAL_SIZE, ADDITIONAL_FIELD );
			}
		}

		if( pressedRIGHT ) {
			if( !Utilz.IsRight( gameAreaModel, HORIZONTAL_SIZE, VERTICAL_SIZE, ADDITIONAL_FIELD ) ) {
				Utilz.PullRight( gameAreaModel, HORIZONTAL_SIZE, VERTICAL_SIZE, ADDITIONAL_FIELD );
				Utilz.UpdateView( gameAreaModel, gameAreaView, HORIZONTAL_SIZE, VERTICAL_SIZE, ADDITIONAL_FIELD );
			}
		}
	}
}
