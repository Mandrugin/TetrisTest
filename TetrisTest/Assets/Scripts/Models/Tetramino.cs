using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Класс представляющий понятие тетрамино
/// </summary>
public class Tetramino
{
	#region Tetramino templates
	public const int TETRAMINO_MAX_SIZE = 4;
	private static readonly int[,] Tetramino1 = { 
		{ 0, 1, 0, 0 },
		{ 0, 1, 0, 0 },
		{ 0, 1, 0, 0 },
		{ 0, 1, 0, 0 } };
	
	private static readonly int[,] Tetramino2 = {
		{ 1, 1 },
		{ 1, 1 } };
	
	private static readonly int[,] Tetramino3 = {
		{ 0, 1, 0 },
		{ 0, 1, 0 },
		{ 0, 1, 1 } };
	
	private static readonly int[,] Tetramino4 = {
		{ 0, 1, 0 },
		{ 0, 1, 0 },
		{ 1, 1, 0 } };
	
	private static readonly int[,] Tetramino5 = {
		{ 0, 1, 0 },
		{ 1, 1, 0 },
		{ 1, 0, 0 } };
	
	private static readonly int[,] Tetramino6 = {
		{ 1, 0, 0 },
		{ 1, 1, 0 },
		{ 0, 1, 0 } };
	
	private static readonly int[,] Tetramino7 = {
		{ 0, 1, 0 },
		{ 1, 1, 0 },
		{ 0, 1, 0 } };
	
	private static readonly List<int[,]> Tetraminos = new List<int[,]> { Tetramino1, Tetramino2, Tetramino3, Tetramino4, Tetramino5, Tetramino6, Tetramino7 };
	#endregion

	public int posY;
	public int posX;
	public int Vertical { get{ return vertical; } }
	public int Horizontal { get{ return horizontal; } }
    public int Number { get { return number; } }
	public int[,] Temaplate { get{ return template; } }

	private int vertical;
	private int horizontal;
    private int number;
	private int[,] template;

	public Tetramino( Vector2 position, int tetraminoNumber = -1 ) {

		if( tetraminoNumber > -1 && tetraminoNumber < Tetraminos.Count ) {
            number = tetraminoNumber;
		} else {
            number = Random.Range(0, Tetraminos.Count);
		}

        template = Tetraminos[number];
        vertical = template.GetLength( 0 );
		horizontal = template.GetLength( 1 );
		posY = (int)position.x;
		posX = (int)position.y;
	}

	private Tetramino( int[,] template, Vector2 position ) {
		this.template = template;
		vertical = template.GetLength( 0 );
		horizontal = template.GetLength( 1 );
		posY = (int)position.x;
		posX = (int)position.y;
	}

	public Tetramino RotateTeramino() {
		int[,] newTemplate = new int[vertical, horizontal];
		
		for( int i = 0; i < vertical; ++i ) {
			for( int j = 0; j < horizontal; ++j ) {
				newTemplate[i, j] = template[vertical - j - 1, i];
			}
		}
		
		return new Tetramino( newTemplate, new Vector2( posY, posX ) );
	}
}
