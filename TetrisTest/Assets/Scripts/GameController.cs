using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

    public const int HORIZONTAL_SIZE = 10;
    public const int VERTICAL_SIZE = 20;

    public const int EMPTY_ELEMENT = 0;
    public const int FREE_ELEMENT = 1;

	private bool pressedUP = false;
	private bool pressedDOWN = false;
	private bool pressedLEFT = false;
	private bool pressedRIGHT = false;

    public RectTransform gameBackGround;

    private int[,] gameAreaModel = new int[VERTICAL_SIZE + Tetramino.TETRAMINO_MAX_SIZE, HORIZONTAL_SIZE];
	private Image[,] gameAreaView = new Image[VERTICAL_SIZE + Tetramino.TETRAMINO_MAX_SIZE, HORIZONTAL_SIZE];

	Tetramino currentTetramino;
	Tetramino nextTetramino;

    void Start () {
		currentTetramino = new Tetramino( Vector2.zero );
		nextTetramino = new Tetramino( Vector2.zero );

        Utilz.FillArea( gameBackGround, gameAreaView );
        Utilz.UpdateView( gameAreaModel, gameAreaView );
		StartCoroutine( Step() );
	}

	IEnumerator Step() {
		while( true ) {
			yield return new WaitForSeconds( 0.2f );
			currentTetramino.posX += 1;
			if( Utilz.TestTetramino( gameAreaModel, currentTetramino ) == false ) {
				currentTetramino.posX -= 1;
				Utilz.PutTetramino( gameAreaModel, currentTetramino );
				currentTetramino = nextTetramino;
				nextTetramino = new Tetramino( Vector2.zero );
				Utilz.RemoveLines( gameAreaModel );
			}
			ShowTetro( gameAreaModel, currentTetramino );
		}
	}

	void Update() {
		pressedUP = Input.GetKeyDown( KeyCode.UpArrow );
		pressedDOWN = Input.GetKeyDown( KeyCode.DownArrow );
		pressedLEFT = Input.GetKeyDown( KeyCode.LeftArrow );
		pressedRIGHT = Input.GetKeyDown( KeyCode.RightArrow );

		int tempPosY = currentTetramino.posY;

		if( pressedLEFT ) {
			tempPosY -= 1;
		}

		if( pressedRIGHT ) {
			tempPosY += 1;
		}

		if( pressedRIGHT || pressedLEFT ) {
			int curPosY = currentTetramino.posY;
			currentTetramino.posY = tempPosY;
			if( Utilz.TestTetramino( gameAreaModel, currentTetramino ) ) {
				ShowTetro( gameAreaModel, currentTetramino );
			} else {
				currentTetramino.posY = curPosY;
			}
		}

		if( pressedUP ) {
			var newTetramino = currentTetramino.RotateTeramino();
			if( Utilz.TestTetramino( gameAreaModel, newTetramino ) ) {
				currentTetramino = newTetramino;
			}
			if( Utilz.TestTetramino( gameAreaModel, currentTetramino ) ) {
				ShowTetro( gameAreaModel, currentTetramino );
			}
		}

		if( pressedDOWN ) {
			while( Utilz.TestTetramino( gameAreaModel, currentTetramino ) ) {
				currentTetramino.posX += 1;
			}
			currentTetramino.posX -= 1;
		}
	}

	void ShowTetro( int[,] gameAreaModel, Tetramino currentTetramino ) {
		Utilz.PutTetramino( gameAreaModel, currentTetramino );
		Utilz.UpdateView( gameAreaModel, gameAreaView );
		Utilz.GetTetramino( gameAreaModel, currentTetramino );
	}
}
