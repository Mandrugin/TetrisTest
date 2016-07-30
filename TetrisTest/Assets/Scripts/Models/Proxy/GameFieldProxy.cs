public class GameFieldProxy : FieldProxy {

    new public const string NAME = "GameFieldProxy";

    private const int _verticalSize = ConstStorage.VERTICAL_SIZE + Tetramino.TETRAMINO_MAX_SIZE;
    private const int _horizontalSize = ConstStorage.HORIZONTAL_SIZE;

    public GameFieldProxy()
        :base(_verticalSize, _horizontalSize, NAME)
    {
        updateNote = NotificationType.GAME_FIELD_VIEW_UPDATE_NOTE;
    }
}
