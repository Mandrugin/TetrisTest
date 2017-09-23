public class NextField : Field
{
    private const int _verticalSize = Tetramino.TETRAMINO_MAX_SIZE;
    private const int _horizontalSize = Tetramino.TETRAMINO_MAX_SIZE;

    [Inject]
    public NextFieldUpdateSignal nextFieldUpdateSignal { get; set; }

    [PostConstruct]
    public void PostConstruct()
    {
        updateNote = nextFieldUpdateSignal;
    }

    public override void Init()
    {
        base.Init();
        SetFieldSize(_verticalSize, _horizontalSize);
    }
}
