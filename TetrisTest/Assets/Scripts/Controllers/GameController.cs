using UnityEngine;
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

    [Inject("GAME_FIELD")]
	public Field gameAreaModel { get; set; }

    [Inject("NEXT_FIELD")]
	private Field nextAreaModel { get; set; }

    [Inject(ContextKeys.CONTEXT_DISPATCHER)]
    private IEventDispatcher contextDispatcher { get; set; }

    [PostConstruct]
	void PostConstruct() {
        contextDispatcher.Dispatch(NotificationType.INIT_GAME_SCENE_NOTE);
        StartCoroutine(Step());
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
		while( true ) {
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
            OnGameOver();
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
    }
}
