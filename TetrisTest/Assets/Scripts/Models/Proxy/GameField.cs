﻿public class GameField : Field {

    private const int _verticalSize = ConstStorage.VERTICAL_SIZE + Tetramino.TETRAMINO_MAX_SIZE;
    private const int _horizontalSize = ConstStorage.HORIZONTAL_SIZE;

    [PostConstruct]
    public void PostConstruct()
    {
        SetFieldSize(_verticalSize, _horizontalSize);
        updateNote = NotificationType.GAME_FIELD_VIEW_UPDATE_NOTE;
    }
}
