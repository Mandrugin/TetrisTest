using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    // флаги нажания клавишь и состояния ввода
	private bool pressedUP = false;
	private bool pressedDOWN = false;
	private bool pressedLEFT = false;
	private bool pressedRIGHT = false;
	private bool unlockControl = true;

	private GameFieldProxy gameAreaModel;
	private NextFieldProxy nextAreaModel;

	void Awake() {
        AppFacade.Instance.SendNotification(NotificationType.INIT_GAME_SCENE_NOTE);

        gameAreaModel = AppFacade.Instance.RetrieveProxy(GameFieldProxy.NAME) as GameFieldProxy;
        nextAreaModel = AppFacade.Instance.RetrieveProxy(NextFieldProxy.NAME) as NextFieldProxy;
    }

    void Start () {
        StartCoroutine( Step() );
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
            GameOver(); // вынести в команду
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

	void GameOver() {
		unlockControl = false;
        StopAllCoroutines();
        AppFacade.Instance.RegisterMediator(new GameOverMediator());
    }
}
