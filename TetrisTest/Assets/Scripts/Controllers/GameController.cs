using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    [Inject]
    public Score score { get; set; }

    [Inject("GAME_FIELD")]
	public IField gameAreaModel { get; set; }

    [Inject("NEXT_FIELD")]
	public IField nextAreaModel { get; set; }

    [Inject]
    public IInputController controller { get; set; }

    [Inject]
    public GameOverSignal gameOverSignal { get; set; }

    [PostConstruct]
	public void PostConstruct() {
        controller.SetLock(false);
        StartCoroutine(Step());
        gameOverSignal.AddListener(OnGameOver);
    }

    void OnDestroy()
    {
        gameOverSignal.RemoveListener(OnGameOver);
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
            gameOverSignal.Dispatch();
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
