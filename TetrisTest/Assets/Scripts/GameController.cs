﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
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
	private bool unlockControl = true;

	public GameObject gameOverWindow;
	public Button ReturnToMenuButton;

    public RectTransform gameBackground;
	public RectTransform nextBackground;

	private FieldModel gameAreaModel;
	private FieldView gameAreaView;

	private FieldModel nextAreaModel;
	private FieldView nextAreaView;

	Tetramino currentTetramino;
	Tetramino nextTetramino;

	void Awake() {
		ReturnToMenuButton.onClick.AddListener( () => { SceneManager.LoadScene( "start" ); } );
	}

    void Start () {
		currentTetramino = new Tetramino( Vector2.zero );
		nextTetramino = new Tetramino( Vector2.zero );

		gameAreaModel = new FieldModel( VERTICAL_SIZE + Tetramino.TETRAMINO_MAX_SIZE, HORIZONTAL_SIZE );
		gameAreaView = new FieldView( gameBackground, VERTICAL_SIZE + Tetramino.TETRAMINO_MAX_SIZE, HORIZONTAL_SIZE );

		nextAreaModel = new FieldModel( Tetramino.TETRAMINO_MAX_SIZE, Tetramino.TETRAMINO_MAX_SIZE );
		nextAreaView = new FieldView( nextBackground, Tetramino.TETRAMINO_MAX_SIZE, Tetramino.TETRAMINO_MAX_SIZE );

		nextAreaView.UpdateView( nextAreaModel );
		ShowTetro( nextAreaModel, nextAreaView, nextTetramino );

		gameAreaView.UpdateView( gameAreaModel );

		currentTetramino.posY = gameAreaModel.Horizontal / 2 - currentTetramino.Horizontal / 2;
		currentTetramino.posX = Tetramino.TETRAMINO_MAX_SIZE - currentTetramino.Vertical;

		StartCoroutine( Step() );
	}

	IEnumerator Step() {
		while( true ) {
			yield return new WaitForSeconds( 0.5f );
			currentTetramino.posX += 1;
			if( gameAreaModel.TestTetramino( currentTetramino ) == false ) {
				currentTetramino.posX -= 1;
				if( currentTetramino.posX <= Tetramino.TETRAMINO_MAX_SIZE - 1 ) {
					GameOver();
					break;
				}
				gameAreaModel.PutTetramino( currentTetramino );
				currentTetramino = nextTetramino;
				nextTetramino = new Tetramino( Vector2.zero );
				gameAreaModel.RemoveLines();
				currentTetramino.posY = gameAreaModel.Horizontal / 2 - currentTetramino.Horizontal / 2;
				currentTetramino.posX = Tetramino.TETRAMINO_MAX_SIZE - currentTetramino.Vertical;
				ShowTetro( nextAreaModel, nextAreaView, nextTetramino );
			}
			ShowTetro( gameAreaModel, gameAreaView, currentTetramino );
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

		if( ( pressedRIGHT || pressedLEFT)  && unlockControl ) {
			int curPosY = currentTetramino.posY;
			currentTetramino.posY = tempPosY;
			if( gameAreaModel.TestTetramino( currentTetramino ) ) {
				ShowTetro( gameAreaModel, gameAreaView, currentTetramino );
			} else {
				currentTetramino.posY = curPosY;
			}
		}

		if( pressedUP && unlockControl ) {
			var newTetramino = currentTetramino.RotateTeramino();
			if( gameAreaModel.TestTetramino( newTetramino ) ) {
				currentTetramino = newTetramino;
			}
			if( gameAreaModel.TestTetramino( currentTetramino ) ) {
				ShowTetro( gameAreaModel, gameAreaView, currentTetramino );
			}
		}

		if( pressedDOWN && unlockControl ) {
			while( gameAreaModel.TestTetramino( currentTetramino ) ) {
				currentTetramino.posX += 1;
			}
			currentTetramino.posX -= 1;
		}
	}

	void ShowTetro( FieldModel areaModel, FieldView areaView, Tetramino currentTetramino ) {
		areaModel.PutTetramino( currentTetramino );
		areaView.UpdateView( areaModel );
		areaModel.GetTetramino( currentTetramino );
	}

	void GameOver() {
		unlockControl = false;
		gameOverWindow.SetActive( true );
	}
}
