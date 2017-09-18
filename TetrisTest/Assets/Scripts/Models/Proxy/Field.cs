using UnityEngine;
using strange.extensions.context.api;
using strange.extensions.dispatcher.eventdispatcher.api;

/// <summary>
/// Класс представляющий и управляющий моделью игрового поля
/// содержит двумерный массив целых чисел который и абстрагирует игровое поле,
/// также содержит тетрамино которое находится на игровом поле
/// </summary>
public class Field : IField
{
    [Inject(ContextKeys.CONTEXT_DISPATCHER)]
    public IEventDispatcher contextDispatcher { get; set; }

    private Tetramino tetramino;

    private int[,] field;
	private int vertical;
	private int horizontal;

    public int TetraminoNumber { get { return tetramino.Number; } }
    public bool IsTetraminoTop { get { return tetramino.posY <= Tetramino.TETRAMINO_MAX_SIZE - 1; } }

    protected string updateNote = "";

    public virtual void Init()
    {
        // ...
    }

    public void TetraminoMoveUp()
    {
        tetramino.posY -= 1;
    }

    public void TetraminoMoveDown()
    {
        tetramino.posY += 1;
    }

    public void TetraminoMoveLeft()
    {
        tetramino.posX -= 1;
    }

    public void TetraminoMoveRight()
    {
        tetramino.posX += 1;
    }

    /// <summary>
    /// создает массив нужной размерности и заполняет его
    /// значениями означающими пустую ячейку
    /// </summary>
    /// <param name="verticalSize"></param>
    /// <param name="horizontalSize"></param>
	public void SetFieldSize( int verticalSize, int horizontalSize)
    {
		vertical = verticalSize;
		horizontal = horizontalSize;
		field = new int[vertical, horizontal];

		for( int i = 0; i < vertical; ++i ) {
			for( int j = 0; j < horizontal; ++ j ) {
				field[i, j] = ConstStorage.EMPTY_ELEMENT;
			}
		}

        NewTetramino();
    }

    public void NewTetramino(int number = -1)
    {
        tetramino = new Tetramino(Vector2.zero, number);
        tetramino.posX = horizontal / 2 - tetramino.Horizontal / 2;
        tetramino.posY = Tetramino.TETRAMINO_MAX_SIZE - tetramino.Vertical;
        contextDispatcher.Dispatch(updateNote, GetField());
    }

    public void FixTetramino()
    {
        PutTetramino(field);
    }

    /// <summary>
    /// "Кладет" тетрамино на игровое поле, не совершает
    /// дополнительных проверок
    /// </summary>
    /// <param name="tetramino"></param>
	private void PutTetramino(int[,] field) {
		for( int i = tetramino.posY; i < tetramino.posY + tetramino.Vertical; ++ i ) {
			for( int j = tetramino.posX; j < tetramino.posX + tetramino.Horizontal; ++ j ) {
				bool outOfRange = i < 0 || j < 0 || i >= vertical || j >= horizontal;
				
				if( tetramino.Temaplate[ i - tetramino.posY, j - tetramino.posX ] == ConstStorage.FREE_ELEMENT && !outOfRange ) {
					field[i, j] = ConstStorage.FREE_ELEMENT;
				}
			}
		}
	}
	
    /// <summary>
    /// "Снимает" тетрамино с игрового поля
    /// </summary>
    /// <param name="tetramino"></param>
    /// <remarks>
    /// использовалась раньше на данный момент не используется
    /// </remarks>
	private void GetTetramino() {
		for( int i = tetramino.posY; i < tetramino.posY + tetramino.Vertical; ++ i ) {
			for( int j = tetramino.posX; j < tetramino.posX + tetramino.Horizontal; ++ j ) {
				bool outOfRange = i < 0 || j < 0 || i >= vertical || j >= horizontal;
				if( tetramino.Temaplate[ i - tetramino.posY, j - tetramino.posX ] == ConstStorage.FREE_ELEMENT && !outOfRange ) {
					field[i, j] = ConstStorage.EMPTY_ELEMENT;
				}
			}
		}
	}

    private int[,] GetField()
    {
        int[,] _field = new int[vertical, horizontal];
        Copy(_field, field);
        PutTetramino(_field);
        return _field;
    }

    private void Copy(int[,] dst, int[,] src)
    {
        for(int i = 0; i < vertical; ++i)
        {
            for(int j = 0; j < horizontal; ++j)
            {
                dst[i, j] = src[i, j];
            }
        }
    }
	
    /// <summary>
    /// Проверяет можно ли положить тетрамино
    /// на игровое поле
    /// </summary>
    /// <param name="tetramino"></param>
    /// <returns>
    /// Возвращает true в случае если тетрамино можно
    /// положить на игровое поле и false в противном случае
    /// </returns>
    private bool Test()
    {
        for (int i = tetramino.posY; i < tetramino.posY + tetramino.Vertical; ++i)
        {
            for (int j = tetramino.posX; j < tetramino.posX + tetramino.Horizontal; ++j)
            {
                bool outOfRange = i < 0 || j < 0 || i >= vertical || j >= horizontal;
                if (tetramino.Temaplate[i - tetramino.posY, j - tetramino.posX] == ConstStorage.FREE_ELEMENT &&
                   (outOfRange || field[i, j] != ConstStorage.EMPTY_ELEMENT))
                {
                    return false;
                }
            }
        }
        return true;
    }

    public bool TestTetramino()
    {
        if (Test())
        {
            contextDispatcher.Dispatch(updateNote, GetField());
            return true;
        }
        else
            return false;
    }

    public bool TryToRotateTetramino()
    {
        Tetramino temp = tetramino;
        tetramino = tetramino.RotateTeramino();
        if (Test())
        {
            contextDispatcher.Dispatch(updateNote, GetField());
            return true;
        }
        else
        {
            tetramino = temp;
            return false;
        }
    }

    public void TryDownTetramino()
    {
        while (Test())
        {
            tetramino.posY += 1;
        }
        tetramino.posY -= 1;
        contextDispatcher.Dispatch(updateNote, GetField());
    }

	public void RemoveLines() {
        int linesCount = 0;
		int fullLine = CheckLines();
		while( fullLine  > -1 ) {
			RemoveLine( fullLine );
			fullLine = CheckLines();
            linesCount += 1;
		}
        if (linesCount > 0)
	        contextDispatcher.Dispatch(NotificationType.GET_SCORE_LINES_REMOVED_NOTE, linesCount);
	}
	
	private int CheckLines() {
		for( int i = 0; i < vertical; ++i ) {
			bool fullLine = true;
			for( int j = 0; j < horizontal; ++j ) {
				if( field[i, j] == ConstStorage.EMPTY_ELEMENT ) {
					fullLine = false;
					break;
				}
			}
			if( fullLine ) {
				return i;
			}
		}
		
		return -1;
	}
	
	private void RemoveLine( int lineNumber ) {
		for( int i = lineNumber; i > 0; --i ) {
			for( int j = 0; j < horizontal; ++j ) {
				field[i, j] = field[i - 1, j];
			}
		}
	}
}
