using UnityEngine;
using UnityEngine.UI;

public static class Utilz {

#region Tetraminos
	public static int[,] Tetramino1 = { 
		{ 0, 1, 0, 0 },
		{ 0, 1, 0, 0 },
		{ 0, 1, 0, 0 },
		{ 0, 1, 0, 0 } };

	public static int[,] Teramino2 = {
		{ 0, 0, 0, 0 },
		{ 0, 1, 1, 0 },
		{ 0, 1, 1, 0 },
		{ 0, 0, 0, 0 } };

	public static int[,] Tetramino3 = {
		{ 0, 1, 0, 0 },
		{ 0, 1, 0, 0 },
		{ 0, 1, 1, 0 },
		{ 0, 0, 0, 0 } };

	public static int[,] Tetramino4 = {
		{ 0, 0, 1, 0 },
		{ 0, 0, 1, 0 },
		{ 0, 1, 1, 0 },
		{ 0, 0, 0, 0 } };

	public static int[,] Tetramino5 = {
		{ 0, 0, 1, 0 },
		{ 0, 1, 1, 0 },
		{ 0, 1, 0, 0 },
		{ 0, 0, 0, 0 } };

	public static int[,] Tetramino6 = {
		{ 0, 1, 0, 0 },
		{ 0, 1, 1, 0 },
		{ 0, 0, 1, 0 },
		{ 0, 0, 0, 0 } };

	public static int[,] Tetramino7 = {
		{ 0, 0, 1, 0 },
		{ 0, 1, 1, 0 },
		{ 0, 0, 1, 0 },
		{ 0, 0, 0, 0 } };
#endregion

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

	public static void PutTetramino( int[,] gameAreaModel, int[,] tetramino, Vector2 tetraminoPosition ) {
		int tetraminoVertical = tetramino.GetLength( 0 );
		int tetraminoHorizontal = tetramino.GetLength( 1 );
		int gameAreaVertical = gameAreaModel.GetLength( 0 );
		int gameAreaHorizontal = gameAreaModel.GetLength( 1 );
		for( int i = (int)tetraminoPosition.x; i < (int)tetraminoPosition.x + tetraminoVertical; ++ i ) {
			for( int j = (int)tetraminoPosition.y; j < (int)tetraminoPosition.y + tetraminoHorizontal; ++ j ) {
				bool outOfRange = i < 0 || j < 0 || i >= gameAreaVertical || j >= gameAreaHorizontal;

				if( tetramino[ i - (int)tetraminoPosition.x, j - (int)tetraminoPosition.y ] == GameController.FREE_ELEMENT && !outOfRange ) {
					gameAreaModel[i, j] = GameController.FREE_ELEMENT;
				}
			}
		}
	}

	public static void GetTetramino( int[,] gameAreaModel, int[,] tetramino, Vector2 tetraminoPosition ) {
		int tetraminoVertical = tetramino.GetLength( 0 );
		int tetraminoHorizontal = tetramino.GetLength( 1 );
		int gameAreaVertical = gameAreaModel.GetLength( 0 );
		int gameAreaHorizontal = gameAreaModel.GetLength( 1 );

		for( int i = (int)tetraminoPosition.x; i < (int)tetraminoPosition.x + tetraminoVertical; ++ i ) {
			for( int j = (int)tetraminoPosition.y; j < (int)tetraminoPosition.y + tetraminoHorizontal; ++ j ) {
				bool outOfRange = i < 0 || j < 0 || i >= gameAreaVertical || j >= gameAreaHorizontal;
				if( tetramino[ i - (int)tetraminoPosition.x, j - (int)tetraminoPosition.y ] == GameController.FREE_ELEMENT && !outOfRange ) {
					gameAreaModel[i, j] = GameController.EMPTY_ELEMENT;
				}
			}
		}
	}

	public static bool TestTetramino( int[,] gameAreaModel, int[,] tetramino, Vector2 tetraminoPosition ) {
		int tetraminoVertical = tetramino.GetLength( 0 );
		int tetraminoHorizontal = tetramino.GetLength( 1 );
		int gameAreaVertical = gameAreaModel.GetLength( 0 );
		int gameAreaHorizontal = gameAreaModel.GetLength( 1 );

		for( int i = (int)tetraminoPosition.x; i < (int)tetraminoPosition.x + tetraminoVertical; ++ i ) {
			for( int j = (int)tetraminoPosition.y; j < (int)tetraminoPosition.y + tetraminoHorizontal; ++ j ) {
				bool outOfRange = i < 0 || j < 0 || i >= gameAreaVertical || j >= gameAreaHorizontal;
				if( tetramino[ i - (int)tetraminoPosition.x, j - (int)tetraminoPosition.y ] == GameController.FREE_ELEMENT &&
				    ( outOfRange || gameAreaModel[i, j] != GameController.EMPTY_ELEMENT ) ) {
					return false;
				}
			}
		}
		return true;
	}



	public static int[,] RotateTeramino( int[,] teramino ) {
		int[,] newTeramino = new int[teramino.GetLength( 0 ),teramino.GetLength( 1 )];

		newTeramino[0, 0] = teramino[3, 0];
		newTeramino[0, 1] = teramino[2, 0];
		newTeramino[0, 2] = teramino[1, 0];
		newTeramino[0, 3] = teramino[0, 0];

		newTeramino[1, 0] = teramino[3, 1];
		newTeramino[1, 1] = teramino[2, 1];
		newTeramino[1, 2] = teramino[1, 1];
		newTeramino[1, 3] = teramino[0, 1];

		newTeramino[2, 0] = teramino[3, 2];
		newTeramino[2, 1] = teramino[2, 2];
		newTeramino[2, 2] = teramino[1, 2];
		newTeramino[2, 3] = teramino[0, 2];

		newTeramino[3, 0] = teramino[3, 3];
		newTeramino[3, 1] = teramino[2, 3];
		newTeramino[3, 2] = teramino[1, 3];
		newTeramino[3, 3] = teramino[0, 3];

		return newTeramino;
	}
}
