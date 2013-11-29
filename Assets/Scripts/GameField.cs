using UnityEngine;
using System.Collections.Generic;
using System;

public class GameField
{
	
	private LevelMap RtoLmap;
	private int width;
	private int height;
	private List<Cube> field;
	private Beat beat;
	
	public GameField(string track)
	{
		width = Config.Logic.GridLength();
		height = Config.Logic.GridDepth();
		field = new List<Cube>();

		try {
			// Right to Left map
			RtoLmap = new LevelMap(track);
			CheckCompliance();
		} catch (Exception) {
			throw;
		}
		InitBoard();
	}
	
	public void StepUpdate()
	{
		Vector2 nextPosition;

		List<Cube> deleteList = new List<Cube>();

		foreach (Cube c in field) {
			nextPosition = c.Move();

			if (c.gameObject.activeSelf && IsOutOfVisibleField(nextPosition)) {
				c.gameObject.SetActive(false);
			} else if (!c.gameObject.activeSelf && !IsOutOfVisibleField(nextPosition)) {
				c.gameObject.SetActive(true);

			}

			if (Collided(c)) {
				// TO-DO collisione!
			} else if (IsOutOfExternalField(nextPosition)) {
				deleteList.Add(c);
				c.Recycle();
			}
		}

		foreach (Cube c in deleteList){
			field.Remove(c);
		}

		AddRows();

	}


	#region private methods
	private void AddRows()
	{
		List<Cube> tmpLine;
		Cube cube;
				
		tmpLine = RtoLmap.GetNewLine();
				
		int x = width;
		int y;
		for (y=0; y< tmpLine.Count; y++) {
			cube = tmpLine [y];
			if (cube != null) {
				cube.SetPosition(x, y);
				cube.gameObject.SetActive(false);
				field.Add(cube);
						
			}
		}

	}

	private void CheckCompliance()
	{
			
		if (RtoLmap.MapWidth() != this.height)
			throw new Exception("Map/Field height not compliant");
		// 
			
	}

	private bool IsOutOfExternalField(Vector2 position)
	{

		if (position.x > this.width + 1)
			return true;
		if (position.y > this.height + 1)
			return true;
		if (position.x < -1)
			return true;
		if (position.y < -1)
			return true;

		return false;
	}

	private bool IsOutOfVisibleField(Vector2 position)
	{
		// Debug.LogError("x: "+position.x+" | y: "+position.y);

		if (position.x == this.width)
			return true;
		if (position.y == this.height)
			return true;
		if (position.x == -1)
			return true;
		if (position.y == -1)
			return true;

		return false;
	}

	private void InitBoard()
	{
//		int i;
//		for (i=0; i<= Config.Logic.GridLength()+2; i++) {
//			StepUpdate();
//		}

	}

	private bool Collided(Cube c)
	{
		if (beat != null) {
			if (c.logicPosition.Equals(beat.logicPosition)) {
				return true;
			} else {
				return false;
			}
		}
		return false;
	}
	#endregion

}