using UnityEngine;
using UnityEngine.UI;

public class FieldView {

	public Image[,] field;
	
	private int vertical;
	private int horizontal;
	public int Vertical { get{ return vertical; } }
	public int Horizontal { get{ return horizontal; } }

	public FieldView( RectTransform rect, int verticalSize, int horizontalSize ) {
		vertical = verticalSize;
		horizontal = horizontalSize;
		field = new Image[vertical, horizontal];
		Fill( rect );
	}

	private void Fill( RectTransform rect ) {
		float verticalSize = rect.rect.size.y / vertical;
		float horizontalSize = rect.rect.size.x / horizontal;
		Sprite sprite = Resources.Load<Sprite>( "Brik" );
		for( int i = 0; i < vertical; ++i ) {
			for( int j = 0; j < horizontal; ++j ) {
				GameObject go = new GameObject( "rect[" + i.ToString() + ", " + j.ToString() + "]", typeof(RectTransform), typeof(Image) );
				RectTransform subRect = go.GetComponent<RectTransform>();
				subRect.SetSizeWithCurrentAnchors( RectTransform.Axis.Horizontal, horizontalSize );
				subRect.SetSizeWithCurrentAnchors( RectTransform.Axis.Vertical, verticalSize );
				subRect.SetParent( rect, false );
				subRect.localPosition = new Vector3( j * verticalSize + verticalSize / 2.0f, -i * horizontalSize - horizontalSize / 2.0f, 0.0f );
				field[i, j] = subRect.GetComponent<Image>();
				field[i, j].sprite = sprite;
			}
		}
	}

	public void UpdateView( FieldModel gameAreaModel ) {
		for( int i = 0; i < gameAreaModel.Vertical; ++i ) {
			for( int j = 0; j < gameAreaModel.Horizontal; ++j ) {
				field[i, j].enabled = ( gameAreaModel.field[i, j] != GameController.EMPTY_ELEMENT );
			}
		}
	}
}
