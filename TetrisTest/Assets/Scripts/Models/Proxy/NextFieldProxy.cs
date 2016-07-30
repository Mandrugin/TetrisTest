public class NextFieldProxy : FieldProxy {

    new public const string NAME = "NextFieldProxy";

    private const int _verticalSize = Tetramino.TETRAMINO_MAX_SIZE;
    private const int _horizontalSize = Tetramino.TETRAMINO_MAX_SIZE;

    public NextFieldProxy()
        :base(_verticalSize, _horizontalSize, NAME)
    {
        updateNote = NotificationType.NEXT_FIELD_VIEW_UPDATE_NOTE;
    }
}
