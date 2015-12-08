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

	int[,] currentTetramino = Utilz.Tetramino7;
	int[,] nextTetramino;

    void Start () {
        Utilz.FillArea( gameBackGround, gameAreaView );
        Utilz.UpdateView( gameAreaModel, gameAreaView );
		StartCoroutine( Step() );
	}

	IEnumerator Step() {
		while( true ) {
			yield return new WaitForSeconds( 0.5f );
			tetraminoPosition.x += 1;
			if( Utilz.TestTetramino( gameAreaModel, currentTetramino, tetraminoPosition ) == false )
				break;
			ShowTetro( gameAreaModel, currentTetramino, tetraminoPosition );
		}
	}

	void Update() {
		pressedUP = Input.GetKeyDown( KeyCode.UpArrow );
		pressedDOWN = Input.GetKeyDown( KeyCode.DownArrow );
		pressedLEFT = Input.GetKeyDown( KeyCode.LeftArrow );
		pressedRIGHT = Input.GetKeyDown( KeyCode.RightArrow );

		Vector2 tempPos = tetraminoPosition;

		if( pressedLEFT ) {
			tempPos.y -= 1;
		}

		if( pressedRIGHT ) {
			tempPos.y += 1;
		}

		if( pressedRIGHT || pressedLEFT ) {
			if( Utilz.TestTetramino( gameAreaModel, currentTetramino, tempPos ) ) {
				tetraminoPosition = tempPos;
				ShowTetro( gameAreaModel, currentTetramino, tetraminoPosition );
			}
		}

		if( pressedUP ) {
			var newTetramino = Utilz.RotateTeramino( currentTetramino );
			if( Utilz.TestTetramino( gameAreaModel, newTetramino, tetraminoPosition ) ) {
				currentTetramino = newTetramino;
			}
			if( Utilz.TestTetramino( gameAreaModel, currentTetramino, tetraminoPosition ) ) {
				ShowTetro( gameAreaModel, currentTetramino, tetraminoPosition );
			}

		}
	}

	void ShowTetro( int[,] gameAreaModel, int[,] currentTetramino, Vector2 tetraminoPosition ) {
		Utilz.PutTetramino( gameAreaModel, currentTetramino, tetraminoPosition );
		Utilz.UpdateView( gameAreaModel, gameAreaView );
		Utilz.GetTetramino( gameAreaModel, currentTetramino, tetraminoPosition );
	}
}
