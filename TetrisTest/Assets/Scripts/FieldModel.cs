
public class FieldModel {

	public int[,] field;

	private int vertical;
	private int horizontal;
	public int Vertical { get{ return vertical; } }
	public int Horizontal { get{ return horizontal; } }


	public FieldModel( int verticalSize, int horizontalSize ) {
		vertical = verticalSize;
		horizontal = horizontalSize;
		field = new int[vertical, horizontal];

		for( int i = 0; i < vertical; ++i ) {
			for( int j = 0; j < horizontal; ++ j ) {
				field[i, j] = GameController.EMPTY_ELEMENT;
			}
		}
	}

	public void PutTetramino( Tetramino tetramino ) {
		for( int i = tetramino.posX; i < tetramino.posX + tetramino.Vertical; ++ i ) {
			for( int j = tetramino.posY; j < tetramino.posY + tetramino.Horizontal; ++ j ) {
				bool outOfRange = i < 0 || j < 0 || i >= Vertical || j >= Horizontal;
				
				if( tetramino.Temaplate[ i - tetramino.posX, j - tetramino.posY ] == GameController.FREE_ELEMENT && !outOfRange ) {
					field[i, j] = GameController.FREE_ELEMENT;
				}
			}
		}
	}
	
	public void GetTetramino( Tetramino tetramino ) {
		for( int i = tetramino.posX; i < tetramino.posX + tetramino.Vertical; ++ i ) {
			for( int j = tetramino.posY; j < tetramino.posY + tetramino.Horizontal; ++ j ) {
				bool outOfRange = i < 0 || j < 0 || i >= Vertical || j >= Horizontal;
				if( tetramino.Temaplate[ i - tetramino.posX, j - tetramino.posY ] == GameController.FREE_ELEMENT && !outOfRange ) {
					field[i, j] = GameController.EMPTY_ELEMENT;
				}
			}
		}
	}
	
	public bool TestTetramino( Tetramino tetramino ) {
		for( int i = tetramino.posX; i < tetramino.posX + tetramino.Vertical; ++ i ) {
			for( int j = tetramino.posY; j < tetramino.posY + tetramino.Horizontal; ++ j ) {
				bool outOfRange = i < 0 || j < 0 || i >= Vertical || j >= Horizontal;
				if( tetramino.Temaplate[ i - tetramino.posX, j - tetramino.posY ] == GameController.FREE_ELEMENT &&
				   ( outOfRange || field[i, j] != GameController.EMPTY_ELEMENT ) ) {
					return false;
				}
			}
		}
		return true;
	}

	public void RemoveLines() {
		int fullLine = CheckLines();
		while( fullLine  > -1 ) {
			RemoveLine( fullLine );
			fullLine = CheckLines();
		}
	}
	
	private int CheckLines() {
		for( int i = 0; i < vertical; ++i ) {
			bool fullLine = true;
			for( int j = 0; j < horizontal; ++j ) {
				if( field[i, j] == GameController.EMPTY_ELEMENT ) {
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
