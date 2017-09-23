public class GameField : Field
{
    private const int _verticalSize = ConstStorage.VERTICAL_SIZE + Tetramino.TETRAMINO_MAX_SIZE;
    private const int _horizontalSize = ConstStorage.HORIZONTAL_SIZE;

    [Inject]
    public GameFieldUpdateSignal gameFieldUpdateSignal { get; set; }

    [PostConstruct]
    public void PostConstruct()
    {
        updateNote = gameFieldUpdateSignal;
    }

    public override void Init()
    {
        base.Init();
        SetFieldSize(_verticalSize, _horizontalSize);
    }
}
