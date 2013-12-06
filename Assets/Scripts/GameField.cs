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
	private Rule currentRule;
	
	public GameField(string track)
	{
		currentRule = new Rule();
		width = Config.Logic.GridLength();
		height = Config.Logic.GridDepth();
		field = new List<Cube>();

		Config config = (Config)GameObject.Find("Config").GetComponent("Config");
		GameObject beatPrefab = config.beatPrefab;
		beat = (Beat)((GameObject)GameObject.Instantiate(beatPrefab)).GetComponent("Beat");
		beat.SetPosition(width / 2, height / 2);

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
		currentRule = currentRule.Step(field, RtoLmap, beat);

		//Controllo se i cubi sono usciti dai margini
		List<Cube> deleteList = new List<Cube>();

		foreach (Cube c in field) {
			if (c.gameObject.activeSelf && IsOutOfVisibleField(c.logicPosition)) {
				c.gameObject.SetActive(false);
			} else if (!c.gameObject.activeSelf && !IsOutOfVisibleField(c.logicPosition)) {
				c.gameObject.SetActive(true);
			} else if (IsOutOfExternalField(c.logicPosition)) {
				deleteList.Add(c);
				c.Recycle();
			}
		}
		//Elimino i cubi usciti troppo
		foreach (Cube c in deleteList) {
			field.Remove(c);
		}
	}

	public void CommandToBeat(Config.Command command)
	{
		// beat.Move(direction);
		beat.PushCommand(command);
	}


	#region private methods


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
	#endregion

}