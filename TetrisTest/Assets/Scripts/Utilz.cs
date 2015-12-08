using UnityEngine;
using UnityEngine.UI;

public static class Utilz {

#region Teraminos
	public static int[,] Teramino1 = { 
		{ 0, 1, 0, 0 },
		{ 0, 1, 0, 0 },
		{ 0, 1, 0, 0 },
		{ 0, 1, 0, 0 } };

	public static int[,] Teramino2 = {
		{ 0, 0, 0, 0 },
		{ 0, 1, 1, 0 },
		{ 0, 1, 1, 0 },
		{ 0, 0, 0, 0 } };

	public static int[,] Teramino3 = {
		{ 0, 1, 0, 0 },
		{ 0, 1, 0, 0 },
		{ 0, 1, 1, 0 },
		{ 0, 0, 0, 0 } };

	public static int[,] Teramino4 = {
		{ 0, 0, 1, 0 },
		{ 0, 0, 1, 0 },
		{ 0, 1, 1, 0 },
		{ 0, 0, 0, 0 } };

	public static int[,] Teramino5 = {
		{ 0, 0, 1, 0 },
		{ 0, 1, 1, 0 },
		{ 0, 1, 0, 0 },
		{ 0, 0, 0, 0 } };

	public static int[,] Teramino6 = {
		{ 0, 1, 0, 0 },
		{ 0, 1, 1, 0 },
		{ 0, 0, 1, 0 },
		{ 0, 0, 0, 0 } };

	public static int[,] Teramino7 = {
		{ 0, 0, 1, 0 },
		{ 0, 1, 1, 0 },
		{ 0, 0, 1, 0 },
		{ 0, 0, 0, 0 } };
#endregion

    public static void FillArea( RectTransform rect, Image[,] gameAreaView, int horizontal, int vertical, int additionalField ) {
        float verticalSize = rect.rect.size.x / horizontal;
        float horizontalSize = rect.rect.size.x / horizontal;
        for( int i = 0; i < vertical + additionalField; ++i ) {
            for( int j = 0; j < horizontal; ++j ) {
                GameObject go = new GameObject( "rect[" + i.ToString() + ", " + j.ToString() + "]", typeof(RectTransform), typeof(Image) );
                RectTransform subRect = go.GetComponent<RectTransform>();
                subRect.SetSizeWithCurrentAnchors( RectTransform.Axis.Horizontal, horizontalSize - 2.0f );
                subRect.SetSizeWithCurrentAnchors( RectTransform.Axis.Vertical, verticalSize - 2.0f );
                subRect.SetParent( rect );
                subRect.localPosition = new Vector3( j * verticalSize + verticalSize / 2.0f, i * horizontalSize + horizontalSize / 2.0f, 0.0f );
                gameAreaView[i, j] = subRect.GetComponent<Image>();
            }
        }
    }

    public static void UpdateView( int[,] gameAreaModel, Image[,] gameAreaView, int horizontal, int vertical, int additionalField ) {
        for( int i = 0; i < vertical + additionalField; ++i ) {
            for( int j = 0; j < horizontal; ++j ) {
                gameAreaView[i, j].enabled = gameAreaModel[i, j] != 0;
            }
        }
    }

    public static bool IsBottom( int[,] gameAreaModel, int horizontal, int vertical, int additionalField ) {
        for( int i = 0; i < vertical + additionalField; ++i ) {
            for( int j = 0; j < horizontal; ++j ) {
				if( gameAreaModel[i, j] == GameController.FREE_ELEMENT ) {
					if( i == 0 )
						return true;
					if( gameAreaModel[i - 1, j] == GameController.FIXED_ELEMENT )
						return true;
				}
            }
        }
        return false;
    }

	public static bool IsRight( int[,] gameAreaModel, int horizontal, int vertical, int additionalField ) {
		for( int i = 0; i < vertical + additionalField; ++i ) {
			for( int j = 0; j < horizontal; ++j ) {
				if( gameAreaModel[i, j] == GameController.FREE_ELEMENT ) {
					if( j == horizontal - 1 )
						return true;
					if( gameAreaModel[i, j + 1] == GameController.FIXED_ELEMENT )
						return true;
				}
			}
		}
		return false;
	}

	public static bool IsLeft( int[,] gameAreaModel, int horizontal, int vertical, int additionalField ) {
		for( int i = 0; i < vertical + additionalField; ++i ) {
			for( int j = 0; j < horizontal; ++j ) {
				if( gameAreaModel[i, j] == GameController.FREE_ELEMENT ) {
					if( j == 0 )
						return true;
					if( gameAreaModel[i, j - 1] == GameController.FIXED_ELEMENT )
						return true;
				}
			}
		}
		return false;
	}

	public static void PullDown( int[,] gameAreaModel, int horizontal, int vertical, int additionalField ) {
		for( int i = 0; i < vertical + additionalField; ++i ) {
			for( int j = 0; j < horizontal; ++j ) {
				if( gameAreaModel[i, j] == GameController.FREE_ELEMENT ) {
					gameAreaModel[i - 1, j] = GameController.FREE_ELEMENT;
					gameAreaModel[i, j] = GameController.EMPTY_ELEMENT;
				}
			}
		}
	}

	public static void PullLeft( int[,] gameAreaModel, int horizontal, int vertical, int additionalField ) {
		for( int i = 0; i < vertical + additionalField; ++i ) {
			for( int j = 0; j < horizontal; ++j ) {
				if( gameAreaModel[i, j] == GameController.FREE_ELEMENT ) {
					gameAreaModel[i, j - 1] = GameController.FREE_ELEMENT;
					gameAreaModel[i, j] = GameController.EMPTY_ELEMENT;
				}
			}
		}
	}

	public static void PullRight( int[,] gameAreaModel, int horizontal, int vertical, int additionalField ) {
		for( int i = vertical + additionalField - 1; i >= 0; --i ) {
			for( int j = horizontal - 1; j >= 0; --j ) {
				if( gameAreaModel[i, j] == GameController.FREE_ELEMENT ) {
					gameAreaModel[i, j + 1] = GameController.FREE_ELEMENT;
					gameAreaModel[i, j] = GameController.EMPTY_ELEMENT;
				}
			}
		}
	}

	public static void RotateTeramino( int[,] teramino ) {

	}
}
