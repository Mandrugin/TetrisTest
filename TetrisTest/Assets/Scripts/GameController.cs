using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public const int HORIZONTAL_SIZE = 10;
    public const int VERTICAL_SIZE = 20;
    public const int ADDITIONAL_FIELD = 4;

    public const int EMPTY_ELEMENT = 0;
    public const int FREE_ELEMENT = 1;
    public const int FIXED_ELEMENT = 2;

    public RectTransform gameBackGround;

    private int[,] gameAreaModel = new int[VERTICAL_SIZE + ADDITIONAL_FIELD, HORIZONTAL_SIZE];
    private Image[,] gameAreaView = new Image[VERTICAL_SIZE + ADDITIONAL_FIELD, HORIZONTAL_SIZE];

    void Start () {
        Utilz.FillArea( gameBackGround, gameAreaView, HORIZONTAL_SIZE, VERTICAL_SIZE, ADDITIONAL_FIELD );
        Utilz.UpdateView( gameAreaModel, gameAreaView, HORIZONTAL_SIZE, VERTICAL_SIZE, ADDITIONAL_FIELD );
	}
}
