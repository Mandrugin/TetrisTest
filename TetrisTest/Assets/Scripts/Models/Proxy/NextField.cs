﻿public class NextField : Field {

    private const int _verticalSize = Tetramino.TETRAMINO_MAX_SIZE;
    private const int _horizontalSize = Tetramino.TETRAMINO_MAX_SIZE;

    public NextField()
        :base(_verticalSize, _horizontalSize)
    {
        updateNote = NotificationType.NEXT_FIELD_VIEW_UPDATE_NOTE;
    }
}