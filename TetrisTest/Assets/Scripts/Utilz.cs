using UnityEngine;
using UnityEngine.UI;

public static class Utilz {

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

    public static bool IsBottom( int[,] gameAreaView, int horizontal, int vertical, int additionalField ) {
        for( int i = 0; i < vertical + additionalField; ++i ) {
            for( int j = 0; j < horizontal; ++j ) {
                // ...
            }
        }
        return false;
    }
}
