using UnityEngine;
using System.Collections.Generic;

public class Tetramino {

	#region Tetramino templates
	private static int[,] Tetramino1 = { 
		{ 0, 1, 0, 0 },
		{ 0, 1, 0, 0 },
		{ 0, 1, 0, 0 },
		{ 0, 1, 0, 0 } };
	
	private static int[,] Tetramino2 = {
		{ 1, 1 },
		{ 1, 1 } };
	
	private static int[,] Tetramino3 = {
		{ 0, 1, 0 },
		{ 0, 1, 0 },
		{ 0, 1, 1 } };
	
	private static int[,] Tetramino4 = {
		{ 0, 1, 0 },
		{ 0, 1, 0 },
		{ 1, 1, 0 } };
	
	private static int[,] Tetramino5 = {
		{ 0, 1, 0 },
		{ 1, 1, 0 },
		{ 1, 0, 0 } };
	
	private static int[,] Tetramino6 = {
		{ 1, 0, 0 },
		{ 1, 1, 0 },
		{ 0, 1, 0 } };
	
	private static int[,] Tetramino7 = {
		{ 0, 1, 0 },
		{ 1, 1, 0 },
		{ 0, 1, 0 } };
	
	private static List<int[,]> Tetraminos = new List<int[,]> { Tetramino1, Tetramino2, Tetramino3, Tetramino4, Tetramino5, Tetramino6, Tetramino7 };
	#endregion

	public Vector2 position;
	public int Vertical { get{ return vertical; } }
	public int Horizontal { get{ return horizontal; } }
	public int[,] temaplate { get{ return template; } }

	private int vertical;
	private int horizontal;
	private int[,] template;

	private static int[,] GetRandomTemplate() {
		return Tetraminos[Random.Range( 0, Tetraminos.Count )];
	}

	public Tetramino( Vector2 position, int tetraminoNumber = -1 ) {

		if( tetraminoNumber > -1 && tetraminoNumber < Tetraminos.Count ) {
			template = Tetraminos[tetraminoNumber];
		} else {
			template = GetRandomTemplate();
		}

		vertical = template.GetLength( 0 );
		horizontal = template.GetLength( 1 );
		this.position = position;
	}
}
