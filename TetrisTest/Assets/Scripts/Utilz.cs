using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public static class Utilz {

    public static void FillArea( RectTransform rect, Image[,] gameAreaView ) {
		int vertical = gameAreaView.GetLength( 0 );
		int horizontal = gameAreaView.GetLength( 1 );
        float verticalSize = rect.rect.size.y / vertical;
        float horizontalSize = rect.rect.size.x / horizontal;
        for( int i = 0; i < vertical; ++i ) {
            for( int j = 0; j < horizontal; ++j ) {
                GameObject go = new GameObject( "rect[" + i.ToString() + ", " + j.ToString() + "]", typeof(RectTransform), typeof(Image) );
                RectTransform subRect = go.GetComponent<RectTransform>();
                subRect.SetSizeWithCurrentAnchors( RectTransform.Axis.Horizontal, horizontalSize * 0.9f );
				subRect.SetSizeWithCurrentAnchors( RectTransform.Axis.Vertical, verticalSize * 0.9f );
                subRect.SetParent( rect );
                subRect.localPosition = new Vector3( j * verticalSize + verticalSize / 2.0f, -i * horizontalSize - horizontalSize / 2.0f, 0.0f );
                gameAreaView[i, j] = subRect.GetComponent<Image>();
            }
        }
    }

    public static void UpdateView( int[,] gameAreaModel, Image[,] gameAreaView ) {
		int vertical = gameAreaView.GetLength( 0 );
		int horizontal = gameAreaView.GetLength( 1 );
        for( int i = 0; i < vertical; ++i ) {
            for( int j = 0; j < horizontal; ++j ) {
                gameAreaView[i, j].enabled = gameAreaModel[i, j] != 0;
            }
        }
    }

	public static void PutTetramino( int[,] gameAreaModel, Tetramino tetramino ) {
		int gameAreaVertical = gameAreaModel.GetLength( 0 );
		int gameAreaHorizontal = gameAreaModel.GetLength( 1 );
		for( int i = (int)tetramino.posX; i < (int)tetramino.posX + tetramino.Vertical; ++ i ) {
			for( int j = (int)tetramino.posY; j < (int)tetramino.posY + tetramino.Horizontal; ++ j ) {
				bool outOfRange = i < 0 || j < 0 || i >= gameAreaVertical || j >= gameAreaHorizontal;

				if( tetramino.Temaplate[ i - (int)tetramino.posX, j - (int)tetramino.posY ] == GameController.FREE_ELEMENT && !outOfRange ) {
					gameAreaModel[i, j] = GameController.FREE_ELEMENT;
				}
			}
		}
	}

	public static void GetTetramino( int[,] gameAreaModel, Tetramino tetramino ) {
		int gameAreaVertical = gameAreaModel.GetLength( 0 );
		int gameAreaHorizontal = gameAreaModel.GetLength( 1 );

		for( int i = (int)tetramino.posX; i < (int)tetramino.posX + tetramino.Vertical; ++ i ) {
			for( int j = (int)tetramino.posY; j < (int)tetramino.posY + tetramino.Horizontal; ++ j ) {
				bool outOfRange = i < 0 || j < 0 || i >= gameAreaVertical || j >= gameAreaHorizontal;
				if( tetramino.Temaplate[ i - (int)tetramino.posX, j - (int)tetramino.posY ] == GameController.FREE_ELEMENT && !outOfRange ) {
					gameAreaModel[i, j] = GameController.EMPTY_ELEMENT;
				}
			}
		}
	}

	public static bool TestTetramino( int[,] gameAreaModel, Tetramino tetramino ) {
		int gameAreaVertical = gameAreaModel.GetLength( 0 );
		int gameAreaHorizontal = gameAreaModel.GetLength( 1 );

		for( int i = (int)tetramino.posX; i < (int)tetramino.posX + tetramino.Vertical; ++ i ) {
			for( int j = (int)tetramino.posY; j < (int)tetramino.posY + tetramino.Horizontal; ++ j ) {
				bool outOfRange = i < 0 || j < 0 || i >= gameAreaVertical || j >= gameAreaHorizontal;
				if( tetramino.Temaplate[ i - (int)tetramino.posX, j - (int)tetramino.posY ] == GameController.FREE_ELEMENT &&
				    ( outOfRange || gameAreaModel[i, j] != GameController.EMPTY_ELEMENT ) ) {
					return false;
				}
			}
		}
		return true;
	}

	public static int CheckLines( int[,] gameAreaModel ) {
		int vertical = gameAreaModel.GetLength( 0 );
		int horizontal = gameAreaModel.GetLength( 1 );

		for( int i = 0; i < vertical; ++i ) {
			bool fullLine = true;
			for( int j = 0; j < horizontal; ++j ) {
				if( gameAreaModel[i, j] == GameController.EMPTY_ELEMENT ) {
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

	public static void RemoveLine( int[,] gameAreaModel, int lineNumber ) {
		int horizontal = gameAreaModel.GetLength( 1 );

		for( int i = lineNumber; i > 0; --i ) {
			for( int j = 0; j < horizontal; ++j ) {
				gameAreaModel[i, j] = gameAreaModel[i - 1, j];
			}
		}
	}

	public static void RemoveLines( int[,] gameAreaModel ) {
		int fullLine = CheckLines( gameAreaModel );
		while( fullLine  > -1 ) {
			RemoveLine( gameAreaModel, fullLine );
			fullLine = CheckLines( gameAreaModel );
		}
	}
}
