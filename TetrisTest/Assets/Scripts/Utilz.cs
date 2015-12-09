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

    public static void UpdateView( FieldModel gameAreaModel, Image[,] gameAreaView ) {
        for( int i = 0; i < gameAreaModel.Vertical; ++i ) {
			for( int j = 0; j < gameAreaModel.Horizontal; ++j ) {
                gameAreaView[i, j].enabled = ( gameAreaModel.field[i, j] != GameController.EMPTY_ELEMENT );
            }
        }
    }
}
