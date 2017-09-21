using UnityEngine;
using System.Collections;
using strange.extensions.context.api;
using strange.extensions.dispatcher.eventdispatcher.api;

public class GameController : MonoBehaviour {

    [Inject]
    public Score score { get; set; }

    [Inject("GAME_FIELD")]
	public IField gameAreaModel { get; set; }

    [Inject("NEXT_FIELD")]
	public IField nextAreaModel { get; set; }

    [Inject]
    public IInputController controller { get; set; }

    [Inject(ContextKeys.CONTEXT_DISPATCHER)]
    public IEventDispatcher contextDispatcher { get; set; }

    [PostConstruct]
	public void PostConstruct() {
        controller.SetLock(false);
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
		if( controller.IsLeft() ) {
            gameAreaModel.TetraminoMoveLeft();
            if (!gameAreaModel.TestTetramino())
                gameAreaModel.TetraminoMoveRight();
		}

		if( controller.IsRight() ) {
            gameAreaModel.TetraminoMoveRight();
            if (!gameAreaModel.TestTetramino())
                gameAreaModel.TetraminoMoveLeft();
        }

		if( controller.IsUp() ) {
            gameAreaModel.TryToRotateTetramino();
        }

		if( controller.IsDown() ) {
            gameAreaModel.TryDownTetramino();
            CheckEndGame();
		}
	}

	void OnGameOver() {
        controller.SetLock(true);
        StopAllCoroutines();
        Destroy(gameObject);
    }
}
