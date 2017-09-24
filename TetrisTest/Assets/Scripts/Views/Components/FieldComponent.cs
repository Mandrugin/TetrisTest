using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Класс отображающий игровое поле на экране
/// </summary>
public class FieldComponent : MonoBehaviour
{
    public RectTransform rect;

    private Image[,] viewField;
	
	private int vertical;
	private int horizontal;

	public void Init( int verticalSize, int horizontalSize ) {
		vertical = verticalSize;
		horizontal = horizontalSize;
		viewField = new Image[vertical, horizontal];
		Fill();
	}

	private void Fill() {
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
				viewField[i, j] = subRect.GetComponent<Image>();
				viewField[i, j].sprite = sprite;
			}
		}
	}

	public void UpdateView( int[,] modelField ) {
		for( int i = 0; i < vertical; ++i ) {
			for( int j = 0; j < horizontal; ++j ) {
				viewField[i, j].enabled = ( modelField[i, j] != ConstStorage.EMPTY_ELEMENT );
			}
		}
	}
}
