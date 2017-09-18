﻿using UnityEngine;
using System.Collections;
using strange.extensions.context.api;
using strange.extensions.dispatcher.eventdispatcher.api;

public class GameController : MonoBehaviour {

    // флаги нажания клавишь и состояния ввода
	private bool pressedUP = false;
	private bool pressedDOWN = false;
	private bool pressedLEFT = false;
	private bool pressedRIGHT = false;
	private bool unlockControl = true;

    [Inject]
    public Score score { get; set; }

    [Inject("GAME_FIELD")]
	public IField gameAreaModel { get; set; }

    [Inject("NEXT_FIELD")]
	public IField nextAreaModel { get; set; }

    [Inject(ContextKeys.CONTEXT_DISPATCHER)]
    public IEventDispatcher contextDispatcher { get; set; }

    [PostConstruct]
	public void PostConstruct() {
        StartCoroutine(Step());
        contextDispatcher.AddListener(NotificationType.GAME_OVER_NOTE, OnGameOver);
    }

    void OnDestroy()
    {
        contextDispatcher.RemoveListener(NotificationType.GAME_OVER_NOTE, OnGameOver);
    }

    /// <summary>
    /// Игровой шаг.
    /// </summary>
    /// <remarks>
    /// Через равные промежутки времени тетрамино сдвигается на одну позицию вниз
    /// и происходит перерасчет игрового состояния
    /// </remarks>
    /// <returns></returns>
	IEnumerator Step() {
        yield return new WaitForSeconds(ConstStorage.STEP_TIME);
        gameAreaModel.Init();
        nextAreaModel.Init();
        while ( true ) {
			yield return new WaitForSeconds( ConstStorage.STEP_TIME );
            gameAreaModel.TetraminoMoveDown();
			if( gameAreaModel.TestTetramino() == false ) {
                gameAreaModel.TetraminoMoveUp();
                CheckEndGame();
			}
        }
	}

    void CheckEndGame()
    {
        if (gameAreaModel.IsTetraminoTop)
        {
            contextDispatcher.Dispatch(NotificationType.GAME_OVER_NOTE);
        }
        else
        {
            gameAreaModel.FixTetramino();
            gameAreaModel.NewTetramino(nextAreaModel.TetraminoNumber);
            nextAreaModel.NewTetramino();
            gameAreaModel.RemoveLines();
        }
    }

	void Update() {
		pressedUP = Input.GetKeyDown( KeyCode.UpArrow );
		pressedDOWN = Input.GetKeyDown( KeyCode.DownArrow );
		pressedLEFT = Input.GetKeyDown( KeyCode.LeftArrow );
		pressedRIGHT = Input.GetKeyDown( KeyCode.RightArrow );

		if( pressedLEFT && unlockControl ) {
            gameAreaModel.TetraminoMoveLeft();
            if (!gameAreaModel.TestTetramino())
                gameAreaModel.TetraminoMoveRight();
		}

		if( pressedRIGHT && unlockControl ) {
            gameAreaModel.TetraminoMoveRight();
            if (!gameAreaModel.TestTetramino())
                gameAreaModel.TetraminoMoveLeft();
        }

		if( pressedUP && unlockControl ) {
            gameAreaModel.TryToRotateTetramino();
        }

		if( pressedDOWN && unlockControl ) {
            gameAreaModel.TryDownTetramino();
            CheckEndGame();
		}
	}

	void OnGameOver() {
        unlockControl = false;
        StopAllCoroutines();
        Destroy(gameObject);
    }
}
